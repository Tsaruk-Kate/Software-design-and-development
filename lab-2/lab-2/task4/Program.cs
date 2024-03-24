using System;
using System.Collections.Generic;

public class Virus : ICloneable
{
    public double Weight { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public List<Virus> Children { get; set; }

    public Virus(double weight, int age, string name, string type)
    {
        Weight = weight;
        Age = age;
        Name = name;
        Type = type;
        Children = new List<Virus>();
    }

    public void AddChild(Virus child)
    {
        Children.Add(child);
    }

    public object Clone()
    {
        Virus clone = new Virus(Weight, Age, Name, Type);

        foreach (var child in Children)
        {
            clone.AddChild((Virus)child.Clone());
        }

        return clone;
    }

    public void PrintDetails(string prefix = "")
    {
        Console.WriteLine($"{prefix}Name: {Name}, Weight: {Weight}, Age: {Age}, Type: {Type}");
        foreach (var child in Children)
        {
            child.PrintDetails(prefix + "  ");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Virus grandParentVirus = new Virus(1.5, 10, "Grandparent", "Type1");
        Virus parentVirus = new Virus(1.2, 5, "Parent", "Type2");
        Virus childVirus1 = new Virus(0.8, 2, "Child1", "Type3");
        Virus childVirus2 = new Virus(0.9, 1, "Child2", "Type4");

        grandParentVirus.AddChild(parentVirus);
        parentVirus.AddChild(childVirus1);
        parentVirus.AddChild(childVirus2);

        Console.WriteLine("Original Virus Family:");
        grandParentVirus.PrintDetails();

        Virus clonedVirusFamily = (Virus)grandParentVirus.Clone();

        Console.WriteLine("\nCloned Virus Family:");
        clonedVirusFamily.PrintDetails();
    }
}
