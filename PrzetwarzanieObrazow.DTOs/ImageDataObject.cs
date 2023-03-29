namespace PrzetwarzanieObrazow.DTOs;

/// <summary>
/// Obiekt wykorzystywany w transferze do API i z API.
/// Obiekt może być interpretowany przez projekty pochodne jako obiekt Bitmap.
/// </summary>
public class ImageDataObject
{
	public byte[] Data { get; set; }
	public int Width { get; set; }
	public int Height { get; set; }
	public string Algorithm { get; set; }
}