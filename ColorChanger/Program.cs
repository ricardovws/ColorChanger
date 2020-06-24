using System;
using System.Drawing;


namespace ColorChanger
{
    class Program
    {
        public static object CoreCompat { get; private set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Hey there! :)");
            Console.WriteLine("Please, insert the path of the image that you would like to change the colors:");
            Console.WriteLine();
            Console.WriteLine();
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"e.g. -> path: C:\Users\Joaquim\Downloads");
            Console.ForegroundColor = aux;
            Console.WriteLine();
            Console.WriteLine();
            //Receive the path
            Console.Write("path: ");
            var path = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Alright! And now...What kind of color changing do you prefer?");
            Console.WriteLine();
            Console.WriteLine("Type the number of your choice.");
            Console.WriteLine();
            Console.WriteLine("#1 - Grayscale");
            Console.WriteLine("#2 - Red");
            Console.WriteLine("#3 - Green");
            Console.WriteLine("#4 - Blue");
            Console.WriteLine("#5 - Negative");
            Console.WriteLine();
            var option = Console.ReadLine();


            //Read the image
            Bitmap bmp = new Bitmap(path);

            //Get the imagem dimensions
            int witdh = bmp.Width;
            int height = bmp.Height;

            //Pixel color
            Color p;

            //Grayscale
            for (int y=0; y < height; y++)
            {
                for(int x = 0; x < witdh; x++)
                {
                    //get pixel value
                    p = bmp.GetPixel(x, y);

                    //extract each pixel component ARGB
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //find the average among them
                    int avg = (r + b + b) / 3;

                    //set a new pixel value for them:
                    bmp.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));

                }
            }

            //write a copy of the image:
            bmp.Save(@"C:\Users\Ricardo\Documents\ColorChanger\ColorChanger\teste.png");

            Console.WriteLine("That's ok!");
            //Console.WriteLine(path);
            Console.ReadLine();
        }
    }
}
