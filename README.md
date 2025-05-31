Image Plugin Framework (.NET)`
Overview:
This is a .NET-based image processing plugin framework designed to:

Handle multiple images simultaneously, each with its own set of image effects (plugins).

Support easy addition/removal of plugins without modifying the core application code.

Allow multiple effects to be applied sequentially to each image.

Provide a flexible architecture using interfaces and dynamic plugin loading.

Simulate image data processing (actual image manipulation is partially implemented for demonstration).

Features:
Object-oriented design using IPlugin interface.

Built-in example plugins:

ResizePlugin — resize image width while preserving aspect ratio.

BlurPlugin — simulate blur effect (simple dummy implementation).

GrayscalePlugin — convert image to grayscale.

Dynamic loading of plugins from external DLLs.

Plugin configuration loading from JSON files.

Asynchronous processing of multiple images with logging.

Uses native .NET System.Drawing.Bitmap for image representation.

No third-party libraries used — fully custom implementation.

Project Structure:
IPlugin.cs — plugin interface.

ImageData.cs — simulated image data model wrapping a Bitmap.

ResizePlugin.cs, BlurPlugin.cs, GrayscalePlugin.cs — example plugin implementations.

PluginLoader.cs — dynamic plugin loader from DLL files.

PluginConfigurator.cs — loads plugin configuration from JSON.

ImageProcessor.cs — core class to manage images and plugins, process images asynchronously.

Program.cs — example usage demonstrating framework functionality.
