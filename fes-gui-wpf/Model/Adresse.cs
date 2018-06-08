namespace fes_gui_wpf.Model
{
    public class Adresse
    {
        private string strasse;
        private string plz;
        private string ort;

        public Adresse(string plz ,string ort ,string strasse)
        {
            this.strasse = strasse;
            this.plz = plz;
            this.ort = ort;
        }

        public string Ort
        {
            get
            {
                return ort;
            }
        }

        public string Plz
        {
            get
            {
                return plz;
            }
        }

        public string Strasse
        {
            get
            {
                return strasse;
            }
        }

        public override string ToString()
        {
            return strasse + ", " + plz + ", " + ort;
        }
    }
}
