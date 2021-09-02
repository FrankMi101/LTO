using ClassLibrary;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AppOperate
{
    public static class AssembleListItem
    {
        private static List<List2Item> GetListData(object parameter)
        {
             string sp = "dbo.tcdsb_LTO_ListDDLNew @Operate,@Para0,@Para1,@Para2,@Para3";
             var myListData =   GeneralDataAccess.GetListofTypeT<List2Item>(sp, parameter);
           // var myListData = GeneralExe.DDList(parameter); //  GeneralDataAccess.GetListofTypeT<List2Item>(sp, parameter);
            return myListData;
        }
        public static void SetSearchList(System.Web.UI.WebControls.ListControl myListControl, string operate, string para0, string para1)
        {
            List2Item parameter = new List2Item { Operate = operate, Para0 = para0, Para1 = para1 };
             string sp = "dbo.tcdsb_LTO_ListDDL_SearchList @Operate,@Para0,@Para1";
           List<List2Item> myListData = GeneralDataAccess.GetListofTypeT<List2Item>(sp, parameter);
         // myListData = GeneralExe.SearchList(parameter);
            AssemblingMyList(myListControl, myListData);
        }
        //public static void SetLists(System.Web.UI.WebControls.ListControl myListControl, string operate, string userID, string para0, string para1, string para2, string para3)
        //{
        //    List2Item parameter = new List2Item { Operate = operate, Para0 = para0, Para1 = para1, Para2 = para2, Para3 = para3 };
        //    SetLists(myListControl, parameter);
        //}
        public static void SetObjLists(object myListControl, string operate, string userID, string para0, string para1, string para2, string para3)
        {
            List2Item parameter = new List2Item { Operate = operate, Para0 = para0, Para1 = para1, Para2 = para2, Para3 = para3 };
            SetObjLists(myListControl, parameter);
        }
        public static void SetObjLists(object myListControl, object parameter)
        {
            // string sp = "dbo.tcdsb_LTO_ListDDLNew @Operate,@Para0,@Para1,@Para2,@Para3";
            //  List2Item parameter = new List2Item { Operate = operate, Para0 = para0, Para1 = para3, Para2 = para2, Para3 = para3 };
            //  List<List2Item> myListData = GeneralDataAccess.GetListofTypeT<List2Item>(sp, parameter);

            // List<List2Item> myList = UListItem.GetLists(operate, userID, userRole, schoolYear); /// new List<List2Item>();
            AssemblingOBJList(myListControl, GetListData(parameter));
        }

        public static void SetLists(System.Web.UI.WebControls.ListControl myListControl, string ddlType, List2Item parameter)
        {
            // string sp = "dbo.tcdsb_LTO_ListDDLNew @Operate,@Para0,@Para1,@Para2,@Para3";
            parameter.Operate = ddlType;
            List<List2Item> myListData = CommonListExecute.GetListData(parameter);
            AssemblingMyList(myListControl, myListData);//GetListData(parameter));
        }
        public static void SetLists(System.Web.UI.WebControls.ListControl myListControl, string ddlType, List2Item parameter, object initialValue)
        {
            SetLists(myListControl, ddlType, parameter);
            SetValue(myListControl, initialValue);
        }

        //public static void SetLists(System.Web.UI.WebControls.ListControl myListControl, List2Item parameter)
        //{
        //    // string sp = "dbo.tcdsb_LTO_ListDDLNew @Operate,@Para0,@Para1,@Para2,@Para3";
        //    // List<List2Item> myListData = GeneralDataAccess.GetListofTypeT<List2Item>(sp, parameter);
        //    List<List2Item> myListData = CommonListExecute.GetListData(parameter);
        //    AssemblingMyList(myListControl, myListData); //  GetListData(parameter));
        //}
        //public static void SetLists(System.Web.UI.WebControls.ListControl myListControl, List2Item parameter, object initialValue)
        //{
        //    SetLists(myListControl, parameter);
        //    SetValue(myListControl, initialValue);
        //}
        private static void AssemblingMyList(System.Web.UI.WebControls.ListControl myListControl, List<List2Item> myList)
        {
            try
            {
                // List<List2Item> myList = myList;
                myListControl.Items.Clear();
                myListControl.DataSource = myList;
                myListControl.DataTextField = "MyText";
                myListControl.DataValueField = "MyValue";
                myListControl.DataBind();
            }
            catch (Exception ex)
            { var em = ex.Message; }
            finally
            { }
        }
        private static void AssemblingOBJList(object myListControl1, List<List2Item> myList)
        {
            try
            {
                HtmlSelect myListControl = (HtmlSelect)myListControl1;
                // List<List2Item> myList = myList;
                myListControl.Items.Clear();
                myListControl.DataSource = myList;
                myListControl.DataTextField = "MyText";
                myListControl.DataValueField = "MyValue";
                myListControl.DataBind();
            }
            catch (Exception ex)
            {
                var em = ex.Message;
            }
            finally
            { }
        }

        private static void AssemblingMyList(System.Web.UI.WebControls.ListControl myListControl, List<List2Item> myList, string ValueField, string TextField)
        {
            try
            {
                // List<List2Item> myList = myList;
                myListControl.Items.Clear();
                myListControl.DataSource = myList;
                myListControl.DataTextField = TextField;
                myListControl.DataValueField = ValueField;
                myListControl.DataBind();
            }
            catch (Exception ex)
            { var em = ex.Message; }
            finally
            { }
        }
        public static void SetValueMultiple(System.Web.UI.WebControls.ListControl myListControl, string value)
        {
            try
            {
                if (myListControl.Items.Count > 0)
                {
                    if (value != null)
                    {
                        myListControl.ClearSelection();
                        foreach (ListItem item in myListControl.Items)
                        {
                            if (value.IndexOf(item.Value) != -1)
                            {
                                item.Selected = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public static void SetValue(System.Web.UI.WebControls.ListControl myListControl, object objectValue)

        {
            try
            {
                myListControl.ClearSelection();
                if (myListControl.Items.Count > 0)
                {
                    if (myListControl.Items.Count == 1)
                    {
                        myListControl.SelectedIndex = 0;
                    }
                    else
                    {
                        if (objectValue != null)
                        {
                            if (objectValue.ToString() == "0")
                            {
                                myListControl.SelectedIndex = 0;
                            }
                            else
                            {
                                foreach (ListItem item in myListControl.Items)
                                {
                                    if (item.Value.ToString().ToLower() == objectValue.ToString().ToLower())
                                    {
                                        item.Selected = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                if (myListControl.Items.Count > 0)
                { myListControl.SelectedIndex = 0; }
                else
                {
                    var error = ex.Message;
                    throw new Exception(error);
                }

            }
        }
        public static void SetObjValue(object myListControl, object objectValue)
        {
            HtmlSelect myListControl1 = (HtmlSelect)myListControl;
            try
            {


                if (myListControl1.Items.Count > 0)
                {
                    if (myListControl1.Items.Count == 1)
                    {
                        myListControl1.SelectedIndex = 0;
                    }
                    else
                    {
                        if (objectValue != null)
                        {
                            if (objectValue.ToString() == "0")
                            {
                                myListControl1.SelectedIndex = 0;
                            }
                            else
                            {
                                foreach (ListItem item in myListControl1.Items)
                                {
                                    if (item.Value.ToString().ToLower() == objectValue.ToString().ToLower())
                                    {
                                        item.Selected = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                if (myListControl1.Items.Count > 0)
                { myListControl1.SelectedIndex = 0; }
                else
                {
                    var error = ex.Message;
                    throw new Exception(error);
                }

            }
        }

        public static void SetLists2(System.Web.UI.WebControls.ListControl myListControl, System.Web.UI.WebControls.ListControl myListControl2, object parameter)
        {
            string sp = "dbo.tcdsb_LTO_ListSchoolsNew  @Operate, @Para0, @Para1, @Para2, @Para3";
            List<List2Item> myListData = GeneralDataAccess.GetListofTypeT<List2Item>(sp, parameter);
            AssemblingSchoolList(myListControl, myListControl2, myListData);
        }
        public static void SetLists2(System.Web.UI.WebControls.ListControl myListControl, System.Web.UI.WebControls.ListControl myListControl2, List2Item parameter, object initialValue)
        {
            SetLists2(myListControl, myListControl2, parameter);
            SetValue(myListControl, initialValue);
            SetValue(myListControl2, initialValue);
        }

        public static void SetLists2(System.Web.UI.WebControls.ListControl myListControl, System.Web.UI.WebControls.ListControl myListControl2, string operate, string userID, string userRole, string schoolYear, string schoolCode)
        {
            // string sp = "dbo.tcdsb_LTO_ListDDLNew @Operate,@Para0,@Para1,@Para2,@Para3";
            List2Item parameter = new List2Item { Operate = "SchoolList", Para0 = userID, Para1 = userRole, Para2 = schoolYear, Para3 = schoolCode };
            SetLists2(myListControl, myListControl2, parameter);


        }
        private static void AssemblingSchoolList(System.Web.UI.WebControls.ListControl myListControl, System.Web.UI.WebControls.ListControl myListControl2, List<List2Item> myList)
        {
            try
            {
                List<List2Item> myList2 = myList.OrderBy(o => o.MyValue).ToList();
                AssemblingMyList(myListControl, myList2, "myValue", "myValue"); // school Code DDL

                AssemblingMyList(myListControl2, myList, "myValue", "myText"); // School Name DDL

            }
            catch (Exception ex)
            { var em = ex.Message; }
            finally
            { }
        }

        public static void SetLists3(System.Web.UI.WebControls.ListControl myListControl1, System.Web.UI.WebControls.ListControl myListControl2, System.Web.UI.WebControls.ListControl myListControl3, List2Item parameter, object initialValue)
        {
            SetLists3(myListControl1, myListControl2, myListControl3, parameter);
            SetValue(myListControl1, initialValue);
            SetValue(myListControl2, initialValue);
            SetValue(myListControl3, initialValue);
        }
        public static void SetLists3(System.Web.UI.WebControls.ListControl myListControl1, System.Web.UI.WebControls.ListControl myListControl2, System.Web.UI.WebControls.ListControl myListControl3, object parameter)
        {
            string sp = "dbo.tcdsb_LTO_ListSchoolPrincipalsNew @Operate, @Para0, @Para1, @Para2, @Para3";
            List<List2Item> myList = GeneralDataAccess.GetListofTypeT<List2Item>(sp, parameter);
            AssemblingMyList(myListControl1, myList, "myValue", "myText"); // school Code DDL
            AssemblingMyList(myListControl2, myList, "myValue", "myText"); // school Code DDL
            AssemblingMyList(myListControl3, myList, "myValue", "myText"); // school Code DDL
        }


        public static void SetListsFromJson(System.Web.UI.WebControls.ListControl myListControl, string ddlType, string JsonFile)
        {
            AssemblingMyListJson(myListControl, JsonFileReader.GetNvList(JsonFile, ddlType)); //GetListDataFromJson(ddlType, JsonFile));
        }
        public static void SetListsFromJson(System.Web.UI.WebControls.ListControl myListControl, string ddlType, string JsonFile, object initialValue)
        {
            SetListsFromJson(myListControl, ddlType, JsonFile);
            SetValue(myListControl, initialValue);
        }

        private static void AssemblingMyListJson(System.Web.UI.WebControls.ListControl myListControl, List<NvListItem> myList)
        {
            try
            {
                // List<List2Item> myList = myList;
                myListControl.Items.Clear();
                myListControl.DataSource = myList;
                myListControl.DataTextField = "Name";
                myListControl.DataValueField = "Value";
                myListControl.DataBind();
            }
            catch (Exception ex)
            { var em = ex.Message; }
            finally
            { }
        }
    }
    public static class AssemblingList
    {
        public static void SetLists(System.Web.UI.WebControls.ListControl myListControl, object myList, string ValueField, string TextField)
        {
            try
            {
                AssemblingMyList(myListControl, myList, ValueField, TextField);
            }
            catch (Exception ex)
            { var em = ex.Message; }
            finally
            { }
        }
        public static void SetLists(System.Web.UI.WebControls.ListControl myListControl, object myList, string ValueField, string TextField, object initialValue)
        {
            try
            {
                AssemblingMyList(myListControl, myList, ValueField, TextField);
                SetValue(myListControl, initialValue);
            }
            catch (Exception ex)
            { var em = ex.Message; }
            finally
            { }
        }
        public static void SetLists(string JsonSource, System.Web.UI.WebControls.ListControl myListControl, string ddlType, List2Item parameter)
        {
            List<NvListItem> myListData = ListDataSource(JsonSource, ddlType, parameter);
            AssemblingMyList(myListControl, myListData, "Value", "Name");
        }
        public static void SetLists(string JsonSource, System.Web.UI.WebControls.ListControl myListControl, string ddlType, List2Item parameter, object initialValue)
        {
            SetLists(JsonSource, myListControl, ddlType, parameter);
            SetValue(myListControl, initialValue);
        }
        private static List<NvListItem> ListDataSource(string JsonSource, string ddlType, List2Item parameter)
        { List<NvListItem> myListData;
            if (JsonSource == "")
            {
                parameter.Operate = ddlType;
              //  string SP = CommonExcute.SPNameAndParameters(JsonSource, "General", "DDList");
             //   myListData = CommonListExecute<NVListItem>.GeneralList(SP, parameter);
              //  myListData = CommonExcute<NVListItem>.GeneralList(SP, parameter);

                myListData = GeneralExe.DDListNV(parameter);
            }
            else
            {
                myListData = JsonFileReader.GetNvList(JsonSource, ddlType);
            }
            return myListData;

        }
        public static void SetValue(System.Web.UI.WebControls.ListControl myListControl, object objectValue)

        {
            try
            {
                myListControl.ClearSelection();
                if (myListControl.Items.Count > 0)
                {
                    if (myListControl.Items.Count == 1)
                    {
                        myListControl.SelectedIndex = 0;
                    }
                    else
                    {
                        if (objectValue != null)
                        {
                            if (objectValue.ToString() == "0")
                            {
                                myListControl.SelectedIndex = 0;
                            }
                            else
                            {
                                foreach (ListItem item in myListControl.Items)
                                {
                                    if (item.Value.ToString().ToLower() == objectValue.ToString().ToLower())
                                    {
                                        item.Selected = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                if (myListControl.Items.Count > 0)
                { myListControl.SelectedIndex = 0; }
                else
                {
                    var error = ex.Message;
                    throw new Exception(error);
                }

            }
        }
        public static void SetValueMultiple(System.Web.UI.WebControls.ListControl myListControl, string value)
        {
            try
            {
                if (myListControl.Items.Count > 0)
                {
                    if (value != null)
                    {
                        myListControl.ClearSelection();
                        foreach (ListItem item in myListControl.Items)
                        {
                            if (value.IndexOf(item.Value) != -1)
                            {
                                item.Selected = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private static void AssemblingMyList(System.Web.UI.WebControls.ListControl myListControl, object myList, string ValueField, string TextField)
        {
            try
            {
                // List<List2Item> myList = myList;
                myListControl.Items.Clear();
                myListControl.DataSource = myList;
                myListControl.DataTextField = TextField;
                myListControl.DataValueField = ValueField;
                myListControl.DataBind();
            }
            catch (Exception ex)
            { var em = ex.Message; }
            finally
            { }
        }

        public static void SetListSchool(System.Web.UI.WebControls.ListControl myListControl1, System.Web.UI.WebControls.ListControl myListControl2, string ddlType, List2Item parameter, object initialValue)
        {
            SetListSchool(myListControl1, myListControl2, ddlType, parameter);
            SetValue(myListControl1, initialValue);
            SetValue(myListControl2, initialValue);
        }
        public static void SetListSchool(System.Web.UI.WebControls.ListControl myListControl1, System.Web.UI.WebControls.ListControl myListControl2, string ddlType, List2Item parameter)
        {


            List<ListSchool> myListData = GeneralExe.SchoolList(parameter); // CommonListExecute.GetSchoolListData(parameter);
            AssemblingSchoolList(myListControl1, myListControl2, myListData);

        }
        private static void AssemblingSchoolList(System.Web.UI.WebControls.ListControl myListControl1, System.Web.UI.WebControls.ListControl myListControl2, List<ListSchool> myList)
        {
            try
            {
                List<ListSchool> sortedList = myList.OrderBy(o => o.Code).ToList();
                AssemblingMyList(myListControl1, sortedList, "Code", "Code"); // school Code DDL
                AssemblingMyList(myListControl2, myList, "Code", "Name"); // School Name DDL

            }
            catch (Exception ex)
            { var em = ex.Message; }
            finally
            { }
        }

    }
}
