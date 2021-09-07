using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Entities;
using Domain;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = File.ReadAllText("../../../../connection.txt");

            var options = new DbContextOptionsBuilder<RetP0Context>()
                //.LogTo(message => Debug.WriteLine(message))
                .UseSqlServer(connectionString)
                .Options;



            using var context = new RetP0Context(options);
           IDL repo = new DL(context);


            bool repeat = true;
            do
            {
                Console.WriteLine("________________________________");
                Console.WriteLine("||Hello, Welcome to the jungle!||");
                Console.WriteLine("[1] List of all the restaurants");
                Console.WriteLine("[2] List all users");             
                Console.WriteLine("[3] Add a User");
                Console.WriteLine("[4] Add a Restaurant");
                
                Console.WriteLine("[5] Search a Restaurant");
                Console.WriteLine("[6] Delete a User");
                Console.WriteLine("[7] Delete a review");
                Console.WriteLine("[8] Delete a restaurant");
                Console.WriteLine("[9] Add a Suggestion");
                Console.WriteLine("[10] List Suggestions");
                Console.WriteLine("[11] Add Review");
                Console.WriteLine("[12] Delete a reviewsecond");
                Console.WriteLine("[0] Exit");

                switch (Console.ReadLine())
                {
                    case "0":
                        Console.WriteLine("ADIOS!");
                        repeat = false;
                        break;

                    case "1":

                        ListRestaurant(repo);

                        break;

                    case "2":
                        ListUser(repo);

                        break;

                    case "3":

                        AddUser(repo);

                        break;
                    case "4":
                            AddRestaurant(repo);

                        break;
                    case "5":

                        SearchRestaurant(repo);

                        break;
                      
                    case "6":

                        DeleteUser(repo);

                        break;
                    case "7":

                        DeleteReview(repo);

                        break;
                    case "8":

                        DeleteRestaurant(repo);

                        break;
                       
                    case "9":

                        AddSuggestion(repo);

                        break;
                    case "10":

                        ListSuggestion(repo);

                        break;

                    case "11":

                        AddReviewSecond(repo);

                        break;

                    case "12":

                        DeleteReviewSecond(repo);

                        break;


                    case "99":
                        Console.WriteLine("You have entered into the secret Administrator path...Enter password:");
                        string z = Console.ReadLine();
                        if (z == "*****")
                        {
                         


                            Console.WriteLine("You have activated special functionalities");
                            Console.WriteLine();
                            Console.WriteLine("[1] Add a restaurant");
                            Console.WriteLine("[2] Average Rating of each restaurant");
                            Console.WriteLine("[3] View all the reviews");
                            Console.WriteLine("[4] View all the users");
                            int c = Convert.ToInt32(Console.ReadLine());
                            if (c == 1)
                            {
                                Console.WriteLine("You are about to add a restaurant");
                               
                                Console.WriteLine("You are exiting administrator mode now");
                            }
                            else if (c == 2)
                            {
                                Console.WriteLine("This is a calculated average of the restaurant selected");
                                
                                Console.WriteLine("You are exiting administrator mode now");

                            }
                            else if (c == 3)
                            {
                                Console.WriteLine("These are all the reviews that we have collected!");
                                
                                Console.WriteLine("You are exiting administrator mode now");

                            }
                            else if (c == 4)
                            {
                                Console.WriteLine("These are all the users that have signed in so far");
                                
                                Console.WriteLine("You are exiting administrator mode now");

                            }
                            else
                            {
                                Console.WriteLine("You are exiting administrator mode now.");

                            }

                        }
                        else
                        {
                            Console.WriteLine("You are not that guy pal.");
                        }

                        break;

                    default:
                        Console.WriteLine("We don't understand what you're doing");
                        break;
                }
            } while (repeat);
        }

        private static void ListRestaurant(IDL x)
        {
            List<Domain.Restaurant> notes = x.GetRestaurants();

            Console.WriteLine();

            if (notes.Count == 0)
            {
                Console.WriteLine("none");
            }
            else
            {
                foreach (var note in notes)
                {
                    Console.WriteLine("Name: "+ note.Name + "  ||  Address: " + note.Address);
                }
            }

        }
        private static void ListSuggestion(IDL x)
        {
            List<Domain.Suggestion> notes = x.ListSuggestion();

            Console.WriteLine();

            if (notes.Count == 0)
            {
                Console.WriteLine("none");
            }
            else
            {
                foreach (var note in notes)
                {
                    Console.WriteLine("Name: " + note.Name);
                }
            }

        }
        private static void ListUser(IDL x)
        {
            List<Domain.Customer> users = x.ListUser();

            Console.WriteLine();

            if (users.Count == 0)
            {
                Console.WriteLine("none");
            }
            else
            {
                foreach (var user in users)
                {
                    Console.WriteLine("Name: " + user.Name + "  ||  Last Name: " + user.LastName);
                }
            }

        }

        private static void AddUser(IDL repo)
        {
            Console.WriteLine("Enter your name: ");
            string a = Console.ReadLine();
            Console.WriteLine("Enter your last name");
            string b = Console.ReadLine();
            Console.WriteLine("Enter your phone number");
            double c = Convert.ToDouble(Console.ReadLine());      //try catch if you input a string DO!!
            Console.WriteLine("Enter your email");
            string d = Console.ReadLine();

            Domain.Customer customer = new Domain.Customer(a, b, c, d);

            customer = repo.AddUser(customer);
            Console.WriteLine("User has been added");
    
        }
        private static void DeleteUser(IDL repo)
        {
            Console.WriteLine("Enter the ID");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the name");
            string b = Console.ReadLine();
            
            Domain.Customer customer = new Domain.Customer(a, b);

            customer = repo.DeleteUser(customer);
            Console.WriteLine("User has been deleted");

        }
        private static void DeleteReview(IDL repo)
        {
            Console.WriteLine("Enter the UserID");
            int k = Convert.ToInt32(Console.ReadLine());

            Domain.Review customer = new Domain.Review(k);

            customer = repo.DeleteReview(customer);
            Console.WriteLine("Review has been deleted");

        }
        private static void DeleteReviewSecond(IDL repo)
        {

            
            Console.WriteLine("Enter the Id");
            int a = Convert.ToInt32( Console.ReadLine());
           

            Domain.ReviewSecond customer = new Domain.ReviewSecond(a);

            customer = repo.DeleteReviewSecond(customer);
            Console.WriteLine("Review has been deleted");

        }
        private static void DeleteRestaurant(IDL repo)
        {
            Console.WriteLine("Enter the ID");
            int k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the name");
            string n = Console.ReadLine();

            Domain.Restaurant res = new Domain.Restaurant(k,n);

            res = repo.DeleteRestaurant(res);
            Console.WriteLine("Restaurant has been deleted");

        }
        /*
                private Domain.Review SelectReview(List<Domain.Review> review)
                {
                    int selection;

                    bool valid = false;

                    do
                    {
                        for (int i = 0; i < review.Count; i++)
                        {
                            Console.WriteLine($"[{i}] {review[i].Id} , Comment: {review[i].Comments}");

                        }
                        //foreach(Restaurant res in restaurants)                             //either one works
                        //  {                                                                   //use if for now
                        //Console.WriteLine(res.Id + " <= "+  res.Name + " efeefefe "+ res.City);

                        //  }

                        valid = int.TryParse(Console.ReadLine(), out selection);
                        // parsing to int has been successful and withing range
                        if (valid && (selection >= 0 && selection < review.Count))
                        {

                            return review[selection];
                        }
                        Console.WriteLine("Enter something valid");
                    } while (true);

                }
        */

        private static void AddRestaurant(IDL repo)
        {


            Console.WriteLine("Enter the name of the restaurant you want to add");
            string a = Console.ReadLine();
            Console.WriteLine("Enter its address");
            string b = Console.ReadLine();
            Console.WriteLine("Enter the City");
            string c = Console.ReadLine();
            Console.WriteLine("Enter the State");
            string d = Console.ReadLine();
            Console.WriteLine("Enter the ZipCode");         // only numbers
            int e = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Cuisine");
            string f = Console.ReadLine();
            Console.WriteLine("Enter the Rating");           // all good here
            decimal g = Convert.ToDecimal(Console.ReadLine());
            Domain.Restaurant restaurant = new Domain.Restaurant(a, b, c, d, e, f, g);

            restaurant = repo.AddRestaurant(restaurant);
            Console.WriteLine("Restaurant has been added to the Data Base!");

        }

        private static void AddSuggestion(IDL repo)
        {


            Console.WriteLine("Enter your name");
            string a = Console.ReadLine();
            Console.WriteLine("Enter your email address");
            string b = Console.ReadLine();

            Console.WriteLine("Enter the message");
            string c = Console.ReadLine();


            Domain.Suggestion sug = new Domain.Suggestion(a, b, c);

            sug = repo.AddSuggestion(sug);
            Console.WriteLine("You have entered a new suggestion");

        }

        private static void AddReviewSecond(IDL repo)
        {


            Console.WriteLine("Enter your name");
            string a = Console.ReadLine();
            Console.WriteLine("Enter your comment");
            string b = Console.ReadLine();

            Console.WriteLine("Enter your rating");

            decimal c = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter your restaurantid");
            int d = Convert.ToInt32(Console.ReadLine());


            Domain.ReviewSecond sug = new Domain.ReviewSecond(a, b, c,d);

            sug = repo.AddReviewSecond(sug);

            Console.WriteLine("You have entered a new Review");

        }

        private static void SearchRestaurant(IDL repo)
        {
            Console.WriteLine("Enter the restaurant you want to search: ");
            string enter;
            enter = Console.ReadLine();

            Domain.Restaurant restaurant = repo.SearchRestaurant(enter);

            if (restaurant.Name is null)
            {

                Console.WriteLine("we did not find your restaurant " + enter); // since that name is not found on the data base
                                                                               //Console.WriteLine("You can try with the type of Cuisine or zipcode")                                                                            // x = Console.ReadLine();
            
            }                                                                            // it will return nothing so blank
            else                                                                        // that is why you gotota used enter only in this case
            {
                Console.WriteLine("You have selected: " + restaurant.Name);
                Console.WriteLine("Here is more information about your restaurant.");
                Console.WriteLine("Name: " + restaurant.Name + " Address: " + restaurant.Address + " City: " + restaurant.City + " Cuisine: " + restaurant.Cuisine);

            }
        }


    }
}
