namespace AtletikaiVerseny
{
    internal class Atleta
    {
        public string Rajtszam { get; private set; }
        public string VezNev { get; private set; }
        public string KerNev { get; private set; }
        public string  Egyesulet { get; private set; }
        public int Ugras { get; private set; }
        public Atleta(string sor)
        {
            string[] adat = sor.Split(';');
            Rajtszam = adat[0];
            Nev(adat[1]);
            Egyesulet  = adat[2];
            Ugras = int.Parse(adat[3]);
            
        }

        public void Nev(string nev)
        {
            string[] adat = nev.Split(' ');
            VezNev = adat[0];
            KerNev = adat[1];
        }
    }
}