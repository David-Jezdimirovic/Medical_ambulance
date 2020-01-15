using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS322_PZ
{
    class Radnik
    {
        private int id;
        private string ime;
        private string prezime;
        private string username;
        private string sifra;
        private string uloga_naziv;

        public Radnik()
        {
        }

        public Radnik(int id, string ime, string prezime, string username, string sifra, string uloga_naziv)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Username = username;
            this.Sifra = sifra;
            this.Uloga_naziv = uloga_naziv;
        }

        public Radnik(string ime, string prezime, string username, string sifra, string uloga_naziv)
        {
            
            this.Ime = ime;
            this.Prezime = prezime;
            this.Username = username;
            this.Sifra = sifra;
            this.Uloga_naziv = uloga_naziv;
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

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Sifra
        {
            get
            {
                return sifra;
            }

            set
            {
                sifra = value;
            }
        }

        internal string Uloga_naziv
        {
            get
            {
                return uloga_naziv;
            }

            set
            {
                uloga_naziv = value;
            }
        }

        public override string ToString()
        {
            return id + " " + ime;
        }


    }
}
