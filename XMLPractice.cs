using System.Xml.Serialization;

namespace SerializePractice;

public class Dog
{
    private string _name;
    private int _age;
    private int[] _review;

    public string Name => _name;
    public int Age => _age;
    public int[] Review => _review.ToArray();

    public Dog(string name, int age)
    {
        _name = name;
        _age = age;
        _review = new int[0];
    }

    public void AddReview(int review)
    {
        Array.Resize(ref _review, _review.Length+1);
        _review[_review.Length - 1] = review;
    }
}

public class DogDTO
{
    // Св-ва с публичными сеттерами
    public string DogType { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int[] Review { get; set; }

    
    // Конструктор без параметров
    public DogDTO()
    {
        
    }
    
    // Dog -> DogDTO
    
    // 1 вариант
    public DogDTO(string name, int age, int[] review)
    {
        DogType = nameof(Dog);
        Name = name;
        Age = age;
        Review = review;
    }
    // 2 Вариант
    public DogDTO(Dog dog) // dog.GetType() == typeof(Dog)
                            // dog.GetType().Name == nameof(Dog)
    {
        DogType = dog.GetType().Name;
        Name = dog.Name;
        Age = dog.Age;
        Review = dog.Review;
    }
    
}

public class Program
{
    static void Main(string[] args)
    {
        Dog dog1 = new Dog("Gerzog", 10);
        dog1.AddReview(5);
        dog1.AddReview(5);
        dog1.AddReview(5);
        dog1.AddReview(5);

        DogDTO petDTO = new DogDTO(dog1.Name, dog1.Age, dog1.Review);
        
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(folderPath, "dog.xml");

        var serializer = new XmlSerializer(typeof(DogDTO));
        //Сериализация
        using (var writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, petDTO);
        }
        // Десериализация 
        DogDTO dogDTO2;
        using (var reader = new StreamReader(filePath))
        {
            dogDTO2 = (DogDTO)serializer.Deserialize(reader);
        }

        Dog dog2 = new Dog(dogDTO2.Name, dogDTO2.Age);

        foreach (int star in dogDTO2.Review)
        {
            dog2.AddReview(star);
        }
        
        if (CompareDog(dog1, dog2))
        {
            Console.WriteLine("Success");
        }
        else
        {
            Console.WriteLine("NOT Success");

        }
    }

    public static bool CompareDog(Dog d1, Dog d2)
    {
        if ((d1.Name == d2.Name) && (d1.Age == d2.Age)) return true;
        if (d1.Review.Length == d2.Review.Length)
        {
            for (int i = 0; i < d1.Review.Length; i++)
            {
                if (d1.Review[i] == d2.Review[i]) return true;
            }
        }

        return false;
    }
}
