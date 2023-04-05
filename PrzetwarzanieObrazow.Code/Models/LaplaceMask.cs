namespace PrzetwarzanieObrazow.Code.Models;

using Interfaces;

public class LaplaceMask : IAlgorithmMask
{
	public int NetSize { get; set; }
	public int[,] Mask { get; set; }

	public LaplaceMask()
	{
		NetSize = 3;

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