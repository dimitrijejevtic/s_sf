using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s_dbmg.model
{
    class Autor
    {
        public string Ime { get; set; }

        public Autor(string ime)
        {
            Ime = ime;
        }

        public override string ToString()
        {
            return Ime;
        }

    }

    class Knjiga
    {
        public Autor Autor { get; set; }
        public string Naziv { get; set; }

        public Knjiga(Autor autor, string naziv)
        {
            Autor = autor;
            Naziv = naziv;
        }
        public override string ToString()
        {
            return Naziv;
        }
    }

    class ListaAutora
    {
        public List<Autor> listaAutora;
        public int N { get { return listaAutora.Count; } }

        public ListaAutora()
        {
            listaAutora = new List<Autor>();
        }

        public void dodajAutora(string ime)
        {
            listaAutora.Add(new Autor(ime));
        }
        public Autor this[int index]
        {
            get { return listaAutora[index]; }
        }
        public void remove(Autor autor)
        {
            listaAutora.Remove(autor);
        }
    }

    class ListaKnjiga
    {
        public List<Knjiga> listaKnjiga;
        public int N { get { return listaKnjiga.Count;} }

        public ListaKnjiga()
        {
            listaKnjiga = new List<Knjiga>();
        }

        public void dodajKnjigu(string imeKnjige, Autor autor)
        {
            listaKnjiga.Add(new Knjiga(autor, imeKnjige));
        }

        public void dodajKnjigu(Knjiga k)
        {
            listaKnjiga.Add(k);
        }

        public Knjiga this[int index]
        {
            get { return listaKnjiga[index]; }
        }
    }
}
