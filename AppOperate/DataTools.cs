using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;


namespace AppOperate
{
    public class DataTools
    {
        public static DataTable ListToDataTable<T>(IList<T> data)
        {
            DataTable table = new DataTable();

            //special handling for value types and string
            if (typeof(T).IsValueType || typeof(T).Equals(typeof(string)))
            {

                DataColumn dc = new DataColumn("Value");
                table.Columns.Add(dc);
                foreach (T item in data)
                {
                    DataRow dr = table.NewRow();
                    dr[0] = item;
                    table.Rows.Add(dr);
                }
            }
            else
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
                foreach (PropertyDescriptor prop in properties)
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                    {
                        try
                        {
                            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        }
                        catch (Exception ex)
                        {
                            var ms = ex.Message;
                            row[prop.Name] = DBNull.Value;
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }
        public static string SchoolPanel(string schoolCode)
        {
            string elementaryPanel = WebConfigValue.getValuebyKey("ElementaryPanel");
            if (schoolCode.Substring(0, 2) == "05")
            { return "S"; }
            else if (elementaryPanel.IndexOf(schoolCode.Substring(0, 2)) == -1 )
            { return "D"; }
            else
            { return "E"; }
        }
        public static string CheckEmail(string email)
        {
            try
            {
                if (!email.Contains("@"))
                {
                   return email + "@tcdsb.org";
                }
                else
                   return email;
            }
            catch (Exception ex)
            {
                return email;
               // throw ex;
            }
        }
    }
}
