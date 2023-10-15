class Invoice
{
    public string Serie { get; set; }
    public int Numar { get; set; }
    public DateTime Data { get; set; }
    public Furnizor Furnizor { get; set; }
    public Cumparator Cumparator { get; set; }
    public List<ProdusServiciu> Produse { get; set; }

    public Invoice(string serie, int numar, DateTime data, Furnizor furnizor, Cumparator cumparator)
    {
        Serie = serie;
        Numar = numar;
        Data = data;
        Furnizor = furnizor;
        Cumparator = cumparator;
        Produse = new List<ProdusServiciu>();
    }

    public void AdaugaProdus(ProdusServiciu produs)
    {
        produs.NrCrt = Produse.Count + 1;
        Produse.Add(produs);
    }

    public void AfiseazaFactura()
    {
        Console.WriteLine("Factura:");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine($"Serie: {Serie}\t Numar: {Numar}\t Data: {Data.ToShortDateString()}");
        Console.WriteLine("Furnizor:");
        Console.WriteLine(Furnizor);
        Console.WriteLine("Cumparator:");
        Console.WriteLine(Cumparator);
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("Nr Crt.\t Denumire\t Unitate\t Cantitate\t Pret Unitar\t Cota TVA\t Valoare Fara TVA\t Valoare TVA\t Total");
        Console.WriteLine("---------------------------------------------------");

        decimal totalFaraTVA = 0;
        decimal totalTVA = 0;

        foreach (var produs in Produse)
        {
            Console.WriteLine(produs);
            totalFaraTVA += produs.ValoareFaraTVA;
            totalTVA += produs.ValoareTVA;
        }

        decimal totalFinal = totalFaraTVA + totalTVA;

        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine($"Total Fara TVA: {totalFaraTVA}");
        Console.WriteLine($"Total TVA: {totalTVA}");
        Console.WriteLine($"Total Final: {totalFinal}");
    }
}

class Furnizor
{
    public string Nume { get; set; }
    public string CodFiscal { get; set; }
    public string Adresa { get; set; }
    public string Banca { get; set; }
    public string ContIBAN { get; set; }

    public Furnizor(string nume, string codFiscal, string adresa, string banca, string contIBAN)
    {
        Nume = nume;
        CodFiscal = codFiscal;
        Adresa = adresa;
        Banca = banca;
        ContIBAN = contIBAN;
    }

    public override string ToString()
    {
        return $"{Nume}\nCod Fiscal: {CodFiscal}\nAdresa: {Adresa}\nBanca: {Banca}\nCont IBAN: {ContIBAN}";
    }
}

class Cumparator
{
    public string Nume { get; set; }
    public string CodFiscal { get; set; }
    public string Adresa { get; set; }
    public string Banca { get; set; }
    public string ContIBAN { get; set; }

    public Cumparator(string nume, string codFiscal, string adresa, string banca, string contIBAN)
    {
        Nume = nume;
        CodFiscal = codFiscal;
        Adresa = adresa;
        Banca = banca;
        ContIBAN = contIBAN;
    }

    public override string ToString()
    {
        return $"{Nume}\nCod Fiscal: {CodFiscal}\nAdresa: {Adresa}\nBanca: {Banca}\nCont IBAN: {ContIBAN}";
    }
}

class ProdusServiciu
{
    public int NrCrt { get; set; }
    public string Denumire { get; set; }
    public string Unitate { get; set; }
    public decimal Cantitate { get; set; }
    public decimal PretUnitar { get; set; }
    public decimal CotaTVA { get; set; }

    public decimal ValoareFaraTVA => Cantitate * PretUnitar;
    public decimal ValoareTVA => ValoareFaraTVA * (CotaTVA / 100);
    public decimal Total => ValoareFaraTVA + ValoareTVA;

    public override string ToString()
    {
        return $"{NrCrt}\t {Denumire}\t {Unitate}\t {Cantitate}\t {PretUnitar:C}\t {CotaTVA}%\t {ValoareFaraTVA}\t {ValoareTVA}\t {Total}";
    }
}

class Program
{
    static void Main()
    {
        Furnizor furnizor = new Furnizor("Furnizor SRL", "RO123456", "Str. Street, nr. 123", "Banca BR", "RO1234567890");
        Cumparator cumparator = new Cumparator("Cumparator SA", "RO654321", "Str. Street2, nr. 456", "Banca ABC", "RO9876543210");

        Invoice factura = new Invoice("2023", 1, DateTime.Now, furnizor, cumparator);

        ProdusServiciu produs1 = new ProdusServiciu
        {
            Denumire = "Produs 1",
            Unitate = "buc",
            Cantitate = 10,
            PretUnitar = 50,
            CotaTVA = 19
        };

        ProdusServiciu produs2 = new ProdusServiciu
        {
            Denumire = "Produs 2",
            Unitate = "kg",
            Cantitate = 5,
            PretUnitar = 15,
            CotaTVA = 9
        };

        factura.AdaugaProdus(produs1);
        factura.AdaugaProdus(produs2);

        factura.AfiseazaFactura();
    }
}
