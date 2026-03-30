using RentalServiceApp.Entity.Abstract;
using RentalServiceApp.Entity.Enum;

namespace RentalServiceApp.Entity.Model;


public class Book : Medium
{
    public string Author { get; set; }
    public BookCover Cover { get; set; }
    public string Publisher { get; set; }

    public Book(string title, string description, bool isAvailable, string author, BookCover cover, string publisher) : base(title, description, isAvailable)
    {
        Author = author;
        Cover = cover;
        Publisher = publisher;
    }

    public override string ToString()
    {
        return base.ToString() + $", Author: {Author}, Cover: {Cover}, Publisher: {Publisher}";
    }
}