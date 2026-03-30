using RentalServiceApp.Entity.Abstract;
using RentalServiceApp.Entity.Model;

namespace RentalServiceApp.Service;

public class RentingService
{
    public bool rent(User user, Medium item, DateOnly rentDate)
    {
        if (item == null)
        {
            throw new ArgumentNullException("Item cannot be null");
        }

        if (!item.IsAvailable)
        {
            Console.WriteLine("Item is not available");
            return false;
        }

        if (user.Rented >= user.RentingLimit)
        {
            Console.WriteLine("Renting limit exceeded");
            return false;
        }
        
        var rental = new Rental(user, item, rentDate, rentDate.AddDays(user.RentingLimit * 7));
        StorageService.addRental(rental);
        
        return true;
    }
    
    public bool returnItem(Rental rental)
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
    
    public bool returnItem(Rental rental, DateOnly date)
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

    private void applyPenalty(User user)
    {
        user.RentingLimit--;
    }

    private void liftPenalty(User user)
    {
        user.RentingLimit++;
    }
}