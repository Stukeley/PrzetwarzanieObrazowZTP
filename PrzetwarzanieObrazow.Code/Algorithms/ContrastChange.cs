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

				double redValue = Math.Clamp((changedContrast * (pixel.R - 128) + 128), 0, 255);
				double greenValue = Math.Clamp((changedContrast * (pixel.G - 128) + 128), 0, 255);
				double blueValue = Math.Clamp((changedContrast * (pixel.B - 128) + 128), 0, 255);
				
				OutputImage[i, j] = new Pixel((byte)redValue, (byte)greenValue, (byte)blueValue);
			}
		}

		return OutputImage;
	}
}