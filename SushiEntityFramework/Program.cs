using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * "Student1 Name"             * 
            *insert new value to database
             * 
             * using (var db = new StudentContext())
            {
                var student = new Student() {Name = "Student1 Name" };
                var subjMath = new Subject() {Name = "math"};
                var subjLang = new Subject() {Name = "eng"};
                student.Subjects.Add(subjMath);
                student.Subjects.Add(subjLang);
                db.Students.Add(student);
                db.SaveChanges(); 
            }*/

           
            Console.ReadKey();
        }
    }
}
