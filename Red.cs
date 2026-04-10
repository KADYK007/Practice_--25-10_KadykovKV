namespace PracticeString_1;

public abstract class Red
{
    private string _input;

    public string Input => _input;

    protected Red(string input)
    {
        _input = input;
    }

    public abstract void Review();

    public virtual void ChangeText(string text)
    {
        _input = text;
        Review();
    }

    public override string ToString()
    {
        return "hehe";
    }

    protected string[] GetWords(string text)
    {
        //Select(x => x.Trim(_punc))
        //Where(x != !String.IsNullOrEmpty(x))
        //ToArray
        
        return null;
    }
}