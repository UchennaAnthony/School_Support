﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSupport.Model.Model
{
    public class StudentLevel
    {
        public long Id { get; set; }
        public Student Student { get; set; }
        public Person person { get; set; }
        public Level Level { get; set; }
        public Programme Programme { get; set; }
        public Department Department { get; set; }
        public DepartmentOption DepartmentOption { get; set; }
        public Session Session { get; set; }
    }
}
