namespace MeasureProject;

public class DiscordObfuscator
{
    private string ConvertChar(string str)
    {
        return string.Join("", str.Select(c => c is '\n' or '\r' ? c + "" : "||" + c + "|| ha :D "));
    }

    private string ConvertWord(string str)
    {
        var s = string.Join("", str.Split().Select(c => c is "\r\n" ? c : "||" + c + " ||"));
        return s.Substring(0, s.Length - " ||".Length) + "||";
    }

    public void Start()
    {
        while (true)
            Console.WriteLine(ConvertChar(Console.ReadLine()!));
    }
}