using CA240130;

static void Beolvasas(List<Allomas> lista) 
{
	try
	{
		StreamReader sr = new(@"..\..\..\src\csapadek.txt");
		while (!sr.EndOfStream)
			lista.Add(new Allomas(sr.ReadLine()));
		sr.Close();
        Console.WriteLine("Fájl sikeresen beolvasva!\n");
    }
	catch
	{
        Console.WriteLine("Hiba a fájl beolvasása során!\n");
    }
}
static void Tablazat(List<Allomas> lista) 
{
    Console.WriteLine("\t1. 2. 3. 4. 5. 6. 7. 8. 9. 10. 11. 12. 13. 14. 15. 16. 17. 18. 19. 20. 21. 22. 23. 24.\n");
    lista.Select((x,i) => $"{i+1}.\t{x}").ToList().ForEach(x => Console.WriteLine(x));
}
static void Feladat3(List<Allomas> lista) 
{
	int db = lista.SelectMany(m => m.Csapadekok).Where(m => m.Equals(0)).Count();
    Console.WriteLine($"\n3.feladat: \n\t{db}x volt olyan óra, hogy nem esett az eső!");
}
static void Feladat4(List<Allomas> lista) 
{
	int szama = lista.IndexOf(lista.Where(m => m.OsszEso == lista.Max(m => m.OsszEso)).First())+1;

    Console.WriteLine($"\n4.feladat: \n\t{szama}. számú mérő állomáson mérték a legtöbb esőt!");
}
static void Feladat5(List<Allomas> lista)
{
	int nemEsettDBnap = lista.Select(m => m.Csapadekok).Where(m => m.Contains(0)).Count();
    Console.WriteLine($"\n5.feladat: \n\t{(lista.Count - nemEsettDBnap >= 1 ? "Volt":"Nem volt")} olyan nap, amikor egész nap esett az eső!");
}
static void Feladat6(List<Allomas> lista) 
{
	List<int> orak = lista.Select(allomas =>
    {
        int elsoMagasErtekOraSzam = allomas.Csapadekok
            .Select((csapadek, index) => new {Csapadek = csapadek, Index = index + 1 })
            .FirstOrDefault(x => x.Csapadek > 10).Index;

        return elsoMagasErtekOraSzam;
    }).ToList();

    try
	{
        StreamWriter sw = new(@"..\..\..\src\ujFile.txt");
        orak.ForEach(s => sw.WriteLine(s));
        sw.Close();
        Console.WriteLine("\n6.feladat: \n\tA fájlba való kiírás sikeres volt!");
    }
	catch
	{
        Console.WriteLine("\n6.feladat: \n\tHiba a fájlba való kiírás során!");
    }
}

//Main
List<Allomas> allomasok = new();
Beolvasas(allomasok);
Tablazat(allomasok);
Feladat3(allomasok);
Feladat4(allomasok);
Feladat5(allomasok);
Feladat6(allomasok);

