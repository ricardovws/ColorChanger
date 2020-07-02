using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ColorChanger
{
    class PictureParameters
    {
        public Bitmap Picture { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }
        public int ARGB_a { get; set; }
        public int ARGB_r { get; set; }
        public int ARGB_g { get; set; }
        public int ARGB_b { get; set; }

        public PictureParameters(Bitmap picture, int positionX, int positionY, int aRGB_a, int aRGB_r, int aRGB_g, int aRGB_b)
        {
            Picture = picture;
            this.positionX = positionX;
            this.positionY = positionY;
            ARGB_a = aRGB_a;
            ARGB_r = aRGB_r;
            ARGB_g = aRGB_g;
            ARGB_b = aRGB_b;
        }
    }
}
