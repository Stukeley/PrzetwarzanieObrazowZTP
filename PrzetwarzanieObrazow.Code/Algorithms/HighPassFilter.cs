namespace PrzetwarzanieObrazow.Code.Algorithms;

using System;
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

				var pixel1 = pixels.GetPixel(i - 1, j - 1);
				var pixel2 = pixels.GetPixel(i - 1, j);
				var pixel3 = pixels.GetPixel(i - 1, j + 1);
				var pixel4 = pixels.GetPixel(i, j - 1);
				var pixel5 = pixels.GetPixel(i, j);
				var pixel6 = pixels.GetPixel(i, j + 1);
				var pixel7 = pixels.GetPixel(i + 1, j - 1);
				var pixel8 = pixels.GetPixel(i + 1, j);
				var pixel9 = pixels.GetPixel(i + 1, j + 1);
				
				int r = 0*pixel1.R + -1*pixel2.R + 0*pixel3.R + -1*pixel4.R + 5*pixel5.R + -1*pixel6.R + 0*pixel7.R + -1*pixel8.R + 0*pixel9.R;
				int g = 0*pixel1.G + -1*pixel2.G + 0*pixel3.G + -1*pixel4.G + 5*pixel5.G + -1*pixel6.G + 0*pixel7.G + -1*pixel8.G + 0*pixel9.G;
				int b = 0*pixel1.B + -1*pixel2.B + 0*pixel3.B + -1*pixel4.B + 5*pixel5.B + -1*pixel6.B + 0*pixel7.B + -1*pixel8.B + 0*pixel9.B;
				
				r /= 1;
				g /= 1;
				b /= 1;

				// Nieoptmalne konwersje.
				r = Math.Clamp(r, 0, 255);
				g = Math.Clamp(g, 0, 255);
				b = Math.Clamp(b, 0, 255);
				
				OutputImage.SetPixel(i, j, Color.FromArgb((byte)r, (byte)g, (byte)b));
			}
		}

		return OutputImage;
	}
}