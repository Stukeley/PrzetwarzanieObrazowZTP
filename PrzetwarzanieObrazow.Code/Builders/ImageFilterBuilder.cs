namespace PrzetwarzanieObrazow.Code.Builders;

using System.Drawing;
using Algorithms;
using Helpers;
using Models;

/// <summary>
/// Klasa budowniczego zwracjąca odpowiednio przygotowane algorytmy do przetwarzania obrazu,
/// wraz z odpowiednio ustawionymi maskami (dla algorytmów, które korzystają z maski).
/// </summary>
public class ImageFilterBuilder
{
	public ImageAlgorithm BuildHighPassFilterAlgorithm(Bitmap inputImage)
	{
		var pixels = ByteArrayToPixels.ConvertByteArrayToPixels(inputImage);
		
		var highPassFilter = new HighPassFilter(pixels, inputImage.Width, inputImage.Height);
		highPassFilter.Mask = new HighPassImageMask();
		
		return highPassFilter;
	}
	
	public ImageAlgorithm BuildGrayscaleFilterAlgorithm(Bitmap inputImage)
	{
		var pixels = ByteArrayToPixels.ConvertByteArrayToPixels(inputImage);
		
		var grayscaleFilter = new GrayscaleFilter(pixels, inputImage.Width, inputImage.Height);
		grayscaleFilter.Mask = null;
		
		return grayscaleFilter;
	}
}