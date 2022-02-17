using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DecisiMaratonaApp
{
    class Dati
    {
        public List<Dato> CollezioneDati { get; set; }

        public Dati()
        {
            CollezioneDati = new List<Dato>();
        }

        public void AggiungiDocumento(Dato documento)
        {
            CollezioneDati.Add(documento);
        }

        public void LeggiDaFile()
        {
            using (FileStream flusso = new FileStream("dati.txt", FileMode.Open, FileAccess.Read))
            {
                StreamReader reader = new StreamReader(flusso);

                string contenuto = "";
                while (!reader.EndOfStream)
                {
                    string linea = reader.ReadLine();
                    string[] campi = linea.Split('%');

                    var unDocumento = new Dato();
                    unDocumento.NomeAtleta = campi[0];
                    unDocumento.Societa = campi[1];
                    unDocumento.Durata = TempoinMinuti(campi[2]);
                    unDocumento.Citta = campi[3];

                    AggiungiDocumento(unDocumento);
                }
            }
        }

        public int TempoinMinuti(string Durata)
        {
            int min = 0;
            int ore = int.Parse(Durata.Substring(0, 2));
            int minuti = int.Parse(Durata.Substring(3, 2));

            min = (ore * 60) + minuti;

            return min;
        }

        public int DurataMaratona(string Durata, string NomeAtleta, string Citta)
        {
            int duratamaratona = 0;

            foreach(var dati in CollezioneDati)
            {
                if(NomeAtleta == dati.NomeAtleta && Citta == dati.Citta)
                {
                    duratamaratona = dati.Durata;
                }
            }
            return duratamaratona;
        }

        public string CercaPartecipanti (string Citta)
        {
            string partecipanti = "";

            foreach(var lista in CollezioneDati)
            {
                if(Citta == lista.Citta)
                {
                    partecipanti += lista.NomeAtleta + " - ";
                }
            }
            return partecipanti;
        }

        public void Salva()
        {
            using (FileStream flusso = new FileStream("dati.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                StreamWriter scrittore = new StreamWriter(flusso);
                foreach (var documento in CollezioneDati)
                {
                    scrittore.WriteLine(documento.ConcatenaValori());
                }
                scrittore.Flush();
            }
        }
    }
}
