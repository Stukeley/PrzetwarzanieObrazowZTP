namespace PrzetwarzanieObrazow.Code.Algorithms;

using System.Drawing;

/// <summary>
/// Algorytm nakładający na obraz filtr górnoprzepustowy (high pass filter).
/// Wersja nieoptymalna.
/// </summary>
public class HighPassFilter : ImageAlgorithm
{
	public HighPassFilter(Bitmap inputImage, int width, int height) : base(inputImage, width, height)
	{
	}

	public override Bitmap Process()
	{
		// Implement high pass image filter on InputImage and save result in OutputImage.
		// You can use Width and Height to get image dimensions.
		var pixels = InputImage;

		for (int i = 0; i < Width; i++)
		{
			for (int j = 0; j < Height; j++)
			{
				if (i == 0 || j == 0 || i == Width - 1 || j == Height - 1)
				{
					OutputImage.SetPixel(i,j, pixels.GetPixel(i,j));
					continue;
				}

				int r = 0, g = 0, b = 0;
				
				for (int x = -1; x <= 1; x++)
				{
					for (int y = -1; y <= 1; y++)
					{
						var pixel = pixels.GetPixel(i + x, j + y);
						r += pixel.R;
						g += pixel.G;
						b += pixel.B;
					}
				}
				
				r /= 1;
				g /= 1;
				b /= 1;
				
				OutputImage.SetPixel(i, j, Color.FromArgb((byte)r, (byte)g, (byte)b));
			}
		}

		return OutputImage;
	}
}