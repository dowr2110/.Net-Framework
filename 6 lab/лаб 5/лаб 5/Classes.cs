using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace лаб_5
{
    [Serializable]
    public class Vladelec
    {
   
        public string name;
        public string family_name;
        public string otcest;
        public string date_of_birth;
        public string pasportno;
        public string personalno;
        public string sex;
        public string place_of_birth;

      

        public string Name
        {
            get
            { return name; }
            set
            { name = value; }
        }
        public string Family_name
        {
            get
            { return family_name; }
            set
            { family_name = value; }
        }
        public string Otcest
        {
            get
            { return otcest; }
            set
            { otcest = value; }
        }
        public string Date_of_birth
        {
            get
            {
                return date_of_birth;
            }
            set
            {
                date_of_birth = value;
            }
        }
        public string Pasportno
        {
            get
            {
                return pasportno;
            }
            set
            {
                pasportno = value;
            }
        }
        public string Personalno
        {
            get
            {
                return personalno;
            }
            set
            {
                personalno = value;
            }
        }
        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }
        public string Place_of_birth
        {
            get
            {
                return place_of_birth;
            }
            set
            {
                place_of_birth = value;
            }
        }

    }

    [Serializable]
    public class Scet
    {
       
        public int nomer;
        [Required(ErrorMessage = "error")]
        public string tip_vklada;
        public int balans;
        public string data_open;
        public string opevesh;
        public string opevesh2;
       
        public Vladelec vladelec;
     



        public int Nomer
        {
            get
            {
                return nomer;
            }
            set
            {
                nomer = value;
            }
        }
        public string Tip_vklada
        {
            get
            {
                return tip_vklada;
            }
            set
            {
                tip_vklada = value;
            }
        }
        public int Balans
        {
            get
            {
                return balans;
            }
            set
            {
                balans = value;
            }
        }
        public string Data_open
        {
            get
            {
                return data_open;
            }
            set
            {
                data_open = value;
            }
        }
        public string Opevesh
        {
            get
            {
                return opevesh;
            }
            set
            {
                opevesh = value;
            }
        }
        public string Opevesh2
        {
            get
            {
                return opevesh2;
            }
            set
            {
                opevesh2 = value;
            }
        }
        public Vladelec Vladelec
        {
            get
            {
                return vladelec;
            }
            set
            {
                vladelec = value;
            }
        }

        public Scet()
        { }
        public Scet(Vladelec vld)
        {
            Vladelec = vld;
        }
    }
}
