// See https://aka.ms/new-console-template for more information

using BaseException;
using MyException.App;

try
{
    Console.WriteLine("Input text: ");
    var text = Console.ReadLine();
    if (text.ToLower().Contains("wrong"))
    {
        throw new BaseException<WrongTextExceptionArgs>(
            new WrongTextExceptionArgs(text), "The input text is wrong");
    }
    Console.WriteLine($"Your text: {text}");

}
catch (BaseException<WrongTextExceptionArgs> ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message, "Unexpected error");
}