namespace PracticeString_1;

public class Task1 : Red
{
    private int _output;


    public int Output => _output;
    public Task1(string input) : base(input)
    {
        _output = default(int);
    }

    public override void Review()
    {
        _output = 134;
    }

    public override string ToString()
    {
        return $"{Input}{Environment.NewLine}{_output}";
    }
}