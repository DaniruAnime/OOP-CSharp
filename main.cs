using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        // Instance гарантирует, что программа работает с единственным списком
        ZooManager zooManager = ZooManager.Instance;

        // Предзаполнение животных для демонстрации
        zooManager.AddAnimal(new Mammal("Basya", 5, "Forest", "Predator", "Black", 20.5, true));
        zooManager.AddAnimal(new Bird("Pit", 2, "Jungle", "Omnivorous", "Green", 1.2, 0.5f));

        bool isRunning = true;

        while (isRunning)
        {
            Console.Write("""
                --- Zoo Menu ---
                1. Show all animals
                2. Add mammal
                3. Add bird
                4. Add fish
                5. Add reptile
                6. Add amphibian
                7. Exit
                Select option: 
                """);

            string input = Console.ReadLine();
            
            if (!Enum.TryParse(input, ignoreCase: true, out menuOption result) ||
                !Enum.IsDefined(typeof(menuOption), result))
            {
                Console.WriteLine("Incorrect input. Try again");
                continue;
            }

            switch (result)
            {
                case menuOption.ShowAllAnimals:
                    zooManager.ShowAllAnimals();
                    break;
                case menuOption.AddMammal:
                    AddMammalUI(zooManager);
                    break;
                case menuOption.AddBird:
                    AddBirdUI(zooManager);
                    break;
                case menuOption.AddFish:
                    AddFishUI(zooManager);
                    break;
                case menuOption.AddReptile:
                    AddReptileUI(zooManager);
                    break;
                case menuOption.AddAmphibian:
                    AddAmphibianUI(zooManager);
                    break;
                case menuOption.Exit:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Incorrect input. Try again");
                    break;
            }
        }
    }

    private static void AddMammalUI(ZooManager zooManager)
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();

        int age = ReadInt("Age: ");
        string habitat = ReadString("Habitat: ");
        string dietType = ReadString("Diet type: ");
        string color = ReadString("Color: ");
        double weight = ReadDouble("Weight: ");
        bool hasFur = ReadBool("Has fur? (y/n): ");

        bool isAdded = zooManager.AddAnimal(
            new Mammal(name, age, habitat, dietType, color, weight, hasFur));

        if (isAdded)
        {
            Console.WriteLine("Mammal added successfully");
        }
        else
        {
            Console.WriteLine("Such an animal already exists");
        }
    }

    private static void AddBirdUI(ZooManager zooManager)
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();

        int age = ReadInt("Age: ");
        string habitat = ReadString("Habitat: ");
        string dietType = ReadString("Diet type: ");
        string color = ReadString("Color: ");
        double weight = ReadDouble("Weight: ");
        float wingSpan = ReadFloat("Wing span: ");

        bool isAdded = zooManager.AddAnimal(
            new Bird(name, age, habitat, dietType, color, weight, wingSpan));

        if (isAdded)
        {
            Console.WriteLine("Bird added successfully");
        }
        else
        {
            Console.WriteLine("Such an animal already exists");
        }
    }

    private static void AddFishUI(ZooManager zooManager)
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();

        int age = ReadInt("Age: ");
        string habitat = ReadString("Habitat: ");
        string dietType = ReadString("Diet type: ");
        string color = ReadString("Color: ");
        double weight = ReadDouble("Weight: ");
        string waterType = ReadString("Water type (Fresh/Sea): ");

        bool isAdded = zooManager.AddAnimal(
            new Fish(name, age, habitat, dietType, color, weight, waterType));

        if (isAdded)
        {
            Console.WriteLine("Fish added successfully");
        }
        else
        {
            Console.WriteLine("Such an animal already exists");
        }
    }

    private static void AddReptileUI(ZooManager zooManager)
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();

        int age = ReadInt("Age: ");
        string habitat = ReadString("Habitat: ");
        string dietType = ReadString("Diet type: ");
        string color = ReadString("Color: ");
        double weight = ReadDouble("Weight: ");
        bool isVenomous = ReadBool("Is venomous? (y/n): ");

        bool isAdded = zooManager.AddAnimal(
            new Reptile(name, age, habitat, dietType, color, weight, isVenomous));

        if (isAdded)
        {
            Console.WriteLine("Reptile added successfully");
        }
        else
        {
            Console.WriteLine("Such an animal already exists");
        }
    }

    private static void AddAmphibianUI(ZooManager zooManager)
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();

        int age = ReadInt("Age: ");
        string habitat = ReadString("Habitat: ");
        string dietType = ReadString("Diet type: ");
        string color = ReadString("Color: ");
        double weight = ReadDouble("Weight: ");
        string skinMoisture = ReadString("Skin moisture level: ");

        bool isAdded = zooManager.AddAnimal(
            new Amphibian(name, age, habitat, dietType, color, weight, skinMoisture));

        if (isAdded)
        {
            Console.WriteLine("Amphibian added successfully");
        }
        else
        {
            Console.WriteLine("Such an animal already exists");
        }
    }

    private static int ReadInt(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            // Проверка на корректное и неотрицательное число
            if (int.TryParse(input, out int result) && result >= 0)
            {
                return result;
            }

            Console.WriteLine("Invalid number. Try again");
        }
    }

    private static double ReadDouble(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();
            
            // InvariantCulture позволяет вводить и точку, и запятую как разделитель
            if (double.TryParse(input, NumberStyles.Any, 
                CultureInfo.InvariantCulture, out double result) && result >= 0)
            {
                return result;
            }

            if (double.TryParse(input, out result) && result >= 0)
            {
                return result;
            }
            
            Console.WriteLine("Invalid number. Try again");
        }
    }

    private static float ReadFloat(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (float.TryParse(input, out float result) && result >= 0)
            {
                return result;
            }

            Console.WriteLine("Invalid number. Try again");
        }
    }

    private static string ReadString(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                input = input.Trim();

                // Проверка что строка не содержит цифр
                if (!input.Any(char.IsDigit))
                {
                    return input;
                }

                Console.WriteLine("Value cannot contain numbers");
            }
            else
            {
                Console.WriteLine("Value cannot be empty");
            }
        }
    }

    private static bool ReadBool(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine()?.Trim().ToLower();

            if (input == "y" || input == "yes")
            {
                return true;
            }
                
            if (input == "n" || input == "no")
            {
                return false;
            }

            Console.WriteLine("Please enter y/n");
        }
    }
}

