using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppOperate.Execute
{
    public class VaildateName
    {

        private static void ValidateStudent(Student std)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");

            if (!regex.IsMatch(std.StudentName))
                throw new InvalidStudentNameException(std.StudentName);

        }

        private static void Vaildate()
        {
            Student newStudent = null;

            try 
            {
                newStudent = new Student
                {
                    FirstName = "Frank002",
                    LastName = "Miller"
                };
                ValidateStudent(newStudent);
            }
            catch (InvalidStudentNameException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
    public class Student
    {
        public int StudentID { get; set; }
        public string  FirstName { get; set; }
        public string  LastName { get; set; }

        public string  StudentName {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    }

    [Serializable]
    class InvalidStudentNameException : Exception
    {
        public InvalidStudentNameException()
        {

        }

        public InvalidStudentNameException(string name)
            : base(String.Format("Invalid Student Name: {0}", name))
        {

        }

    }
}
