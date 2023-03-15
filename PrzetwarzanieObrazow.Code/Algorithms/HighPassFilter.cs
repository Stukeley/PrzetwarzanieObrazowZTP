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

		// TODO: implementacja algorytmu
		// https://github.com/Stukeley/HighPassImageFilter/blob/master/HighPassImageFilter.CS/HighPassFilter.cs
		
		return OutputImage;
	}
}