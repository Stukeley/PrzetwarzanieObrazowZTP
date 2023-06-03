namespace PrzetwarzanieObrazow.Code.Builders;

using Algorithms;
using DTOs;
using Helpers;
using Models;

/// <summary>
/// Klasa budowniczego zwracjąca odpowiednio przygotowane algorytmy do przetwarzania obrazu,
/// wraz z odpowiednio ustawionymi maskami (dla algorytmów, które korzystają z maski).
/// </summary>
public class ImageFilterBuilder
{
	public ImageAlgorithm BuildHighPassFilterAlgorithm(ImageDataObject dto)
	{
		var highPassFilter = new HighPassFilter(ByteArrayToPixels.ConvertImageDataToPixels(dto), dto.Width, dto.Height);
		highPassFilter.Mask = new HighPassImageMask();
		
		return highPassFilter;
	}
	
	public ImageAlgorithm BuildGrayscaleFilterAlgorithm(ImageDataObject dto)
	{
		var grayscaleFilter = new GrayscaleFilter(ByteArrayToPixels.ConvertImageDataToPixels(dto), dto.Width, dto.Height);
		grayscaleFilter.Mask = null;
		
		return grayscaleFilter;
	}

	public ImageAlgorithm BuildBrightnessChangeAlgorithm(ImageDataObject dto)
	{
		var brightnessChange = new BrightnessChange(ByteArrayToPixels.ConvertImageDataToPixels(dto), dto.Width, dto.Height);
		brightnessChange.Mask = null;
		
		return brightnessChange;
	}
	
	public ImageAlgorithm BuildContrastChangeAlgorithm(ImageDataObject dto)
	{
		var contrastChange = new ContrastChange(ByteArrayToPixels.ConvertImageDataToPixels(dto), dto.Width, dto.Height);
		contrastChange.Mask = null;
		
		return contrastChange;
	}
	
	public ImageAlgorithm BuildLaplaceFilterAlgorithm(ImageDataObject dto)
	{
		var laplaceFilter = new LaplaceFilter(ByteArrayToPixels.ConvertImageDataToPixels(dto), dto.Width, dto.Height);
		laplaceFilter.Mask = new LaplaceMask();
		
		return laplaceFilter;
	}

	public ImageAlgorithm BuildImageToBinaryAlgorithm(ImageDataObject dto)
	{
		var imageToBinary = new ImageToBinary(ByteArrayToPixels.ConvertImageDataToPixels(dto), dto.Width, dto.Height);
		imageToBinary.Mask = null;
		
		return imageToBinary;
	}
}