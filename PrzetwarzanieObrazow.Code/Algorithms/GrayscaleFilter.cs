namespace PrzetwarzanieObrazow.Code.Algorithms;

using Models;

/// <summary>
/// Algorytm konwertujący obraz na obraz w skali szarości.
/// Korzysta z wzoru: gray = 0.299 * r + 0.587 * g + 0.114 * b.
/// </summary>
public class GrayscaleFilter : ImageAlgorithm
{
	public GrayscaleFilter(Pixel[] inputImage, int width, int height) : base(inputImage, width, height)
	{
	}
	
	public override Pixel[] Process()
	{
		for (int i = 0; i < InputImage.Length; i++)
		{
			int r = InputImage[i].R;
			int g = InputImage[i].G;
			int b = InputImage[i].B;
			
			int gray = (int)(0.299 * r + 0.587 * g + 0.114 * b);
			
			OutputImage[i] = new Pixel((byte)gray, (byte)gray, (byte)gray);
		}

		return OutputImage;
	}
}