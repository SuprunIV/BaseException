using System.Runtime.Serialization;
using System.Security.Permissions;

namespace BaseException;

[Serializable]
public sealed class BaseException<TExceptionArgs>: Exception, ISerializable
    where TExceptionArgs : ExceptionArgs
{
    private const string ARGS = "Args";
    private readonly TExceptionArgs _args;

    public TExceptionArgs Args => _args;

    public BaseException(string message = null, Exception innerException = null) 
        : this(null, message, innerException)
    {
    }
    public BaseException(TExceptionArgs args, string message = null, Exception innerException = null)
    {
        _args = args;
    }

    private BaseException(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext)
    {
        _args = ((TExceptionArgs)serializationInfo.GetValue(ARGS, typeof(TExceptionArgs)))!;
    }

    public override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
    {
        serializationInfo.AddValue(ARGS, _args);
        base.GetObjectData(serializationInfo, streamingContext);
    }

    public override string Message
    {
        get
        {
            var baseMsg = base.Message;
            return _args is null ? baseMsg : $"{baseMsg} ({_args.Message})";

        }
    }

    /// <summary>Determines whether the specified object is equal to the current object.</summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>
    /// <see langword="true" /> if the specified object  is equal to the current object; otherwise, <see langword="false" />.</returns>
    public override bool Equals(object? obj)
    {
        BaseException<TExceptionArgs> other = obj as BaseException<TExceptionArgs>;
        if (other is null)
        {
            return false;
        }
        

        return Object.Equals(_args, other._args) && base.Equals(obj);
    }
}