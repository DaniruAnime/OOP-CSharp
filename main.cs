using System;
using System.Collections.Generic;
using System.Globalization;

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
            Console.WriteLine("\n--- Zoo Menu ---");
            Console.WriteLine("1. Show all animals");
            Console.WriteLine("2. Add mammal");
            Console.WriteLine("3. Add bird");
            Console.WriteLine("4. Add fish");
            Console.WriteLine("5. Add reptile");
            Console.WriteLine("6. Add amphibian");
            Console.WriteLine("7. Exit");
            Console.Write("Select option: ");

            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    zooManager.ShowAllAnimals();
                    break;
                case "2":
                    AddMammalUI(zooManager);
                    break;
                case "3":
                    AddBirdUI(zooManager);
                    break;
                case "4":
                    AddFishUI(zooManager);
                    break;
                case "5":
                    AddReptileUI(zooManager);
                    break;
                case "6":
                    AddAmphibianUI(zooManager);
                    break;
                case "7":
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

        zooManager.AddAnimal(
            new Mammal(name, age, habitat, dietType, color, weight, hasFur));

        Console.WriteLine("Mammal added successfully");
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

        zooManager.AddAnimal(
            new Bird(name, age, habitat, dietType, color, weight, wingSpan));

        Console.WriteLine("Bird added successfully");
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

        zooManager.AddAnimal(
            new Fish(name, age, habitat, dietType, color, weight, waterType));

        Console.WriteLine("Fish added successfully");
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

        zooManager.AddAnimal(
            new Reptile(name, age, habitat, dietType, color, weight, isVenomous));

        Console.WriteLine("Reptile added successfully");
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

        zooManager.AddAnimal(
            new Amphibian(name, age, habitat, dietType, color, weight, skinMoisture));

        Console.WriteLine("Amphibian added successfully");
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
            
            // Проверка на пустой ввод
            if (!string.IsNullOrWhiteSpace(input))
            {
               return input.Trim();
            }

            Console.WriteLine("Value cannot be empty"); 
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

            Console.WriteLine("Please enter y/n.");
        }
    }
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

    // virtual разрешает наследникам переопределять этот метод
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

    public static ZooManager Instance => instance;

    public void AddAnimal(Animal animal)
    {
        animals.Add(animal);
    }

    public void ShowAllAnimals()
    {
        if (animals.Count == 0)
        {
            Console.WriteLine("Zoo is empty.");
            return;
        }

        for (int index = 0; index < animals.Count; index++)
        {
            Console.WriteLine($"{index + 1}. {animals[index].GetInfo()}");
        }
    }
}