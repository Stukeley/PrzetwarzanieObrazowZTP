namespace PrzetwarzanieObrazow.Code.Interfaces;

/// <summary>
/// Interfejs reprezentujący maskę algorytmu.
/// Tylko dla algorytmów, które korzystają z maski.
/// </summary>
public interface IAlgorithmMask
{
	public int NetSize { get; set; }
	public int[,] Mask { get; set; }
}