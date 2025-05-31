using Photoredactor.Interfaces;
using Photoredactor.Models;
using System.Drawing;

namespace Photoredactor.Plugins
{
    public class Resize : IPlugin
    {
        public int TargetWidth { get; private set; }

        public Resize(int targetWidth)
        {
            TargetWidth = targetWidth;
        }

        public string Name => "Resize";

        public void Apply(ImageData image)
        {
            double aspectRatio = (double)image.Bitmap.Height / image.Bitmap.Width;
            int newHeight = (int)(TargetWidth * aspectRatio);
            var resized = new Bitmap(image.Bitmap, new Size(TargetWidth, newHeight));
            image.Bitmap.Dispose();
            image.Bitmap = resized;
            image.LogEffect($"Resized to {TargetWidth}x{newHeight}");
        }
    }
}
