namespace RentalServiceApp.Entity.Abstract;

public abstract class Medium
{
    protected static long _id = 0;
    public long Id { get; set; } = ++_id;
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsAvailable { get; set; }
    public bool IsRentable { get; set; } = true;

    protected Medium(string title, string description, bool isAvailable)
    {
        Title = title;
        Description = description;
        IsAvailable = isAvailable;
    }

    public bool takeForMaintainace()
    {
        if (!IsAvailable)
        {
            Console.WriteLine("Item isn't available");
            return false;
        }
        
        IsAvailable = false;
        IsRentable = false;
        return true;
    }

    public bool returnItemFromMaintainace()
    {
        if (IsRentable)
        {
            Console.WriteLine("Item wasn't taken for maintenance");
            return false;
        }
        
        IsAvailable = true;
        IsRentable = true;
        return true;
    }

    public override string ToString()
    {
        return $"ID: {Id},  Title: {Title}, Description: {Description}, Available: {IsAvailable}";
    }
}