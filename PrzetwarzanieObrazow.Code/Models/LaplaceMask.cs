﻿namespace PrzetwarzanieObrazow.Code.Models;

using Interfaces;

/// <summary>
/// Konkretna maska, używana w algorytmie Laplace.
/// </summary>
public class LaplaceMask : IAlgorithmMask
{
	public int NetSize { get; set; }
	public int[,] Mask { get; set; }
	public int Sum { get; set; }

	public LaplaceMask()
	{
		NetSize = 3;
		Sum = 0;

		Mask = new int[NetSize, NetSize];
		
		Mask[0, 0] = -1;
		Mask[0, 1] = -1;
		Mask[0, 2] = -1;
		Mask[1, 0] = -1;
		Mask[1, 1] = 8;
		Mask[1, 2] = -1;
		Mask[2, 0] = -1;
		Mask[2, 1] = -1;
		Mask[2, 2] = -1;
	}
}