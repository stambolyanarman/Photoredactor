using Photoredactor.Interfaces;
using Photoredactor.Models;
using System.Drawing;

namespace Photoredactor.Plugins
{
    public class Grayscale : IPlugin
    {
        public string Name => "Grayscale";

        public void Apply(ImageData image)
        {
            for (int y = 0; y < image.Bitmap.Height; y++)
            {
                for (int x = 0; x < image.Bitmap.Width; x++)
                {
                    Color original = image.Bitmap.GetPixel(x, y);
                    int gray = (int)(original.R * 0.3 + original.G * 0.59 + original.B * 0.11);
                    Color newColor = Color.FromArgb(gray, gray, gray);
                    image.Bitmap.SetPixel(x, y, newColor);
                }
            }
            image.LogEffect("Converted to grayscale");
        }
    }
}
