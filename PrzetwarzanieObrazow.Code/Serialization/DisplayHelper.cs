namespace PrzetwarzanieObrazow.Code.Serialization;

using System.Drawing;
using Models;

/// <summary>
/// Klasa pomocnicza do wyświetlania wyników algorytmów na ekran w formie obrazu lub tekstowej.
/// </summary>
public class DisplayHelper
{
	private static DisplayHelper _instance;

	public static DisplayHelper Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new DisplayHelper();
			}
			
			return _instance;
		}
	}

	public Bitmap TransformOutputToDisplayableForm()
	{
		return null;
	}

	public string TransformOutputToTextForm(Pixel[] output, int width, int height)
	{
		return "";
	}
}