using RentalServiceApp.Entity.Enum;
using RentalServiceApp.Entity.Model;
using RentalServiceApp.Service;

namespace RentalServiceApp;

public class Main
{
    public static void main(string[] args)
    {
        var book = new Book("Wiedzmin", "A story about a white-haired man", true, "Sapkowski", BookCover.PAPERBAG,
            "SuperNowa");
        var audiobook = new Audiobook("METRO 2033", "A story about living in russia", false, 400, "Glukhovsky", "Rasputin");
        var movie = new Movie("Horse", "Everyone knows what a horse is", true, 135, "Samuel Linde");
        
        StorageService.add(book);
        StorageService.add(audiobook);
        StorageService.add(movie);

        var student = new Student("Jas", "Fasola", "jas@fasola.de", new DateTime(333, 12, 3), 2);
        var employee = new Employee("Saj", "Alosaf", "alosaf@saj.ed", new DateTime(777, 7, 7), 64.31);
        
        StorageService.add(student);
        StorageService.add(employee);

        var check = RentingService.rent(student, book, DateOnly.FromDateTime(DateTime.Now));
        Console.WriteLine(check != null);
        
        var check2 = RentingService.rent(employee, book, DateOnly.FromDateTime(DateTime.Now));
        Console.WriteLine(check2 != null);
        
        RentingService.returnItem(check);

        var check3 = RentingService.rent(employee, movie, DateOnly.FromDateTime(new DateTime(1000, 4, 23)));
        Console.WriteLine(check3 != null);
        Console.WriteLine(employee.RentingLimit);
        RentingService.returnItem(check3, DateOnly.FromDateTime(new DateTime(1984, 10, 1)));
        Console.WriteLine(employee.RentingLimit);

        var ss = new StorageService();
        Console.WriteLine("\n\n\n\n\n\n");
        ss.generateShortSummary();

    }
}