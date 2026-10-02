class Program
{
    public static void add()
    {
        Console.Write("input 1: ");
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.Write("input 2: ");
        int y = int.Parse(Console.ReadLine());
        Console.WriteLine(x+y);
        return;
    }

    static void Main()
    {
        Console.WriteLine("Hello, World!");
        add();
    }
}
