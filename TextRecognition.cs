using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Text.RegularExpressions;

namespace ADCinvoice
{
    class TextRecognition
    {
        public event EventHandler<BlocksEventArgs<Rectangle, string>> RecognitionUpdate;   // #5 Here I now use a "strongly typed generic event" so we can pass and receive our "status
                                                                                           // object" easily

        public event EventHandler<BlockEventsArgs<string, Rectangle, int>> ProcessingUpdate;

        private static Bitmap Get24bppRgb(Image image)
        {
            Bitmap bitmap24;
            using (var bitmap = new Bitmap(image))
            {
                bitmap24 = new Bitmap(bitmap.Width, bitmap.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                using (var gr = Graphics.FromImage(bitmap24))
                {
                    gr.DrawImage(bitmap, new Rectangle(0, 0, bitmap24.Width, bitmap24.Height));
                }
            }
            return bitmap24;
        }

        public Bitmap CropImage(Bitmap source, Rectangle section)
        {
            // An empty bitmap which will hold the cropped image
            Bitmap bmp = new Bitmap(section.Width, section.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //Rectangle rect = ;
            using (Graphics g_bmp = Graphics.FromImage(bmp))
            {

                // Draw the given area (section) of the source image
                // at location 0,0 on the empty bitmap (bmp)
                g_bmp.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
                using (Pen pen = new Pen(Color.White))
                {
                    g_bmp.DrawRectangle(pen, new Rectangle(0, 0, section.Width, section.Height));
                }
            }

            return bmp;
        }
        /// <exception cref="Exception"></exception>
        private string Do_OCR(Image<Gray, byte> block, Tesseract engine)
        {
            string text = "";
            engine.Recognize(block);
            text += engine.GetText();
            return text;
        }

        public static string DirProject()
        {
            string DirDebug = System.IO.Directory.GetCurrentDirectory();
            string DirProj = DirDebug;

            //for (int counter_slash = 0; counter_slash < 2; counter_slash++)
            //{
            //    DirProj = DirProj.Substring(0, DirProj.LastIndexOf(@"\"));
            //}

            return DirProj + @"\";
        }

        public void StartTextRecognition(LinkedList<Rectangle> rectangles, string dir, string filename)
        {
            try
            {
                using (Tesseract engine = new Tesseract(DirProject() + "tessdata", "swe", OcrEngineMode.Default))
                using (Image<Gray, byte> img = new Image<Gray, byte>(dir + filename))
                {

                    engine.SetVariable("tessedit_char_whitelist", @"0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ,-:.% ");//abcdefghijklmnopqrstuvwxyzåäöABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ
                   
                    foreach (Rectangle block in rectangles)
                    {
                        img.ROI = block;
                        var text = Do_OCR(img, engine);
                        RecognitionUpdate.Raise(this, block, text);
                        FindNeededInformation(text, block);
                    }
                }
            }
            catch (Exception er)
            {
                System.Diagnostics.Trace.TraceError(er.ToString());
            }
            RecognitionUpdate.Raise(this, Rectangle.Empty, ""); // #6 - status is of type Rectange
                                                             // Here I use the extension defined below, which (aside from ease of use) solve the possible race condition in the old 
                                                             // example. There it could have happened that the event got null after the if-check, but before the call if the event 
                                                             // handler was removed in another thread at just that moment. This can't happen here, as the extensions gets a "copy" of 
                                                             // the event delegate and in the same situation the handler is still registered inside the Raise method.
                                                             //part 2
        }

        public static string months = @"januari|februari|mars|april|maj|juni|juli|augusti|september|oktober|november|december";

        private static string[] patterns =
        {
            @"(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([/[a-zA-Z]\.-]*)*\/?",
            @"[A-Z]{2}(\s*([0-9]|[A-Z])){2}(\s*[0-9O]){20}",
            @"[A-Z]{2}(\s*\d){12}",

            @"[1-9](\s*[0-9]){5}\s*\-?(\s*[0-9]){7}\s*\-\s*[0-9]",
            @"0(( \-)?\s*[0-9]){9}",
            @"[0-9]{2}[2-9][0-9]{3}\-?[0-9]{4}",
            @"([0-9]\s*){4,5}((\.(\s*[0-9]){3}\s*\.(\s*[0-9]){4}\s*\-(\s*[0-9]){2})|(\-(\s*[0-9]){8}))",


            @"([0-9]\s*){3,4}\-(\s*[0-9]){4}",
            @"([0-9]\s*){6}\-\s*[0-9]",
            @"(\s*[0-9]){2}((\s*[0-9]){2})?\s*(\-(\s*[0-9]){2}\s*\-|" + months + @")(\s*[0-9]){2}((\s*[0-9]){2})?",
            @"(SEK|LKR|\$|\€|kronor|kr)",
            
            @"^[A-Z]([A-Za-z0-9]|[- @\.#&!])+ AB",
            @"([0-9] *){5} [A-Za-z]{2,}",
            @"^\s*[A-Z]([a-zA-Z] *){2,} [0-9]{1,5}(\s*[a-zA-Z])?(?![\-0-9])\s*$",
            @"(sweden|sverige)",

            @"^\s*[1-9][0-9]{1,2}(\s*\.(\s*[0-9]){2})?\s*\%\s*$",
            @"^\s*([0-9]{1,3} ?|[0-9]{1,2} [0-9]{3} ?)+ *[\,\.]( *[0-9]){2}\s*$",
            @"( *[0-9])+"
        };

        public enum Pattern
        {
            WEBSITE,
            IBAN,
            TAX_REGISTRATION_NUMBER,

            INSURANCE_NUMBER,
            PHONE_NUMBER,
            ORGANIZATION_REFERENCE,
            OBJECT_REFERENCE,

            BANKGIRO,
            PLUSGIRO,
            DATE,
            CURRENCY,

            COMPANY_NAME,
            COMPANY_INDEX_AND_CITY,
            COMPANY_ADDRESS,
            COMPANY_COUNTRY,

            TAX_IN_PERCENT,
            PRICE,
            OCR_REFERENCE,

            BACKUP_NUMBERS
        };

        private List<string> numbers = new List<string>();

        public void FindNeededInformation(string text, Rectangle rect)
        {
            Console.WriteLine(text);
            string output = "";
            int i = 0, l = patterns.Length;
            while (i < l)
            {
                var pat = "";
                switch ((Pattern)i)
                {
                    case Pattern.IBAN:
                        pat = @"(\s*[0-9]){23,}";
                        break;

                    case Pattern.TAX_REGISTRATION_NUMBER:
                        pat = @"(\s*[0-9]){13,}";
                        break;
                    case Pattern.PHONE_NUMBER:
                        pat = @"(\s*[0-9]){11,}";
                        break;
                    case Pattern.BANKGIRO:
                        pat = @"([0-9]\s*){3,}(\-(\s*[0-9]){5,})";
                        break;
                    /*case Pattern.TAX_REGISTRATION_NUMBER:
                        pat = @"(\s*[0-9]){13,22}";
                        break;
                    case Pattern.ORGANIZATION_REFERENCE:
                        pat = @"(?![\-0-9])(\s*[0-9]){7,12}";
                        break;*/
                    case Pattern.PRICE:
                        pat = @"([0-9] *)+( *[\,\.]( *[0-9]){3,})+";
                        break;
                    default:

                        break;
                }
                if (!pat.Equals(""))
                {
                    // Instantiate the regular expression object.
                    Regex e = new Regex(pat, RegexOptions.IgnoreCase);

                    // Match the regular expression pattern against a text string.
                    Match a = e.Match(text);
                    while (a.Success)
                    {

                        output = a.Value;
                        
                        output = output.Replace(" ", "");

                        if (output.Length == 24 || (output.Length == 14 && i == (int)Pattern.TAX_REGISTRATION_NUMBER))
                        {
                            ProcessingUpdate.Raise(this, output, rect, i);
                        }
                        numbers.Add(output);
                        Console.WriteLine("Pre-Match " + i + " : " + output);
                        ProcessingUpdate.Raise(this, output, rect, (int)Pattern.BACKUP_NUMBERS);

                        a = a.NextMatch();
                    }
                    if (numbers.Count > 0)
                    {
                        text = e.Replace(text, "");
                        numbers.Sort();
                        var greatestNumber = "";
                        foreach (string number in numbers)
                        {
                            if (greatestNumber.Length < number.Length && !number.Contains('.') && !number.Contains(',') && !number.Contains('-'))
                            {
                                greatestNumber = number;
                            }

                        }
                        ProcessingUpdate.Raise(this, greatestNumber, rect, (int)Pattern.OCR_REFERENCE);
                        numbers.Clear();
                    }
                }
                Regex r = new Regex(patterns[i], RegexOptions.Multiline);

                // Match the regular expression pattern against a text string.
                Match m = r.Match(text);
                
                while (m.Success)
                {

                    output = m.Value;
                    switch ((Pattern)i)
                    {
                        case Pattern.PHONE_NUMBER:
                        case Pattern.COMPANY_NAME:
                        case Pattern.COMPANY_ADDRESS:
                        case Pattern.COMPANY_INDEX_AND_CITY:
                        case Pattern.DATE:
                            if (output.Contains('-'))
                            {
                                output = output.Replace(" ", "");
                            }
                            break;
                        case Pattern.PRICE:
                            output = output.Replace(" ", "");
                            output = output.Replace(',', '.');
                            break;
                        case Pattern.TAX_IN_PERCENT:
                            output = output.Replace(" ", "");
                            output = output.Replace("%", "");
                            break;
                        default:
                            output = output.Replace(" ", "");
                            break;
                    }
                    Console.WriteLine("Match " + i + " : " + output);
                    ProcessingUpdate.Raise(this, output, rect, i);
                    m = m.NextMatch();
                }

                text = r.Replace(text, "");
                i++;

            }

            if (text.Length > 5)
                ProcessingUpdate.Raise(this, text, rect, -1);
        }

    }
}
