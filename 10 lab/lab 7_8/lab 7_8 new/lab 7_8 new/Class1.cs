using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 
namespace lab_7_8_new
{
    public interface ICommand
    {
        event EventHandler CanExecuteChanged;
        void Execute(object parameter);
        bool CanExecute(object parameter);
    }
  
    [Serializable]
    public class Zam
    {
        public string kratkoe_nazvaniye;
        public string polnoe_opisanie;
        public string katigoria;
        public string preoritet;
        public DateTime datetime;
        public bool status;
        public string status2;

        public string Kratkoe_nazvaniye
        {
            get
            { return kratkoe_nazvaniye; }
            set
            { kratkoe_nazvaniye = value; }
        }
        public string Polnoe_opisanie
        {
            get
            { return polnoe_opisanie; }
            set
            { polnoe_opisanie = value; }
        }
        public string Katigoria
        {
            get
            { return katigoria; }
            set
            { katigoria = value; }
        }
        public string Preoritet
        {
            get
            {
                return preoritet;
            }
            set
            {
                preoritet = value;
            }
        }
        public string Datetime
        {
            get
            {
                return Convert.ToString( datetime);
            }
            set
            {
                datetime =Convert.ToDateTime( value);
            }
        }
        public bool Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                if (status == false)
                {
                    status2 = "невыполненная";
                }
                else 
                {
                    status2 = "выполненная";
                }
            }
        }
        public string Status2
        {
            get
            {
                return status2;
            }
            set
            {
                status2 = value;
            }
        }
            
    }
}
