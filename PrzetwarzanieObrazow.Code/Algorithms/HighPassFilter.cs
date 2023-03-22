namespace PrzetwarzanieObrazow.Code.Algorithms;

using Models;

/// <summary>
/// Algorytm nakładający na obraz filtr górnoprzepustowy (high pass filter).
/// Maska filtru (3x3): { 0, -1, 0, -1, 5, -1, 0, -1, 0 }.
/// </summary>
public class HighPassFilter : ImageAlgorithm
{
	public HighPassFilter(Pixel[] inputImage, int width, int height) : base(inputImage, width, height)
	{
	}

	public override Pixel[] Process()
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
					OutputImage[i + j * Width] = pixels[i + j * Width];
					continue;
				}

				int r = 0, g = 0, b = 0;
				
				for (int x = -1; x <= 1; x++)
				{
					for (int y = -1; y <= 1; y++)
					{
						var pixel = pixels[(i + x) + (j + y) * Width];
						r += pixel.R;
						g += pixel.G;
						b += pixel.B;
					}
				}
				
				r /= 1;
				g /= 1;
				b /= 1;
				
				OutputImage[i + j * Width] = new Pixel((byte)r, (byte)g, (byte)b);
			}
		}

		return OutputImage;
	}
}