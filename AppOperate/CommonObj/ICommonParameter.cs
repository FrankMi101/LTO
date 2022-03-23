using ClassLibrary;

namespace AppOperate
{
    public interface ICommonParameter
    {
        object GetParameterObj(string type);
        ParametersForPosition GetParameters(string schoolYear, string positionId);
        ParametersForPosition GetParameters(string schoolYear, string positionId, string cpNum);

        ParametersForPositionList GetParameters(string operate, string userId, string schoolYear, string schoolCode);
        ParametersForPositionList GetParameters(string operate, string userId, string schoolYear, string positionType, string searchBy, string value1 );
        ParametersForPositionList GetParameters(string operate, string userId, string schoolYear, string positionType, string panel, string status, string searchBy, string value1, string value2);
        Profile ParametersForProfile(string userID, string schoolYear, string profileType, string checkValue);
    }
}