namespace PrzetwarzanieObrazow.Code.Models;

/// <summary>
/// Struktura reprezentująca piksel z kolorami RGB.
/// Będzie wykorzystywana w przyszłości zamiast korzystania z Bitmap.
/// </summary>
public struct Pixel
{
	public byte R { get; set; }
	public byte G { get; set; }
	public byte B { get; set; }

	public Pixel()
	{
		R = 0;
		G = 0;
		B = 0;
	}
	
	public Pixel(byte r, byte g, byte b)
	{
		R = r;
		G = g;
		B = b;
	}
}