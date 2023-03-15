namespace PrzetwarzanieObrazow.Web.Requests;

using Microsoft.Build.Framework;

public class ImageProcessingRequest
{
	[Required]
	public byte[] InputImage { get; set; }
	[Required]
	public int Width { get; set; }
	[Required]
	public int Height { get; set; }
}