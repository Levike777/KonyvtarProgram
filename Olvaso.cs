using System;

namespace Konyvtar
{
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
			var p = sor.Split('|');
			return new Olvaso
			{
				Nev = p[0],
				Eletkor = int.Parse(p[1]),
				Mufaj = p[2],
				Hirlevel = bool.Parse(p[3]),
				SmsErtesites = bool.Parse(p[4]),
				Tagsag = p[5]
			};
		}
	}
}
