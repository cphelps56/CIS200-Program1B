// By: Colin Phelps
// Program 1A
// CIS 200-10
// Summer 2015
// Due: 5/31/2015

// Also By: Andrew L. Wright

// File: TestParcels.cs
// This is a simple, console application designed to exercise the Parcel hierarchy.
// It uses LINQ to sort parcels in different ways and displays them

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created, sorted by LINQ, and displayed.
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("John Smith", "123 Any St.", "Apt. 45",
                "Louisville", "KY", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.", "",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("Sherlock Holmes", "221 Baker Street", "Apt. B",
                "Boston", "MA", 02108); // Test Address 5
            Address a6 = new Address("Tyler Durden", "537 Paper Street", "",
                "Bradford", "DE", 19808);
            Address a7 = new Address("Connor MacManus", "567 Red Road", "",
                "Denver", "CO", 80123);
            Address a8 = new Address("Kevin Lannister", "2020 Blue Street", "Apt. 20",
                "Independence", "MO", 64050);

            Letter letter1 = new Letter(a1, a2, 3.95M); // Letter test object 1
            Letter letter2 = new Letter(a6, a8, 5.25M); // Letter test object 2
            Letter letter3 = new Letter(a4, a7, 4.35M); // Letter test object 3
            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5); // Ground test object 1
            GroundPackage gp2 = new GroundPackage(a5, a3, 20, 18, 18, 15); // Ground test object 2
            GroundPackage gp3 = new GroundPackage(a1, a6, 30, 30, 25, 80); // Ground test object 3
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15, // Next Day test object 1
                85, 7.50M);
            NextDayAirPackage ndap2 = new NextDayAirPackage(a4, a5, 12, 18, 30, // Next Day test object 2
                15, 9.5M);
            NextDayAirPackage ndap3 = new NextDayAirPackage(a8, a1, 40, 50, 40, // Next Day test object 3
                35, 6.85M);
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, // Two Day test object 1
                80.5, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a5, a6, 30, 25, 20, // Two Day test object 2
                25, TwoDayAirPackage.Delivery.Early);
            TwoDayAirPackage tdap3 = new TwoDayAirPackage(a7, a4, 50, 40, 35, // Two Day test object 3
                56, TwoDayAirPackage.Delivery.Saver);


            List<Parcel> parcels;      // List of test parcels

            parcels = new List<Parcel>();

            parcels.Add(letter1); // Populate list
            parcels.Add(letter2);
            parcels.Add(letter3);
            parcels.Add(gp1);
            parcels.Add(gp2);
            parcels.Add(gp3);
            parcels.Add(ndap1);
            parcels.Add(ndap2);
            parcels.Add(ndap3);
            parcels.Add(tdap1);
            parcels.Add(tdap2);
            parcels.Add(tdap3);

            // sort parcels by destination zip 
            var sortedByZip =
                from p in parcels
                orderby p.DestinationAddress.Zip descending
                select p;

            Console.WriteLine("Parcels sorted by destination zip"); // header

            // displays parcels
            foreach (var parcel in sortedByZip)
                Console.WriteLine("\n" + parcel);

            Console.WriteLine("------------------------------------------"); // divider

            // sort parcels by cost
            var sortedByCost =
                from p in parcels
                orderby p.CalcCost()
                select p;

            Console.WriteLine("\nParcels sorted by cost"); // header

            // displays parcels
            foreach (var parcel in sortedByCost)
                Console.WriteLine("\n" + parcel);
            
            Console.WriteLine("------------------------------------------"); // divider
            
            // sort parcels by type
            var sortedByParcelType =
                from p in parcels
                orderby p.GetType().ToString(), p.CalcCost() descending
                select p;

            Console.WriteLine("\nParcels sorted by type and cost"); // header

            // displays parcels
            foreach (var parcel in sortedByParcelType)
                Console.WriteLine("\n" + parcel);

            Console.WriteLine("------------------------------------------"); // divider

            // sort heavy air packages by weight
            var heavyAirPackagesByWeight =
                from p in parcels
                where (p is AirPackage) && (((AirPackage)p).IsHeavy())
                orderby ((AirPackage)p).Weight
                select p;

            Console.WriteLine("\nHeavy Air Packages sorted by weight\n"); // header

            // displays parcels
            foreach (var parcel in heavyAirPackagesByWeight)
                Console.WriteLine("\n" + parcel);

            Console.WriteLine("------------------------------------------"); // divider

            Console.ReadLine();
        }
    }
}
