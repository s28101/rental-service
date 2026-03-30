using RentalServiceApp.Entity.Abstract;

namespace RentalServiceApp.Entity.Model;

[Serializable]
public class Rental
{   
    private static long _id = 0;
    public long Id { get; set; } = ++_id;
    public User Reciever { get; set; }
    public Medium Item { get; set; }
    public DateOnly RentalDate { get; set; }
    public DateOnly DueDate { get; set; }
    public DateOnly ReturnDate { get; set; }
    public bool IsDue { get; set; } =  false;

    public Rental(Medium item, DateOnly rentalDate, DateOnly dueDate)
    {
        Item = item;
        RentalDate = rentalDate;
        DueDate = dueDate;
    }

    public void setStaticId(long id)
    {
        _id = id;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Reciever: {Reciever},  Item: {Item}, DueDate: {DueDate}, ReturnDate: {ReturnDate},  IsDue: {IsDue}";
    }
}