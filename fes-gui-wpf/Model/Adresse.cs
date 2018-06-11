namespace fes_gui_wpf.Model
{
    public class Adresse
    {
        /// <summary>
        /// Konstruktor der Adresse
        /// </summary>
        /// <param name="plz"></param>
        /// <param name="ort"></param>
        /// <param name="strasse"></param>
        public Adresse(string plz ,string ort ,string strasse)
        {
            Plz = plz;
            Ort = ort;
            Strasse = strasse;
        }

        public string Ort { get; private set; }

        public string Plz { get; private set; }

        public string Strasse { get; private set; }

        public override string ToString()
        {
            return Strasse + ", " + Plz + ", " + Ort;
        }
    }
}
