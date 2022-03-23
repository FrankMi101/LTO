using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        List<T> ListOfT(string spName, object para);

        T ObjectOfT( string spName, object para );

        string ValueString( string spName, object para );

        T ValueOfT( string spName, object para );


        List<T> ListOfT(string db, string spName, object para);

        T ObjectOfT(string db, string spName, object para);

        string ValueString(string db, string spName, object para);
        string ValueString(string db, string spName, T para);

        T ValueOfT(string db, string spName, object para);
    }
}
