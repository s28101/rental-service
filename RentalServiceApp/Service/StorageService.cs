

using RentalServiceApp.Entity.Abstract;
using RentalServiceApp.Entity.Model;

namespace RentalServiceApp.Service;

public class StorageService
{
    public static Dictionary<long, User> Users { get; private set; } = new ();
    public static Dictionary<long, Rental> Rentals { get; private set; } = new ();
    public static Dictionary<long, Medium> Items { get; private set; } = new ();
    
    public static void addUser(User user)
    {
        Users.Add(user.Id, user);
    }
    
    public static void addRental(Rental rental){
        Rentals.Add(rental.Id, rental);
    }

    public static void addItem(Medium item)
    {
        Items.Add(item.Id, item);
    }

    private List<Rental> getRentalsFiltered(Predicate<Rental> predicate)
    {
        var result = new List<Rental>();

        foreach (Rental rental in Rentals.Values)
        {
            if (predicate(rental))
            {
                result.Add(rental);
            }
        }
        
        return result;
    }

    public List<Rental> getOverdueRentals()
    {
        Predicate<Rental> filter = rental => rental.IsDue;
        
        return getRentalsFiltered(filter);
    }
    
    public List<Rental> getReturnedOnTimeRentals()
    {
        Predicate<Rental> filter = rental => rental.ReturnDate != null && !rental.IsDue;
        
        return getRentalsFiltered(filter);
    }
    
    public List<Rental> getNotReturnedRentals()
    {
        Predicate<Rental> filter = rental => rental.ReturnDate == null;
        
        return getRentalsFiltered(filter);
    }
    
    public List<Rental> getNotReturnedOverdueRentals()
    {
        Predicate<Rental> filter = rental => rental.ReturnDate == null && rental.IsDue;
        
        return getRentalsFiltered(filter);
    }
    
    public List<Rental> getNotReturnedNotOverdueRentals()
    {
        Predicate<Rental> filter = rental => rental.ReturnDate == null && !rental.IsDue;
        
        return getRentalsFiltered(filter);
    }

    public List<Student> GetStudents()
    {
        List<Student> result = new List<Student>();

        foreach (User user in Users.Values)
        {
            if (user is Student student)
            {
                result.Add(student);
            }
        }
        
        return  result;
    }

    public List<Employee> GetEmployees()
    {
        List<Employee> result = new List<Employee>();
        
        foreach(User user in Users.Values)
        {
            if (user is Employee employee)
            {
                result.Add(employee);
            }
        }
        
        return result;
    }

    

}