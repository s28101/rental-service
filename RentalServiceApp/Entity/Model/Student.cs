using RentalServiceApp.Entity.Abstract;

namespace RentalServiceApp.Entity.Model;


public class Student : User
{
    protected int _semesters;
    public int Semesters
    {
        get { return _semesters; }
        set
        {
            if (value < 1 || value > 10)
            {
                throw new ArgumentOutOfRangeException("Semesters must be between 1 and 10");
            }
            
            _semesters = value;
        }
    }

    public Student(string name, string surname, string email, DateTime dob, int semesters) : base(name, surname, email, dob)
    {
        Semesters = semesters;
        RentingLimit = 3;
    }

    public override string ToString()
    {
        return base.ToString() +   $", Semesters: {Semesters}";
    }
}