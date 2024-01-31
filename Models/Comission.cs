using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_work.Models
{
    internal class Comission
    {
        public string id { get; set; }

        public string employee_id { get; set; }

        public int number_of_properties { get; set; }

        public int week { get; set; }   


        public decimal comission_amount { get; set; }   

        public int bonus_applied { get; set; }  

    }
}
