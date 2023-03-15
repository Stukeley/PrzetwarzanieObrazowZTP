namespace PrzetwarzanieObrazow.Code.Helpers;

using System.Drawing;
using Models;

/// <summary>
/// Klasa pomocnicza do konwersji obrazu z formatu Bitmap do tablicy pikseli.
/// </summary>
public static class ByteArrayToPixels
{
	public static Pixel[] ConvertByteArrayToPixels(Bitmap inputImage)
	{
		int width = inputImage.Width;
		int height = inputImage.Height;

		int size = width * height;

		var pixels = new Pixel[size];
		
		for (int i =0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				var color = inputImage.GetPixel(j, i);
				
				pixels[i * width + j] = new Pixel
				{
					R = color.R,
					G = color.G,
					B = color.B
				};
			}
		}

		return pixels;
	}
}