namespace PrzetwarzanieObrazow.Code.Models;

using Interfaces;

/// <summary>
/// Konkretna maska, używana w algorytmie High Pass Image Filter.
/// </summary>
public class HighPassImageMask : IAlgorithmMask
{
	public int NetSize { get; set; }
	public int[,] Mask { get; set; }
	public int Sum { get; set; }

	public HighPassImageMask()
	{
		NetSize = 3;
		Sum = 1;

		Mask = new int[NetSize, NetSize];
		
		Mask[0, 0] = 0;
		Mask[0, 1] = -1;
		Mask[0, 2] = 0;
		Mask[1, 0] = -1;
		Mask[1, 1] = 5;
		Mask[1, 2] = -1;
		Mask[2, 0] = 0;
		Mask[2, 1] = -1;
		Mask[2, 2] = 0;
	}
}