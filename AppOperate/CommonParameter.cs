using ClassLibrary;

namespace AppOperate
{
    public class CommonParameter
    {
        public static Profile ParametersForProfile(string operate,string userID, string schoolYear, string profileType,string checkValue)
        {
            var parameters = new Profile()
            {
                UserID = userID,
                SchoolYear = schoolYear,
                ProfileType = profileType,
                CheckValue = checkValue,
                Operate = operate

            };
            return parameters;
        }

        public static ParametersForApplicantList GetParameters3(string operate, string schoolYear)
        {
            return GetParameters3(operate, schoolYear, null);
        }

        public static ParametersForApplicantList GetParameters3(string operate, string schoolYear, string positionID)
        {
            var parameters = new ParametersForApplicantList()
            {
                Operate = operate,
                SchoolYear = schoolYear,
                PositionID = positionID

            };
            return parameters;

        }

        public static ParametersForPosition GetParameters(string schoolYear, string positionId)
        {
            var parameter = new ParametersForPosition()
            {
                PositionID = positionId,
                SchoolYear = schoolYear
            };
            return parameter;
        }
        public static ParametersForPosition GetParameters(string schoolYear, string positionId, string cpNum)
        {
            var parameter = new ParametersForPosition()
            {

                SchoolYear = schoolYear,
                PositionID = positionId,
                CPNum = cpNum

            };
            return parameter;
        }
        public static ParametersForPositionList GetParameters(string operate, string userId, string schoolYear, string schoolCode)
        {
            var parameters = new ParametersForPositionList()
            {
                Operate = operate,
                UserID = userId,
                SchoolYear = schoolYear,
                SchoolCode = schoolCode

            };
            return parameters;

        }
        public static ParametersForPositionList GetParametersSchool(string operate, string userId, string schoolYear, string schoolCode, string progress)
        {
            var parameters = new ParametersForPositionList()
            {
                Operate = operate,
                UserID = userId,
                SchoolYear = schoolYear,
                SchoolCode = schoolCode,
                SearchValue1 = progress

            };
            return parameters;

        }
        public static ParametersForPositionList GetParameters(string operate, string userId, string schoolYear, string positionType, string searchBy, string value1)
        {
            var parameters = new ParametersForPositionList()
            {
                Operate = operate,
                UserID = userId,
                SchoolYear = schoolYear,
                PositionType = positionType,
                SearchBy = searchBy,
                SearchValue1 = value1
            };
            return parameters;

        }
        public static ParametersForPositionList GetParameters(string operate, string userId, string schoolYear, string positionType, string searchBy, string value1, string userRole, string cpnum)
        {
            var parameters = new ParametersForPositionList()
            {
                Operate = operate,
                UserID = userId,
                SchoolYear = schoolYear,
                PositionType = positionType,
                SearchBy = searchBy,
                SearchValue1 = value1,
                UserRole = userRole,
                CPNum = cpnum
            };
            return parameters;

        }
        public static ParametersForPositionList GetParameters(string operate, string userId, string schoolYear, string positionType, string panel, string status, string searchBy, string value1, string value2)
        {
            var parameters = new ParametersForPositionList()
            {
                Operate = operate,
                UserID = userId,
                SchoolYear = schoolYear,
                PositionType = positionType,
                Panel = panel,
                Status = status,
                SearchBy = searchBy,
                SearchValue1 = value1,
                SearchValue2 = value2
            };
            return parameters;

        }
        public ParametersForPosition GetParameterObj<T>(string type)
        {
            return new ParametersForPosition();

        }
    }
    public class CommonParameter<T> : ICommonParameter
    {
        public object GetParameterObj(string type)
        {
            var typeName = (typeof(T)).Name;
            switch (typeName)
            {
                case "ParametersForPosition":
                    return new ParametersForPosition();
                case "ParametersForPositionList":
                    return new ParametersForPositionList();
                case "ParametersForOperation":
                    return new ParametersForOperation(); // ParametersForPositionList();
                case "ParametersForApplicantList":
                    return new ParametersForApplicantList();
                case "Profile":
                    return new Profile();
                default:
                    return new ParametersForOperation();

            }
        }

        public ParametersForPosition GetParameters(string schoolYear, string positionId)
        {
            var parameter = new ParametersForPosition()
            {
                PositionID = positionId,
                SchoolYear = schoolYear
            };
            return parameter;
        }
        public ParametersForPosition GetParameters(string schoolYear, string positionId, string cpNum)
        {
            var parameter = new ParametersForPosition()
            {
                SchoolYear = schoolYear,
                PositionID = positionId,
                CPNum = cpNum

            };
            return parameter;
        }
        public ParametersForPositionList GetParameters(string operate, string userId, string schoolYear, string schoolCode)
        {
            var parameters = new ParametersForPositionList()
            {
                Operate = operate,
                UserID = userId,
                SchoolYear = schoolYear,
                SchoolCode = schoolCode

            };
            return parameters;

        }
        public ParametersForPositionList GetParameters(string operate, string userId, string schoolYear, string positionType, string searchBy, string value1)
        {
            var parameters = new ParametersForPositionList()
            {
                Operate = operate,
                UserID = userId,
                SchoolYear = schoolYear,
                PositionType = positionType,
                SearchBy = searchBy,
                SearchValue1 = value1
            };
            return parameters;

        }

        public ParametersForPositionList GetParameters(string operate, string userId, string schoolYear, string positionType, string searchBy, string value1, string userRole, string cpnum)
        {
            var parameters = new ParametersForPositionList()
            {
                Operate = operate,
                UserID = userId,
                SchoolYear = schoolYear,
                PositionType = positionType,
                SearchBy = searchBy,
                SearchValue1 = value1,
                UserRole = userRole,
                CPNum = cpnum
            };
            return parameters;

        }

        public ParametersForPositionList GetParameters(string operate, string userId, string schoolYear, string positionType, string panel, string status, string searchBy, string value1, string value2)
        {
            var parameters = new ParametersForPositionList()
            {
                Operate = operate,
                UserID = userId,
                SchoolYear = schoolYear,
                PositionType = positionType,
                Panel = panel,
                Status = status,
                SearchBy = searchBy,
                SearchValue1 = value1,
                SearchValue2 = value2
            };
            return parameters;

        }

        public Profile ParametersForProfile(string userID, string schoolYear, string profileType, string checkValue)
        {
            var parameters = new Profile()
            {
                UserID = userID,
                SchoolYear = schoolYear,
                ProfileType = profileType,
                CheckValue = checkValue
            };
            return parameters;
        }
    }

}

