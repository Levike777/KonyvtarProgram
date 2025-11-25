public class Olvaso
{
	public string Nev { get; set; }
	public int Eletkor { get; set; }
	public string Mufaj { get; set; }
	public bool Hirlevel { get; set; }
	public bool SmsErtesites { get; set; }
	public string Tagsag { get; set; }

	public override string ToString()
	{
		return $"{Nev}|{Eletkor}|{Mufaj}|{Hirlevel}|{SmsErtesites}|{Tagsag}";
	}

	public static Olvaso FromString(string sor)
	{
		var parts = sor.Split('|');
		return new Olvaso
		{
			Nev = parts[0],
			Eletkor = int.Parse(parts[1]),
			Mufaj = parts[2],
			Hirlevel = bool.Parse(parts[3]),
			SmsErtesites = bool.Parse(parts[4]),
			Tagsag = parts[5]
		};
	}
}
