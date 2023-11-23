namespace BaseException;

[Serializable]
public abstract class ExceptionArgs
{
    /// <summary>
    /// Описание ошибки.
    /// </summary>
    public virtual string Message => string.Empty;
}