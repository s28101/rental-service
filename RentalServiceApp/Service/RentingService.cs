using RentalServiceApp.Entity.Abstract;
using RentalServiceApp.Entity.Model;

namespace RentalServiceApp.Service;

public class RentingService
{
    public static Rental? rent(User user, Medium item, DateOnly rentDate)
    {
        if (item == null)
        {
            throw new ArgumentNullException("Item cannot be null");
        }

        if (!item.IsAvailable)
        {
            Console.WriteLine("Item is not available");
            return null;
        }

        if (user.Rented >= user.RentingLimit)
        {
            Console.WriteLine("Renting limit exceeded");
            return null;
        }
        
        item.IsAvailable = false;
        user.Rented++;
        var rental = new Rental(user, item, rentDate, rentDate.AddDays(user.RentingLimit * 7));
        StorageService.add(rental);
        
        return rental;
    }
    
    public static bool returnItem(Rental rental)
    {
        if (rental == null)
        {
            throw new ArgumentNullException("rental cannot be null");
        }

        if (rental.ReturnDate != null)
        {
            Console.WriteLine("Item was already returned");
            return false;
        }

        rental.ReturnDate = DateOnly.FromDateTime(DateTime.Now);
        User user = rental.Reciever;
        Medium item = rental.Item;

        user.Rented--;
        item.IsAvailable = true;

        if (rental.IsDue)
        {
            Console.WriteLine("Item was overdue");
            applyPenalty(user);
        }
        else
        {
            Console.WriteLine("thank you for timely return");
            
            if (user.RentingLimit < 5)
            {
                liftPenalty(user);
            }
            
        }

        return true;
    }
    
    public static bool returnItem(Rental rental, DateOnly date)
    {
        if (rental == null)
        {
            throw new ArgumentNullException("rental cannot be null");
        }

        if (rental.ReturnDate != null)
        {
            Console.WriteLine("Item was already returned");
            return false;
        }
        
        rental.ReturnDate = date;
        User user = rental.Reciever;
        Medium item = rental.Item;

        user.Rented--;
        item.IsAvailable = true;

        if (rental.IsDue)
        {
            Console.WriteLine("Item was overdue");
            applyPenalty(user);
        }
        else
        {
            Console.WriteLine("thank you for timely return");
            
            if (user.RentingLimit < 5)
            {
                liftPenalty(user);
            }
            
        }

        return true;
    }

    private static void applyPenalty(User user)
    {
        user.RentingLimit--;
    }

    private static void liftPenalty(User user)
    {
        user.RentingLimit++;
    }
}