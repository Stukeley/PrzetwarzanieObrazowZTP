namespace PrzetwarzanieObrazow.Code.Algorithms;

using Models;

/// <summary>
/// Algorytm nakładający na obraz filtr górnoprzepustowy (high pass filter).
/// </summary>
public class HighPassFilter : ImageAlgorithm
{
	public HighPassFilter(Pixel[,] inputImage, int width, int height) : base(inputImage, width, height)
	{
	}

	public override Pixel[,] Process()
	{
		int sumR, sumG, sumB;
		byte byteR, byteG, byteB;
		
		for (int j = 1; j < Height - 1; j++)
		{
			for (int i = 1; i < Width - 1; i++)
			{
				sumR = 0;
				sumG = 0;
				sumB = 0;

				for (int x = -1; x <= 1; x++)
				{
					for (int y = -1; y <= 1; y++)
					{
						sumR += InputImage[i + x, j + y].R * Mask.Mask[x + 1, y + 1];
						sumG += InputImage[i + x, j + y].G * Mask.Mask[x + 1, y + 1];
						sumB += InputImage[i + x, j + y].B * Mask.Mask[x + 1, y + 1];
					}
				}

				byteR = sumR switch
				{
					>255 => 255,
					<0 => 0,
					_ => (byte)sumR
				};
				byteG = sumG switch
				{
					>255 => 255,
					<0 => 0,
					_ => (byte)sumG
				};
				byteB = sumB switch
				{
					>255 => 255,
					<0 => 0,
					_ => (byte)sumB
				};

				OutputImage[i, j] = new Pixel(byteR, byteG, byteB);
			}
		}

		return OutputImage;
	}
}