using System;
using System.Collections.Generic;

abstract class ParkingGarage
{
    protected decimal minimumFee;
    protected decimal hourlyRate;
    protected decimal maxCharge;

    public abstract decimal CalculateCharges(int hoursParked);
}


// Student Name: Desmond Oseme
//Student ID: 24787


class Garage1 : ParkingGarage
{
    public Garage1()
    {
        minimumFee = 2.00m;
        hourlyRate = 0.50m;
        maxCharge = 10.00m;
    }

    public override decimal CalculateCharges(int hoursParked)
    {
        decimal charge = minimumFee + Math.Max(0, hoursParked - 3) * hourlyRate;
        return Math.Min(charge, maxCharge);
    }
}

class Garage2 : ParkingGarage
{
    public Garage2()
    {
        minimumFee = 2.00m;
        hourlyRate = 0.60m;
        maxCharge = 10.00m;
    }

    public override decimal CalculateCharges(int hoursParked)
    {
        decimal charge = minimumFee + Math.Max(0, hoursParked - 3) * hourlyRate;
        return Math.Min(charge, maxCharge);
    }
}

class Garage3 : ParkingGarage
{
    public Garage3()
    {
        minimumFee = 2.00m;
        hourlyRate = 0.75m;
        maxCharge = 10.00m;
    }

    public override decimal CalculateCharges(int hoursParked)
    {
        decimal charge = minimumFee + Math.Max(0, hoursParked - 3) * hourlyRate;
        return Math.Min(charge, maxCharge);
    }
}

class Program
{
    static void Main()
    {

        Console.WriteLine("Student Name: Desmomd Oseme");
        Console.WriteLine("Student ID: 24787\n");


        List<string> garage1Customers = GenerateRandomRegistrationNumbers(10);
        List<string> garage2Customers = GenerateRandomRegistrationNumbers(6);
        List<string> garage3Customers = GenerateRandomRegistrationNumbers(8);

        Console.WriteLine("Garage 1 Charges:");
        CalculateAndDisplayCharges(garage1Customers, new Garage1());

        Console.WriteLine("\nGarage 2 Charges:");
        CalculateAndDisplayCharges(garage2Customers, new Garage2());

        Console.WriteLine("\nGarage 3 Charges:");
        CalculateAndDisplayCharges(garage3Customers, new Garage3());

        Console.ReadLine();
    }

    static void CalculateAndDisplayCharges(List<string> customers, ParkingGarage garage)
    {
        int lessThan3HoursCount = 0;
        int exactly3HoursCount = 0;
        int moreThan3HoursCount = 0;
        decimal totalReceipts = 0;

        foreach (var customer in customers)
        {
            Console.Write($"Enter hours parked for customer {customer}: ");
            int hoursParked = int.Parse(Console.ReadLine());

            decimal charge = garage.CalculateCharges(hoursParked);
            totalReceipts += charge;

            Console.WriteLine($"Parking charge for customer {customer}: €{charge:F2}");

            if (hoursParked < 3)
            {
                lessThan3HoursCount++;
            }
            else if (hoursParked == 3)
            {
                exactly3HoursCount++;
            }
            else
            {
                moreThan3HoursCount++;
            }
        }

        Console.WriteLine($"Total receipts for this garage: €{totalReceipts:F2}");
        Console.WriteLine($"Less than 3 hours: {lessThan3HoursCount} cars");
        Console.WriteLine($"Exactly 3 hours: {exactly3HoursCount} cars");
        Console.WriteLine($"More than 3 hours: {moreThan3HoursCount} cars");
    }

    static List<string> GenerateRandomRegistrationNumbers(int count)
    {
        List<string> registrationNumbers = new List<string>();
        Random random = new Random();

        for (int i = 0; i < count; i++)
        {
            registrationNumbers.Add($"ABC{random.Next(100, 1000)}");
        }

        return registrationNumbers;
    }
}
