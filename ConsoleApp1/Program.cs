using System;
using System.IO;
using OpenCvSharp;
using Husty.OpenCvSharp;

namespace ConsoleApp1
{
    class Program
    {

        const string imgDir = @"C:\Users\melo3611\Downloads\mask-20211214T081358Z-001\mask";
        const string paramFile = @"C:\Users\melo3611\Downloads\1208_calib\1208_calib\intrinsic.json";

        static void Main(string[] args)
        {
            var param = IntrinsicCameraParameters.Load(paramFile);
            foreach (var file in Directory.GetFiles(imgDir, "*.png", SearchOption.AllDirectories))
            {
                var img = Cv2.ImRead(file);
                img = img.Undistort(param.CameraMatrix, param.DistortionCoeffs);
                var name = Path.GetFileName(file);
                Cv2.ImWrite(name, img);
                Console.WriteLine($"saved : {name}");
            }
            Console.WriteLine("completed.");

        }
    }
}
