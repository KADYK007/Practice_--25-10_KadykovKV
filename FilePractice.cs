namespace FilePractice;

class Program
{
    static void Main(string[] args)
    {
        // Получаем путь папки
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        string fileName = "example.txt";
        
        // Путь до файла
        string fullPath = Path.Combine(folderPath, fileName);

        File.Create(fullPath).Close();
        File.WriteAllText(fullPath, "hello");
        File.AppendAllText(fullPath, "world");
        // File.WriteAllText(fullPath, "hello, again"); Удаляет старый текст и записывает новый
        File.AppendAllText(fullPath, "WWWW");

        string[] words = new string[] { "wohoo", "so", "funny" };
        File.WriteAllLines(fullPath, words);
        File.AppendAllLines(fullPath, words);
        File.AppendAllText(fullPath, "text");
        File.AppendAllText(fullPath, "text");
        File.AppendAllText(fullPath, "text");



        string content = File.ReadAllText(fullPath);
        string[] lines = File.ReadAllLines(fullPath);
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }

        string folderPath2 = Path.Combine(folderPath, "ExampleFolder");
        string filePath = Path.Combine(folderPath2, "anotherExample.txt");

        if (!Directory.Exists(folderPath2))
        {
            Directory.CreateDirectory(folderPath2);
        }

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
        else
        {
            File.WriteAllText(filePath, "");
        }
        
        // Мы знаем только полный путь
        string folderPath3 = Path.GetDirectoryName(filePath);
        string fileName2 = Path.GetFileName(filePath);

        Console.WriteLine(folderPath3);
        Console.WriteLine(fileName2);
    }
}
