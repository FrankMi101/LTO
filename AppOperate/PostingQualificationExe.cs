using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
   public  class PostingQualificationExe
    {
    
        public static IList<QualificationSelected> Qual(ParametersForPosition parameter)
        {
            var mylist = new PostingQualification();
            return mylist.rList(parameter);
        }
        public static string UpdateQual(QualificationUpdate qual)
        {
            var myval = new PostingQualification();
            return myval.QualificationUpdate(qual);
        }

    }
}
