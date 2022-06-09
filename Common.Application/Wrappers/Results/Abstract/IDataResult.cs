namespace Common.Application.Wrappers.Results.Abstract
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
