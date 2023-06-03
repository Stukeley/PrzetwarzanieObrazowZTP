namespace PrzetwarzanieObrazow.Code.Algorithms;

using Models;

/// <summary>
/// Algorytm konwertujący obraz na obraz w skali szarości.
/// Korzysta z wzoru: gray = 0.299 * r + 0.587 * g + 0.114 * b.
/// </summary>
public class GrayscaleFilter : ImageAlgorithm
{
	public GrayscaleFilter(Pixel[,] inputImage, int width, int height) : base(inputImage, width, height)
	{
	}
	
	public override Pixel[,] Process()
	{
		for (int i = 0; i < Width; i++)
		{
			for (int j = 0; j < Height; j++)
			{
				var pixel = InputImage[i, j];
			
				int gray = (int)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);
				byte grayByte;

				switch (gray)
				{
					case > 255:
						grayByte = 255;
						break;
					case < 0:
						grayByte = 0;
						break;
					default:
						grayByte = (byte)gray;
						break;
				}

				OutputImage[i, j] = new Pixel(grayByte, grayByte, grayByte);
			}
		}

		return OutputImage;
	}
}