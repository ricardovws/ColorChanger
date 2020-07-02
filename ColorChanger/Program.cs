using System;
using System.Drawing;
using System.Linq;

namespace ColorChanger
{
    class Program
    {
        public static object CoreCompat { get; private set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Hey there! :)");
            Console.WriteLine();
            Console.WriteLine("Please, insert the path of the image that you would like to change the colors:");
            Console.WriteLine();
            Console.WriteLine();
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"e.g. -> path: C:\Users\Joaquim\Downloads\YOUR_PICTURE.JPEG");
            Console.ForegroundColor = aux;
            Console.WriteLine();
            Console.WriteLine();
            //Receive the path
            Console.Write("path: ");
            var path = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Alright! And now...What kind of color changing do you prefer?");
            Console.WriteLine();
            Console.WriteLine("Type the number of your choice:");
            Console.WriteLine();
            Console.WriteLine("#1 - Grayscale");
            Console.WriteLine("#2 - Red");
            Console.WriteLine("#3 - Green");
            Console.WriteLine("#4 - Blue");
            Console.WriteLine("#5 - Negative");
            Console.WriteLine();
            var option = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("The file will be exported to the same file's original path.");
            Console.WriteLine();
            Console.WriteLine("Almost there! Please, just write the file's name: ");
            Console.Write("File's name: ");
            var fileName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Just wait, please...");

            //Read the image
            Bitmap bmp = new Bitmap(path);

            //Get the imagem dimensions
            int witdh = bmp.Width;
            int height = bmp.Height;

            //Pixel color
            Color p;

            //Set status message after export file
            Messages messages = new Messages();
            string finalMessage = messages.successfulMessage;


            //starting pixel setting...
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

                    PictureParameters pic = new PictureParameters(bmp, x, y, a, r, g, b);

                    //#1 - Grayscale
                    if (option == "1")
                    {
                        SetGrayscale(pic);
                    }
                    //#2 - Red
                    else if (option == "2")
                    {
                        SetRedscale(pic);
                    }
                    //#3 - Green
                    else if (option == "3")
                    {
                        SetGreenscale(pic);
                    }
                    //#4 - Blue
                    else if (option == "4")
                    {
                        SetBluescale(pic);
                    }
                    //#5 - Negative
                    else if (option == "5")
                    {
                        SetNegative(pic);
                    }
                    else
                    {
                        finalMessage = messages.errorMessage;
                    }

                }
            }

            //Export file
            if (finalMessage == messages.successfulMessage)
            {
                ExportFile(bmp, path, fileName);
            }
                                   
            //Return status and finish task!
            Console.WriteLine(finalMessage);
            Console.ReadLine();
        }

      

        private static void SetGrayscale(PictureParameters picture)
        {
            //find the average of them(a, r, g, b)
            int avg = (picture.ARGB_r + picture.ARGB_g + picture.ARGB_b) / 3;

            //set a new pixel value for them:
            picture.Picture.SetPixel(picture.positionX, picture.positionY, Color.FromArgb(picture.ARGB_a, avg, avg, avg));
        }

        private static void SetRedscale(PictureParameters picture)
        {
            //set a new pixel value for them:
            picture.Picture.SetPixel(picture.positionX, picture.positionY, Color.FromArgb(picture.ARGB_a, picture.ARGB_r, 0, 0));
        }

        private static void SetGreenscale(PictureParameters picture)
        {
            //set a new pixel value for them:
            picture.Picture.SetPixel(picture.positionX, picture.positionY, Color.FromArgb(picture.ARGB_a, 0, picture.ARGB_g, 0));
        }

        private static void SetBluescale(PictureParameters picture)
        {
            //set a new pixel value for them:
            picture.Picture.SetPixel(picture.positionX, picture.positionY, Color.FromArgb(picture.ARGB_a, 0, 0, picture.ARGB_b));
        }

        private static void SetNegative(PictureParameters picture)
        {

            picture.ARGB_r = 255 - picture.ARGB_r;
            picture.ARGB_g = 255 - picture.ARGB_g;
            picture.ARGB_b = 255 - picture.ARGB_b;

            //set a new pixel value for them:
            picture.Picture.SetPixel(picture.positionX, picture.positionY, Color.FromArgb(picture.ARGB_a, picture.ARGB_r, picture.ARGB_g, picture.ARGB_b));
        }

        private static void ExportFile(Bitmap bmp, string path, string fileName)
        {
            //extract file extension:
            var pathFileInfo = path.Split('.');
            var fileExtension = pathFileInfo[1];

            //extract file path:    
            //gets first part of the array
            var pathFile = pathFileInfo[0];
            //splits again
            var newPathFile = pathFile.Split("\\");
            //take all array except the last part
            var newPath = newPathFile.SkipLast(1).ToArray();

            //add "\" for each element:
            path = null;
            foreach (var element in newPath)
            {
                var e = element + "\\";
                path += e;
            }

            //write a copy of the image:

            path = path + fileName + "." + fileExtension;

            bmp.Save(path);

        }

    }
}
