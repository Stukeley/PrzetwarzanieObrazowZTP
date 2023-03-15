namespace PrzetwarzanieObrazow.Code.Serialization;

using System.Text.Json;
using Algorithms;

/// <summary>
/// Klasa pomocnicza do zapisywania stanu wewnętrznego algorytmu (obraz wejściowy, wyjściowy, rozmiar).
/// </summary>
public class SerializationHelper
{
	private static SerializationHelper _instance;
	
	public static SerializationHelper Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new SerializationHelper();
			}

			return _instance;
		}
	}

	public string Serialize(ImageAlgorithm algorithm)
	{
		var json = JsonSerializer.Serialize<ImageAlgorithm>(algorithm);

		return json;
	}
}