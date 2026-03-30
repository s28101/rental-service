namespace RentalServiceApp.Entity;

public abstract class User
{
    public static long _id = 0;
    public long Id { get; set; } = ++_id;
    
    protected string _name;
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Name cannot be null or empty");
            }
        }
    }

    protected string _surname;
    public string Surname
    {
        get => _surname;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Surname cannot be null or empty");
            }
            
            _surname = value;
            
        }
    }

    protected string _email;
    public string Email
    {
        get => _email;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
            {
                throw new ArgumentException("Email cannot be empty or in incorrect format");
            }
            
            _email = value;
        }
    }

    protected DateTime _dob;
    public DateTime DoB
    {
        get => _dob;
        set
        {
            if (value > DateTime.Now)
            {
                throw new Exception("User cannot be born in future");
            }
            
            _dob = value;
        }
    }
    
    public int Age => DateTime.Now.Year - DoB.Year;
    
    public static void setStaticId(int id)
    {
        _id = id;
    }

    protected User(string name, string surname, string email, DateTime dob)
    {
        Name = name;
        Surname = surname;
        Email = email;
        DoB = dob;
    }
}