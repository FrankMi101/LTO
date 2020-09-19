using AppOperate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            AbstractFactory shapeFactory = FactoryProducer.getFactory("SHAPE");
            Shape shape1 = shapeFactory.getShape("Circle");
            shape1.draw();
            Shape shape2 = shapeFactory.getShape("Square");
            shape2.draw();
            Shape shape3 = shapeFactory.getShape("Rectangle");
            shape3.draw();
            var line = Console.ReadLine();


            AbstractFactory colorFactory = FactoryProducer.getFactory("COLOR");
            Color col1 = colorFactory.getColor("Red");
            col1.fill();
            Color col2 = colorFactory.getColor("Blue");
            col2.fill();
            Color col3 = colorFactory.getColor("Green");
            col3.fill();
            line = Console.ReadLine();



        }

        void Students_Delgate_LinQ()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

            //  delegate (Student s) { return s.Age > 12 && s.Age < 20; };

            Func<Student, bool> isStudentTeenAger = s => s.Age > 12 && s.Age < 20;

            var teenStudents = from s in studentList
                               where isStudentTeenAger(s)
                               select s;

            bool isStudentTeenAger1(Student s)
            {
                return s.Age > 12 && s.Age < 20;
            }
            var teenStudents1 = from s in studentList
                               where isStudentTeenAger1(s)
                               select s;



        }


    }
}
