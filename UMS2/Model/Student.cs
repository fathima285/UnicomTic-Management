﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS2.Model
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIC { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
