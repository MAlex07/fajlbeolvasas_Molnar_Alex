namespace fajlbeolvasas
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Karakter> karakterek = [];

			Beolvasas("karakterek.txt", karakterek);

			foreach(var item in karakterek)
			{
                Console.WriteLine(item);
            }

			legnagyobbEletero(karakterek);
		}

		static void Beolvasas(string fajlnev, List<Karakter> karakterek)
		{
			StreamReader sr = new(fajlnev);

			sr.ReadLine();
			
			while (!sr.EndOfStream)
			{
				string sor = sr.ReadLine();
				string[] szavak = sor.Split(';');

				Karakter karakter = new(szavak[0], Convert.ToInt16(szavak[1]), Convert.ToInt16(szavak[2]), Convert.ToInt16(szavak[3]));
				karakterek.Add(karakter);

			}
		}

		static void legnagyobbEletero(List<Karakter> karakterek)
		{
			Karakter max = karakterek[0];
			foreach (var item in karakterek)
			{
				if (item.Eletero > max.Eletero) 
				{
					max = item;
				}
			}
            Console.WriteLine($"A legtöbb életerővel rendelkező karakter: {max.Nev} szintje: {max.Szint} erőssége: {max.Ero}");
        }
	}
}
