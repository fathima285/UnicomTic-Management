using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS2.Model
{
    internal class ClassTimetable
    {
        public int Id { get; set; }
        public int? SubjectId { get; set; }
        public string Room { get; set; }
        public DateTime ClassDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}

