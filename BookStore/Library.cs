using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore
{
    class Library
    {

        private List<Book> books = new List<Book>();

        public Library()
        {
            this.books = new List<Book>();
        }

        public List<Book> getBooks()
        {
            return this.books;
        }

        public static void Menu()
        {
            Console.WriteLine("Welcome to the Book Store\n1. Add a Book\n2. Remove a book\n3. List all Books\n4. Search for a book\n5. Exit");
            Console.Write("Enter Action: ");
        }

        public void removeBook(int n) 
        {
            if (n < this.books.Count() && n >= 0)
            {
                this.books.RemoveAt(n);
                Console.WriteLine("Book Removed");
            }
            else 
            {
                Console.WriteLine("Book Index Not Found");
            } 
        }

        public bool listBooks() 
        {
            List<Book> books = getBooks();

            if (books.Count() > 0)
            {
                int index = 0;

                foreach (Book b in books)
                {
                    Console.Write($"{index}: ");
                    b.details();
                    index++;
                }
                return true;
            }
            else 
            { 
                Console.WriteLine("No Books Available");
                return false;
            }

            
        }

        public void Program() 
        {
            bool check = true;
            while (check)
            {
                Menu();
                try
                {
                    string input = Console.ReadLine();
                    int x = Convert.ToInt32(input);

                    if (x == 1)
                    {
                        try
                        {
                            Console.Write("Title Name: ");
                            string Title = Console.ReadLine();

                            Console.Write("Author Name: ");
                            string Author = Console.ReadLine();

                            int YearVal = 0;
                        
                            Console.Write("Input Year: ");
                            string Year = Console.ReadLine();
                            YearVal = Convert.ToInt32(Year);

                            Console.Write("Input ISBN: ");
                            string ISBN = Console.ReadLine();

                            Book b = new Book(Title, Author, YearVal, ISBN);
                            this.books.Add(b);
                            Console.WriteLine("Book Added");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error");
                        }
                    }
                    else if (x == 2)
                    {
                        bool book_check = listBooks();
                        if (book_check)
                        {
                            Console.Write("Enter Book to Remove");
                            string choice = Console.ReadLine();
                            try
                            {
                                int choiceInt = Convert.ToInt32(choice);
                                removeBook(choiceInt);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                    }
                    else if (x == 3)
                    {
                        listBooks();
                    }
                    else if (x == 4)
                    {
                        Console.Write("Enter Book Title: ");
                        string bookTitle = Console.ReadLine();
                        
                        var query = from book in books where book.Title == bookTitle select book;

                        if (query.Count() > 0)
                        {
                            foreach (var book in query)
                            {
                                book.details();
                            }
                        }
                        else {
                            Console.WriteLine("Book Not Found");
                        }  
                        
                    }
                    else if (x == 5)
                    {
                        Console.WriteLine("Exiting Program");
                        check = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        static void Main(string[] args)
        {
            Library library = new Library();
            library.Program();
        }
    }
}
