using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DecisiMaratonaApp
{
    class Dato
    {
        public string NomeAtleta { get; set; }
        public string Societa { get; set; }
        public int Durata { get; set; }
        public string Citta { get; set; }

        public string ConcatenaValori()
        {
            return NomeAtleta + "%" + Societa + "%" + Durata + "%" + Citta;
        }

        public string ConcatenaValoriAnalizzati()
        {
            return NomeAtleta + "%" + Durata;
        }

    }
}
