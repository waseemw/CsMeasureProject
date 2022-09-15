using System.Runtime.CompilerServices;

namespace MeasureProject;

public class TestAtomicity
{
    private int bigI;

    // [MethodImpl(MethodImplOptions.Synchronized)]
    public void PrintI()
    {
        bigI++;
        Console.WriteLine(bigI);
    }

    public void Start()
    {
        List<Thread> list = new();
        for (var i = 0; i < 10; i++)
        {
            var thread = new Thread(PrintI);
            list.Add(thread);
        }

        list.ForEach(item => item.Start());
        list.ForEach(item => item.Join());
    }

    public static void Main()
    {
        new TestAtomicity().Start();
    }
}