namespace PrzetwarzanieObrazow.Code.Algorithms;

using System;
using Models;

/// <summary>
/// Algorytm zmieniający kontrast obrazu.
/// http://www.algorytm.org/przetwarzanie-obrazow/zmiana-kontrastu-obrazu.html
/// </summary>
public class ContrastChange : ImageAlgorithm
{
	public ContrastChange(Pixel[,] inputImage, int width, int height) : base(inputImage, width, height)
	{
	}

	public override Pixel[,] Process()
	{
		const double changedContrast = 1.5;
		
		for (int i = 0; i < Width; i++)
		{
			for (int j = 0; j < Height; j++)
			{
				var pixel = InputImage[i, j];
				
				byte redValue = (changedContrast * (pixel.R - 128) + 128) switch
				{
					>255 => 255,
					<0 => 0,
					_ => (byte)(changedContrast * (pixel.R - 128) + 128)
				};
				byte greenValue = (changedContrast * (pixel.G - 128) + 128) switch
				{
					>255 => 255,
					<0 => 0,
					_ => (byte)(changedContrast * (pixel.G - 128) + 128)
				};
				byte blueValue = (changedContrast * (pixel.B - 128) + 128) switch
				{
					>255 => 255,
					<0 => 0,
					_ => (byte)(changedContrast * (pixel.B - 128) + 128)
				};

				OutputImage[i, j] = new Pixel(redValue, greenValue, blueValue);
			}
		}

		return OutputImage;
	}
}