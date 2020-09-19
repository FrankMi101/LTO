namespace AppOperate
{
    public   class SPSource
    {
        private static string _SPFile = "";

       
        //public static string SPFile1 
        //{
        //    get { return _SPFile; }
        //}
        //public static void SetSPFile(string filepath)
        //{
        //    _SPFile = filepath;
        //}


        public static string SPFile
        {
            get { return _SPFile; }
            set { _SPFile = value; }
        }
    }
}
