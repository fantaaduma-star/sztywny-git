class Program
{

    public static int add()
    {
        Console.Write("input 1: ");
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.Write("input 2: ");
        int y = int.Parse(Console.ReadLine());
        return x+y;
    }

    static void Main()
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(add());
    }
}
