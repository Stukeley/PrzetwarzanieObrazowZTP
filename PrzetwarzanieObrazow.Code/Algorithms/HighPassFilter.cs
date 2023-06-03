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
		// todo

		return OutputImage;
	}
}