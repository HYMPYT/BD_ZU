using System;
using System.Collections.Generic;
using System.Text;

namespace BDLZ.Models
{
    public class LecturesPlan
    {
        public int id { get; set; }
        public int day_of_week { get; set; }
        public int group_id { get; set; }
        public int subject_id { get; set; }
        public int teacher_id { get; set; }

    }
}
