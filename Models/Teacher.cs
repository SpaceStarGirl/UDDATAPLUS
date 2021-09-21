using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDDATA.Models
{
    public enum Subjects { Science, Music, Math }
    sealed class Teacher : Person
    {
        public string CoffeeClub { get; set; }
        public Subjects Subjects { get; set; }
        public List<Student> StudentListProperty { get; set; }

        public List<Student> studentList = new List<Student>();

    }
}
