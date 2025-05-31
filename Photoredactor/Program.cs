using Photoredactor.Models;
using Photoredactor.Plugins;
using System.Threading.Tasks;

namespace Photoredactor
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var processor = new ImageProcessor();

            var img1 = new ImageData("image1.jpg");
            var img2 = new ImageData("image1.jpg");
            var img3 = new ImageData("image1.jpg");

            processor.AddImage(img1);
            processor.AddImage(img2);
            processor.AddImage(img3);

            processor.AddPluginToImage(img1, new Resize(100));
            processor.AddPluginToImage(img1, new Blur(2));

            processor.AddPluginToImage(img2, new Resize(100));

            processor.AddPluginToImage(img3, new Resize(150));
            processor.AddPluginToImage(img3, new Blur(5));
            processor.AddPluginToImage(img3, new Grayscale());

            await processor.ProcessAllAsync();

        }
    }
}
