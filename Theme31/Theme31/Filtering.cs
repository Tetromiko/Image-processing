using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Theme31
{
    internal class Filtering
    {
        static float[,] blur = 
        {   
            { 1f/25, 1f/25, 1f/25, 1f/25, 1f/25 },
            { 1f/25, 1f/25, 1f/25, 1f/25, 1f/25 },
            { 1f/25, 1f/25, 1f/25, 1f/25, 1f/25 },
            { 1f/25, 1f/25, 1f/25, 1f/25, 1f/25 },
            { 1f/25, 1f/25, 1f/25, 1f/25, 1f/25 },  
        };
        static float[,] sharpness =
        {
            {  0,  0, -1,  0,  0 },
            {  0,  1, -2, -1,  0 },
            { -1, -2, 16, -2, -1 },
            {  0, -1, -2, -1,  0 },
            {  0,  0, -1,  0,  0 },
        };
        static float[,] repulsion =
        {
            { -1, -1, -1 },
            { -1,  9, -1 },
            { -1, -1, -1 },
        };
        public static Image Blur(Image inputImage)
        {
            Bitmap input = new Bitmap(inputImage);
            Bitmap output = new Bitmap(inputImage);
            for (int x = 0; x < input.Width; x++)
            {
                for (int y = 0; y < input.Height; y++)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;
                    for (int xi = 0; xi < blur.GetLength(0); xi++)
                    {
                        for (int yi = 0; yi < blur.GetLength(1); yi++)
                        {
                            int i = x - blur.GetLength(0) / 2 + xi;
                            int j = y - blur.GetLength(1) / 2 + yi;
                            if (i >= 0 && i < input.Width && j >= 0 && j < input.Height)
                            {
                                Color pixel = input.GetPixel(i, j);
                                red += blur[xi, yi] * pixel.R;
                                green += blur[xi, yi] * pixel.G;
                                blue += blur[xi, yi] * pixel.B;
                            }
                        }
                    }
                    red = Math.Min(Math.Max(red, 0), 255);
                    green = Math.Min(Math.Max(green, 0), 255);
                    blue = Math.Min(Math.Max(blue, 0), 255);
                    output.SetPixel(x, y, Color.FromArgb((int)red, (int)green, (int)blue));
                }
            }
            return output;
        }
        public static Image Repulsion(Image inputImage)
        {
            Bitmap input = new Bitmap(inputImage);
            Bitmap output = new Bitmap(inputImage);
            for (int x = 1; x < input.Width - 1; x++)
            {
                for (int y = 1; y < input.Height - 1; y++)
                {
                    float sumR = 0;
                    float sumG = 0;
                    float sumB = 0;
                    for (int xi = -1; xi < 2; xi++)
                    {
                        for (int yi = -1; yi < 2; yi++)
                        {
                            sumR += input.GetPixel(x + xi, y + yi).R * repulsion[1 + xi, 1 + yi];
                            sumG += input.GetPixel(x + xi, y + yi).G * repulsion[1 + xi, 1 + yi];
                            sumB += input.GetPixel(x + xi, y + yi).B * repulsion[1 + xi, 1 + yi];
                        }
                    }
                    sumR = Math.Max(0, Math.Min(sumR, 255));
                    sumG = Math.Max(0, Math.Min(sumG, 255));
                    sumB = Math.Max(0, Math.Min(sumB, 255));
                    output.SetPixel(x, y, Color.FromArgb((int)sumR, (int)sumG, (int)sumB));
                }
            }
            return output;
        }
        public static Image Sharpen(Image inputImage)
        {
            Bitmap input = new Bitmap(inputImage);
            Bitmap output = new Bitmap(inputImage);
            for (int x = 2; x < input.Width - 2; x++)
            {
                for (int y = 2; y < input.Height - 2; y++)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;
                    for (int xi = 0; xi < sharpness.GetLength(0); xi++)
                    {
                        for (int yi = 0; yi < sharpness.GetLength(1); yi++)
                        {
                            int i = x - sharpness.GetLength(0) / 2 + xi;
                            int j = y - sharpness.GetLength(1) / 2 + xi;
                            if (i >= 0 && i < input.Width && j >= 0 && j < input.Height)
                            {
                                Color pixel = input.GetPixel(i, j);
                                red += sharpness[xi, yi] * pixel.R;
                                green += sharpness[xi, yi] * pixel.G;
                                blue += sharpness[xi, yi] * pixel.B;
                            }
                        }
                    }
                    red = Math.Min(Math.Max(red, 0), 255);
                    green = Math.Min(Math.Max(green, 0), 255);
                    blue = Math.Min(Math.Max(blue, 0), 255);
                    output.SetPixel(x, y, Color.FromArgb((int)red, (int)green, (int)blue));
                }
            }
            return output;
        }
        public static Image Mediane(Image inputImage)
        {
            Bitmap input = new Bitmap(inputImage);
            Bitmap output = new Bitmap(inputImage);
            for (int x = 0; x < input.Width; x++)
            {
                for (int y = 0; y < input.Height; y++)
                {
                    List<float> sumR = new List<float>() { };
                    List<float> sumG = new List<float>() { };
                    List<float> sumB = new List<float>() { };
                    for (int xi = 0; xi < 5; xi++)
                    {
                        for (int yi = 0; yi < 5; yi++)
                        {
                            int i = x - 5 / 2 + xi;
                            int j = y - 5 / 2 + yi;
                            if (i >= 0 && i < input.Width && j >= 0 && j < input.Height)
                            {
                                sumR.Add(input.GetPixel(i, j).R);
                                sumG.Add(input.GetPixel(i, j).G);
                                sumB.Add(input.GetPixel(i, j).B);
                            }
                        }
                    }
                    sumR.Sort();
                    sumG.Sort();
                    sumB.Sort();
                    output.SetPixel(x, y, Color.FromArgb((int)sumR[(int)MathF.Floor(sumR.Count / 2)], (int)sumG[(int)MathF.Floor(sumG.Count / 2)], (int)sumB[(int)MathF.Floor(sumB.Count / 2)])); ;
                }
            }
            return output;
        }
        public static Image GaussianDifference(Image inputImage)
        {
            return Difference(GaussianBlur(new Bitmap(inputImage), 3), GaussianBlur(new Bitmap(inputImage), 11));
        }
        public static Image GaussianBlur(Image inputImage,int size)
        {
            Bitmap input = new Bitmap(inputImage);
            Bitmap output = new Bitmap(inputImage);
            double[,] gausianFilter = CreateGaussianFilter(size, size*size);
            for (int x = 0; x < input.Width; x++)
            {
                for (int y = 0; y < input.Height; y++)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;
                    for (int xi = 0; xi < gausianFilter.GetLength(0); xi++)
                    {
                        for (int yi = 0;yi < gausianFilter.GetLength(1); yi++)
                        {
                            int i = x - gausianFilter.GetLength(0) / 2 + xi;
                            int j = y - gausianFilter.GetLength(1) / 2 + yi;
                            if (i >= 0 && i < input.Width && j >= 0 && j < input.Height)
                            {
                                Color pixel = input.GetPixel(i, j);
                                red += gausianFilter[xi, yi] * pixel.R;
                                green += gausianFilter[xi, yi] * pixel.G;
                                blue += gausianFilter[xi, yi] * pixel.B;
                            }
                        }
                    }
                    red = Math.Min(Math.Max(red, 0), 255);
                    green = Math.Min(Math.Max(green, 0), 255);
                    blue = Math.Min(Math.Max(blue, 0), 255);
                    output.SetPixel(x, y, Color.FromArgb((int)red, (int)green, (int)blue));
                }
            }
            return output;
        }
        public static Image Difference(Image inputImage1, Image inputImage2)
        {
            Bitmap input1 = new Bitmap(inputImage1);
            Bitmap input2 = new Bitmap(inputImage2);
            Bitmap output = new Bitmap(inputImage1);
            for (int x = 0; x < inputImage1.Width; x++)
            {
                for (int y = 0; y < inputImage1.Height; y++)
                {
                    float pixel1 = input1.GetPixel(x, y).GetBrightness() * 255;
                    float pixel2 = input2.GetPixel(x, y).GetBrightness() * 255;
                    float dif = pixel1 - pixel2;
                    dif = Math.Max(0, Math.Min(dif, 255));

                    output.SetPixel(x, y, Color.FromArgb((int)dif, (int)dif, (int)dif));
                }
            }
            return AddBrightness(output);
        }
        public static Image AddBrightness(Image inputImage)
        {
            Bitmap input = new Bitmap(inputImage);
            Bitmap output = new Bitmap(inputImage);
            for (int x = 0; x < inputImage.Width; x++)
            {
                for (int y = 0; y < inputImage.Height; y++)
                {
                    float pixel = input.GetPixel(x, y).GetBrightness() * 255;
                    float dif = MathF.Max(0, MathF.Min(MathF.Pow(pixel,2)/3, 255));
                    output.SetPixel(x, y, Color.FromArgb((int)dif, (int)dif, (int)dif));
                }
            }
            return output;
        }
        static double[,] CreateGaussianFilter(int size, double sigma)
        {
            double[,] filter = new double[size, size];
            double sum = 0.0;
            int radius = size / 2;

            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    double distance = (i * i + j * j) / (2 * sigma * sigma);
                    filter[i + radius, j + radius] = Math.Exp(-distance);
                    sum += filter[i + radius, j + radius];
                }
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    filter[i, j] /= sum;
                }
            }
            return filter;
        }
    }
}
