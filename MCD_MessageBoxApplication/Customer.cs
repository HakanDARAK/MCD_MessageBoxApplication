using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCD_MessageBoxApplication
{
    public class Customer
    {
        public Guid id { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public string emailAdress { get; set; }
        public string telno { get; set; }

        public override string ToString()
        {
            return isim + " " + soyisim + " " + emailAdress + " " + telno;
        }
    }
}
