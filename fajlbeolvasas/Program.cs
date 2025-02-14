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

			atlagSzint(karakterek);
            Console.WriteLine("---------------------------------------");

            rendezes(karakterek);
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

		static void atlagSzint(List<Karakter> karakterek)
		{

			int ossz = 0;

			foreach(var item in karakterek)
			{
				ossz += item.Szint;
				
			}
			double atlag = ossz / karakterek.Count;
			Console.WriteLine($"A karakterek szintjének atlaga: {atlag}");
        }

		static void rendezes(List<Karakter> karakterek)
		{
			for (int i = 0; i < karakterek.Count; i++)
			{
				for(int j = 0; j < karakterek.Count; j++)
				{
					if (karakterek[i].Ero < karakterek[j].Ero)
					{
						Karakter csere = karakterek[i];
						karakterek [i] = karakterek[j];
						karakterek[j] = csere;
					}
				}
			}
            foreach(var item in karakterek)
			{
                Console.WriteLine(item);
            }
        }
	}
}
