using System;

abstract class Device
{
    public abstract void DisplayInfo();
}
class Laptop : Device
{
    public override void DisplayInfo()
    {
        Console.Write("Laptop ");
    }
}

class Netbook : Device
{
    public override void DisplayInfo()
    {
        Console.Write("Netbook ");
    }
}

class EBook : Device
{
    public override void DisplayInfo()
    {
        Console.Write("EBook ");
    }
}

class Smartphone : Device
{
    public override void DisplayInfo()
    {
        Console.Write("Smartphone ");
    }
}

// Abstract class for device factories
abstract class DeviceFactory
{
    public abstract Device CreateDevice();
}

// Concrete classes for different device factories
class IPhoneFactory : DeviceFactory
{
    public override Device CreateDevice()
    {
        return new Smartphone();
    }
}

class XiaomiFactory : DeviceFactory
{
    public override Device CreateDevice()
    {
        return new Laptop();
    }
}

class GalaxyFactory : DeviceFactory
{
    public override Device CreateDevice()
    {
        return new Netbook();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose the type of device: (1 - Laptop, 2 - Netbook, 3 - EBook, 4 - Smartphone)");
        int deviceType = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Choose the brand of the device: (1 - IPhone, 2 - Xiaomi, 3 - Galaxy)");
        int brandType = Convert.ToInt32(Console.ReadLine());

        DeviceFactory factory = null;

        // Choose factory based on brand
        switch (brandType)
        {
            case 1:
                factory = new IPhoneFactory();
                break;
            case 2:
                factory = new XiaomiFactory();
                break;
            case 3:
                factory = new GalaxyFactory();
                break;
            default:
                Console.WriteLine("Invalid brand selected.");
                return;
        }

        Device device = null;

        // Create device based on type
        switch (deviceType)
        {
            case 1:
                device = new Laptop();
                break;
            case 2:
                device = new Netbook();
                break;
            case 3:
                device = new EBook();
                break;
            case 4:
                device = new Smartphone();
                break;
            default:
                Console.WriteLine("Invalid device type selected.");
                return;
        }

        // Display information about the created device and brand
        Console.Write("Manufactured: ");
        device.DisplayInfo();
        switch (brandType)
        {
            case 1:
                Console.WriteLine("IPhone");
                break;
            case 2:
                Console.WriteLine("Xiaomi");
                break;
            case 3:
                Console.WriteLine("Galaxy");
                break;
            default:
                break;
        }
    }
}
