namespace PrzetwarzanieObrazow.Code.Builders;

using System.Drawing;
using Algorithms;
using Models;

/// <summary>
/// Klasa budowniczego zwracjąca odpowiednio przygotowane algorytmy do przetwarzania obrazu,
/// wraz z odpowiednio ustawionymi maskami (dla algorytmów, które korzystają z maski).
/// </summary>
public class ImageFilterBuilder
{
	public ImageAlgorithm BuildHighPassFilterAlgorithm(Bitmap inputImage)
	{
		var highPassFilter = new HighPassFilter(inputImage, inputImage.Width, inputImage.Height);
		highPassFilter.Mask = new HighPassImageMask();
		
		return highPassFilter;
	}
	
	public ImageAlgorithm BuildGrayscaleFilterAlgorithm(Bitmap inputImage)
	{
		var grayscaleFilter = new GrayscaleFilter(inputImage, inputImage.Width, inputImage.Height);
		grayscaleFilter.Mask = null;
		
		return grayscaleFilter;
	}

	public ImageAlgorithm BuildBrightnessChangeAlgorithm(Bitmap inputImage)
	{
		var brightnessChange = new BrightnessChange(inputImage, inputImage.Width, inputImage.Height);
		brightnessChange.Mask = null;
		
		return brightnessChange;
	}
	
	public ImageAlgorithm BuildContrastChangeAlgorithm(Bitmap inputImage)
	{
		var contrastChange = new ContrastChange(inputImage, inputImage.Width, inputImage.Height);
		contrastChange.Mask = null;
		
		return contrastChange;
	}
}