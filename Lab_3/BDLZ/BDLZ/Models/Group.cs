using System;
using System.Collections.Generic;
using System.Text;

namespace BDLZ.Models
{
    public class Group
    {
        public int id { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        public int amount_of_students { get; set; }
        public int faculty_id { get; set; }
    }
}
