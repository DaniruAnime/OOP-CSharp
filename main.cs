using System;
using System.Collections.Generic;

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

}

public class Bird : Animal
{
    public float WingSpan {get; set;}

}

public class Fish : Animal
{
    public string WaterType {get; set;}

}

public class Reptile : Animal
{
    public bool IsVenomous {get; set;}

}

public class Amphibian : Animal
{
    public string SkinMoisture {get; set;}

}

