namespace fes_gui_wpf.Model
{
    public class Person
    {
        private string vorname;
        private string nachname;
        private Adresse adresse;

        public Person(string vorname, string nachname, Adresse adresse)
        {
            this.vorname = vorname;
            this.nachname = nachname;
            this.adresse = adresse;
        }

        public string Name
        {
            get
            {
                return vorname + " " + nachname;
            }
        }

        public string Vorname
        {
            get
            {
                return vorname;
            }
        }

        public string Nachname
        {
            get
            {
                return nachname;
            }
        }

        public Adresse Adresse
        {
            get
            {
                return adresse;
            }
        }

        public override string ToString()
        {
            return "Person: " + Name + "\n" +
                "Adresse: " + adresse;
        }
    }
}
