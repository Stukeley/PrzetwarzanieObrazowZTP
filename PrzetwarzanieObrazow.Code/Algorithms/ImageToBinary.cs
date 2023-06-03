namespace PrzetwarzanieObrazow.Code.Algorithms;

using Models;

/// <summary>
/// Algorytm konwertujący obraz na obraz binarny (taki, w którym piksele są reprezentowane przez 1 lub 0).
/// Pułap konwersji jest ustawiony na stałe na 0.50.
/// </summary>
public class ImageToBinary : ImageAlgorithm
{
	public ImageToBinary(Pixel[,] inputImage, int width, int height) : base(inputImage, width, height)
	{
	}

	public override Pixel[,] Process()
	{
		const double threshold = 0.50;

		for (int i = 0; i < Width; i++)
		{
			for (int j = 0; j < Height; j++)
			{
				var pixel = InputImage[i,j];
				var grayScale = (pixel.R + pixel.G + pixel.B) / 3;

				if (grayScale > threshold * 256)
				{
					OutputImage[i, j] = new Pixel(255, 255, 255);
				}
				else
				{
					OutputImage[i, j] = new Pixel(0, 0, 0);
				}
			}
		}

		return OutputImage;
	}
}