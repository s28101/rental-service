

using RentalServiceApp.Entity.Abstract;
using RentalServiceApp.Entity.Model;

namespace RentalServiceApp.Service;

public class StorageService
{
    public static Dictionary<long, User> Users { get; private set; } = new ();
    public static Dictionary<long, Rental> Rentals { get; private set; } = new ();
    public static Dictionary<long, Medium> Items { get; private set; } = new ();

    public void generateShortSummary()
    {
        Console.WriteLine($"There currently are {Users.Count} users: {GetStudents().Count} Students and {GetEmployees().Count} Employees\n");
        Console.WriteLine($"Out of our {Items.Count} items there are: {getBooks().Count} Books, {getAudiobooks().Count} Audiobooks, and {getMovies().Count} Movies\n");
        Console.WriteLine($"{getNotRentableItems().Count} of items is under maintenance");
        Console.WriteLine($"Out of {Items.Count - getNotRentableItems().Count} rentable items {getAvailableItems().Count} are available\n");
        Console.WriteLine($"There are {Rentals.Count} records of rentals");
        Console.WriteLine($"{getOverdueRentals().Count} of rentals are overdue");
        Console.WriteLine($"out of which {getNotReturnedOverdueRentals().Count} are yet to be returned");
        Console.WriteLine($"{getReturnedOnTimeRentals().Count} of rentals were returned on time");
        Console.WriteLine($"There are {getNotReturnedNotOverdueRentals().Count} rentals that have a chance to be returned on time");
    }
    
    public static void addUser(User user)
    {
        Users.Add(user.Id, user);
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
  
    public static void addRental(Rental rental){
        Rentals.Add(rental.Id, rental);
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

    public List<Rental> getUsersRentals(User user)
    {
        Predicate<Rental> filter = rental => rental.Reciever == user;
        
        return getRentalsFiltered(filter);
    }

    public List<Rental> getItemsRentals(Medium item)
    {
        Predicate<Rental> filter = rental => rental.Item == item;
        return getRentalsFiltered(filter);
    }
    
    public static void addItem(Medium item)
        {
            Items.Add(item.Id, item);
        }

    private List<Medium> getItemsFiltered(Predicate<Medium> predicate)
    {
        var result = new List<Medium>();

        foreach (Medium item in Items.Values)
        {
            if (predicate(item))
            {
                result.Add(item);
            }
        }

        return result;
    }

    public List<Medium> getAvailableItems()
    {
        Predicate<Medium> filter = item => item.IsAvailable;
        
        return getItemsFiltered(filter);
    }

    public List<Medium> getNotAvailableItems()
    {
        Predicate<Medium> filter = item => !item.IsAvailable;
        return getItemsFiltered(filter);
    }

    public List<Medium> getNotRentableItems()
    {
        Predicate<Medium> filter = item => !item.IsRentable;
        return getItemsFiltered(filter);
    }

    public List<Audiobook> getAudiobooks()
    {
        List<Audiobook> result = new List<Audiobook>();
  
        foreach (Medium item in Items.Values)
        {
            if (item is Audiobook audiobook)
            {
                result.Add(audiobook);
            }
        }
          
        return  result;
    }
    
    public List<Book> getBooks()
    {
        List<Book> result = new List<Book>();
  
        foreach (Medium item in Items.Values)
        {
            if (item is Book book)
            {
                result.Add(book);
            }
        }
          
        return  result;
    }
    
    public List<Movie> getMovies()
    {
        List<Movie> result = new List<Movie>();
  
        foreach (Medium item in Items.Values)
        {
            if (item is Movie movie)
            {
                result.Add(movie);
            }
        }
          
        return  result;
    }

}