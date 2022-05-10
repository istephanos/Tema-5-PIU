using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;
using System.IO;


namespace StocareDateClienti
{
    public class AdministrareMasini_FisierText
    {
        private const int NR_MAX_MASINI = 50;
        private string numeFisier1;

        public AdministrareMasini_FisierText(string numeFisier1)
        {
            this.numeFisier1 = numeFisier1;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisier1, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddMasina(Masina masina)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier1, true))
            {
                streamWriterFisierText.WriteLine(masina.ConversieLaSir_PentruFisier());
            }
        }

        public Masina[] GetMasini(out int nrMasini)
        {
            Masina[] masini = new Masina[NR_MAX_MASINI];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier1))
            {
                string linieFisier;
                nrMasini = 0;
                // citeste cate o linie si creaza un obiect de tip Masina
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    masini[nrMasini++] = new Masina(linieFisier);
                }
            }
            return masini;
        }


        public Masina GetMasina(string firma, string model, string an_fabricatie, int NrCuloare)
        {
            using (StreamReader streamReader = new StreamReader(numeFisier1))
            {
                string lin;
                while ((lin = streamReader.ReadLine()) != null)
                {
                    Masina masina = new Masina(lin);
                    if (masina.GetFirma == firma && masina.GetModel ==model)//&& masina.GetAnFabricatie()== an_fabricatie && masina.GetCuloare()==culoare
                        return masina;
                }
            }
            Masina m = new Masina();
            return m;
        }
    }
}
