using RentalServiceApp.Entity.Abstract;

namespace RentalServiceApp.Entity.Model;


public class Movie : Medium
{
    private int _duration;
    public int Duration
    {
        get => _duration;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Duration cannot be negative");
            }
            _duration = value;
        }
    }
    
    public string Director { get; set; }

    public Movie(string title, string description, bool isAvailable, int duration, string director) : base(title, description, isAvailable)
    {
        Duration = duration;
        Director = director;
    }

    public override string ToString()
    {
        return base.ToString() + $", Director: {Director}, Duration: {Duration}";
    }
}