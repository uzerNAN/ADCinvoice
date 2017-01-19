//using journeyofcode.Images.OnenoteOCR;
using System;
using System.Windows.Forms;

namespace ADCinvoice
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InvoiceForm());
        }
        /*static void Main()
        {
            var imagePath = "C:\\Users\\Sergej\\Documents\\Visual Studio 2015\\Projects\\ADCinvoice\\ADCinvoice\\scan3.png";//args.FirstOrDefault();
            //if (String.IsNullOrWhiteSpace(imagePath) || !File.Exists(args[0]))
            //{
            //    Console.WriteLine("Usage: {0} [Path to image file]", Path.GetFileName(Assembly.GetAssembly(typeof(Program)).CodeBase));
            //    return;
            //}

            Console.WriteLine("Running OCR for file " + imagePath);
            try
            {
                using (var ocrEngine = new OnenoteOcrEngine())
                using (var image = Image.FromFile(imagePath))
                {
                    var text = ocrEngine.Recognize(image);
                    if (text == null)
                        Console.WriteLine("nothing recognized");
                    else
                        Console.WriteLine("Recognized: " + text);
                }
            }
            catch (OcrException ex)
            {
                Console.WriteLine("OcrException:\n" + ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Exception:\n" + ex);
            }

            Console.ReadLine();
        }*/
    }
}
