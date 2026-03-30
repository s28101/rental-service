using RentalServiceApp.Entity.Enum;
using RentalServiceApp.Entity.Model;
using RentalServiceApp.Service;

namespace RentalServiceApp;

public class Main
{
    public static void main(string[] args)
    {   
        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine("Creation of items");
        var book = new Book("Wiedzmin", "A story about a white-haired man", true, "Sapkowski", BookCover.PAPERBAG,
            "SuperNowa");
        var audiobook = new Audiobook("METRO 2033", "A story about living in russia", false, 400, "Glukhovsky", "Rasputin");
        var movie = new Movie("Horse", "Everyone knows what a horse is", true, 135, "Samuel Linde");
        
        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine("Adding items to the extend");
        StorageService.add(book);
        StorageService.add(audiobook);
        StorageService.add(movie);
        
        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine("Creation of users");
        var student = new Student("Jas", "Fasola", "jas@fasola.de", new DateTime(333, 12, 3), 2);
        var employee = new Employee("Saj", "Alosaf", "alosaf@saj.ed", new DateTime(777, 7, 7), 64.31);
        
        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine("Adding users to the extend");
        StorageService.add(student);
        StorageService.add(employee);
        
        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine("Correct renting");
        var check = RentingService.rent(student, book, DateOnly.FromDateTime(DateTime.Now));
        Console.WriteLine(check != null);
        
        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine("Incorrect renting");
        var check2 = RentingService.rent(employee, book, DateOnly.FromDateTime(DateTime.Now));
        Console.WriteLine(check2 != null);
        
        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine("Return on time with reward as sign of building trust");
        Console.WriteLine($"User's renting limit before return: {student.RentingLimit}");
        RentingService.returnItem(check);
        Console.WriteLine($"User's renting limit after timely return: {student.RentingLimit}");
        
        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine("Correct renting");
        var check3 = RentingService.rent(employee, movie, DateOnly.FromDateTime(new DateTime(1000, 4, 23)));
        Console.WriteLine(check3 != null);
        
        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine("Overdue return with penalty");
        Console.WriteLine($"User's renting limit before return: {student.RentingLimit}");
        RentingService.returnItem(check3, DateOnly.FromDateTime(new DateTime(1984, 10, 1)));
        Console.WriteLine($"User's renting limit after timely return: {student.RentingLimit}");
        
        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine("Short summary\n\n");
        var ss = new StorageService();
        ss.generateShortSummary();

    }
}