public enum menuOption
{
    ShowAllAnimals = 1,
    AddMammal,
    AddBird,
    AddFish,
    AddReptile,
    AddAmphibian,
    Exit
}

public abstract class Animal
{
    /*
    private set нужен чтобы свойства можно было читать только снаружи,
    но менять только внутри конструктора
    */
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Habitat { get; private set; }
    public string DietType { get; private set; }
    public string Color { get; private set; }
    public double Weight { get; private set; }

    protected Animal(string name, int age, string habitat,
                     string dietType, string color, double weight)
    {
        Name = name;
        Age = age;
        Habitat = habitat;
        DietType = dietType;
        Color = color;
        Weight = weight;
    }

    public virtual string GetInfo()
    {
        return $"Name: {Name}, Age: {Age}, Habitat: {Habitat}, " +
               $"Diet: {DietType}, Color: {Color}, Weight: {Weight}";
    }
}

public class Mammal : Animal
{
    public bool HasFur { get; private set; }

    public Mammal(string name, int age, string habitat,
                  string dietType, string color, double weight,
                  bool hasFur)
        : base(name, age, habitat, dietType, color, weight)
    {
        HasFur = hasFur;
    }

    public override string GetInfo()
    {
        return base.GetInfo() +
               $", Type: Mammal, Has fur: {(HasFur ? "Yes" : "No")}";
    }
}

public class Bird : Animal
{
    public float WingSpan { get; private set; }

    public Bird(string name, int age, string habitat,
                string dietType, string color, double weight,
                float wingSpan)
        : base(name, age, habitat, dietType, color, weight)
    {
        WingSpan = wingSpan;
    }

    public override string GetInfo()
    {
        return base.GetInfo() +
               $", Type: Bird, Wing span: {WingSpan}";
    }
}

public class Fish : Animal
{
    public string WaterType { get; private set; }

    public Fish(string name, int age, string habitat,
                string dietType, string color, double weight,
                string waterType)
        : base(name, age, habitat, dietType, color, weight)
    {
        WaterType = waterType;
    }

    public override string GetInfo()
    {
        return base.GetInfo() +
               $", Type: Fish, Water type: {WaterType}";
    }
}

public class Reptile : Animal
{
    public bool IsVenomous { get; private set; }

    public Reptile(string name, int age, string habitat,
                   string dietType, string color, double weight,
                   bool isVenomous)
        : base(name, age, habitat, dietType, color, weight)
    {
        IsVenomous = isVenomous;
    }

    public override string GetInfo()
    {
        return base.GetInfo() +
               $", Type: Reptile, Venomous: {(IsVenomous ? "Yes" : "No")}";
    }
}

public class Amphibian : Animal
{
    public string SkinMoisture { get; private set; }

    public Amphibian(string name, int age, string habitat,
                     string dietType, string color, double weight,
                     string skinMoisture)
        : base(name, age, habitat, dietType, color, weight)
    {
        SkinMoisture = skinMoisture;
    }

    public override string GetInfo()
    {
        return base.GetInfo() +
               $", Type: Amphibian, Skin moisture: {SkinMoisture}";
    }
}

public sealed class ZooManager
{
    private static readonly ZooManager instance = new ZooManager();
    private readonly List<Animal> animals;

    private ZooManager()
    {
        animals = new List<Animal>();
    }

    public static ZooManager Instance
    {
        get
        {
            return instance;
        }
    }

    public bool AddAnimal(Animal animal)
    {
        if (AnimalExists(animal))
        {
            return false;
        }

        animals.Add(animal);
        return true;
    }

    public void ShowAllAnimals()
    {
        if (animals.Count == 0)
        {
            Console.WriteLine("Zoo is empty");
            return;
        }

        for (int index = 0; index < animals.Count; ++index)
        {
            Console.WriteLine($"{index + 1}. {animals[index].GetInfo()}");
        }
    }

    private bool AnimalExists(Animal newAnimal)
    {
        foreach (Animal animal in animals)
        {
            if (animal.GetType() == newAnimal.GetType() &&
                animal.Name.Equals(newAnimal.Name, StringComparison.OrdinalIgnoreCase) &&
                animal.Age == newAnimal.Age &&
                animal.Habitat.Equals(newAnimal.Habitat, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }
}
