using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Numerics;
using System.Runtime.InteropServices;
using OpenCvSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestEyes_Server
{
    class EyeTrackingFramework
    {
        public static CascadeClassifier eyeClassifier;

        public static void loadEyeClassifierData()
        {
            if (!File.Exists(Main.storageFolder + "\\haarcascade_eye.xml"))
            {
                File.WriteAllText(Main.storageFolder + "\\haarcascade_eye.xml", Properties.Resources.haarcascade_eye);
            }
            eyeClassifier = new CascadeClassifier(Main.storageFolder + "\\haarcascade_eye.xml");
        }

        public static void detectEyes(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            Bitmap bitmap = new Bitmap(stream);

            var source = new Mat();
            source = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap);

            var modified = new Mat();

            var left = new Mat();
            var leftmodified = new Mat();
            var right = new Mat();
            var rightmodified = new Mat();

            //turn the image grey
            Cv2.CvtColor(source, modified, ColorConversionCodes.BGR2GRAY);
            source.Release();
            source.Dispose();

            //erode and create the blur
            //Cv2.Erode(modified, modified, 1);
            //Cv2.MedianBlur(modified, modified, 25);
            //Cv2.Threshold(modified, modified, 100, 255, ThresholdTypes.BinaryInv);

            //detect the eyes
            Rect[] eyes = eyeClassifier.DetectMultiScale(modified, 1.3, 2, HaarDetectionTypes.ScaleImage, new OpenCvSharp.Size(30, 50));
   
            //find each eyes coords
            foreach (Rect eye in eyes)
            {
                var center = new OpenCvSharp.Point
                {
                    X = (int)(eye.X + eye.Width * 0.5),
                    Y = (int)(eye.Y + eye.Height * 0.5)
                };
                var axes = new OpenCvSharp.Size
                {
                    Width = (int)(eye.Width * 0.5),
                    Height = (int)(eye.Height * 0.5)
                };
                Cv2.Rectangle(modified, eye, new Scalar(255, 0, 255), thickness: 2);
                if (center.X < 365) //Left side
                {
                    left = new Mat(modified, eye);
                    Cv2.Threshold(left, leftmodified, 100, 255, ThresholdTypes.Binary);
                    left.Release();
                    left.Dispose();
                    if (Diagnostics.diagnosticsOpen == true)
                    {
                        Bitmap left_bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(leftmodified);
                        SupportFunctions.DiagnosticsUpdateLeft(left_bitmap);
                    }
                }
                else //Right side
                {
                    right = new Mat(modified, eye);
                    Cv2.Threshold(right, rightmodified, 100, 255, ThresholdTypes.Binary);
                    right.Release();
                    right.Dispose();
                    if (Diagnostics.diagnosticsOpen == true)
                    {
                        Bitmap right_bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(rightmodified);
                        SupportFunctions.DiagnosticsUpdateRight(right_bitmap);
                    }
                }
            }

            //determine the irises












            /**MSER mser = MSER.Create();

            OpenCvSharp.Point[][] contours;
            Rect[] bboxes;

            mser.DetectRegions(modified, out contours, out bboxes);

            

            for (int i = 0; i < contours.Length; i++)
            {
                Cv2.Rectangle(modified, bboxes[i], new Scalar(255, 0, 255));
            }


            /**foreach (OpenCvSharp.Point[] pts in contours)
            {
                Scalar color = Scalar.RandomColor();
                foreach (OpenCvSharp.Point p in pts)
                {
                    modified.Circle(p, 1, color);
                }
            }**/




            if (Diagnostics.diagnosticsOpen == true)
            {
                Bitmap result_bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(modified);
                modified.Release();
                modified.Dispose();
                SupportFunctions.DiagnosticsUpdateTrue(result_bitmap);
            }

            /**OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierachy;
            Cv2.FindContours(gray, out contours, out hierachy, RetrievalModes.List, ContourApproximationModes.ApproxSimple);

            for (int i = 0; i < contours.Length; i++)
            {
                // Fitting function must have at least five points, less than or without fitting
                if (contours[i].Length < 5) continue;
                // Elliptic fitting
                var rrt = Cv2.FitEllipse(contours[i]);

                // ROI recovery
                rrt.Center.X += eye.X;
                rrt.Center.Y += eye.Y;

                // Draw an ellipse
                Cv2.Ellipse(result, rrt, new Scalar(0, 0, 255), 2, LineTypes.AntiAlias);
                // Draw the center of a circle
                Cv2.Circle(result, (int)(rrt.Center.X), (int)(rrt.Center.Y), 4, new Scalar(255, 0, 0), -1, LineTypes.Link8, 0);
            }**/
        }
    }
}
