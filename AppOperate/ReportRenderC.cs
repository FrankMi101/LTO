using ClassLibrary;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
namespace AppOperate
{
    public class ReportRenderC
    {
        public ReportRenderC()
        {
        }

        public static ReportParameter GetParameter(Int16 Seq, string pName, string pVAlue)
        {
            ReportParameter para1 = new ReportParameter();
            para1.ParaName = pName;
            para1.ParaValue = pVAlue;
            return para1;
        }
 
        //public static void setParameterArray(MyADO.MyParameterRS[] _ParaArray, int X, string _Name, string _Value)
        //{
        //    try
        //    {
        //        _ParaArray[X] = new MyADO.MyParameterRS();
        //        _ParaArray[X].pName = _Name;
        //        _ParaArray[X].pValue = _Value;
        //    }
        //    catch (Exception ex)
        //    {
        //        string error = ex.Message;
        //    }
        //}

        public static void RenderReport(string _reportName, string rFormat, Byte[] result)
        {
            try
            {
                HttpContext.Current.Response.AppendHeader("content-disposition", "filename=" + _reportName + "." + rFormat);
                HttpContext.Current.Response.ContentType = getReportContentType(rFormat);

                HttpContext.Current.Response.OutputStream.Write(result, 0, result.GetLength(0));

                HttpContext.Current.Response.End();

            }
            catch (Exception ex)
            {
                string showmsg = ex.Message;
            }

        }
        public static void RenderReport(string _reportName, string _reportFormat, List<ReportParameter> _reportParameter) // MyCommon.MyParameterRS[] _reportParameter)
        {
            try
            {
                Byte[] result = GetReportR2(_reportName, _reportFormat, _reportParameter);
                string rFormat = WebConfigValue.ReportFormat();
                HttpContext.Current.Response.AppendHeader("content-disposition", "filename=" + _reportName + "." + rFormat);
                HttpContext.Current.Response.ContentType = getReportContentType(rFormat);

                HttpContext.Current.Response.OutputStream.Write(result, 0, result.GetLength(0));

                HttpContext.Current.Response.End();

            }
            catch (Exception ex)
            {
                string showmsg = ex.Message;
            }

        }


        public static void RenderReport(string reportName, string schoolyear, string schoolcode, string publishCycle, string userID)
        {
            try
            {
                //  MyCommon.MyParameterRS[] reportParameters = new MyCommon.MyParameterRS[4];
                List<ReportParameter> paras = new List<ReportParameter>();
                paras.Add(new ReportParameter { ParaName = "UserID", ParaValue = userID });
                paras.Add(new ReportParameter { ParaName = "SchoolYear", ParaValue = schoolyear });
                paras.Add(new ReportParameter { ParaName = "SchoolCode", ParaValue = schoolcode });
                paras.Add(new ReportParameter { ParaName = "PublishCycle", ParaValue = publishCycle });

                string rFormat = WebConfigValue.ReportFormat();
                Byte[] result = GetReportR2(reportName, "PDF", paras);

                if (result.Length != 0)
                {
                    HttpContext.Current.Response.AppendHeader("content-disposition", "filename=" + reportName + "." + rFormat);
                    HttpContext.Current.Response.ContentType = getReportContentType(rFormat);

                    HttpContext.Current.Response.OutputStream.Write(result, 0, result.GetLength(0));

                    HttpContext.Current.Response.End();
                }
                else
                {
                    HttpContext.Current.Response.Redirect("PDFPageFile2.aspx?");
                }
            }
            catch (Exception ex)
            {
                string showmsg = ex.Message;
            }

        }


        public static Byte[] GetReportR2(string _reportName, string reportFormat, List<ReportParameter> _reportParameter) // MyCommon.MyParameterRS[] _reportParameter)

