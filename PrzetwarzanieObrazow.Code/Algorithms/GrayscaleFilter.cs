namespace PrzetwarzanieObrazow.Code.Algorithms;

using System.Drawing;

/// <summary>
/// Algorytm konwertujący obraz na obraz w skali szarości.
/// Korzysta z wzoru: gray = 0.299 * r + 0.587 * g + 0.114 * b.
/// </summary>
public class GrayscaleFilter : ImageAlgorithm
{
	public GrayscaleFilter(Bitmap inputImage, int width, int height) : base(inputImage, width, height)
	{
	}
	
	public override Bitmap Process()
	{
		for (int i = 0; i < InputImage.Width; i++)
		{
			for (int j = 0; j < InputImage.Height; j++)
			{
				int r = InputImage.GetPixel(i, j).R;
				int g = InputImage.GetPixel(i, j).G;
				int b = InputImage.GetPixel(i, j).B;
			
				int gray = (int)(0.299 * r + 0.587 * g + 0.114 * b);

				OutputImage.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
			}
		}

		return OutputImage;
	}
}