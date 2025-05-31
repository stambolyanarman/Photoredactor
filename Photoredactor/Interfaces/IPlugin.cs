using Photoredactor.Models;

namespace Photoredactor.Interfaces
{
    public interface IPlugin
    {
        string Name { get; }
        void Apply(ImageData image);
    }
}
