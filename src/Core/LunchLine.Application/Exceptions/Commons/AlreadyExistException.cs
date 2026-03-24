using Microsoft.AspNetCore.Http;

namespace LunchLine.Application.Exceptions.Commons;

public class AlreadyExistException<T> : Exception, IBaseException
{
    public int Code => StatusCodes.Status404NotFound;
    const string _message = " already exist!";
    public string ErrorMessage { get; }

    public AlreadyExistException() : base(typeof(T).Name + _message)
    {
        ErrorMessage = typeof(T).Name + _message;
    }

    public AlreadyExistException(string message) : base(message)
    {
        ErrorMessage = message;
    }
}