using Photoredactor.Interfaces;
using Photoredactor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Photoredactor
{
    public class ImageProcessor
    {
        private Dictionary<ImageData, List<IPlugin>> _imagePlugins = new Dictionary<ImageData, List<IPlugin>>();

        public void AddImage(ImageData image)
        {
            if (!_imagePlugins.ContainsKey(image))
                _imagePlugins[image] = new List<IPlugin>();
        }

        public void AddPluginToImage(ImageData image, IPlugin plugin)
        {
            if (_imagePlugins.ContainsKey(image))
                _imagePlugins[image].Add(plugin);
        }

        public async Task ProcessAllAsync()
        {
            var tasks = new List<Task>();

            foreach (var pair in _imagePlugins)
            {
                var image = pair.Key;
                var plugins = pair.Value;

                tasks.Add(Task.Run(() =>
                {
                    foreach (var plugin in plugins)
                    {
                        Console.WriteLine($"[{DateTime.Now}] Applying {plugin.Name} to {image.FileName}");
                        plugin.Apply(image);
                    }
                    SaveImage(image);
                }));
            }

            await Task.WhenAll(tasks);
        }

        private void SaveImage(ImageData image)
        {
            string outputDir = "output";
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            string outputPath = Path.Combine(outputDir, image.FileName);
            image.Bitmap.Save(outputPath);
            Console.WriteLine($"[{DateTime.Now}] Saved processed image to {outputPath}");
        }

    }

}
