﻿using ClassLibrary;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public class PostingPositionExeAsync
    {
        private readonly static IAppServicesAsync _action = new AppServiceAsync( new ApproveRequestAsync(DBConnection.DBSource));


        public async static Task<List<PositionListApprove>> Positions(object parameter)
        {
            string SP = GetSP("Positions");
            return await _action.AppOne.CommonList<PositionListApprove>(SP, parameter);
          //  return CommonExcute<PositionListApprove>.GeneralList(GetSP("Positions"), parameter);
        }
        public async static Task<List<PositionApprove>> Position(object parameter)
        {
            string SP = GetSP("Position");
            return await _action.AppOne.CommonList<PositionApprove>(SP, parameter);
            //            return CommonExcute<PositionApprove>.GeneralList(GetSP("Position"), parameter);
        }

        public async static Task<string> Save(object parameter)
        {
            string SP = "Save";
            return await _action.AppOne.CommonAction(SP, parameter);
            // return CommonExcute<string>.GeneralValue(GetSP("Save"), parameter);
        }
        public async static Task<string> Update(object parameter)
        {
            string SP = "Save";
            return await _action.AppOne.CommonAction(SP, parameter);
            //           return CommonExcute<string>.GeneralValue(GetSP("Save"), parameter);
        }
        public async static Task<string> Reject(object parameter)
        {
            string SP = "Reject";
            return await _action.AppOne.CommonAction(SP, parameter);
            //             return CommonExcute<string>.GeneralValue(GetSP("Reject"), parameter);
        }
        public async static Task<string> Posting(object parameter)
        {
            string SP = "Posting";
            return await _action.AppOne.CommonAction(SP, parameter);
            //             return CommonExcute<string>.GeneralValue(GetSP("Posting"), parameter);
        }
        public async static Task<string> PostingNumber(object parameter)
        {
            string SP = "PostingNumber";
            return await _action.AppOne.CommonAction(SP, parameter);
            //            return CommonExcute<string>.GeneralValue(GetSP("PostingNumber"), parameter);
        }

        private static string GetSP(string action)
        {
            if (SPSource.SPFile == "")
            { return GetSPInClass(action); }
            else
            { return GetSPFromJsonFile(action); }

        }
        public static string SPName(string action)
        {
            return GetSPInClass(action);
        }
        public static string SPName(string action, object para)
        {
            return GetSPInClass(action, para);
        }
        private static string GetSPInClass(string action)
        {
            return action;
        }
        private static string GetSPInClass(string action, object parameter)
        {
            return   _action.AppOne.SpName(action, parameter);
        }
        private static string GetSPFromJsonFile(string action)
        { 
            return GetSpNameFormJsonFile.SPName(action, "Approve");
        }
    }
}