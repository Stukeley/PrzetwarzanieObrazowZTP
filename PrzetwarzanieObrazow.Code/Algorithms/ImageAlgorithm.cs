﻿namespace PrzetwarzanieObrazow.Code.Algorithms;

using Interfaces;
using Models;

/// <summary>
/// Klasa bazowa dla wszystkich algorytmów przetwarzania obrazu.
/// Zawiera dane wejściowe, ich rozmiar oraz wyjściowe, a także wszystkie niezbędne do przetwarzania informacje.
/// </summary>
public abstract class ImageAlgorithm
{
	public Pixel[,] InputImage { get; set; }
	public int Width { get; set; }
	public int Height { get; set; }
	
	public Pixel[,] OutputImage { get; set; }
	
	// Na ten moment nie używane. Będzie null dla algorytmów, które nie korzystają z maski.
	// Będzie to przyszła optymalizacja działania algorytmów.
	public IAlgorithmMask Mask { get; set; }

	public abstract Pixel[,] Process();

	public ImageAlgorithm(Pixel[,] inputImage, int width, int height)
	{
		InputImage = inputImage;
		Width = width;
		Height = height;

		OutputImage = new Pixel[Width, Height];
	}
}