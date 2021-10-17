using L02.Models;
using System.Collections.Generic;

namespace L02.Repositories
{
    public class StudentRepo
    {
        public static List<Student> Studenti = new List<Student>() {
            new Student { id = 1, nume = "Matei", facultate = "AC", an = 3 },
            new Student { id = 2, nume = "Marius", facultate = "ETC", an = 4 }
        };
    }
}