        {
            Byte[] result;
            try
            {

                ReportingWebService.ReportExecutionService RS = new ReportingWebService.ReportExecutionService();
                //  CredentialCache cache = new CredentialCache();
                string accessUser = WebConfigValue.ReportUser();
                string accessRWSPW = WebConfigValue.ReportPW();
                string accessDomain = WebConfigValue.DomainName();
                string reportingServices = WebConfigValue.ReportServices();
                string currentDB = WebConfigValue.CurrentDB();
                string report = WebConfigValue.ReportPathWS() + currentDB + "/" + _reportName;
                string format = reportFormat; // getReportContentType(reportFormat); //WebConfigValue.ReportFormat();

                RS.Url = reportingServices;
                RS.Credentials = new System.Net.NetworkCredential(accessUser, accessRWSPW, accessDomain);


                string historyID = null;
                string devInfo = "<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>";

                string encoding = "";
                string mimeType = "";
                ReportingWebService.Warning[] warnings = new ReportingWebService.Warning[0];
                string[] streamIDs = null;


                ReportingWebService.ServerInfoHeader sh = new ReportingWebService.ServerInfoHeader();   //'ServerInfoHeader  
                RS.ServerInfoHeaderValue = sh;  //'ServerInfoHeaderValue = sh  
                                                // ReportingWebService.Warning warning = new ReportingWebService.Warning();

                // MyCommon.MyParameterRS[] _reportParameter = GetReportParameters(_reportName, parameters);
                // List<NVListItem> _reportParameter = GetReportParameters(_reportName, parameters);
                int pLeng = _reportParameter.Count; //  .Length;
                ReportingWebService.ParameterValue[] rptParameters = new ReportingWebService.ParameterValue[pLeng];


                int i = 0;
                foreach (var item in _reportParameter)
                {
                    rptParameters[i] = new ReportingWebService.ParameterValue();
                    rptParameters[i].Name = item.ParaName;
                    rptParameters[i].Value = item.ParaValue.ToString(); // para.pValue.ToString();
                    i += 1;
                }

                // ReDim rptParameters(cnt - 1)

                ReportingWebService.ExecutionInfo execInfo = new ReportingWebService.ExecutionInfo();
                ReportingWebService.ExecutionHeader execHeader = new ReportingWebService.ExecutionHeader();


                execInfo = RS.LoadReport(report, historyID);

                RS.SetExecutionParameters(rptParameters, "en-us");

                string extension = "";
                string SessionId = RS.ExecutionHeaderValue.ExecutionID;
                //   Console.WriteLine("SessionID: {0}", RS.ExecutionHeaderValue.ExecutionID);

                result = RS.Render(format, devInfo, out extension, out encoding, out mimeType, out warnings, out streamIDs);

                return result;

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return new Byte[0];
            }
        }
        public static Byte[] MultiplePDF(string[] mySelectIDArray, string reportName, string schoolyear, string schoolcode, string sessionID)
        {
            //Document doc = new Document();
            MemoryStream msOutput = new MemoryStream();
            ////           PdfCopy pCopy;
            //PdfCopy pCopy = new PdfSmartCopy(doc, msOutput);
            //doc.Open();

            //for (int j = 0; j < mySelectIDArray.Length; j++)
            //{

            //    string userID = HttpContext.Current.User.Identity.Name;
            //    string employeeID = mySelectIDArray[j].ToString();
            //    if (employeeID != "")
            //    {
            //        try
            //        {
            //            Byte[] myPDF;
            //            myPDF = GetOneReport(reportName, userID, schoolyear, schoolcode, sessionID);
            //            MemoryStream stream1 = new MemoryStream(myPDF);
            //            PdfReader pdfFile1 = new PdfReader(stream1.ToArray());
            //            for (int i = 1; i <= pdfFile1.NumberOfPages; i++)
            //            {
            //                pCopy.AddPage(pCopy.GetImportedPage(pdfFile1, i));
            //            }
            //            pdfFile1.Close();
            //        }
            //        catch { }
            //    }

            //}
            //try
            //{
            //    pCopy.Close();
            //    doc.Close();
            //}
            //catch { }

            return msOutput.ToArray();
        }


        public static Byte[] GetOneReport(string reportName, string userID, string schoolyear, string schoolcode, string version)
        {
            //MyCommon.MyParameterRS[] reportParameters = new MyCommon.MyParameterRS[4];
            //setParameterArray(reportParameters, 0, "UserID", userID);
            //setParameterArray(reportParameters, 1, "SchoolYear", schoolYear);
            //setParameterArray(reportParameters, 2, "SchoolCode", schoolCode);
            //setParameterArray(reportParameters, 3, "Version", version);


            List<ReportParameter> paras = new List<ReportParameter>();
            paras.Add(new ReportParameter { ParaName = "UserID", ParaValue = userID });
            paras.Add(new ReportParameter { ParaName = "SchoolYear", ParaValue = schoolyear });
            paras.Add(new ReportParameter { ParaName = "SchoolCode", ParaValue = schoolcode });
            paras.Add(new ReportParameter { ParaName = "Version", ParaValue = version });
            return GetReportR2(reportName, "PDF", paras);
        }

