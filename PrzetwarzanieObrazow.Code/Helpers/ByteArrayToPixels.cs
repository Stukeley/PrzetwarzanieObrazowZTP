namespace PrzetwarzanieObrazow.Code.Helpers;

using DTOs;
using Models;

/// <summary>
/// Klasa pomocnicza do konwersji obrazu z formatu Bitmap do tablicy pikseli.
/// </summary>
public static class ByteArrayToPixels
{
	public static Pixel[,] ConvertImageDataToPixels(ImageDataObject obj)
	{
		var pixels = new Pixel[obj.Width, obj.Height];

		int index = 0;

		for (int y = 0; y < obj.Height; y++)
		{
			for (int x = 0; x < obj.Width; x++)
			{
				pixels[x, y] = new Pixel(obj.Data[index], obj.Data[index+1], obj.Data[index+2]);
				index += 3;
			}
		}

		return pixels;
	}
}