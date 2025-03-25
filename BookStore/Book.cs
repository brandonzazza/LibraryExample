using System;

namespace BookStore
{
    class Book
    {
        public string Title;
        public string Author;
        public int Year;
        public string ISBN;

        public Book(string title, string author, int year, string isbn) { 
            this.Title = title;
            this.Author = author;
            this.Year = year;
            this.ISBN = isbn;
        }

        public void details() 
        {
            Console.WriteLine($"Title: {this.Title} Author: {this.Author} Year: {this.Year} ISBN: {this.ISBN}");
        }
    }
}
