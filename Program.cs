namespace PracticeString_1;

class Program
{
    static void Main(string[] args)
    {
        Task1 task1 = new Task1("Hello my friend!");
        Console.WriteLine(task1.Output);
        task1.Review();
        Console.WriteLine(task1.Output);
        Console.WriteLine(task1.ToString());    
    }
}