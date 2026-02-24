using System;
using System.Collections.Generic;

class Programm
{
    static void Main()
    {
        



    }
}

public abstract class Animal
{
    public string Name {get; set;}
    public int Age {get; set;}
    public string Habitat {get; set;}
    public string DietType {get; set;}
    public string Skin {get; set;}
    public int Weight {get; set;}

    protected Animal(string name, int age, string habitat, string dietType, string skin, int weight)
    {
        Name = name;
        Age = age;
        Habitat = habitat;
        DietType = dietType;
        Skin = skin;
        Weight = weight;
    }

    public virtual string GetInfo()
    {
        return $"Name: {Name}, Age: {Age}, Habitat: {Habitat}, Diet type: {DietType}, Skin: {Skin}, Weight: {Weight}";
    }
}

public class Mammal : Animal
{
    public bool HasFur {get; set;}

    public Mammal(string name, int age, string habitat, string dietType, string skin, int weight, bool hasFur) : base(name, age, habitat, dietType, skin, weight) => HasFur = hasFur;

    public override string GetInfo()
    {
        return base.GetInfo() + $", Type: mammal, HasFur: {(HasFur ? "Yes" : "No")}";;
    }
}

public class Bird : Animal
{
    public float WingSpan {get; set;}

    public Bird(string name, int age, string habitat, string dietType, string skin, int weight, float wingSpan) : base(name, age, habitat, dietType, skin, weight) => WingSpan = wingSpan;

    public override string GetInfo()
    {
        return base.GetInfo() + $", Type: bird, Wing span: {WingSpan}";
    }
}

public class Fish : Animal
{
    public string WaterType {get; set;}

    public Fish(string name, int age, string habitat, string dietType, string skin, int weight, string waterType) : base(name, age, habitat, dietType, skin, weight) => WaterType = waterType;

    public override string GetInfo()
    {
        return base.GetInfo() + $", Type: fish, Water: {WaterType}";
    }
}

public class Reptile : Animal
{
    public bool IsVenomous {get; set;}

    public Reptile(string name, int age, string habitat, string dietType, string skin, int weight, bool isVenomous) : base(name, age, habitat, dietType, skin, weight) => IsVenomous = isVenomous;

    public override string GetInfo()
    {
        return base.GetInfo() + $", Type: reptile, Is venomous: {(IsVenomous ? "Yes" : "No")}";
    }
}

public class Amphibian : Animal
{
    public string SkinMoisture {get; set;}

    public Amphibian(string name, int age, string habitat, string dietType, string skin, int weight, string skinMoisture) : base(name, age, habitat, dietType, skin, weight) => SkinMoisture = skinMoisture;

    public override string GetInfo()
    {
        return base.GetInfo() + $", Type: amphibian, Skin moisture: {IsVenomous}";
    }

}

