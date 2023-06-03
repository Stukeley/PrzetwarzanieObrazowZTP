namespace PrzetwarzanieObrazow.Code.Algorithms;

using Models;

/// <summary>
/// Algorytm nakładający na obraz filtr Laplace.
/// Filtr LAPL2.
/// http://www.algorytm.org/przetwarzanie-obrazow/filtrowanie-obrazow.html
/// </summary>
public class LaplaceFilter : ImageAlgorithm
{
	public LaplaceFilter(Pixel[,] inputImage, int width, int height) : base(inputImage, width, height)
	{
	}

	public override Pixel[,] Process()
	{
		// todo

		return OutputImage;
	}
}