        public static string reportFormat(string pFormat)
        {
            string rValue = "";
            switch (pFormat)
            {
                case "PDF1":
                    rValue = "&rs:Command=Render&rs:Format=PDF&rs:ClearSession=true&rc:Toolbar=false";
                    break;
                case "PDF":
                    rValue = "&rs:Command=Render&rs:Format=PDF&rs:ClearSession=true&rc:Toolbar=false&rc:LinkTarget=_blank";
                    break;
                case "PDFV":
                    rValue = "&rs:Command=Render&rs:Format=PDF&rs:ClearSession=true&rc:Toolbar=true&rc:LinkTarget=_blank";
                    break;
                case "CSV":
                    rValue = "&rs:Command=Render&rs:Format=CSV&rc:Toolbar=false&rc:LinkTarget=_blank";
                    break;
                case "EXCEL":
                    rValue = "&rs:Command=Render&rs:Format=EXCEL&rc:Toolbar=false&rc:LinkTarget=_blank";
                    break;
                case "IMAGE":
                    rValue = "&rs:Command=Render&rs:Format=IMAGE&rc:Toolbar=false&rc:LinkTarget=_blank";
                    break;
                case "HTML":
                    rValue = "&rs:Command=Render&rs:Format=HTML4.0&rc:Toolbar=false&rc:LinkTarget=_blank";
                    break;
                case "HTMLV":
                    rValue = "&rs:Command=Render&rs:Format=HTML4.0&rc:Toolbar=true&rc:LinkTarget=_blank";
                    break;
                case "XML":
                    rValue = "&rs:Command=Render&rs:Format=XML&rc:Toolbar=false&rc:LinkTarget=_blank";
                    break;
                default:

                    rValue = "&rs:Command=Render&rs:Format=HTML4.0&rc:Toolbar=false&rc:LinkTarget=_blank";

                    break;
            }
            return rValue;

        }
        public static string getReportContentType(string _reportFormat)
        {

            string rValue = "";
            switch (_reportFormat)
            {
                case "PDF":
                    rValue = "application/pdf";
                    break;
                case "CSV":
                    rValue = "application/csv";
                    break;
                case "EXCEL":
                    //  rValue = "application / vnd.ms - excel";
                    //   rValue = "application/excel";
                    rValue = "application/vnd.ms-excel";
                    break;
                case "Word": 
                    rValue = "application/vnd.ms-word";
                    break;
                case "WORD":
                    rValue = "application/vnd.msword.document.12";
                    break;
                case "IMAGE":
                    rValue = "image/tiff";
                    break;
                case "HTML":
                    rValue = "application/html";
                    break;
                case "XML":
                    rValue = "application/xml";
                    break;
                default:

                    rValue = _reportFormat;

                    break;
            }
            return rValue;

        }
        public static string getFileExtension(string _reportFormat)
        {

            string rValue = "";
            switch (_reportFormat)
            {
                case "PDF":
                    rValue = ".pdf";
                    break;
                case "CSV":
                    rValue = ".csv";
                    break;
                case "EXCEL":
                    //  rValue = "application / vnd.ms - excel";
                    //   rValue = "application/excel";
                    rValue = ".xls";
                    break;
                case "IMAGE":
                    rValue = ".gif";
                    break;
                case "HTML":
                    rValue = ".html";
                    break;
                case "XML":
                    rValue = ".xml";
                    break;
                default:

                    rValue = ".pdf";

                    break;
            }
            return rValue;

        }

        public static void RenderDocument( Byte[]  _pdfReport, string  _reportName , string  _reportFormat )
        {
            try
            {
                string fileName = $"filename= { _reportName }" + getFileExtension(_reportFormat);

                HttpContext.Current.Response.AppendHeader("content-disposition", fileName);  // "filename=" + _reportName + ".xls");
                HttpContext.Current.Response.ContentType = getReportContentType(_reportFormat);
                // output the actual document contents to the response output stream
                HttpContext.Current.Response.OutputStream.Write(_pdfReport, 0, _pdfReport.GetLength(0));
                // end the response
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();


            }
            catch (Exception ex)
            {
                string error = ex.Message;
            
            }

        }

        public static List<ReportParameter> GetReportParameters(string reportName, ParametersForPositionList reportPara)
        {
            List<ReportParameter> paras = new List<ReportParameter>();

            switch (reportName)
            {
                case "":
                    paras.Add(new ReportParameter { ParaName = "UserID", ParaValue = reportPara.UserID });
                    paras.Add(new ReportParameter { ParaName = "SchoolYear", ParaValue = reportPara.SchoolYear });
                    paras.Add(new ReportParameter { ParaName = "SchoolCode", ParaValue = reportPara.SchoolCode });
                    paras.Add(new ReportParameter { ParaName = "PublishCycle", ParaValue = reportPara.PositionType });

                    break;
                default:
                    break;
            }
            return paras;
        }
    }
    public class ReportParameter
    {
        public string ParaName { get; set; }
        public string ParaValue { get; set; }
    }
}