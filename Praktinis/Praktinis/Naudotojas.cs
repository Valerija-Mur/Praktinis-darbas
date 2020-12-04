using System;

namespace Praktinis
{

    public class Naudotojas
    {
        public int ID;
        public string vardas;
        public string pavarde;
        public int lygis;

        public Naudotojas(int ID,string vardas, string pavarde, int lygis)
        {
            if (string.IsNullOrWhiteSpace(vardas) || string.IsNullOrWhiteSpace(pavarde))
            {
                throw new Exception("Tušti langai");
            }
            this.ID = ID;
            this.vardas = vardas;
            this.pavarde = pavarde;
            this.lygis = lygis;
        }
    }
}
