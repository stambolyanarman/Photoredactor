using System.Collections.Generic;
using System.Drawing;

namespace Photoredactor.Models
{
    public class ImageData
    {
        public string FileName { get; set; }
        public Bitmap Bitmap { get; set; }
        public List<string> AppliedEffects { get; } = new List<string>();

        public ImageData(string fileName)
        {
            FileName = fileName;
            Bitmap = new Bitmap(fileName);
        }

        public void LogEffect(string effect)
        {
            AppliedEffects.Add(effect);
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} | Size: {2}x{3}",
                FileName,
                string.Join(", ", AppliedEffects),
                Bitmap.Width,
                Bitmap.Height);
        }

        public void Save(string outputFile)
        {
            Bitmap.Save(outputFile);
        }
    }
}
