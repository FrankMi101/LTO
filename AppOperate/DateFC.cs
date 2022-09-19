using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public class DateFC
    {
        public DateFC()
        { }
        public static string WorkDay(DateTime vDate)
        {
            if (vDate.DayOfWeek == DayOfWeek.Saturday) vDate = vDate.AddDays(1);
            if (vDate.DayOfWeek == DayOfWeek.Sunday) vDate = vDate.AddDays(1);

            return YMD(vDate);
        }
        public static string Format(DateTime pDate, string pFormat)
        {
            //  string iDate = "05/05/2005";
            //  DateTime oDate = Convert.ToDateTime(iDate);
            try
            {
                string rValue = "";
                if (pDate.GetType().Name == "DateTime")
                {
                    string vYY = pDate.Year.ToString();
                    string vMM = pDate.Month.ToString();
                    string vDD = pDate.Day.ToString();
                    int iMM = pDate.Month; //.ToString();
                    int iDD = pDate.Day; //.ToString();
                    if (iMM < 10)
                    { vMM = "0" + iMM.ToString(); }
                    if (iDD < 10)
                    { vDD = "0" + iDD.ToString(); }
                    switch (pFormat)
                    {
                        case "YYYYMMDD":
                            rValue = vYY + "/" + vMM + "/" + vDD;
                            break;
                        case "DDMMYYYY":
                            rValue = vDD + "/" + vMM + "/" + vYY;
                            break;
                        case "MMDDYYYY":
                            rValue = vMM + "/" + vDD + "/" + vYY;
                            break;
                        case "MMMDDYYYY":
                            string sMonthName = pDate.ToString("MMM");
                            rValue = sMonthName + "/" + vDD + "/" + vYY;
                            break;
                        default:
                            rValue = vYY + "/" + vMM + "/" + vDD;
                            break;
                    }
                }
                else
                { rValue = pDate.ToString(); }
                return rValue;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return pDate.ToString();
            }
        }
        public static string YMDStr(string vDate)
        {
            string rDate = "";
            try
            {
                if (vDate == null)
                { rDate = ""; }
                else
                {
                    rDate = vDate.Replace("-", "/");
                }
                return rDate;

            }
            catch
            {
                return rDate;
            }

        }
        public static string YMD(DateTime vDate)
        {
            try
            {
                return YMDF("/", vDate);
            }
            catch (Exception)
            {
                return vDate.ToString();
            }
        }
        public static string YMDHMS(DateTime vDate)
        {
            try
            {
                return vDate.ToString("yyyy/MM/dd-HH:mm:ss");
            }
            catch (Exception)
            {
                DateTime now = DateTime.Today;
                return now.ToString("yyyy/MM/dd-HH:mm:ss");
            }


        }
        public static string YMD(DateTime vDate, string linkStr)
        {
            try
            {
                return YMDF(linkStr, vDate);
            }
            catch (Exception)
            {
                return vDate.ToString();
            }

        }
        public static string YMD(DateTime vDate, string linkStr, string skipWeekEnd)
        {
            if (skipWeekEnd == "Y")
            {
                if (vDate.DayOfWeek == DayOfWeek.Saturday) vDate = vDate.AddDays(1);
                if (vDate.DayOfWeek == DayOfWeek.Sunday) vDate = vDate.AddDays(1);
            }

            return YMDF(linkStr, vDate);
        }

        public static string YMD(string vDate, string linkStr, string skipWeekEnd)
        {
            DateTime nDate = YMD(vDate);
            if (skipWeekEnd == "Y")
            {
                if (nDate.DayOfWeek == DayOfWeek.Saturday) nDate = nDate.AddDays(1);
                if (nDate.DayOfWeek == DayOfWeek.Sunday) nDate = nDate.AddDays(1);
            }

            return YMDF(linkStr, nDate);
        }

        private static string YMDF(string linkStr, DateTime vDate)
        {
            if (string.IsNullOrEmpty(linkStr)) linkStr = "-";
            string rDate = "";
            try
            {
                if (vDate == null)
                { rDate = ""; }
                else
                {
                    string vYY = vDate.Year.ToString();
                    string vMM = vDate.Month.ToString();
                    string vDD = vDate.Day.ToString();
                    if (vDate.Month < 10)
                    { vMM = "0" + vMM; }
                    if (vDate.Day < 10)
                    { vDD = "0" + vDD; }
                    rDate = vYY + linkStr + vMM + linkStr + vDD;
                }
                return rDate;
            }
            catch
            {
                return rDate;
            }
        }
        public static DateTime YMD(string eDate)
        {
            try
            {
                string[] format = new[] { "dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "yyyy/MM/dd", "yyyy-MM-dd" };
                DateTime oDate = DateTime.ParseExact(eDate, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None);
                return oDate;

            }
            catch (Exception ex)
            {

                return DateTime.Now;
            }
        }
        public static string YMD2(string eDate)
        {
            try
            {
                string[] format = new[] { "dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "yyyy/MM/dd" };
                DateTime oDate = DateTime.ParseExact(eDate, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None);
                return YMD(oDate);

            }
            catch (Exception)
            {

                return eDate;
            }
        }

        public static int Age(DateTime BirthDate)
        {
            DateTime now = DateTime.Today;
            return Age(BirthDate, now);


        }
        public static int Age(DateTime birthdate, DateTime comparedate)
        {

            int age = comparedate.Year - birthdate.Year;
            if (comparedate < birthdate.AddYears(age))
            { age--; }

            return age;
        }


        public static string SchoolYearFrom(string strType, string cSchoolYear)
        {
            string bYear = cSchoolYear.Substring(0, 4);
            string eYear = cSchoolYear.Substring(4, 4);
            return bYear + strType + eYear;
        }

        public static string SchoolYearNext(string strType, string cSchoolYear)
        {
            string bYear = cSchoolYear.Substring(4, 4);
            int iYear = int.Parse(bYear) + 1;
            string eYear = iYear.ToString();
            return bYear + strType + eYear;
        }

        public static string SchoolYearPrevious(string strType, string cSchoolYear)
        {
            string eYear = cSchoolYear.Substring(0, 4);
            int iYear = int.Parse(eYear) - 1;

            string bYear = iYear.ToString();
            return bYear + strType + eYear;
        }

        public static string YearTOGO(string strType, string cSchoolYear)
        {
            try
            {
                int thisYear = 2000;
                string rSchoolyear = "";
                DateTime vDate = DateTime.Now;
                var vMM = vDate.Month;
                if (vMM < 10)
                    thisYear = int.Parse(cSchoolYear.Substring(0, 4));
                else
                    thisYear = int.Parse(cSchoolYear.Substring(4, 4));
                int goYear = 0;
                if (strType == "Next")
                {
                    goYear = thisYear + 1;
                    rSchoolyear = thisYear.ToString() + goYear.ToString();
                }
                else
                {
                    goYear = thisYear - 1;
                    var preYear = goYear - 1;
                    rSchoolyear = preYear.ToString() + goYear.ToString();
                }
                return rSchoolyear;
            }
            catch
            {
                return cSchoolYear;
            }
        }
        public static string YearTOGO(string strType, int cMonth, string cSchoolYear)
        {
            try
            {
                int thisYear = 2000;
                string rSchoolyear = "";
                DateTime vDate = DateTime.Now;
                var vMM = vDate.Month;
                if (cMonth < 10)
                    thisYear = int.Parse(cSchoolYear.Substring(0, 4));
                else
                    thisYear = int.Parse(cSchoolYear.Substring(4, 4));
                int goYear = 0;
                if (strType == "Next")
                {
                    goYear = thisYear + 1;
                    rSchoolyear = thisYear.ToString() + goYear.ToString();
                }
                else
                {
                    goYear = thisYear - 1;
                    var preYear = goYear - 1;
                    rSchoolyear = preYear.ToString() + goYear.ToString();
                }
                return rSchoolyear;

            }

            catch
            {
                return cSchoolYear;
            }
        }
        public static string CurrentYearString()
        {
            DateTime now = DateTime.Today;
            return now.Year.ToString();
        }
    }

}
