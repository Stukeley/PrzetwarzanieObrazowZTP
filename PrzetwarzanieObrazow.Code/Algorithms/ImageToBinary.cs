namespace PrzetwarzanieObrazow.Code.Algorithms;

using System.Drawing;

/// <summary>
/// Algorytm konwertujący obraz na obraz binarny (taki, w którym piksele są reprezentowane przez 1 lub 0).
/// Pułap konwersji jest ustawiony na stałe na 0.50.
/// </summary>
public class ImageToBinary : ImageAlgorithm
{
	public ImageToBinary(Bitmap inputImage, int width, int height) : base(inputImage, width, height)
	{
	}

	public override Bitmap Process()
	{
		const double threshold = 0.50;

		for (int i = 0; i < InputImage.Width; i++)
		{
			for (int j = 0; j < InputImage.Height; j++)
			{
				var pixel = InputImage.GetPixel(i, j);
				var grayScale = (pixel.R + pixel.G + pixel.B) / 3;

				if (grayScale > threshold * 256)
				{
					OutputImage.SetPixel(i, j, Color.White);
				}
				else
				{
					OutputImage.SetPixel(i, j, Color.Black);
				}
			}
		}

		return OutputImage;
	}
}