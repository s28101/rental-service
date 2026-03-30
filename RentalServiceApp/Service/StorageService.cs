

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

    
    

}