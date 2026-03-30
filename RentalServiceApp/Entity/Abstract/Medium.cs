namespace RentalServiceApp.Entity;

public abstract class Medium
{
    protected static long _id = 0;
    public long Id { get; set; } = ++_id;
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsAvailable { get; set; }

    protected Medium(string title, string description, bool isAvailable)
    {
        Title = title;
        Description = description;
        IsAvailable = isAvailable;
    }

    public override string ToString()
    {
        return $"ID: {Id},  Title: {Title}, Description: {Description}, Available: {IsAvailable}";
    }
}