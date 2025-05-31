using Photoredactor.Interfaces;
using Photoredactor.Models;
using System.Drawing;

namespace Photoredactor.Plugins
{
    public class Blur : IPlugin
    {
        public int Radius { get; private set; }

        public Blur(int radius)
        {
            Radius = radius;
        }

        public string Name => "Blur";

        public void Apply(ImageData image)
        {
            if (image.Bitmap == null) return;

            Bitmap blurred = ApplyBoxBlur(image.Bitmap, Radius);
            image.Bitmap.Dispose();
            image.Bitmap = blurred;

            image.LogEffect("Applied real blur with radius " + Radius + "px");
        }

        private Bitmap ApplyBoxBlur(Bitmap src, int radius)
        {
            Bitmap dest = new Bitmap(src.Width, src.Height);
            int w = src.Width;
            int h = src.Height;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    int r = 0, g = 0, b = 0;
                    int count = 0;

                    for (int dy = -radius; dy <= radius; dy++)
                    {
                        for (int dx = -radius; dx <= radius; dx++)
                        {
                            int nx = x + dx;
                            int ny = y + dy;

                            if (nx >= 0 && nx < w && ny >= 0 && ny < h)
                            {
                                Color pixel = src.GetPixel(nx, ny);
                                r += pixel.R;
                                g += pixel.G;
                                b += pixel.B;
                                count++;
                            }
                        }
                    }

                    r /= count;
                    g /= count;
                    b /= count;

                    dest.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return dest;
        }
    }
}
