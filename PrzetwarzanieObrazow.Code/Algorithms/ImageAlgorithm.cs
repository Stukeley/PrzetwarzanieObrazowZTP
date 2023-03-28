namespace PrzetwarzanieObrazow.Code.Algorithms;

using System.Drawing;
using Interfaces;
using Models;

/// <summary>
/// Klasa bazowa dla wszystkich algorytmów przetwarzania obrazu.
/// Zawiera dane wejściowe, ich rozmiar oraz wyjściowe, a także wszystkie niezbędne do przetwarzania informacje.
/// </summary>
public abstract class ImageAlgorithm
{
	public Bitmap InputImage { get; set; }
	public int Width { get; set; }
	public int Height { get; set; }
	
	public Bitmap OutputImage { get; set; }
	
	// Na ten moment nie używane. Będzie null dla algorytmów, które nie korzystają z maski.
	public IAlgorithmMask Mask { get; set; }

	public abstract Bitmap Process();

	public ImageAlgorithm(Bitmap inputImage, int width, int height)
	{
		InputImage = inputImage;
		Width = width;
		Height = height;
		
		OutputImage = new Bitmap(Width, Height);
	}
}