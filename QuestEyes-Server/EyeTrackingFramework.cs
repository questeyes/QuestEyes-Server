using System;
using System.Drawing;
using System.IO;
using OpenCvSharp;

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

        public static Tuple<int, int, int, int> detectEyes(byte[] data)
        {
            //declare the positional variables for sending later
            int right_X = 0, right_Y = 0;
            int left_X = 0, left_Y = 0;

            //turn the byte stream into a bitmap image
            MemoryStream stream = new(data);
            Bitmap bitmap = new(stream);

            //create the main material
            var main = new Mat();
            main = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap);

            //create the left and right material
            var left = new Mat();
            var right = new Mat();

            //turn the main image grey
            Cv2.CvtColor(main, main, ColorConversionCodes.BGR2GRAY);

            //apply modifiers
            try
            {
                Cv2.EqualizeHist(main, main);
                //Cv2.Erode(main, main, 1);
                Cv2.MedianBlur(main, main, DiagnosticsPanel.Blur);
            }
            catch { }

            //detect the eyes in main
            Rect[] eyes = eyeClassifier.DetectMultiScale(main, 1.3, 2, HaarDetectionTypes.DoCannyPruning, new OpenCvSharp.Size(30, 50));
   
            //find each eye
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
                Cv2.Rectangle(main, eye, new Scalar(255, 0, 255), thickness: 2);
                if (center.X < 365) //left side
                {
                    //create left eye material
                    left = new Mat(main, eye);

                    //apply modifiers
                    Cv2.Threshold(left, left, 100, 255, ThresholdTypes.BinaryInv);

                    //determine the iris position
                    /**double largest_area = 0;
                    int largest_contour_index = 0;

                    OpenCvSharp.Point[][] leftContours;
                    OpenCvSharp.HierarchyIndex[] leftHierarchy;

                    Cv2.FindContours(left, out leftContours, out leftHierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple);

                    for (int i = 0; i < leftContours.Length; i++)
                    {
                        double a = Cv2.ContourArea(leftContours[i], false);
                        if (a > largest_area)
                        {
                            largest_area = a;
                            largest_contour_index = i;
                        }
                    }

                    try
                    {
                        OpenCvSharp.Rect bounding_rect = Cv2.BoundingRect(leftContours[largest_contour_index]);
                        right = right[bounding_rect];
                    }
                    catch { }

                    double cannyThreshold = DiagnosticsPanel.cannyThreshold;
                    double circleAccumulatorThreshold = DiagnosticsPanel.circleAccThreshold;
                    int minRadius = DiagnosticsPanel.minRad;
                    int maxRadius = DiagnosticsPanel.maxRad;
                    CircleSegment[] circles = Cv2.HoughCircles(left, HoughModes.Gradient, 2.0, 20.0, cannyThreshold, circleAccumulatorThreshold, minRadius, maxRadius);

                    foreach (CircleSegment circle in circles)
                        Cv2.Circle(left, (OpenCvSharp.Point)circle.Center, (int)circle.Radius, new Scalar(128, 0, 128), 2);**/

                    if (DiagnosticsPanel.DiagnosticsOpen)
                    {
                        //convert to bitmap and send to diagnostics panel
                        Bitmap left_bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(left);
                        SupportFunctions.DiagnosticsUpdateLeft(left_bitmap);
                    }
                }
                else //right side
                {
                    //create right eye material
                    right = new Mat(main, eye);

                    //apply modifiers
                    Cv2.Threshold(right, right, 100, 255, ThresholdTypes.BinaryInv);

                    //determine the iris position
                    /**double largest_area = 0;
                    int largest_contour_index = 0;
                    
                    OpenCvSharp.Point[][] rightContours;
                    OpenCvSharp.HierarchyIndex[] rightHierarchy;

                    Cv2.FindContours(right, out rightContours, out rightHierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple);

                    for (int i = 0; i < rightContours.Length; i++)
                    {
                        double a = Cv2.ContourArea(rightContours[i], false);
                        if (a > largest_area)
                        {
                            largest_area = a;
                            largest_contour_index = i;
                        }
                    }

                    try
                    {
                        OpenCvSharp.Rect bounding_rect = Cv2.BoundingRect(rightContours[largest_contour_index]);
                        right = right[bounding_rect];
                    }
                    catch { }

                    double cannyThreshold = DiagnosticsPanel.cannyThreshold;
                    double circleAccumulatorThreshold = DiagnosticsPanel.circleAccThreshold;
                    int minRadius = DiagnosticsPanel.minRad;
                    int maxRadius = DiagnosticsPanel.maxRad;
                    CircleSegment[] circles = Cv2.HoughCircles(right, HoughModes.Gradient, 2.0, 20.0, cannyThreshold, circleAccumulatorThreshold, minRadius, maxRadius);

                    foreach (CircleSegment circle in circles)
                        Cv2.Circle(right, (OpenCvSharp.Point)circle.Center, (int)circle.Radius, new Scalar(128, 0, 128), 2);**/


                    if (DiagnosticsPanel.DiagnosticsOpen)
                    {
                        //convert to bitmap and send to diagnostics panel
                        Bitmap right_bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(right);
                        SupportFunctions.DiagnosticsUpdateRight(right_bitmap);
                    }
                }
            }

            if (DiagnosticsPanel.DiagnosticsOpen)
            {
                //convert to bitmap and send to diagnostics panel
                Bitmap result_bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(main);
                SupportFunctions.DiagnosticsUpdateTrue(result_bitmap);
            }

            //release and dispose of all the materials we don't need anymore
            main.Release();
            main.Dispose();
            left.Release();
            left.Dispose();
            right.Release();
            right.Dispose();

            //return the positions
            return Tuple.Create(right_X, right_Y, left_X, left_Y);
        }
    }
}
