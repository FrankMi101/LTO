using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    class MainApp

    {
        /// <summary>

        /// Entry point into console application.

        /// </summary>

        static void Main()
        {
            // Note: constructors call Factory Method

            FactoryTeacherList[] teacherlists = new FactoryTeacherList[2];

            teacherlists[0] = new TeacherListCandidate();
            teacherlists[1] = new TeacherListInterview();

           

            // Display document pages

            foreach (FactoryTeacherList document in teacherlists)
            {
                Console.WriteLine("\n" + document.GetType().Name + "--");
                foreach (TeacherList page in document.Teachers)
                {
                    Console.WriteLine(" " + page.GetType().Name);
                    
                }
            }

            // Wait for user

            Console.ReadKey();
        }
    }

    public abstract class FactoryTeacherList
    {   /// <summary>
        /// this is create list of Teacher factory
        /// </summary>
        private List<TeacherList> _teacherlist = new List<TeacherList>();
        public FactoryTeacherList()
        {
            this.CreateList();
        }
        public List<TeacherList> Teachers
        {
            get { return _teacherlist; }
        }
        public abstract List<TeacherList> CreateList();
       

    }
    public class TeacherListCandidate : FactoryTeacherList
    {
        public override List<TeacherList> CreateList()
        {
            Teachers.Add(new TeacherListForPrincipalInterview());
            return null;
        }
    }
    public class TeacherListInterview : FactoryTeacherList
    {
        public override List<TeacherList> CreateList()
        {
            Teachers.Add(new TeacherListForPrincipalInterview());
            return null;
        }
    }

}
