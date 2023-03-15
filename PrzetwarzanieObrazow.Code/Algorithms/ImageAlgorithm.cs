namespace PrzetwarzanieObrazow.Code.Algorithms;

public abstract class Algorithm
{
	public byte[] InputImage { get; set; }
	public int Width { get; set; }
	public int Height { get; set; }
	
	public byte[] OutputImage { get; set; }
}