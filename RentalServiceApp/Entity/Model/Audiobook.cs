namespace RentalServiceApp.Entity;

public class Audiobook : Medium
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
    
    public string Author { get; set; }
    
    public string VoicedBy {get; set;}

    public Audiobook(string title, string description, bool isAvailable, int duration, string author, string voicedBy) : base(title, description, isAvailable)
    {
        Duration = duration;
        Author = author;
        VoicedBy = voicedBy;
    }

    public override string ToString()
    {
        return base.ToString()  + $", Author: {Author}, Duration: {Duration}, Voiced by: {VoicedBy}";
    }
}