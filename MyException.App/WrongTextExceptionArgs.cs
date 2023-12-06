using BaseException;

namespace MyException.App;

public sealed class WrongTextExceptionArgs: ExceptionArgs
{
    public string WrongText { get; init; }

    public WrongTextExceptionArgs(string text)
    {
        WrongText = text;
    }

    public override string Message
    {
        get
        {
            return string.IsNullOrEmpty(WrongText) ? base.Message : $"Wrong Text = {WrongText}";
        }
    }
}