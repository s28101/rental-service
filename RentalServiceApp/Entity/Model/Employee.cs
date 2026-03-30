using RentalServiceApp.Entity.Abstract;

namespace RentalServiceApp.Entity.Model;

[Serializable]
public class Employee : User
{   
    protected double _salary;

    public double Salary
    {
        get => _salary;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Salary cannot be negative");
            }
            _salary = value;
        }
    }
    
    public Employee(string name, string surname, string email, DateTime dob, double salary) : base(name, surname, email, dob)
    {
        Salary = salary;
        RentingLimit = 5;
    }

    public override string ToString()
    {
        return base.ToString() +  $", Salary: {Salary}";
    }
}