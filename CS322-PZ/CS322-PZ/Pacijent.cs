using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS322_PZ
{
    class Pacijent
    {

        int id;
        string ime;
        string prezime;

        public Pacijent() { }

        public Pacijent(int id, string ime, string prezime)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Ime
        {
            get
            {
                return ime;
            }

            set
            {
                ime = value;
            }
        }

        public string Prezime
        {
            get
            {
                return prezime;
            }

            set
            {
                prezime = value;
            }
        }
    }
}
