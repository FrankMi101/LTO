namespace AppOperate
{
    public interface ICommonOperation<T>
    {
        string Operation(T position, string action);
    }
}