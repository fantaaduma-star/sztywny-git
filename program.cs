class Program
{
    public void add()
    {
        console.Write("input 1: ");
        int x = (int)console.readline();
        console.WriteLine();
        console.Write("input 2: ");
        int y = (int)console.readline();
        console.Writeline(x+y);
        return;
    }

    static void Main()
    {
        Console.WriteLine("Hello, World!");
        add();
    }
}
