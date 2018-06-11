namespace fes_gui_wpf.Model
{
    public class Person
    {
        public Person(string vorname, string nachname, Adresse adresse)
        {
            Vorname = vorname;
            Nachname = nachname;
            Adresse = adresse;
        }

        public string Name
        {
            get
            {
                return Vorname + " " + Nachname;
            }
        }

        public string Vorname { get; private set; }

        public string Nachname { get; private set; }

        public Adresse Adresse { get; private set; }


        public override string ToString()
        {
            return "Person: " + Name + "\n" +
                "Adresse: " + Adresse;
        }
    }
}
