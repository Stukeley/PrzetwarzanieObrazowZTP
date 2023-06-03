namespace PrzetwarzanieObrazow.Code.Algorithms;

using System;
using Models;

/// <summary>
/// Algorytm zmieniający jasność obrazu.
/// http://www.algorytm.org/przetwarzanie-obrazow/zmiana-jasnosci-obrazu.html
/// </summary>
public class BrightnessChange : ImageAlgorithm
{
	public BrightnessChange(Pixel[,] inputImage, int width, int height) : base(inputImage, width, height)
	{
	}
	
	public override Pixel[,] Process()
	{
		const int addedBrightness = 30;
		
		for (int i = 0; i < Width; i++)
		{
			for (int j = 0; j < Height; j++)
			{
				var pixel = InputImage[i, j];

				byte redValue = (pixel.R + addedBrightness) switch
				{
					> 255 => 255,
					< 0 => 0,
					_ => (byte)(pixel.R + addedBrightness)
				};
				byte greenValue = (pixel.G + addedBrightness) switch
				{
					> 255 => 255,
					< 0 => 0,
					_ => (byte)(pixel.G + addedBrightness)
				};
				byte blueValue = (pixel.B + addedBrightness) switch
				{
					> 255 => 255,
					< 0 => 0,
					_ => (byte)(pixel.B + addedBrightness)
				};

				OutputImage[i,j] = new Pixel(
					redValue,
					greenValue,
					blueValue
				);
			}
		}

		return OutputImage;
	}
}