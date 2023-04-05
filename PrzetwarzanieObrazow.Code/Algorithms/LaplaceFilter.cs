namespace PrzetwarzanieObrazow.Code.Algorithms;

using System.Drawing;

/// <summary>
/// Algorytm nakładający na obraz filtr Laplace.
/// Filtr LAPL2.
/// http://www.algorytm.org/przetwarzanie-obrazow/filtrowanie-obrazow.html
/// </summary>
public class LaplaceFilter : ImageAlgorithm
{
	public LaplaceFilter(Bitmap inputImage, int width, int height) : base(inputImage, width, height)
	{
	}

	public override Bitmap Process()
	{
		for (int i = 1; i < Width - 1; i++)
		{
			for (int j = 1; j < Height - 1; j++)
			{
				int sum = 0;
				sum += InputImage.GetPixel(i - 1, j - 1).R * -1;
				sum += InputImage.GetPixel(i - 1, j).R * -1;
				sum += InputImage.GetPixel(i - 1, j + 1).R * -1;
				sum += InputImage.GetPixel(i, j - 1).R * -1;
				sum += InputImage.GetPixel(i, j).R * 8;
				sum += InputImage.GetPixel(i, j + 1).R * -1;
				sum += InputImage.GetPixel(i + 1, j - 1).R * -1;
				sum += InputImage.GetPixel(i + 1, j).R * -1;
				sum += InputImage.GetPixel(i + 1, j + 1).R * -1;

				if (sum < 0)
				{
					sum = 0;
				}
				else if (sum > 255)
				{
					sum = 255;
				}

				OutputImage.SetPixel(i, j, Color.FromArgb(sum, sum, sum));
			}
		}

		return OutputImage;
	}
}