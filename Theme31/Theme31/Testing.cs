using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theme31
{
    internal class Testing
    {
        public static double CalculatePSNR(Image inputImage, Image outputImage)
        {
            Bitmap input = new Bitmap(inputImage);
            Bitmap output = new Bitmap(outputImage);
            double mse = 0;
            double psnr = 0;
            int width = input.Width;
            int height = input.Height;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color c1 = input.GetPixel(x, y);
                    Color c2 = output.GetPixel(x, y);
                    int rDiff = c1.R - c2.R;
                    int gDiff = c1.G - c2.G;
                    int bDiff = c1.B - c2.B;
                    mse += (rDiff * rDiff + gDiff * gDiff + bDiff * bDiff);
                }
            }
            mse /= (width * height);
            if (mse > 0)
            {
                psnr = 20 * Math.Log10(255 / Math.Sqrt(mse));
            }
            return psnr;
        }

        public static double CalculateSSIM(Image inputImage, Image outputImage)
        {
            Bitmap input = new Bitmap(inputImage);
            Bitmap output = new Bitmap(outputImage);
            const double K1 = 0.01;
            const double K2 = 0.03;
            double avg1 = AverageBrightness(input);
            double avg2 = AverageBrightness(output);
            double var1 = Variance(input, avg1);
            double var2 = Variance(output, avg2);
            double covar = Covariance(input, output, avg1, avg2);
            double numerator = (2 * avg1 * avg2 + K1) * (2 * covar + K2);
            double denominator = (avg1 * avg1 + avg2 * avg2 + K1) * (var1 + var2 + K2);
            return numerator / denominator;
        }

        private static double AverageBrightness(Bitmap bmp)
        {
            double sum = 0;
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    sum += bmp.GetPixel(x, y).GetBrightness();
                }
            }
            return sum / (bmp.Width * bmp.Height);
        }

        private static double Variance(Bitmap bmp, double avg)
        {
            double sum = 0;
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++) {
                    double brightness = bmp.GetPixel(x, y).GetBrightness();
                    sum += (brightness - avg) * (brightness - avg);
                }
            }
            return sum / (bmp.Width * bmp.Height);
        }

        private static double Covariance(Bitmap input, Bitmap output, double avg1, double avg2)
        {
            double sum = 0;
            for (int y = 0; y < input.Height; y++)
            {
                for (int x = 0; x < input.Width; x++)
                {
                    double brightness1 = input.GetPixel(x, y).GetBrightness();
                    double brightness2 = output.GetPixel(x, y).GetBrightness();
                    sum += (brightness1 - avg1) * (brightness2 - avg2);
                }
            }
            return sum / (input.Width * input.Height);
        }
    }
}