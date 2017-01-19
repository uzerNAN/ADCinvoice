//#include <tessnet2>;

using System;
using System.Drawing;
using System.Windows.Forms;
//using OneNote = Microsoft.Office.Interop.OneNote;
//using journeyofcode.Images.OnenoteOCR;
using System.Drawing.Drawing2D;
//using System.Drawing.Imaging;
using System.Collections.Generic;
//using Tesseract;

using Emgu.CV.OCR;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.UI;
using Emgu.CV;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Drawing.Imaging;
using System.Diagnostics;

//using Emgu.Util;
//using System.IO;
//using Tesseract;
//using MyTestBaseAPI;

///using System.Collections.Generic;

namespace ADCinvoice
{

    public partial class InvoiceForm : Form
    {
        //OneNote namespace
        //static String strNamespace = "http://schemas.microsoft.com/office/onenote/2013/onenote";
        //string project_path = Environment.CurrentDirectory; // @"C:\Users\Sergej\Documents\Visual Studio 2015\Projects\ADCinvoice\ADCinvoice\";
        //private System.Windows.Forms.TextBox textBox1;
        //private System.Windows.Forms.Button GetOCR_button;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.Container compons = null;
        public InvoiceForm()
        {
            InitializeComponent();
            flowLayoutPanel1.HorizontalScroll.Enabled = false;
            flowLayoutPanel1.HorizontalScroll.Visible = false;

            invoiceBox.Paint += InvoiceBox_Paint;
        }

        
        public Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);



            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.Bicubic;//InterpolationMode.HighQualityBicubic;


                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.Clear(Color.White);

                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;//.AntiAlias; //  <-- This is the correct value to use. ClearTypeGridFit is better yet!
                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    //using (Brush b = new SolidBrush(Color.White))
                    //    graphics.FillRectangle(b, new Rectangle(0, 0, width, height));
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                    //using (Pen pen = new Pen(Color.White)) { 
                    //    graphics.DrawRectangle(pen, new Rectangle(0, 0, width+6, height+6));
                    //}
                }
            }

            return destImage;
        }

        public Bitmap CropBitmap(Bitmap source, Rectangle section)
        {
            // An empty bitmap which will hold the cropped image
            Bitmap bmp = new Bitmap(section.Width, section.Height, PixelFormat.Format24bppRgb);
            Graphics g_bmp = Graphics.FromImage(bmp);

            // Draw the given area (section) of the source image
            // at location 0,0 on the empty bitmap (bmp)
            g_bmp.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
            Pen pen = new Pen(Color.White);
            g_bmp.DrawRectangle(pen, new Rectangle(0, 0, section.Width, section.Height));
            pen.Dispose();
            g_bmp.Dispose();

            return bmp;
        }
        


        public static int iterator = 0;

        


        public Bitmap Rescale(Image image, int dpiX, int dpiY)
        {
            Bitmap bm = new Bitmap((int)(image.Width * dpiX / image.HorizontalResolution), (int)(image.Height * dpiY / image.VerticalResolution));
            bm.SetResolution(dpiX, dpiY);
            Graphics g = Graphics.FromImage(bm);
            g.InterpolationMode = InterpolationMode.Bicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawImage(image, 0, 0);

            g.Dispose();

            return bm;
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

        private static Bitmap Get24bppRgb(Image image)
        {
            var bitmap = new Bitmap(image);
            var bitmap24 = new Bitmap(bitmap.Width, bitmap.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (var gr = Graphics.FromImage(bitmap24))
            {
                gr.DrawImage(bitmap, new Rectangle(0, 0, bitmap24.Width, bitmap24.Height));
            }
            return bitmap24;
        }

        public static bool valueInRange(int value, int min, int max)
        {
            return (min <= value) && (value <= max);
        }

        

        private static string log = "";
        public static bool doPrint = true;
        private static void WriteLog(string line, bool print)
        {

            log += "\r\n" + line;
            if (print)
                Console.WriteLine(line);

        }

        private void ShowWaitMessage(string message)
        {

            zoomBox.Visible = false;
            //zoomBox.Invalidate();
            progressBar1.Visible = true;
            progressBar1.Enabled = true;
            //progressBar1.Invalidate();
            waitLabel.Text = message;
            waitLabel.Visible = true;
            waitLabel.Enabled = true;
            viewBlock.Text = "Be patient";
            //viewBlock.Invalidate();
        }
        private void HideWaitMessage()
        {
            zoomBox.Visible = true;
            //zoomBox.Invalidate();
            progressBar1.Visible = false;
            progressBar1.Enabled = false;
            //progressBar1.Invalidate();
            waitLabel.Text = "";
            waitLabel.Visible = false;
            waitLabel.Enabled = false;
            viewBlock.Text = "Zoomed Block";
            InitBoxes();
            //viewBlock.Invalidate();
        }

        private Rectangle paintRect = Rectangle.Empty;

        delegate void SetImageProcessingResultCallback(string file, bool last);
        private void SetImageProcessingResult(string file, bool last)
        {
            if (this.InvokeRequired)
            {
                //SetResultCallback d = new SetResultCallback(SetResult);
                //this.Invoke(d, new object[] { textBox, text });
                this.Invoke((MethodInvoker)delegate
                {
                    //paintRect = new Rectangle((int)(rect.X * scale), (int)(rect.Y * scale), (int)(rect.Width * scale), (int)(rect.Height * scale));
                    //using (System.IO.Stream stream = System.IO.File.OpenRead(file))
                    //{
                    LoadI(file);
                    if (last)
                    {
                        if (ibr > 0)
                        {
                            StartBR(Path.GetDirectoryName(file) + @"\", Path.GetFileName(file));
                        }
                        else
                        {
                            //ibr = 0;
                            br = null;
                            StartOCR(Path.GetDirectoryName(file) + @"\", Path.GetFileName(file));
                        }
                        //}
                        //invoiceBox.Invalidate();

                    }
                    /*else
                    {
                        if (ibr == 0)
                        {
                            ibr = -1;
                            //loadImage(file);
                        }
                    }*/

                });
            }
        }

        private Pen pen = new Pen(Color.Red, 2);

        delegate void SetContourRecognitionResultCallback(Rectangle rect, bool isImportant);
        private void SetContourRecognitionResult(Rectangle rect, bool isImportant)
        {
            if (this.InvokeRequired)
            {
                //SetResultCallback d = new SetResultCallback(SetResult);
                //this.Invoke(d, new object[] { textBox, text });
                //Recta
                //int i;
                this.Invoke((MethodInvoker)delegate
                {
                    WriteLog("Rectangle CR : " + rect.X + " , " + rect.Y + " , " + rect.Width + " , " + rect.Height + " ;", doPrint);
                    SetCRResult(rect, isImportant);
                    //someLabel.Text = newText; // runs on UI thread
                });
            }// else
             //{
             //    WriteLog("Rectangle 2 : " + rect.X + " , " + rect.Y + " , " + rect.Width + " , " + rect.Height + " ;", doPrint);
             //int i = SetCRResult(rect, isImportant);
             //}
        }

        Rectangle largestOrigin = Rectangle.Empty;
        ///Rectangle largestScaled = Rectangle.Empty;

        public void SetLargestArea(Rectangle origin)
        {

            if (largestOrigin.Equals(Rectangle.Empty))
            {
                largestOrigin = origin;
            }
            else
            {
                Rectangle o = largestOrigin;
                //Rectangle s = new Rectangle(largestScaled.X, largestScaled.Y, largestScaled.Width, largestScaled.Height);
                if (largestOrigin.Left > origin.Left)
                {
                    o.X = origin.Left;
                    o.Width += largestOrigin.Left - origin.Left;

                    //s.X = scaled.Left;
                    //s.Width += largestScaled.Left - scaled.Left;
                }

                if (largestOrigin.Top > origin.Top)
                {

                    o.Y = origin.Top;
                    o.Height += largestOrigin.Top - origin.Top;
                }

                if (largestOrigin.Right < origin.Right)
                {
                    o.Width = origin.Right - o.Left;
                }

                if (largestOrigin.Bottom < origin.Bottom)
                {
                    o.Height = origin.Bottom - o.Top;
                }
                largestOrigin = o;
            }
        }

        public void SetCRResult(Rectangle rect, bool isImportant)
        {
            if (!rect.Equals(Rectangle.Empty))
            {

                Rectangle r = new Rectangle((int)(rect.X * scale)-1, (int)(rect.Y * scale)-1, (int)(rect.Width * scale) + 2, (int)(rect.Height * scale) + 2);
                if (isImportant)
                {

                    if (pen.Color != Color.Yellow)
                    {
                        pen.Color = Color.Yellow;
                    }
                    SetLargestArea(rect);
                    rectangles.AddLast(rect);
                    paintRects.AddLast(r);
                }
                else
                {
                    if (pen.Color != Color.Red)
                    {
                        pen.Color = Color.Red;
                    }
                    paintRect = r;

                    //disturbs.AddFirst(rect);
                }

                invoiceBox.Invalidate();
            }
            else
            {
                LoadI(invoicePath.Text);
                ibr = -1;
                //otsu = false;
                StartBR(Path.GetDirectoryName(invoicePath.Text) + @"\", Path.GetFileName(invoicePath.Text));
                //ibr = -1;
                //otsu = true;
                //StartOCR(Path.GetDirectoryName(invoicePath.Text) + @"\", Path.GetFileName(invoicePath.Text))
                //using (System.IO.Stream stream = System.IO.File.OpenRead(invoicePath.Text))
                //{
                //}
            }
            //return 0;
        }

        private Color onFocusColor = Color.FloralWhite;

        private void BoxGotFocus(object sender, EventArgs e)
        {
            ClearPrevPatterns();
            var tb = sender as TextBox;
            var inv = Box2Inv(tb.Name);
            var block = new Block(Rectangle.Empty, (int)inv);
            if (bounds.Contains(block)){
                var r = bounds.Find(block).Value.Rectangle;
                //Point p = new Point(r.X+r.Width/2, r.Y+r.Height/2);
                SelectZoomBlock(r, new Rectangle((int)(r.X * scale)-1, (int)(r.Y * scale)-1, (int)(r.Width * scale)+2, (int)(r.Height * scale)+2));
               
            }
            tb.BackColor = onFocusColor;
            
            patterns.AddLast(inv);
            field = inv;
            button1.Enabled = true;
            //Box2Inv(tb.Name);
        }

        private void BoxLostFocus(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            /*if (bounds.Contains(new Block(Rectangle.Empty, (int)Box2Inv(tb.Name)))){
                var r = bounds.Find(new Block(Rectangle.Empty, (int)Box2Inv(tb.Name))).Value.Rectangle;
                //Point p = new Point(r.X - 1, r.Y - 1);
                SelectZoomBlock(r, new Rectangle((int)(r.X * scale), (int)(r.Y * scale), (int)(r.Width * scale), (int)(r.Height * scale)));
            }*/
            tb.BackColor = Color.White;

            patterns.Remove(Box2Inv(tb.Name));
            /*if(field != Invoice.MESSAGE)
            {

                field = Invoice.MESSAGE;
            }*/
            //Box2Inv(tb.Name);
        }

        private void InitBoxes()
        {
            if (initBox)
            {
                initBox = false;
                int i = 0, l = (int)Invoice.MESSAGE - 1;
                while (i < l)
                {
                    var box = GetBox((Invoice)i);
                    box.GotFocus += BoxGotFocus;
                    box.LostFocus += BoxLostFocus;
                    i++;
                }
            }
        }
        private bool initBox = true;

        private void LoadI(string path)
        {
            if (image != null)
            {
                image.Dispose();
            }
            image = CvInvoke.Imread(path, LoadImageType.Grayscale).GetOutputArray().GetUMat().ToImage<Gray, byte>();
            invoiceBox.Image = image;
            invoiceBox.Refresh();
            if(!br_in_progress)
                largestOrigin = new Rectangle(0,0,image.Width, image.Height);
            
        }

        private void ValidatePrices()
        {
           
            float total = 0.00f, beforetax = 0.00f, tax = 0.00f, round = 0.00f;
            float.TryParse(totalAmount.Text, out total);
            float.TryParse(priceBeforeTax.Text, out beforetax);
            float.TryParse(taxAmount.Text, out tax);
            float.TryParse(rounded.Text, out round);

            total -= round;

            if (total > .0f)
            {

                //total = float.Parse(totalAmount.Text);
                int taxpercent = taxInPercent.Text.Length > 0 ? int.Parse(taxInPercent.Text) : 25,
                    reverstax = taxpercent * 100 / (100 + taxpercent);

                if (beforetax > .0f)
                {
                    //beforetax = float.Parse(priceBeforeTax.Text);
                    if( (int)( beforetax * 100.0f / total ) != ( 100 - reverstax ) )
                    {
                        beforetax = total * (100 - reverstax) / 100;
                    }
                }
                else
                {
                    beforetax = total * (100 - reverstax) / 100 ;
                }

                if (taxAmount.Text.Length > 0)
                {
                    tax = float.Parse(taxAmount.Text);
                    if ((int)(tax * 100.0f / beforetax) != taxpercent)
                    {
                        tax = beforetax * taxpercent / 100;
                    }
                }
                else
                {
                    tax = beforetax * taxpercent / 100;
                }
            }

            total += round;

            totalAmount.Text = total.ToString("0.00");

            priceBeforeTax.Text = beforetax.ToString("0.00");

            taxAmount.Text = tax.ToString("0.00");

            rounded.Text = round.ToString("0.00");
            
        }

        private void FindPrices()
        {
            numbers.Sort();
            int total = 0, beforetax = 0, tax = 0;
            Rectangle tr = Rectangle.Empty, br = Rectangle.Empty, xr = Rectangle.Empty;
            foreach (TextBlock t in numbers)
            {
                if(t.Text.Length > 0 && t.Text[0] != '0' && !t.Text.Contains('.'))
                {
                    try
                    {
                        int number = int.Parse(t.Text);
                        Rectangle r = t.Rectangle;
                        if (number < 9999999)
                        {
                            if (total < number && (total == 0 || total != beforetax + tax))
                            {
                                var prev = total;
                                Rectangle pr = tr;
                                total = number;
                                tr = r;
                                number = prev;
                                r = pr;
                            }
                            if (number < total && ((beforetax * 100 / total > 79 && beforetax > number) || (beforetax * 100 / total < 79 && beforetax < number)))
                            {
                                var prev = beforetax;
                                Rectangle pr = br;
                                beforetax = number;
                                br = r;
                                number = prev;
                                r = pr;
                            }
                            if (number < beforetax && ((tax * 100 / total > 19 && tax > number) || (tax * 100 / total < 19 && tax < number)))
                            {
                                //var prev = tax;
                                tax = number;
                                xr = r;
                                //number = prev;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.StackTrace);
                    }
                }

            }
            if (total > 0)
            {
                
                //}
                if(total != beforetax+tax)
                {
                    tax = total * 25 / 100;
                    beforetax = total;
                    total = beforetax + tax;
                    AddBound(tr, Invoice.TOTAL_AMOUNT);
                    AddBound(tr, Invoice.EXCL_TAX_AMOUNT);
                    AddBound(tr, Invoice.TAX_AMOUNT);
                }
                else
                {
                    AddBound(tr, Invoice.TOTAL_AMOUNT);
                    AddBound(br, Invoice.EXCL_TAX_AMOUNT);
                    AddBound(xr, Invoice.TAX_AMOUNT);
                }

                totalAmount.Text = total + ".00";

                priceBeforeTax.Text = beforetax + ".00";
                    
                taxAmount.Text = tax + ".00";


                rounded.Text = "0.00";
                    
            }
        }

        public enum Invoice
        {
            PROVIDER_NAME,
            PHONE_NUMBER,
            WEBSITE,
            PROVIDER_ADDRESS,
            PROVIDER_INDEX,
            PROVIDER_CITY,
            PROVIDER_COUNTRY,
            IBAN,
            TAX_REGISTRATION_NUMBER,
            INSURANCE_NUMBER,

            ORGANIZATION_REFERENCE,



            BANKGIRO,
            PLUSGIRO,

            TAX_IN_PERCENT,

            INVOICE_DATE,
            PAY_DATE,

            OBJECT_REFERENCE,
            OCR_REFERENCE,

            

            CURRENCY,


            ROUNDED_AMOUNT,
            TAX_AMOUNT,
            EXCL_TAX_AMOUNT,
            TOTAL_AMOUNT,

            RECEIVER_NAME,
            RECEIVER_ADDRESS,
            RECEIVER_INDEX,
            RECEIVER_CITY,
            RECEIVER_COUNTRY,

            MESSAGE
        };

        private int MaxInv = (int)Invoice.MESSAGE;

        public TextBox GetBox(Invoice i)
        {
            TextBox tb = messageIOBox;
            switch (i)
            {
                case Invoice.PROVIDER_NAME: tb = providerName; break;
                case Invoice.PHONE_NUMBER: tb = providerPhone; break;
                case Invoice.WEBSITE: tb = providerWebb; break;
                case Invoice.PROVIDER_ADDRESS: tb = providerAddress; break;
                case Invoice.PROVIDER_INDEX: tb = providerPostalIndex; break;
                case Invoice.PROVIDER_CITY: tb = providerCity; break;
                case Invoice.PROVIDER_COUNTRY: tb = providerCountry; break;
                case Invoice.IBAN: tb = ibanNumber; break;
                case Invoice.TAX_REGISTRATION_NUMBER: tb = vatNumber; break;
                case Invoice.INSURANCE_NUMBER: tb = insuranceNumber; break;
                case Invoice.ORGANIZATION_REFERENCE: tb = organizationReference; break;
                case Invoice.BANKGIRO: tb = bankgiroNumber; break;
                case Invoice.PLUSGIRO: tb = plusgiroNumber; break;
                case Invoice.TAX_IN_PERCENT: tb = taxInPercent; break;
                case Invoice.INVOICE_DATE: tb = invoiceDate; break;
                case Invoice.PAY_DATE: tb = payDate; break;
                case Invoice.OBJECT_REFERENCE: tb = objectReference; break;
                case Invoice.OCR_REFERENCE: tb = ocrReference; break;
                case Invoice.CURRENCY: tb = currency; break;
                case Invoice.ROUNDED_AMOUNT: tb = rounded; break;
                case Invoice.TAX_AMOUNT: tb = taxAmount; break;
                case Invoice.EXCL_TAX_AMOUNT: tb = priceBeforeTax; break;
                case Invoice.TOTAL_AMOUNT: tb = totalAmount; break;
                case Invoice.RECEIVER_NAME: tb = receiverName; break;
                case Invoice.RECEIVER_ADDRESS: tb = receiverAddress; break;
                case Invoice.RECEIVER_INDEX: tb = receiverPostalIndex; break;
                case Invoice.RECEIVER_CITY: tb = receiverCity; break;
                case Invoice.RECEIVER_COUNTRY: tb = receiverCountry; break;
                case Invoice.MESSAGE: tb = messageIOBox; break;
            }
            return tb;
        }

        public Invoice Pat2Inv(Pattern i)
        {
            Invoice inv = Invoice.MESSAGE;
            switch (i)
            {
                case Pattern.PROVIDER_NAME: inv = Invoice.PROVIDER_NAME; break;
                case Pattern.PHONE_NUMBER: inv = Invoice.PHONE_NUMBER; break;
                case Pattern.WEBSITE: inv = Invoice.WEBSITE; break;
                case Pattern.PROVIDER_ADDRESS: inv = Invoice.PROVIDER_ADDRESS; break;
                case Pattern.PROVIDER_INDEX: inv = Invoice.PROVIDER_INDEX; break;
                case Pattern.PROVIDER_CITY: inv = Invoice.PROVIDER_CITY; break;
                case Pattern.PROVIDER_COUNTRY: inv = Invoice.PROVIDER_COUNTRY; break;
                case Pattern.IBAN: inv = Invoice.IBAN; break;
                case Pattern.TAX_REGISTRATION_NUMBER: inv = Invoice.TAX_REGISTRATION_NUMBER; break;
                case Pattern.INSURANCE_NUMBER: inv = Invoice.INSURANCE_NUMBER; break;
                case Pattern.ORGANIZATION_REFERENCE: inv = Invoice.ORGANIZATION_REFERENCE; break;
                case Pattern.BANKGIRO: inv = Invoice.BANKGIRO; break;
                case Pattern.PLUSGIRO: inv = Invoice.PLUSGIRO; break;
                case Pattern.TAX_IN_PERCENT: inv = Invoice.TAX_IN_PERCENT; break;
                case Pattern.DATE: inv = Invoice.INVOICE_DATE; break;
                case Pattern.PAY_DATE: inv = Invoice.PAY_DATE; break;
                case Pattern.OBJECT_REFERENCE: inv = Invoice.OBJECT_REFERENCE; break;
                case Pattern.OCR_REFERENCE: inv = Invoice.OCR_REFERENCE; break;
                case Pattern.CURRENCY: inv = Invoice.CURRENCY; break;
                case Pattern.ROUNDED_AMOUNT: inv = Invoice.ROUNDED_AMOUNT; break;
                case Pattern.TAX_AMOUNT: inv = Invoice.TAX_AMOUNT; break;
                case Pattern.EXCL_TAX_AMOUNT: inv = Invoice.EXCL_TAX_AMOUNT; break;
                case Pattern.TOTAL_AMOUNT: inv = Invoice.TOTAL_AMOUNT; break;
                case Pattern.RECEIVER_NAME: inv = Invoice.RECEIVER_NAME; break;
                case Pattern.RECEIVER_ADDRESS: inv = Invoice.RECEIVER_ADDRESS; break;
                case Pattern.RECEIVER_INDEX: inv = Invoice.RECEIVER_INDEX; break;
                case Pattern.RECEIVER_CITY: inv = Invoice.RECEIVER_CITY; break;
                case Pattern.RECEIVER_COUNTRY: inv = Invoice.RECEIVER_COUNTRY; break;
            }
            return inv;
        }


        public Invoice Box2Inv(string name)
        {
            Invoice inv = Invoice.MESSAGE;
            switch (name)
            {
                case "providerName": inv = Invoice.PROVIDER_NAME; break;
                case "providerPhone": inv = Invoice.PHONE_NUMBER; break;
                case "providerWebb": inv = Invoice.WEBSITE; break;
                case "providerAddress": inv = Invoice.PROVIDER_ADDRESS; break;
                case "providerPostalIndex": inv = Invoice.PROVIDER_INDEX; break;
                case "providerCity": inv = Invoice.PROVIDER_CITY; break;
                case "providerCountry": inv = Invoice.PROVIDER_COUNTRY; break;
                case "ibanNumber": inv = Invoice.IBAN; break;
                case "vatNumber": inv = Invoice.TAX_REGISTRATION_NUMBER; break;
                case "insuranceNumber": inv = Invoice.INSURANCE_NUMBER; break;
                case "organizationReference": inv = Invoice.ORGANIZATION_REFERENCE; break;
                case "bankgiroNumber": inv = Invoice.BANKGIRO; break;
                case "plusgiroNumber": inv = Invoice.PLUSGIRO; break;
                case "taxInPercent": inv = Invoice.TAX_IN_PERCENT; break;
                case "invoiceDate": inv = Invoice.INVOICE_DATE; break;
                case "payDate": inv = Invoice.PAY_DATE; break;
                case "objectReference": inv = Invoice.OBJECT_REFERENCE; break;
                case "ocrReference": inv = Invoice.OCR_REFERENCE; break;
                case "currency": inv = Invoice.CURRENCY; break;
                case "rounded": inv = Invoice.ROUNDED_AMOUNT; break;
                case "taxAmount": inv = Invoice.TAX_AMOUNT; break;
                case "priceBeforeTax": inv = Invoice.EXCL_TAX_AMOUNT; break;
                case "totalAmount": inv = Invoice.TOTAL_AMOUNT; break;
                case "receiverName": inv = Invoice.RECEIVER_NAME; break;
                case "receiverAddress": inv = Invoice.RECEIVER_ADDRESS; break;
                case "receiverPostalIndex": inv = Invoice.RECEIVER_INDEX; break;
                case "receiverCity": inv = Invoice.RECEIVER_CITY; break;
                case "receiverCountry": inv = Invoice.RECEIVER_COUNTRY; break;
            }
            Console.WriteLine("Box2Inv : " + name + " , " + inv.ToString());
            return inv;
        }



        private void SaveResult(string bg, string ocr)
        {
            string dir = DirProject() + @"saved\";
            if (bg.Length > 0 && ocr.Length > 0)
            {

                SaveFiles(dir, bg, dict_ext, 13);
                SaveFiles(dir, bg + "_" + ocr, inv_ext, MaxInv, 11);
                if (image.IsROISet)
                    image.ROI = largestOrigin;
                image.Save(dir + bg + "_" + ocr + ".tif");
                
            }
            else
            {
                WriteLog("Cannot do database correction. Giro or OCR number is missing", doPrint);
            }
        }

        private static string dict_ext = ".dictionary";

        private void SaveFiles(string dir, string file, string i_ext, int stop_i, int start_i = 0)
        {
            string output = "", cln = ":", nl = "\r\n";
            
            string[] names = Enum.GetNames(typeof(Invoice));
            int i = start_i, l = stop_i;
            //LoadImage(dir+file+".tif");
            while (i <= l)
            {
                output += names[i] + cln + GetBox((Invoice)i).Text + nl;
                i++;
            }

            File.WriteAllText(dir + file + i_ext, output);

            output = "";

            i = 0;
            l = bounds.Count;
            var cm = ",";
            foreach (Block block in bounds)
            {
                var rect = block.Rectangle;
                output += rect.X + cm + rect.Y + cm + rect.Width + cm + rect.Height + cm + block.PatternId + nl;
                
            }

            File.WriteAllText(dir + file + bnd_ext, output);
            //invoiceBox.
            //invoiceBox.Image.Save(dir + file +);
            
        }

        private string inv = "invoice";
        private string bnd = "bounds";

        private void DatabaseCorrection(string name)
        {
            string dir = DirProject()+@"saved\";
            if(name.Length > 0)
            {
                ParseFiles(dir, name, dict_ext, 13);
            } else
            {
                WriteLog("Cannot do database correction, BankGiro number doesn't exists", doPrint);
            }
        }

        private static string inv_ext = ".invoice";
        private static  string bnd_ext = ".bounds";

        private void ParseFiles(string dir, string file, string i_ext, int stop_i, int start_i = 0)
        {
            if(File.Exists(dir + file + i_ext))
                using (StreamReader stream = new StreamReader(dir + file + i_ext))
                {
                    string[] names = Enum.GetNames(typeof(Invoice));
                    int i = start_i, l = stop_i;
                    //LoadImage(dir+file+".tif");
                    while (i <= l)
                    {
                        var line = stream.ReadLine();
                        string[] spl = line.Split(':');
                        if (spl.Length >= 2)
                            for (int s = 1; s < spl.Length; s++)
                                if (s > 1)
                                    GetBox((Invoice)i).Text += ":" + spl[s];
                                else
                                    GetBox((Invoice)i).Text = spl[s];
                        if(line.Length > 0 || i == l)
                            i++;
                    }
                }
            if (File.Exists(dir + file + bnd_ext))
                using (StreamReader stream = new StreamReader(dir + file + bnd_ext))
                {
                    //string[] names = Enum.GetNames(typeof(Invoice));
                    //int i = 0, l = length;
                    //LoadImage(dir+file+".tif");
                    while (!stream.EndOfStream)
                    {
                        var line = stream.ReadLine();
                        string[] b = line.Split(',');
                        if (b.Length == 5)
                        {
                            int b4 = int.Parse(b[4]);
                            //bounds.Remove(new Block(Rectangle.Empty, b4));
                            AddBound(new Rectangle(int.Parse(b[0]), int.Parse(b[1]), int.Parse(b[2]), int.Parse(b[3])), (Invoice)b4);
                        }
                        else
                        {
                            WriteLog("ParseFiles : error occured, length = " + b.Length, doPrint);
                        }
                        //i++;
                    }
                }
        }

        private char spl = '_';
        private string img_ext = ".tif";

        private void OpenResult(string idir, string idict, string inum)
        {
            ClearPrevPatterns();
            LoadImage(idir + idict + spl + inum + img_ext);
            DatabaseCorrection(idict);
            ParseFiles(idir, idict + spl + inum, inv_ext, MaxInv, 11);
        }

        private void FillTrash()
        {
            string nl = "\r\n";
            string trash = " ### BACKUP NUMBERS ###" + nl;
            foreach (TextBlock t in numbers)
            {
                trash += t.Text + nl;
            }
            trashBoxReal.Text = trash + nl + " ### OTHER THRASH ###" + nl + nl + trashBoxReal.Text;
            numbers.Clear();
        }
        //int ir = 0;

        delegate void SetOCRResultCallback(string text, Rectangle rect);
        private void SetOCRResult(string text, Rectangle rect)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {

                    if (rect.Equals(Rectangle.Empty))
                    {

                        paintRect = Rectangle.Empty;
                        invoiceBox.Refresh();
                        if (totalAmount.Text.Length == 0 && priceBeforeTax.Text.Length == 0 && taxAmount.Text.Length == 0)
                        {
                            FindPrices();
                        } else
                        {
                            ValidatePrices();
                        }
                        DatabaseCorrection(bankgiroNumber.Text.Length > 0 ? bankgiroNumber.Text : plusgiroNumber.Text);
                        FillTrash();
                        HideWaitMessage();
                        saveBtn.Enabled = true;
                        getBtn.Enabled = true;
                        loadBtn.Enabled = true;
                        openBtn.Enabled = true;
                        invoiceBox.Enabled = true;
                        sw.Stop();
                        last_time = sw.ElapsedMilliseconds;
                        sw.Reset();
                        timeLabel.Text = "Last run time : " + last_time/1000.0 + " seconds";
                    }
                    else
                    {
                        paintRect = new Rectangle((int)(rect.X * scale)-1, (int)(rect.Y * scale)-1, (int)(rect.Width * scale)+2, (int)(rect.Height * scale)+2);
                        invoiceBox.Refresh();
                    }
                });
            }
        }

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

            PROVIDER_NAME,
            PROVIDER_INDEX_AND_CITY,
            PROVIDER_ADDRESS,
            PROVIDER_COUNTRY,

            TAX_IN_PERCENT,
            PRICE,
            OCR_REFERENCE,

            BACKUP_NUMBERS,

            PROVIDER_INDEX,
            PROVIDER_CITY,
            RECEIVER_NAME,
            RECEIVER_INDEX_AND_CITY,
            RECEIVER_INDEX,
            RECEIVER_CITY,
            RECEIVER_ADDRESS,
            RECEIVER_COUNTRY,

            TOTAL_AMOUNT,
            TAX_AMOUNT,
            EXCL_TAX_AMOUNT,
            PAY_DATE,

            ROUNDED_AMOUNT
        };

        List<TextBlock> numbers = new List<TextBlock>();
        List<TextBlock> prices = new List<TextBlock>();

        private Pattern SetText(string text, Rectangle rect, Pattern ptrn)
        {
            Console.WriteLine("2 : " + text + "; PatternId : " + (int)ptrn + "; Rectangle : " + rect.X + ", " + rect.Y + ", " + rect.Width + ", " + rect.Height);
            Pattern pat = ptrn;
            switch (pat)
            {
                case Pattern.WEBSITE :
                    providerWebb.Text = text;
                    break;
                case Pattern.IBAN :
                    ibanNumber.Text = text;
                    break;
                case Pattern.TAX_REGISTRATION_NUMBER :
                    if ( vatNumber.Text.Length == 0 || ( char.IsLetter( text[0] ) && char.IsLetter( text[1] ) ) )
                    {
                        if (vatNumber.Text.Length > 0)
                        {
                            var prev = vatNumber.Text;
                            vatNumber.Text = text;
                            HandleTextResult(prev, bounds.Find(new Block(Rectangle.Empty, (int)Pat2Inv(pat))).Value.Rectangle, (int)Pattern.OCR_REFERENCE);

                        }
                        else
                        {
                            vatNumber.Text = text;
                        }
                    } else
                    {
                        pat = SetText(text, rect, Pattern.OCR_REFERENCE);
                    }
                    break;
                case Pattern.PHONE_NUMBER :
                    providerPhone.Text = text;
                    break;
                case Pattern.DATE :
                    if(invoiceDate.Text.Length == 0)
                    {
                        invoiceDate.Text = text;
                    } else
                    {
                        if (payDate.Text.Length == 0 || !text.Contains('-') || payDate.Text.Contains('-') && text.Contains('-') && DateTime.Parse(payDate.Text + " 00:00").Ticks < DateTime.Parse(text + " 00:00").Ticks)
                        {
                            payDate.Text = text;
                            pat = Pattern.PAY_DATE;
                        } else
                        {
                            pat = Pattern.BACKUP_NUMBERS;
                        }
                    }
                    break;
                case Pattern.ORGANIZATION_REFERENCE :
                    if (organizationReference.Text.Length > 0)
                    {
                        if(text.ElementAt(6) == '-')
                        {
                            organizationReference.Text = text;
                        } else
                        {
                            if(bounds.Contains(new Block(Rectangle.Empty, (int)Pat2Inv(Pattern.ORGANIZATION_REFERENCE))))
                                numbers.Add(new TextBlock(bounds.Find(new Block(Rectangle.Empty, (int)Pat2Inv(Pattern.ORGANIZATION_REFERENCE))).Value.Rectangle, text));
                            pat = Pattern.BACKUP_NUMBERS;
                        }
                    } else
                    {
                        organizationReference.Text = text;
                    }
                    break;
                case Pattern.OBJECT_REFERENCE:
                    objectReference.Text = text;
                    break;
                case Pattern.INSURANCE_NUMBER:
                    insuranceNumber.Text = text;
                    break;
                case Pattern.OCR_REFERENCE:
                    if (text.Length > ocrReference.Text.Length && !text.Equals(ibanNumber.Text) && !text.Equals(vatNumber.Text))
                    {
                        ocrReference.Text = text;
                    } else
                    {
                        pat = Pattern.BACKUP_NUMBERS;
                        numbers.Add(new TextBlock(rect, text));
                    }
                    break;
                case Pattern.BANKGIRO :
                    bankgiroNumber.Text = text;
                    break;
                case Pattern.PLUSGIRO :
                    plusgiroNumber.Text = text;
                    break;
                case Pattern.PROVIDER_NAME:
                    if (receiverName.Text.Length == 0)
                    {
                        receiverName.Text = text;
                        pat = Pattern.RECEIVER_NAME;
                    }
                    else if(providerName.Text.Length == 0 || !receiverName.Text.Equals(text))
                    {
                        providerName.Text = text;
                    } else
                    {
                        pat = Pattern.BACKUP_NUMBERS;
                    }
                    break;
                case Pattern.PROVIDER_ADDRESS:
                    if (receiverAddress.Text.Length == 0 && !text.Replace(" ", "").Substring(0, 3).Equals("Box"))
                    {
                        receiverAddress.Text = text;
                        pat = Pattern.RECEIVER_ADDRESS;
                    }
                    else
                    {
                        providerAddress.Text = text;
                    } 
                    //receiverAddress.Text = text;
                    break;
                case Pattern.PROVIDER_INDEX:
                    if (receiverPostalIndex.Text.Length == 0)
                    {
                        receiverPostalIndex.Text = text;
                        pat = Pattern.RECEIVER_INDEX;
                    }
                    else if (providerPostalIndex.Text.Length == 0)
                    {
                        providerPostalIndex.Text = text;
                    }
                    else
                    {
                        pat = Pattern.BACKUP_NUMBERS;
                    }

                    break;
                case Pattern.PROVIDER_CITY:
                    if (receiverCity.Text.Length == 0)
                    {
                        receiverCity.Text = text;
                        pat = Pattern.RECEIVER_CITY;
                    }
                    else if (providerCity.Text.Length == 0)
                    {
                        providerCity.Text = text;
                    }
                    else
                    {
                        pat = Pattern.BACKUP_NUMBERS;
                    }

                    break;
                case Pattern.PROVIDER_COUNTRY:
                    if(receiverCountry.Text.Length == 0)
                    {
                        receiverCountry.Text = text;
                        pat = Pattern.RECEIVER_COUNTRY;
                    }
                    providerCountry.Text = text;
                    break;
                case Pattern.TAX_IN_PERCENT:
                    taxInPercent.Text = text;
                    break;
                case Pattern.CURRENCY:
                    currency.Text = text;
                    break;
                case Pattern.PRICE:
                    TextBox amount = null;
                    int patternId = -1;
                    float num = float.Parse(text);

                    if(totalAmount.Text.Length == 0 || float.Parse(totalAmount.Text) <= num)
                    {
                        if (totalAmount.Text.Length == 0 || float.Parse(totalAmount.Text) < num)
                        {
                            amount = totalAmount;
                        }
                        patternId = (int)Pattern.TOTAL_AMOUNT;
                        
                    }
                    else if (priceBeforeTax.Text.Length == 0 || float.Parse(priceBeforeTax.Text) < num && (int)(float.Parse(priceBeforeTax.Text)*100.0f/float.Parse(totalAmount.Text)) != 79 || float.Parse(priceBeforeTax.Text) == num)
                    {
                        if (priceBeforeTax.Text.Length == 0 || float.Parse(priceBeforeTax.Text) < num)
                        {
                            amount = priceBeforeTax;
                        }
                        patternId = (int)Pattern.EXCL_TAX_AMOUNT;
                    }
                    else if (taxAmount.Text.Length == 0 || float.Parse(taxAmount.Text) < num && (int)(float.Parse(taxAmount.Text) * 100.0f / float.Parse(totalAmount.Text)) != 19 || float.Parse(taxAmount.Text) == num)
                    {

                        if (taxAmount.Text.Length == 0 || float.Parse(taxAmount.Text) < num)
                        {
                            amount = taxAmount;
                        }
                        patternId = (int)Pattern.TAX_AMOUNT;
                    }
                    else if (rounded.Text.Length == 0 || (int)(float.Parse(rounded.Text) + float.Parse(taxAmount.Text) + float.Parse(priceBeforeTax.Text)) != (int)float.Parse(totalAmount.Text))
                    {
                        if ( ( rounded.Text.Length == 0 || float.Parse(rounded.Text) == 0.00f && num != float.Parse(rounded.Text) ) && num < 1.0f )
                        {
                            amount = rounded;

                            patternId = (int)Pattern.ROUNDED_AMOUNT;
                        } else
                        {

                            patternId = (int)Pattern.BACKUP_NUMBERS;
                        }
                    } else
                    {
                        pat = Pattern.BACKUP_NUMBERS;
                        numbers.Add(new TextBlock(rect, text));
                    }

                    if (patternId >= 0)
                    {
                        pat = (Pattern)patternId;
                    }
                    if (amount != null) { 
                        var prev_total = amount.Text;
                        amount.Text = text;
                        if (prev_total.Length > 0)
                        {
                            HandleTextResult(prev_total, bounds.Find(new Block(Rectangle.Empty, (int)Pat2Inv((Pattern)patternId))).Value.Rectangle, (int)Pattern.PRICE);
                        }
                    }
                    //prices
                    break;
                case Pattern.BACKUP_NUMBERS :
                    //if (!text.Equals(ibanNumber.Text))
                    //{
                        numbers.Add(new TextBlock(rect, text));
                    //}
                    break;
                default :
                    break;
            }
            return pat;
        }

        private void AddBound(Rectangle rect,  Invoice invId)
        {
            var block = new Block(Rectangle.Empty, (int)invId);

            while (bounds.Contains(block))
            {
                var r = bounds.Find(block).Value.Rectangle;
                bounds.Remove(block);
                paintRects.Remove( new Rectangle( (int)(r.X * scale)-1, (int)(r.Y * scale)-1, (int)(r.Width * scale)+2, (int)(r.Height * scale)+2 ) );
                originalPaintRects.Remove(r);
            }
            bounds.AddLast(new Block(rect, (int)invId));
            //var rect = rectangles.ElementAt(rectId);
            originalPaintRects.AddLast(rect);
            paintRects.AddLast(new Rectangle((int)(scale * rect.X) - 1, (int)(scale * rect.Y) - 1, (int)(scale * rect.Width) + 2, (int)(scale * rect.Height) + 2));
            invoiceBox.Refresh();
        }

        private void HandleTextResult(string text, Rectangle rect, int patternId)
        {
            Console.WriteLine("1 : " + text + "; PatternId : " + patternId + "; Rectangle : " + rect.X + ", " + rect.Y + ", " + rect.Width + ", " + rect.Height);

            patternId = (int)SetText(text, rect, (Pattern)patternId);
            if((Pattern)patternId != Pattern.PRICE && (Pattern)patternId != Pattern.BACKUP_NUMBERS)
            {
                Console.WriteLine("3 : " + text + "; PatternId : " + patternId + "; Rectangle : " + rect.X + ", " + rect.Y + ", " + rect.Width + ", " + rect.Height);
               

                Console.WriteLine("6 Add Text : " + text + "; patternId : " + patternId + ";");
                AddBound(rect, Pat2Inv((Pattern)patternId));
            }
        }

        private LinkedList<Block> bounds = new LinkedList<Block>();

        delegate void SetTextResultCallback(string text, Rectangle rect, int patternId);
        private void SetTextResult(string text, Rectangle rect, int patternId)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if(patternId < 0)
                    {
                        trashBoxReal.Text += text;
                    }
                    else
                    {
                        if (patternId == (int)Pattern.PROVIDER_INDEX_AND_CITY)
                        {
                            var index = text.Substring(0, 6).Replace(" ", "");
                            var city = text.Substring(6).Replace(" ", "");
                            HandleTextResult(index, rect, (int)Pattern.PROVIDER_INDEX);
                            HandleTextResult(city, rect, (int)Pattern.PROVIDER_CITY);
                        }
                        else
                        {
                            HandleTextResult(text, rect, patternId);
                        }
                    }
                });
            }
        }

        public void ImageProcessingResult(object sender, BlocksEventArgs<string, bool> e)
        {

            string s = e.block();
            bool b = e.result();
            SetImageProcessingResult(s, b);

        }

        public void ContourRecognitionResult(object sender, BlocksEventArgs<Rectangle, bool> e)
        {
            bool isImportant = e.result(); // e.result() is curently used to identify rectangles that should be saved
            Rectangle rect = e.block();

            SetContourRecognitionResult(rect, isImportant);
        }

        public void OCRResult(object sender, BlocksEventArgs<Rectangle, string> e)
        {
            string text = e.result();
            Rectangle rect = e.block();


            SetOCRResult(text, rect);

        }


        public void TextResult(object sender, BlockEventsArgs<string, Rectangle, int> e)
        {
            string text = e.text();
            Rectangle rect = e.rectangle();
            var pattern = e.patternId();


           SetTextResult(text, rect, pattern);

        }
        bool br_in_progress = false;
        BoundsRecognition PrepareBR()
        {
            //your code
            var br = new BoundsRecognition();
            br.ProgressOfBlocks += ContourRecognitionResult;
            br.ProgressOfImage += ImageProcessingResult;
            largestOrigin = Rectangle.Empty;
            br_in_progress = true;
            return br;
        }

        TextRecognition PrepareTR()
        {
            //your code
            var tr = new TextRecognition();
            tr.RecognitionUpdate += OCRResult;
            tr.ProcessingUpdate += TextResult;
            return tr;
        }

        /*TextProcessing PrepareTP()
        {
            //your code
            var tr = new TextProcessing();
            tr.ProgressUpdate += TextResult;
            return tr;
        }*/

        private Stopwatch sw = new Stopwatch();
        private long last_time;

        private void GetTEXT_button_Click_1(object sender, EventArgs e)
        {
            bounds.Clear();
            rectangles.Clear();
            paintRects.Clear();
            originalPaintRects.Clear();
            paintRect = Rectangle.Empty;

            //var file = "7";
            //var _tif = @".tif";
            //var _tiff = ".tiff";

            //int i = 0;
            sw.Start();
            saveBtn.Enabled = false;
            getBtn.Enabled = false;
            loadBtn.Enabled = false;
            openBtn.Enabled = false;
            invoiceBox.Enabled = false;
            button1.Enabled = false;
            //this.Paint += InvoiceForm_Paint;
            ShowWaitMessage("Recognition in progress, please wait.");
            StartBR(Path.GetDirectoryName(invoicePath.Text) + @"\", Path.GetFileName(invoicePath.Text));




            //HideWaitMessage();
        }
        

        private LinkedList<Rectangle> paintRects = new LinkedList<Rectangle>();
        private LinkedList<Rectangle> originalPaintRects = new LinkedList<Rectangle>();
        private Rectangle[] fillRects = null;

        private void InvoiceBox_Paint(object sender, PaintEventArgs e)
        {
            if (!zoom)
            {
                Graphics g = e.Graphics;
                //{
                Color c = pen.Color;
                float w = pen.Width;

                

                //else
                //{
                if (paintRects.Count > 0)
                {
                    if (!c.Equals(Color.Yellow))
                    {
                        pen.Color = Color.Green;
                        pen.Width = 1;
                    }
                    else
                    {
                        pen.Width = 2;
                    }
                    foreach (Rectangle rect in paintRects)
                    {
                        g.DrawRectangle(pen, rect);
                    }
                }
                if (fillRects != null)
                {
                    g.FillRectangles(new SolidBrush(Color.White), fillRects);
                }
                pen.Color = c;
                pen.Width = w;
                if (!paintRect.Equals(Rectangle.Empty))
                {
                    g.DrawRectangle(pen, paintRect);
                    //paintRect = Rectangle.Empty;
                }
                if (!drawRect.Equals(Rectangle.Empty))
                {
                    g.DrawRectangle(pen, drawRect);
                }
               // }
            }
        }
        

        private Task brTask;
        private int ibr = 0;
        private BoundsRecognition br = null;
        //private bool otsu = true;
        private Rectangle invoiceSize = Rectangle.Empty;
        void StartBR(string directory, string filename)
        {
            if (br == null)
            {
                br = PrepareBR();
            }
            switch (ibr)
            {
                case -1:

                    waitLabel.Text = "Trimming out white space around invoice.";
                    waitLabel.Refresh();
                    int st = 1, sb = 2;

                    largestOrigin.X -= largestOrigin.X > st ? st : largestOrigin.X;
                    largestOrigin.Y -= largestOrigin.Y > st ? st : largestOrigin.Y;
                    Bitmap b;
                    using (Stream stream = File.OpenRead(directory + filename))
                    using (var img = Image.FromStream(stream))
                    {
                        largestOrigin.Width += img.Width >= largestOrigin.Width + sb ? sb : img.Width-largestOrigin.Width;
                        largestOrigin.Height += img.Height >= largestOrigin.Height + sb ? sb : img.Height-largestOrigin.Height ;
                        filename = "cropped.tif";
                        directory = DirProject();
                        b = CropBitmap(Get24bppRgb(img), largestOrigin);
                    }
                    b.Save(directory + filename, ImageFormat.Tiff);

                    paintRects.Clear();
                    originalPaintRects.Clear();
                    

                    LinkedListNode<Rectangle> node = rectangles.First;
                    while (node != null)
                    {
                        var val = node.Value;
                        val.X -= largestOrigin.X;
                        val.Y -= largestOrigin.Y;
                        node.Value = val;
                        node = node.Next;
                    }

                    br_in_progress = false;
                    LoadImage(directory + filename);

                    
                    waitLabel.Text = "Preparing image for OCR.";
                    waitLabel.Refresh();
                    brTask = Task.Run(() => br.PrepareImageForOCR(directory, filename));
                    
                    break;
                case 0:
                    waitLabel.Text = "Image pre-processing.";
                    waitLabel.Refresh();
                    brTask = Task.Run(() => br.PrepareImageForBounds(directory, filename));
                    //waitLabel.Text = "Using Binary filter.";
                    break;
                case 1:
                    waitLabel.Text = "Detecting bounds.";
                    waitLabel.Refresh();
                    //waitLabel.Invalidate();
                    brTask = Task.Run(() => br.RecognizeBounds(directory, filename));  // #3 Instead of a new Thread we now use a Task. To later be able to check its (successfull) 
                                                                                       // completion we save it in the global calcTask member. In the background this also starts a 
                                                                                       // new thread and runs the action there, but it is much easier to handle and has some other 
                                                                                       // benefits.
                                                                                       //waitLabel.Text = "Detecting bounds.";
                    ibr = -1;
                    break;
                default:
                    break;
            }
            ibr++;

        }
        
        private Pen foundPen = new Pen(Color.Green, 2);
        

        private Task ocrTask;
        private int rectIter = 0;
        void StartOCR(string directory, string filename)
        {

            pen.Color = Color.Orange;
            var ocr = PrepareTR();
            rectIter = rectangles.Count;
            waitLabel.Text = "Text recognition in progress. Please wait.";
            ocrTask = Task.Run(() => ocr.StartTextRecognition(rectangles, directory, filename));  // #3 Instead of a new Thread we now use a Task. To later be able to check its (successfull) 
                                                                                                  // completion we save it in the global calcTask member. In the background this also starts a 
                                                                                                  // new thread and runs the action there, but it is much easier to handle and has some other 
                                                                                                  // benefits.
            
            
        }

        private OpenFileDialog openFileDialog1 = null;
        private void button1_Click(object sender, EventArgs e)
        {
            ClearPrevPatterns();
            // Create an instance of the open file dialog box.
            openFileDialog1 = new OpenFileDialog();

            openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialog1_FileOk);

            // Set filter options and filter index.
            openFileDialog1.Filter = "Tif (best quality)|*.tif|Png (not recommended)|*.png";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Image Browser";

            // Call the ShowDialog method to show the dialog box.
            openFileDialog1.ShowDialog();
            getBtn.Select();
        }

        // This method handles the FileOK event.  It opens each file 
        // selected and loads the image from a stream into pictureBox1.
        float scale = 1.0f, reversedScale = 1.0f;

        private Image<Gray, byte> image = null;
        private void LoadImage(string name)
        {
            //using (var bm = Image.FromFile(name)) {
            invoicePath.Text = name;
            invoiceBox.WaitOnLoad = false;
            using (System.IO.Stream stream = System.IO.File.OpenRead(name))
            using (var bm = Image.FromStream(stream))
            {
                scale = (float)invoiceBox.Height / bm.Height;
                reversedScale = (float)bm.Height / invoiceBox.Height;
                invoiceBox.Width = (int)(bm.Width * scale);
            }
            if (invoiceBox.Right > readBox.Left)
            {
                
                int diff = invoiceBox.Right - readBox.Left + 10;
                readBox.Left += diff;
                readBox.Width -= diff;
                //flowLayoutPanel1.Refresh();
            }
            invoiceBox.SizeMode = PictureBoxSizeMode.StretchImage;


            LoadI(name);
        }

        //private FileDialog openInvoiceDialog = null;
        

        private void openInvoiceDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (openFileDialog1.CheckPathExists && openFileDialog1.CheckFileExists)
            {
                string path = openFileDialog1.FileName;
                string file = openFileDialog1.SafeFileName;
                string dir = path.Substring(0, path.Length - file.Length);
                string name = file.Split('.')[0];

                openFileDialog1.Dispose();
                openFileDialog1 = null;
                bounds.Clear();
                rectangles.Clear();
                paintRects.Clear();
                originalPaintRects.Clear();

                HideWaitMessage();

                int i = 0, l = MaxInv;

                while (i < MaxInv)
                {
                    GetBox((Invoice)i).Text = "";
                    i++;
                }
                trashBoxReal.Text = "";
                

                if (zoom)
                    zoom = false;
                
                string[] vals = name.Split('_');
                OpenResult(dir, vals[0], vals[1]);

                //}
                getBtn.Enabled = true;
                saveBtn.Enabled = true;
                //EnableProgressBar();
                //loadBtn.Enabled = false;
                viewBlock.Text = "Zoomed block";
                waitLabel.Text = "";
                InitBoxes();

            } else
            {

                openFileDialog1.Dispose();
                openFileDialog1 = null;
            }

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (openFileDialog1.CheckPathExists && openFileDialog1.CheckFileExists)
            {

                bounds.Clear();
                rectangles.Clear();
                paintRects.Clear();
                originalPaintRects.Clear();

                int i = 0, l = MaxInv;

                while(i < MaxInv)
                {
                    GetBox((Invoice)i).Text = "";
                    i++;
                }
                trashBoxReal.Text = "";
                LoadImage(openFileDialog1.FileName);
                //}
                getBtn.Enabled = true;
                //EnableProgressBar();
                //loadBtn.Enabled = false;
                viewBlock.Text = "Next step";
                waitLabel.Text = @"Click on 'Extract Text' button, in order to start the process.";

            }
            openFileDialog1.Dispose();
            openFileDialog1 = null;

            //

            //var tp = new TextProcessing();
            //tp.FindNeededInformation(@"IBAN SE8374628374659203746385", 0);

            //

        }

        

        private LinkedList<Rectangle> rectangles = new LinkedList<Rectangle>();
        private LinkedList<Invoice> patterns = new LinkedList<Invoice>();

        private void openBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();

            openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(openInvoiceDialog_FileOk);

            // Set filter options and filter index.
            openFileDialog1.Filter = "Saved Invoice |*.invoice";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Invoice Browser";

            // Call the ShowDialog method to show the dialog box.
            openFileDialog1.ShowDialog();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveResult(bankgiroNumber.Text.Length > 0 ? bankgiroNumber.Text : plusgiroNumber.Text, ocrReference.Text);
            // Code is entered here that performs a calculation
            // Display a message box informing the user that the calculations 
            // are complete
            MessageBox.Show("Digital Invoice is saved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearPrevPatterns()
        {
            if (patterns.Count > 0)
            {
                foreach (Invoice p in patterns)
                {
                    GetBox(p).BackColor = Color.White;
                }
                patterns.Clear();
            }
            zoomBox.Image = null;
            paintRect = Rectangle.Empty;
            invoiceBox.Refresh();

        }

        private void SelectZoomBlock(Rectangle block, Rectangle pRect)
        {
            //Rectangle block = zoomNode.Value;
            //block.X = (int)(block.X * scale);
            //block.Y = (int)(block.Y * scale);
            //block.Width = (int)(block.Width * scale);
            //block.Height = (int)(block.Height * scale);
            image.ROI = block;
            Image rect = image.ToBitmap();

            image.ROI = largestOrigin;
            //rect.Save(DirProject()+"0res_"+iterator+".tif");
            //iterator++;
            //using (var page = "")
            //{
            //Image<Bgr, byte> img = new Image<Bgr, byte>(rect);
            //imgEntrada.Draw(RealImageRect, new Bgr(Color.Red), thickness);
            //img = img.ThresholdBinary(new Bgr(1,1,1), new Bgr(255,255,255));
            paintRect = pRect;
            pen.Color = Color.Orange;
            pen.Width = 2;
            invoiceBox.Refresh();
            zoomBox.Width = (int)(rect.Width * ((float)zoomBox.Height / rect.Height));
            if (zoomBox.Width > viewBlock.Width)
            {
                zoomBox.Width = viewBlock.Width;
            }
            var height = (int)(rect.Height * ((float)zoomBox.Width / rect.Width));
            zoomBox.SizeMode = PictureBoxSizeMode.CenterImage;
            zoomBox.Image = ResizeImage(rect, zoomBox.Width, height);
            zoomBox.Refresh();

        }

        private void SelectBox(Point p)
        {
            bool hit = false;
            if (paintRects != null && paintRects.Count > 0)
            {
                field = Invoice.MESSAGE;
                LinkedListNode<Rectangle> node = paintRects.First;
                LinkedListNode<Rectangle> zoomNode = originalPaintRects.First;
                int i = 0;
                while (node != null)
                {
                    if (node.Value.Contains(p.X, p.Y))
                    {
                        Rectangle block = zoomNode.Value;

                        SelectZoomBlock(block, node.Value);

                        var n = bounds.First;
                        while (n != null)
                        {
                            if (n.Value.Rectangle.Equals(block))
                            {
                                field = (Invoice)n.Value.PatternId;
                                GetBox(field).BackColor = onFocusColor;
                                patterns.AddLast(field);
                                
                            }
                            GetBox(field).Focus();
                            n = n.Next;
                        }
                        this.Refresh();
                        Console.WriteLine("InvoiceBox Click : one of rectangles Contains mouse pointer");
                        Console.WriteLine("Block : " + block.X + " , " + block.Y + " , " + block.Width + " , " + block.Height);
                        Console.WriteLine("Point : " + p.X + " , " + p.Y);
                        hit = true;
                    }
                    //else
                    //{
                    node = node.Next;
                    zoomNode = zoomNode.Next;
                    //}
                    i++;
                }

            }
            if (!hit)
            {
                DoZoom(p.X, p.Y);
            }
        }

        private bool zoom = false;
        private Rectangle drawRect = Rectangle.Empty;
        private Point startP = Point.Empty;


        private void RedrawRectangle(Point p)
        {
            if (p.X >= drawRect.Right)
            {
                drawRect.Width = p.X - startP.X;
                drawRect.X = startP.X;
            }
            else if (p.X <= drawRect.Left)
            {
                drawRect.Width = startP.X - p.X;
                drawRect.X = p.X;
            }
            else
            {
                if (startP.X > p.X)
                {
                    drawRect.Width = startP.X - p.X;
                    drawRect.X = p.X;
                }
                else
                {
                    drawRect.Width = p.X - startP.X;
                    drawRect.X = startP.X;
                }
            }
            if (p.Y >= drawRect.Bottom)
            {
                drawRect.Height = p.Y - startP.Y;
                drawRect.Y = startP.Y;
            }
            else if (p.Y <= drawRect.Top)
            {
                drawRect.Height = startP.Y - p.Y;
                drawRect.Y = p.Y;
            }
            else
            {
                if (startP.Y > p.Y)
                {
                    drawRect.Height = startP.Y - p.Y;
                    drawRect.Y = p.Y;
                }
                else
                {
                    drawRect.Height = p.Y - startP.Y;
                    drawRect.Y = startP.Y;
                }
            }
            invoiceBox.Refresh();
        }

        private void invoiceBox_Click_1(object sender, EventArgs e)
        {

            var ee = (MouseEventArgs)e;
            if (draw)
            {

                if (drawRect.Equals(Rectangle.Empty))
                {
                    ClearPrevPatterns();
                    drawRect = new Rectangle(ee.X, ee.Y, 0, 0);
                    startP = ee.Location;
                } else
                {
                    RedrawRectangle(ee.Location);
                    AddBound(new Rectangle((int)(drawRect.X/scale)+1, (int)(drawRect.Y/scale)+1, (int)(drawRect.Width/scale), (int)(drawRect.Height/ scale)), field);

                    draw = false;
                    drawRect = Rectangle.Empty;

                }
                invoiceBox.Refresh();
            }
            else
            {
                if (zoom)
                {
                    zoom = false;
                    image.ROI = largestOrigin;
                    invoiceBox.Image = image;
                    invoiceBox.Refresh();
                }
                else
                {
                    ClearPrevPatterns();
                    bool hit = false;
                    SelectBox(ee.Location);
                }
            }
        }

        Invoice field = Invoice.MESSAGE;
        bool draw = false;
        private void button1_Click_1(object sender, EventArgs e) // Draw Region 
        {
            if(field != Invoice.MESSAGE)
            {
                //var block = new Block(Rectangle.Empty, (int)field);
                
                draw = true;
            }
            button1.Enabled = false;
        }

        private void invoiceBox_Move(object sender, EventArgs e)
        {
            if (!drawRect.Equals(Rectangle.Empty))
            {
                RedrawRectangle(((MouseEventArgs)e).Location);
                 
            }
        }

        private void DoZoom(int ux, int uy)
        {
            if (image != null)
            {
                zoom = true;
                int width = (int)(largestOrigin.Width * scale), height = (int)(largestOrigin.Height * scale), w = width / 2, w2 = w / 2, h = height / 2, h2 = h / 2, x = ux - w2, y = uy - h2;
                if (x < 0)
                    x = 0;
                if (y < 0)
                    y = 0;
                if (x + w > width)
                    x += width - (x + w);
                if (y + h > height)
                    y += height - (y + h);
                image.ROI = new Rectangle((int)(x / scale), (int)(y / scale), (int)(w / scale), (int)(h / scale));
                invoiceBox.Image = image;
                invoiceBox.Refresh();
            }
        }
        
    }



    public class TextBlock : IComparable<TextBlock>
    {

        public TextBlock(Rectangle r, string t)
        {
            Rectangle = r;
            Text = t;
        }
        public Rectangle Rectangle
        {
            get;set;
        }
        public string Text
        {
            get;set;
            
        }
        public override bool Equals(object obj)
        {
            return CompareTo(((TextBlock)obj)) == 0;
        }

        public override int GetHashCode()
        {
            return Rectangle.GetHashCode()*17+Text.Length*17+Text.GetHashCode();
        }

        public int CompareTo(TextBlock it)
        {
            return Text.CompareTo(it.Text);
        }
    }

    public class Block : IComparable<Block>
    {
        //private int rId, ptrn;
        public Block (Rectangle r, int p)
        {
            Rectangle = r;
            PatternId = p;
        }
        public Rectangle Rectangle
        {
            get;set;
        }
        public int PatternId
        {
            get;set;
        }
        public override bool Equals(object obj)
        {
            return CompareTo(((Block)obj)) == 0;
        }
        public int CompareTo(Block it)
        {
            return it.PatternId >= 0 && PatternId < it.PatternId ? -1
                 : it.PatternId >= 0 && PatternId > it.PatternId ? 1 : 0;
        }
    }

}