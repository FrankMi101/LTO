using ClassLibrary;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess.Common
{
    public class GeneralDataAccess
    {
        static string conSTR = DBConnectionHelper.ConnectionSTR();

        public static List<T> ListofT<T>(string sp, Parameters<T> parameter)
        {
            {// T will be class type. such are School, person, Staff and so on. 
                using (IDbConnection connection = new SqlConnection(conSTR))
                {
                    var tlist = connection.Query<T>(sp, parameter).ToList();
                    return tlist;
                }
            }

        }
        public static List<T> ListofT<T>(string sp, object parameter)
        {
            {// T will be class type. such are School, person, Staff and so on. 
                using (IDbConnection connection = new SqlConnection(conSTR))
                {
                    var tlist = connection.Query<T>(sp, parameter).ToList();
                    return tlist;
                }
            }

        }
        public static List<T> GetListofTypeT<T>(string sp, object parameter)
        {// T will be class type. such are School, person, Staff and so on. 

            try
            {
                using (IDbConnection connection = new SqlConnection(conSTR))
                {
                    var tlist = connection.Query<T>(sp, parameter).ToList();
                    return tlist;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public static List<T> GetObjectList<T>(string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                var mylist = connection.Query<T>(sp, parameter).ToList();
                return mylist;
            }
        }

        public static T ValueOfT<T>(string sp, Parameters<T> parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                var myValue = connection.QuerySingle<T>(sp, parameter);
                return myValue;
            }
        }

        public static T ValueOfT<T>(string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                //var myText = connection.QuerySingle<SingleString>(sp, parameter);
                //return myText.MyValue;
                var myValue = connection.QuerySingle<T>(sp, parameter);
                return myValue;//  .MyValue;
            }
        }
        public static object TextValue<T>(string sp, object parameter)
        {
            using (IDbConnection connection = new SqlConnection(conSTR))
            {
                //var myText = connection.QuerySingle<SingleString>(sp, parameter);
                //return myText.MyValue;
                var myValue = connection.QuerySingle<T>(sp, parameter);
                return myValue;//  .MyValue;
            }
        }
        public static string TextValue(string sp, object parameter)
        {
            return ValueOfT<string>(sp, parameter);
            //using (IDbConnection connection = new SqlConnection(conSTR))
            //{
            //    //var myText = connection.QuerySingle<SingleString>(sp, parameter);
            //    //return myText.MyValue;
            //    var myText = connection.QuerySingle<string>(sp, parameter);
            //    return myText;//  .MyValue;
            //}
        }

        public static bool BoolValue(string sp, object parameter)
        {
            return ValueOfT<bool>(sp, parameter);
            //using (IDbConnection connection = new SqlConnection(conSTR))
            //{
            //    var result = connection.QuerySingle<bool>(sp, parameter);
            //    return result;

            //}
        }

        public static DateTime DtValue(string sp, object parameter)
        {
            return ValueOfT<DateTime>(sp, parameter);
        }

        //public static List<SiteTeams> GetListsold(string operate, string userID, string userRole, string schoolYear, string schoolCode)
        //{
        //    using (IDbConnection connection = new SqlConnection(conSTR))
        //    {
        //        // connection.Query is a Dapper function
        //        //var output = connection.Query<Person>($"select * from People where LastName = '{lastName }'").ToList();
        //        string SP = "dbo.tcdsb_PLF_SchoolSiteTeamNew  @Operate,@UserID, @SchoolYear,@SchoolCode";
        //        ParameterSP1 parameter = new ParameterSP1 { Operate = operate, UserID = userID, UserRole = userRole, SchoolYear = schoolYear, SchoolCode = schoolCode };
        //        var mylist = connection.Query<SiteTeams>(SP, parameter).ToList();
        //        //  new { Operate = operate, UserID = userID, SchoolYear = schoolYear, SchoolCode = schoolCode,SchoolArea = schoolArea }).ToList();
        //        return mylist;
        //    }
        //}
        public static bool IsStringNull(string s)
        {
            return (s == null || s == String.Empty) ? true : false;
        }


    }
}
