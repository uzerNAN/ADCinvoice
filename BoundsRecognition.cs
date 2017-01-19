using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ADCinvoice
{
    class BoundsRecognition
    {
        public event EventHandler<BlocksEventArgs<Rectangle, bool>> ProgressOfBlocks;   // #5 Here I now use a "strongly typed generic event" so we can pass and receive our "status
                                                                                        // object" easily
        public event EventHandler<BlocksEventArgs<string, bool>> ProgressOfImage;

        public static bool valueInRange(int value, int min, int max)
        {
            return (min <= value) && (value <= max);
        }

        public static bool rectOverlap(Rectangle A, Rectangle B)
        {
            bool x1Overlap = valueInRange(A.Left, B.Left, B.Right) ||
                            valueInRange(B.Left, A.Left, A.Right);

            bool y1Overlap = valueInRange(A.Top, B.Top, B.Bottom) ||
                            valueInRange(B.Top, A.Top, A.Bottom);

            bool x2Overlap = valueInRange(A.Right, B.Left, B.Right) ||
                            valueInRange(B.Right, A.Left, A.Right);

            bool y2Overlap = valueInRange(A.Bottom, B.Top, B.Bottom) ||
                            valueInRange(B.Bottom, A.Top, A.Bottom);

            return (x1Overlap || x2Overlap) && (y1Overlap || y2Overlap);
        }

        public Rectangle MergeBlock(LinkedList<Rectangle> rects, Rectangle mergeRect)
        {

            Rectangle rect = mergeRect;
            //WriteLog(" # Merge nullcheck start #", doPrint);
            if (rects != null)
            {
                bool again;
                do
                {
                    again = false;
                    //WriteLog(" # Merge start # Rectangle : " + rect.X + " , " + rect.Y + " , " + rect.Width + " , " + rect.Height + " ;", doPrint);
                    //int i = 0, length = rects.Count;

                    LinkedListNode<Rectangle> node = rects.First;

                    while (node != null)
                    {

                        Rectangle block = new Rectangle(node.Value.X, node.Value.Y, node.Value.Width, node.Value.Height);
                        if (rectOverlap(block, rect))
                        {

                            //Rectangle result = block;


                            if (block.Right < rect.Right)               // if Right side of block is smaller than Right side of rect ,
                            {                                           // ( iow. if Right side of block makes cover-area smaller than if it was the Right side of rect ) .
                                block.Width += (rect.Right - block.Right);
                            }

                            if (block.Bottom < rect.Bottom)             // if Bottom side of block is smaller than Bottom side of rect ,
                            {                                           // ( iow. if Bottom side of block makes cover-area smaller than if it was the Bottom side of rect ) .
                                block.Height += (rect.Bottom - block.Bottom);
                            }

                            if (block.Left > rect.Left)                 // if Left side of block is bigger than Left side of rect ,
                            {                                           // ( iow. if Left side of block makes cover-area smaller than if it was the Left side of rect ) .
                                int space = block.Left - rect.Left;
                                block.X -= space;
                                block.Width += space;
                            }

                            if (block.Top > rect.Top)                   // if Top side of block is bigger than Top side of rect ,
                            {                                           // ( iow. if Top side of block makes cover-area smaller than if it was the Top side of rect ) .
                                int space = block.Top - rect.Top;
                                block.Y -= space;
                                block.Height += space;
                            }
                            var remove = node;
                            node = node.Next;
                            rects.Remove(remove);
                            //ListRemove(rects, remove);

                            rect = block;

                            //WriteLog(" # Merge processing # New Rectangle : " + rect.X + " , " + rect.Y + " , " + rect.Width + " , " + rect.Height + " ;", doPrint);

                            //i = length;
                            again = true;
                        }
                        else
                        {
                            node = node.Next;
                            //i++;
                        }

                    }
                    //WriteLog(" # Merge end # Rectangle : " + rect.X + " , " + rect.Y + " , " + rect.Width + " , " + rect.Height + " ;", doPrint);
                } while (again);
            }
            //WriteLog(" # Merge nullcheck end #", doPrint);
            //result = rect;



            return rect;
        }

        public Rectangle MergeAndAddBlock(LinkedList<Rectangle> rects, Rectangle rect)
        {
            //, origSpace = space;

            ///if(maxWidth > re)
            Rectangle result = MergeBlock(rects, rect);
            //if ( result.Equals( Rectangle.Empty))
            //{
            //    result = rect;
            //}
            //WriteLog(" MergeAndAdd Result : " + result.X + " , " + result.Y + " , " + result.Width + " , " + result.Height + " ;", doPrint);

            //;
            //rects.AddFirst(result);

            return rects.AddFirst(result).Value;
        }


        private static string log = "";
        private static bool doPrint = true;
        private static void WriteLog(string line, bool print)
        {

            log += "\r\n" + line;
            if (print)
                Console.WriteLine(line);

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

        public void PrepareImageForOCR(string dir, string filename, bool inv = true, double threshold = 110.0, double maxValue = 255.0)
        {

            using (UMat uimg = CvInvoke.Imread(dir + filename, LoadImageType.Grayscale).GetOutputArray().GetUMat())
            {

                string file;
                Point point = new Point(1, 1);
                Size size = new Size(2, 2);

                dir = DirProject();
                //{
                //ProgressOfImage.Raise(this, uimg.);
                /*using (UMat duimg = new UMat())
                {

                    using (UMat uuimg = new UMat())
                    {*/
                CvInvoke.Threshold(uimg, uimg, threshold, maxValue, ThresholdType.BinaryInv);

                file = dir + "io1.tif";
                uimg.Save(file);
                ProgressOfImage.Raise(this, file, false);
                //point.X = 1;
                //point.Y = 1;
                //size.Width = 2;
                //size.Height = 2;

                /*using (Image<Gray, Byte> temp = new Image<Gray, Byte>((Bitmap)Bitmap.FromFile((Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\photoRoiSB" + ".bmp"))))
                {
                    System.IntPtr srcPtr = temp.Ptr;

                    CvInvoke.cvSmooth(srcPtr, srcPtr, Emgu.CV.CvEnum.SMOOTH_TYPE.CV_MEDIAN, 3, 0, 0, 0);
                    imageBox1.Image = temp;
                    this.imageBox1.Image.Save(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\photoRoiSmooth" + ".bmp");

                    CvInvoke.FastNlMeansDenoising(uuimg, uimg);
                    file = dir + "ip_2.tif";
                    uimg.Save(file);
                    ProgressOfImage.Raise(this, file, false);
                }*/
                //cvSmooth(cvOldFrameRight, cvOldFrameRight, CV_MEDIAN, 5);
                using (Mat morphKernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, size, point))
                {
                    CvInvoke.MorphologyEx(uimg, uimg, MorphOp.Erode, morphKernel, point, 1, BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);
                    file = dir + "io2.tif";
                    uimg.Save(file);
                    ProgressOfImage.Raise(this, file, false);
                    CvInvoke.MorphologyEx(uimg, uimg, MorphOp.Dilate, morphKernel, point, 1, BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);
                    file = dir + "io3.tif";
                    uimg.Save(file);
                    ProgressOfImage.Raise(this, file, false);
                    CvInvoke.MorphologyEx(uimg, uimg, MorphOp.Close, morphKernel, point, 1, BorderType.Constant, new MCvScalar(0, 0, 0));
                    file = dir + "io4.tif";
                    uimg.Save(file);
                    ProgressOfImage.Raise(this, file, false);
                }


                CvInvoke.Threshold(uimg, uimg, 1.0, 255.0, ThresholdType.BinaryInv);
                file = dir + "io5.tif";
                uimg.Save(file);
                ProgressOfImage.Raise(this, file, true);

            }/*
            Point point = new Point(4, 0);
            Size size = new Size(9, 1);
            string file;
            using (UMat uimg = CvInvoke.Imread(dir+filename, LoadImageType.Grayscale).GetInputOutputArray().GetUMat())
                {
                //file = dir + "io0.tif";
                //uimg.Save(file);
                //ProgressOfImage.Raise(this, file, false);
                using (UMat uuimg = new UMat())
                {
                    CvInvoke.Threshold(uimg, uuimg, threshold, maxValue, inv ? ThresholdType.BinaryInv : ThresholdType.Binary);

                    file = dir + "io1.tif";
                    uuimg.Save(file);
                    ProgressOfImage.Raise(this, file, false);
                    point.X = 1;
                    point.Y = 1;
                    size.Width = 2;
                    size.Height = 2;

                    using (Mat morphKernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, size, point))
                    {
                        CvInvoke.MorphologyEx(uuimg, uimg, MorphOp.Erode, morphKernel, point, 1, BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);
                        file = dir + "io2.tif";
                        uimg.Save(file);
                        ProgressOfImage.Raise(this, file, false);
                        CvInvoke.MorphologyEx(uimg, uuimg, MorphOp.Dilate, morphKernel, point, 1, BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);
                        file = dir + "io3.tif";
                        uuimg.Save(file);
                        ProgressOfImage.Raise(this, file, false);
                        CvInvoke.MorphologyEx(uuimg, uimg, MorphOp.Close, morphKernel, point, 1, BorderType.Constant, new MCvScalar(0, 0, 0));
                        file = dir + "ip4.tif";
                        uimg.Save(file);
                        ProgressOfImage.Raise(this, file, true);
                    }


                }
                
                

            }*/
        }

        //private bool boundsWaiting = false;
        
        public void PrepareImageForBounds(string dir, string filename)
        {

            using (UMat uimg = CvInvoke.Imread(dir + filename, LoadImageType.Grayscale).GetOutputArray().GetUMat())
            {
                //Convert the image to grayscale and filter out the noise
                //UMat uimg = new UMat();
                //CvInvoke.CvtColor(img, uimg, ColorConversion.Bgr2Gray);

                //use image pyr to remove noise

                string file;
                Point point = new Point(1,1);
                Size size = new Size(2,2);
                dir = DirProject();

                //{
                //ProgressOfImage.Raise(this, uimg.);
                /*using (UMat duimg = new UMat())
                {

                    using (UMat uuimg = new UMat())
                    {*/
                CvInvoke.Threshold(uimg, uimg, 110.0, 255.0, ThresholdType.BinaryInv);

                        file = dir + "ip_1.tif";
                        uimg.Save(file);
                        ProgressOfImage.Raise(this, file, false);
                        //point.X = 1;
                        //point.Y = 1;
                        //size.Width = 2;
                        //size.Height = 2;

                        /*using (Image<Gray, Byte> temp = new Image<Gray, Byte>((Bitmap)Bitmap.FromFile((Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\photoRoiSB" + ".bmp"))))
                        {
                            System.IntPtr srcPtr = temp.Ptr;

                            CvInvoke.cvSmooth(srcPtr, srcPtr, Emgu.CV.CvEnum.SMOOTH_TYPE.CV_MEDIAN, 3, 0, 0, 0);
                            imageBox1.Image = temp;
                            this.imageBox1.Image.Save(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\photoRoiSmooth" + ".bmp");

                            CvInvoke.FastNlMeansDenoising(uuimg, uimg);
                            file = dir + "ip_2.tif";
                            uimg.Save(file);
                            ProgressOfImage.Raise(this, file, false);
                        }*/
                        //cvSmooth(cvOldFrameRight, cvOldFrameRight, CV_MEDIAN, 5);
                        using (Mat morphKernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, size, point))
                        {
                            CvInvoke.MorphologyEx(uimg, uimg, MorphOp.Erode, morphKernel, point, 1, BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);
                            file = dir + "ip_2.tif";
                            uimg.Save(file);
                            ProgressOfImage.Raise(this, file, false);
                            CvInvoke.MorphologyEx(uimg, uimg, MorphOp.Dilate, morphKernel, point, 1, BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);
                            file = dir + "ip_3.tif";
                            uimg.Save(file);
                            ProgressOfImage.Raise(this, file, false);
                            CvInvoke.MorphologyEx(uimg, uimg, MorphOp.Close, morphKernel, point, 1, BorderType.Constant, new MCvScalar(0, 0, 0));
                            file = dir + "ip_4.tif";
                            uimg.Save(file);
                            ProgressOfImage.Raise(this, file, false);
                        }

                    
                        CvInvoke.Threshold(uimg, uimg, 1.0, 255.0, ThresholdType.BinaryInv);
                        file = dir + "ip_5.tif";
                        uimg.Save(file);
                        ProgressOfImage.Raise(this, file, true);
                        //CvInvoke.PyrDown(uuimg, duimg);

                    //}
                    /*point.X = 3;
                    size.Height = 4;
                    size.Width = 7;

                    
                        //CvInvoke.PyrUp(duimg, uimg);
                        //CvInvoke.PyrDown(uimg, duimg);

                        //file = dir + "ip_3.tif";
                        //uimg.Save(file);
                        //ProgressOfImage.Raise(this, file, false);
                    //}
                    //file = dir + "ip0.tif";
                    //duimg.Save(file);
                    //ProgressOfImage.Raise(this, file);
                    using (UMat oimg = new UMat())
                    {
                        CvInvoke.Blur(duimg, oimg, size, point, BorderType.Constant);


                        file = dir + "ip0.tif";
                        oimg.Save(file);
                        ProgressOfImage.Raise(this, file, false);

                        using (Mat morphKernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, size, point))
                        {
                            CvInvoke.MorphologyEx(oimg, duimg, MorphOp.Erode, morphKernel, point, 1, BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);
                            file = dir + "ip1.tif";
                            duimg.Save(file);
                            ProgressOfImage.Raise(this, file, false);
                            CvInvoke.MorphologyEx(duimg, oimg, MorphOp.Dilate, morphKernel, point, 1, BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);

                            CvInvoke.PyrUp(oimg, uimg);
                            file = dir + "ip2.tif";
                            uimg.Save(file);
                            ProgressOfImage.Raise(this, file, false);


                            CvInvoke.Threshold(uimg, duimg, 1.0, 255.0, ThresholdType.Binary | ThresholdType.Otsu);
                            file = dir + "ip3.tif";
                            duimg.Save(file);
                            ProgressOfImage.Raise(this, file, true);

                            //point.Y = 0;
                            //size.Height = 1;

                            //CvInvoke.MorphologyEx(duimg, uimg, MorphOp.Close, morphKernel, point, 1, BorderType.Constant, new MCvScalar(0, 0, 0));
                            //file = dir + "ip4.tif";
                            //uimg.Save(file);
                            //ProgressOfImage.Raise(this, file, true);
                        }

                    }*/
                //}



            }
            

        }
        

        public void RecognizeBounds(string dir, string filename, int spaceX = 17, int spaceY = 1, float maxPercentWidth = 0.041f, float maxPercentHeight = 0.03f, float minPercentWidth = 0.0007f, float minPercentHeight = 0.0007f) // maxWidth : img.Width * 85%    minHeight : img.Height * 1.21%
        {
            //int largest_contour_index = 0;
            //double largest_area = 0;
            //VectorOfPoint largestContour;
            LinkedList<Rectangle> rects = new LinkedList<Rectangle>();

            

            int maxWidth, maxHeight, minWidth, minHeight;

            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                using (Mat hierachy = new Mat())
                using (Mat img = new Mat(dir + filename, LoadImageType.Grayscale))
                {
                    //IOutputArray hirarchy;
                    maxWidth = (int)(maxPercentWidth * img.Width);
                    maxHeight = (int)(maxPercentHeight * img.Height);
                    minWidth = (int)(minPercentWidth * img.Width);
                    minHeight = (int)(minPercentHeight * img.Height);
                    CvInvoke.FindContours(img, contours, hierachy, RetrType.List, ChainApproxMethod.ChainApproxNone);
                }
                //rects = new LinkedList<Rectangle>();

                //CvInvoke.Imshow(win1, img); //Show the image

                //CvInvoke.FindContours(cannyEdges, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                //Rectangle zero = new Rectangle(0, 0, 0, 0);
                int count = contours.Size;
                Rectangle r = new Rectangle(0, 0, 0, 0);
                for (int i = 0; i < count; i++)
                {
                    using (VectorOfPoint contour = contours[i])
                    //using (VectorOfPoint approxContour = new VectorOfPoint())
                    {
                        //CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                        Rectangle block = CvInvoke.BoundingRectangle(contour);
                        if (CvInvoke.ContourArea(contour, false) >= 2.0 && (block.Width >= minWidth && block.Height >= minHeight) )// && !block.Equals(Rectangle.Empty) && !block.Equals(zero)) //only consider contours with area greater than 250
                        {

                            Rectangle rect = CvInvoke.BoundingRectangle(contour);
                            rect.X -= spaceX;
                            rect.Y -= spaceY;
                            rect.Width += 2 * spaceX;
                            rect.Height += 2 * spaceY;
                            if (rect.X > 0 && rect.Y > 0
                            && rect.Width <= maxWidth && rect.Height <= maxHeight)
                            {
                                
                                Rectangle n = MergeAndAddBlock(rects, rect);
                                WriteLog("Rectangle : " + n.X + " , " + n.Y + " , " + n.Width + " , " + n.Height + " ;", doPrint);

                                //ProgressOfBlocks.Raise(this,  n, false);

                                //img.Draw(MergeAndAddBlock(rects, rect), new Bgr(0, 255, 0), 6);
                                //img.Save(DirProject() + name + "_1" + _exp);
                                //CvInvoke.Imshow(win1, img); //Show the image
                            }
                            //}
                        }
                    }
                }
            }
            //rects.Sort();
            int itr = 0;//, l = rects.Count;


            LinkedListNode<Rectangle> node = rects.First;
            //result = new Rectangle[l];
            //WriteLog(" # Merge Result List start #", doPrint);
            while (node != null)
            {

                Rectangle block = node.Value;
                if (block.Height > minHeight && block.Width > minWidth && block.Width*block.Height > 1000)
                {
                    //img.Draw(block, new Bgr(0, 0, 255), 2);
                    //result[itr] = block;
                    node = node.Next;
                    ProgressOfBlocks.Raise(this, block, true);
                    //Thread.Sleep(1000);
                    WriteLog("Rectangle [ " + itr + " ] : " + block.X + " , " + block.Y + " , " + block.Width + " , " + block.Height + " ;", doPrint);
                    itr++;
                }
                else
                {
                    var tmp = node;
                    node = node.Next;
                    rects.Remove(tmp);
                }

            }
            //int ik = 1+1;
            ProgressOfBlocks.Raise(this, Rectangle.Empty, false);
            WriteLog(" # Merge Result List end #", doPrint);

            // temp save
            //img.Save(DirProject() + "7_1.tif");



            //return rects;
        }
    }
}
