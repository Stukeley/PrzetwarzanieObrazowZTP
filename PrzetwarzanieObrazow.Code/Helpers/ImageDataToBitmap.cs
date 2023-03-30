namespace PrzetwarzanieObrazow.Code.Helpers;

using System.Drawing;
using System.IO;
using DTOs;

public static class ImageDataToBitmap
{
	public static Bitmap ConvertImageDataToBitmap(ImageDataObject obj)
	{
		using (var memoryStream = new MemoryStream(obj.Data))
		{
			var bitmap = new Bitmap(memoryStream);
			return bitmap;
		}
	}
}