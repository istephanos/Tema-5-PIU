using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Masina
    {
        //constante
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int ID = 0;
        private const int FIRMA = 1;
        private const int MODEL = 2;
        private const int AN_FABRICATIE = 3;
        private const int CULOARE = 4;
        private const int OPTIUNE = 5;
        private const int DISPONIBILITATE =6;

        //proprietati auto-implemented

        public int idMasina { get; set; }//identificator unic 
        public string firma { get; set; } //ex:Audi
        public string model { get; set; }//A4
        public string an_fabricatie { get; set; }
        public Culori CuloriDipsonibile { get; set; }
        public Optiuni OptiuniDisponibile { get; set; }
        public bool disponibilitate { get; set; }
        //enum optiuni
        public enum Optiuni
        {
            AerConditionat=1,
            GeamuriElectrice=2,
            Navigatie=3,
            CutieAutomata=4,
            FaruriCeata=5,
            ScauneIncalzite=6,
            OglinziIncalzite=7
        }

        //enum culori masina
        public enum Culori
        {
            alb=0,
            negru=1,
            argintiu=2,
            auriu=3,
            albastru=4,
            gri=5,
            galben=6,
            portocaliu=7,
            verde=8,
            turcoaz=9
        }
        //constructor implicit
        public Masina()
        {
            disponibilitate=true;
            firma = model = an_fabricatie = string.Empty;
            CuloriDipsonibile = Culori.alb;
            OptiuniDisponibile = Optiuni.AerConditionat; 
        }
        //constructor cu parametri
        public Masina(int _id, string _firma, string _model, string _an_fabricatie, Culori _culoare, Optiuni _optiune)
        {
            idMasina = _id;
            firma = _firma;
            model = _model;
            an_fabricatie = _an_fabricatie;
            CuloriDipsonibile = _culoare;
            OptiuniDisponibile = _optiune;
            disponibilitate = true;
        }

        public Masina(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            idMasina = Convert.ToInt32(dateFisier[ID]);
            firma = dateFisier[FIRMA];
            model = dateFisier[MODEL];
            an_fabricatie = dateFisier[AN_FABRICATIE];
            CuloriDipsonibile = (Culori)Convert.ToInt32(dateFisier[CULOARE]);
            OptiuniDisponibile= (Optiuni)Convert.ToInt32(dateFisier[OPTIUNE]);
            disponibilitate = Convert.ToBoolean(dateFisier[DISPONIBILITATE]);
        }
        public string ConversieLaSir_PentruFisier()
        {
            string obiectMasinaPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}",
                SEPARATOR_PRINCIPAL_FISIER,
                idMasina.ToString(),
                (firma ?? " NECUNOSCUT "),
                (model ?? " NECUNOSCUT "),
                (an_fabricatie ?? " NECUNOSCUT "),
                (CuloriDipsonibile.ToString()),
                (OptiuniDisponibile.ToString()),
                (disponibilitate , "NECUNOSCUT"));

            return obiectMasinaPentruFisier;
        }
        //Id masina(numar de inregistrare)
        public int GetIdMasina
        {
            get
            {
                return idMasina;
            }
        }
        //firma(marca) masina
        public string GetFirma
        {
            get
            {
                return firma;
            }
        }
        //model masina
        public string GetModel
        {
            get
            {
                return model;
            }
        }
        //an fabricatie
        public string GetAnFabricatie
        {
            get
            {
                return an_fabricatie;
            }
        }
        //verificare disponibilitate masina
        public string Disponibilitate()
        {
            Masina m=new Masina();
                if (m.disponibilitate == true)
                    return "Masina disponibila";
                else
                    return "Masina indisponibila";
            
        }
        public string GetCuloare
        {
            get
            {
                 return CuloriDipsonibile.ToString();
            }
        }
        public string GetOptiune
        {
            get
            {
                return OptiuniDisponibile.ToString();
            }
        }
    }
}
