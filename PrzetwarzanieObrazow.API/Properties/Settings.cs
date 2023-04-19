namespace PrzetwarzanieObrazow.API.Properties;

public class Settings
{
	private static Settings _instance;

	public static Settings Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new Settings();
			}

			return _instance;
		}
	}
	
	public string ApplicationUrl { get; set; } = "http://localhost:5089";
	public int ApplicationPort { get; set; } = 5089;
}