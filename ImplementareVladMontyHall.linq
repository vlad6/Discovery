<Query Kind="Program" />

void Main()
{
	// Sa vedem ce avem in fata...
	Console.WriteLine("Cate jocuri vrei sa simulam?");
	var ceZiceUseru = Console.ReadLine();
	
	if (!int.TryParse(ceZiceUseru, out ImplementareVladMontyHall.NumarDeJocuri))
		ImplementareVladMontyHall.NumarDeJocuri = 100000; // Ne rezumam la 100.000 daca idiotu de la tastatura nu stie sa scrie un numar
	
	// Porneste
	ImplementareVladMontyHall.Start();
}

class ImplementareVladMontyHall
{
	// Reglam, reglam... conturile :)
	public static int NumarDeJocuri;

	public static void Start()
	{
		var castiguriPeSchimbare = 0;
        var castiguriPeMentinere = 0;
         var random = new Random();
 
        for (int nrJoc = 0; nrJoc < NumarDeJocuri; nrJoc++ )
        {
			// Plecam cu 3 capre
            string[] listaUsi = { "capra", "capra", "capra" };
 
 			// Generam o pozitie intamplatoare pe care punem masina
            var pozitieCastigatoare = random.Next(3);
            listaUsi[pozitieCastigatoare] = "masina";
 
		    int usaAleasa = random.Next(3);
		    int usaDeschisa;
		    
			do // Deschidem o usa care nu are in spate masina SI CARE nu este alegerea (deci cat timp A SAU B :))
	            usaDeschisa = random.Next(3);
		    while (listaUsi[usaDeschisa] == "masina" || usaDeschisa == usaAleasa);		
	 		
			if (listaUsi[usaAleasa] == "masina")
			    ++castiguriPeMentinere;
			else {
				var cealaltaUsa = 3 - usaAleasa - usaDeschisa;
				
				if (listaUsi[cealaltaUsa] == "masina")
					++castiguriPeSchimbare;
			}			            
        }
 		
		// Calcule procente
		var procentMentinere = (double)castiguriPeMentinere / NumarDeJocuri * 100;
		var procentSchimbare = (double)castiguriPeSchimbare / NumarDeJocuri * 100;
  
  		// Afisare cacat
        Console.Out.WriteLine("Castiguri pe mentinerea alegerii initiale: {0} din {1} ({2}%)", castiguriPeMentinere, NumarDeJocuri, procentMentinere);
        Console.Out.WriteLine("Castiguri pe schimbarea alegerii initiale: {0} din {1} ({2}%)", castiguriPeSchimbare, NumarDeJocuri, procentSchimbare);
	}
}