namespace PrzetwarzanieObrazow.Code.Helpers;

using Models;

public static class ByteArrayToPixels
{
	public static Pixel[] ConvertByteArrayToPixels(byte[] inputImage, int imageWidth, int imageHeight)
	{
		var pixels = new Pixel[imageWidth * imageHeight];
		
		for (int i = 0; i < pixels.Length; i++)
		{
			pixels[i] = new Pixel
			{
				R = inputImage[i * 3],
				G = inputImage[i * 3 + 1],
				B = inputImage[i * 3 + 2]
			};
		}

		return pixels;
	}
}