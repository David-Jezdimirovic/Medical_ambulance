using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS322_PZ
{
    class Uloga
    {
        private int id;
        private string naziv;

        public Uloga() { }

        public Uloga(int id, string naziv)
        {
            this.id = id;
            this.naziv = naziv;
           
        }

        public string Id
        {
            get;
            set;
        }

        public string Naziv
        {
            get;
            set;
        }


        public override string ToString()
        {
            return id +" "+ naziv;
        }

        public static implicit operator Uloga(DataRow v)
        {
            Uloga u = new Uloga();
           
            u.id = Int32.Parse(v.ItemArray[0].ToString());
            u.naziv = v.ItemArray[1].ToString();
          

            return u;
        }
    }
}
