namespace PrzetwarzanieObrazow.Code.Algorithms;

using System;
using System.Drawing;

/// <summary>
/// Algorytm zmieniający jasność obrazu.
/// http://www.algorytm.org/przetwarzanie-obrazow/zmiana-jasnosci-obrazu.html
/// </summary>
public class BrightnessChange : ImageAlgorithm
{
	public BrightnessChange(Bitmap inputImage, int width, int height) : base(inputImage, width, height)
	{
	}
	
	public override Bitmap Process()
	{
		const int addedBrightness = 30;
		
		for (int i = 0; i < Width; i++)
		{
			for (int j = 0; j < Height; j++)
			{
				var pixel = InputImage.GetPixel(i, j);
				
				double redValue = Math.Clamp(pixel.R + addedBrightness, 0, 255);
				double greenValue = Math.Clamp(pixel.G + addedBrightness, 0, 255);
				double blueValue = Math.Clamp(pixel.B + addedBrightness, 0, 255);
				
				OutputImage.SetPixel(i, j, Color.FromArgb(
					(byte) (redValue),
					(byte) (greenValue),
					(byte) (blueValue)
				));
			}
		}

		return OutputImage;
	}
}