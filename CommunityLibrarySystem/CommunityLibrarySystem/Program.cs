using System;
using System.Diagnostics.Metrics;
using static System.Console;

namespace CommunityLibrarySystem
{

    class Program
    {
        const int Max = 1000;
        static string loggedInUsername; // Declare a variable to store the logged-in username
        static Member rmember;
        static Member [] members =new Member[Max];
        static MemberCollection mcollection = new MemberCollection();
        static MovieCollection collection = new MovieCollection(Max);

        static void Main()
        {
            RunProgram();
        }

        static void RunProgram()
        {
            //Initialise Movies and Members
            InitialMovies();
            InitialMembers();
            while (true)
            {
                DisplayMainMenu();
                break;
            }
        }
        static void DisplayMainMenu()
        {
            Clear();
            //MainMenu
            WriteLine("========================================================");
            WriteLine("COMMUNITY LIBBRARY MOVIE DVD MANAGEMENT SYSTEM");
            WriteLine("========================================================");
            WriteLine();
            WriteLine("Main Menu");
            WriteLine("--------------------------------------------------------");
            WriteLine("Select from the following: ");
            WriteLine();
            WriteLine("1. Staff Login"); //Done
            WriteLine("2. Member Login"); //Done
            WriteLine("0. End the Program"); //Done
            WriteLine();
            Write("Enter your choice ==>  ");
            var Choice = ReadLine();

            //Exit
            if (Choice == "0")
            {
                Environment.Exit(0);
            }

            //Login & Go to the StaffMenu
            else if (Choice == "1")
            {
                Write("Enter your username ==>  ");
                var username = ReadLine();
                Write("Enter your password ==>  ");
                var password = ReadLine();
                if (username == "staff’" || password == "today123")
                {
                    DisplayStaffMenu();
                }
                else
                {
                    WriteLine();
                    Write("Invalid username/password. Please try again."); //Check if the username/password is correct
                    Main();
                }
            }

            //Go to the MemberMenu
            else if (Choice == "2")
            {
                //Login & Go to the MemberMenu
                Write("Enter your username ==>  ");
                var username = ReadLine();
                loggedInUsername = username; //firstname

                Write("Enter your password ==>  ");
                int password;
                while (!int.TryParse(ReadLine(), out password))
                {
                    WriteLine("Invalid password. Please enter a valid 4-digit number.");//Check if the password is 4 digit number
                    Write("Enter your password ==> ");
                }
                bool memberLogin = false;
                foreach (Member member in mcollection.members) //Check if the username and password is currently existed
                {
                    if (member != null && username == member.FirstName && password == member.Password)
                    {
                        memberLogin = true;
                        break;
                    }
                }
                if (memberLogin) // login
                {
                    DisplayMemberMenu(); //display member menu
                }
                else
                {
                    WriteLine(); // Invalid username/password
                    WriteLine("Invalid username/password. Please try again.");
                    //Enter any key return to Staff Menu
                    Write("Enter any key return to Main Menu ==>  ");
                    var choice1 = ReadLine();
                    DisplayMainMenu();
                }
            }
            else
            {
                Write("Invalid enter. Enter any key return to Main Menu ==>  "); //Return main menu if the choice beside 1 or 2
                var choice1 = ReadLine();
                DisplayMainMenu();
            }
        }


            static void DisplayStaffMenu()
            {
                Clear();
                //StaffMenu
                WriteLine("Staff Menu");
                WriteLine("--------------------------------------------------------");
                WriteLine("1. Add DVDs of a new movie to the system"); //Done
                WriteLine("2. Add new DVDs of an existing movie to the system"); //Done
                WriteLine("3. Remove DVDs of an existing movie from the system"); //Done
                WriteLine("4. Register a new member to the system"); //Done
                WriteLine("5. Remove a registered member from the system"); //Done
                WriteLine("6. Find a member's contact phone number, given the member's name"); //Done
                WriteLine("7. Find members who are currently renting a particular movie"); //Done1/3 & give up (;Д;)
                WriteLine("8. Browse the member collection"); //Done
                WriteLine("9. Browse the movie collection"); //Done
                WriteLine("0. Return to main menu&Logout"); //Done
                WriteLine();

                Write("Enter your choice ==>  ");
                string Choice = ReadLine();

                switch (Choice)
               {
                    //Go back to MainMenu
                    case "0": 
                            DisplayMainMenu();
                            break;

                    //Add DVDs of a new movie to the system
                    case "1":
                        Write("Enter new movie title ==>  ");
                        string movieTitle = ReadLine();

                        //Check if the movie has already in the collection
                        if (collection.FindMovieByTitle(movieTitle) == null)
                        {
                            Write("Enter new Movie DVD quantity ==>  ");
                            int dvdQuantity = Convert.ToInt32(ReadLine());
                            Write("Enter new Movie Genre ==>  ");
                            string genre = ReadLine();
                            Write("Enter new Movie Classification ==>  ");
                            string classification = ReadLine();
                            Write("Enter new Movie Duration ==>  ");
                            string duration = ReadLine();

                            //Add new Movie
                            collection.AddMovie(movieTitle, dvdQuantity, genre, classification, duration);
                            collection.Print();
                        }
                        else
                        {
                            DisplayStaffMenu();
                        }

                        //Enter any key return to Staff Menu
                        Write("Enter any key return to Staff Menu ==>  ");
                        var choice1 = ReadLine();
                        DisplayStaffMenu();
                        break;

                    //Add new DVDs of an existing movie to the system
                    case "2":
                        Write("Enter Movie Title ==> ");
                        string movieTitle2 = ReadLine();
                        Movie movie2 = collection.FindMovieByTitle(movieTitle2);

                        //Find Movie by movie title if movie does exist in hashtable collection
                        if (movie2 != null)
                        {
                            WriteLine($"Found movie: \r\n" + "\r\n" +
                           $"Title: {movie2.Title}, \r\n" +
                           $"DVD Quantity: {movie2.DVDQuantity}, \r\n" +
                           $"Genre: {movie2.Genre}, \r\n" +
                           $"Classification: {movie2.Classification}, \r\n" +
                           $"Duration: {movie2.Duration}, \r\n" +
                           $"Borrowed Times: {movie2.BorrowedTimes}\r\n");

                            //Add DVDs into the existing movies
                            Write("How many DVDs you want to add to this movie ==> ");
                            int dvdQuantity1 = Convert.ToInt32(ReadLine());
                            movie2.DVDQuantity += dvdQuantity1;

                            //Print out Movie information after add dvds
                            if (dvdQuantity1 > 0)
                            {
                                WriteLine($"Found movie: \r\n" + "\r\n" +
                                                $"Title: {movie2.Title} \r\n" +
                                                $"DVD Quantity: {movie2.DVDQuantity} \r\n" +
                                                $"Genre: {movie2.Genre} \r\n" +
                                                $"Classification: {movie2.Classification} \r\n" +
                                                $"Duration: {movie2.Duration} \r\n" +
                                                $"Borrowed Times: {movie2.BorrowedTimes}\r\n");
                            }
                            //If the input is invalid then return to Staff Menu
                            else
                            {
                                DisplayStaffMenu();
                            }
                        }
                        else
                        //Print movie not found if movie title movie title does not exist in hashtable collection
                        {
                            WriteLine($"We cannot find the movie ' {movieTitle2} '.");
                        }

                        //Enter any key return to Staff Menu
                        Write("Enter any key return to Staff Menu ==>  ");
                        string choice2 = ReadLine();
                        DisplayStaffMenu();
                        break;

                    //Remove DVDs of an existing movie from the system
                    case "3":
                        Write("Enter Movie Title ==> ");
                        string movieTitle3 = ReadLine();
                        Movie movie3 = collection.FindMovieByTitle(movieTitle3);

                        //Find Movie by movie title if movie does exist in hashtable collection
                        if (movie3 != null)
                        {
                            WriteLine($"Found movie: \r\n" + "\r\n" +
                           $"Title: {movie3.Title} \r\n" +
                           $"DVD Quantity: {movie3.DVDQuantity} \r\n" +
                           $"Genre: {movie3.Genre} \r\n" +
                           $"Classification: {movie3.Classification} \r\n" +
                           $"Duration: {movie3.Duration} \r\n" +
                           $"Borrowed Times: {movie3.BorrowedTimes}\r\n");

                            //Enter DVDs number to remove DVDs
                            Write("How many DVDs you want to remove from this movie ==> ");
                            int dvdQuantity3 = Convert.ToInt32(ReadLine());
                            movie3.DVDQuantity -= dvdQuantity3;

                            //Remove Movie if DVD quantity <=0
                            collection.RemoveMovie(movieTitle3);

                            //Print out Movie information after remove dvd
                            WriteLine($"Found movie: \r\n" + "\r\n" +
                                            $"Title: {movie3.Title} \r\n" +
                                            $"DVD Quantity: {movie3.DVDQuantity} \r\n" +
                                            $"Genre: {movie3.Genre} \r\n" +
                                            $"Classification: {movie3.Classification} \r\n" +
                                            $"Duration: {movie3.Duration} \r\n" +
                                            $"Borrowed Times: {movie3.BorrowedTimes}\r\n");
                        }
                        else
                        //Print movie not found if movie title movie title does not exist in hashtable collection
                        {
                            WriteLine($"We cannot find the movie ' {movieTitle3} '.");
                        }

                        //Enter any key return to Staff Menu
                        Write("Enter any key return to Staff Menu ==>  ");
                        string choice3 = ReadLine();
                        DisplayStaffMenu();
                        break;

                    //Register a new member to the system
                    case "4":
                        Write("Enter the member's first name==>  ");
                        string firstname4 = ReadLine();
                        Write("Enter the member's last name==>  ");
                        string lastname4 = ReadLine();
                        Write("Enter the member's password(4 digit number) ==>  ");
                        int password4 = Convert.ToInt32(ReadLine());

                    //Check if the password is 4 digit number
                        string passwordString = password4.ToString();
                        int length = passwordString.Length;
                        if (length != 4)
                        {
                            Write("Invalid number, please enter 4 digit number.");
                            Write("Enter any key to return to Staff Menu ==>  ");
                            ReadLine();
                            DisplayStaffMenu();
                            break;
                        }
                        Write("Enter the member's phone number==>  ");
                        int phonenumber4 = Convert.ToInt32(ReadLine());

                    //If the enter is valid then add new member to the member collection
                        mcollection.AddMember(firstname4, lastname4, password4, phonenumber4);
                        Write("Enter any key to return to Staff Menu ==>  ");
                        ReadLine();
                        DisplayStaffMenu();
                        break;

                    //Remove a registered member from the system
                    case "5":
                        Write("Enter the member's first name ==>  ");
                        string firstName = ReadLine();
                        Write("Enter the member's first name ==>  ");
                        string lastName = ReadLine();
                        rmember = mcollection.GetMemberByName(firstName); // Find member by loggedin usename
                        if (firstName != null)
                            {
                            //Check if the staff want to remove this member
                                Write("Do you want to remove this member from member collection(Y/N) ==>  ");
                                var choice5 = ReadLine();
                                if (choice5 == "Y")
                                {
                                    mcollection.RemoveMember(firstName, lastName);
                                    Write("Enter any key to return to Staff Menu ==>  ");
                                    ReadLine();
                                    DisplayStaffMenu();
                                    break;
                                }
                                else
                                {
                                    DisplayStaffMenu(); //Display staff menu
                                    break;
                                }
                            }
                            break;

                    //Find a member's contact phone number, given the member's name
                    case "6":
                        Write("Enter the member's first name ==>  ");
                        string firstName6 = ReadLine();
                        Write("Enter the member's last name ==>  ");
                        string lastName6 = ReadLine();
                        rmember = mcollection.GetMemberByFullName(firstName6, lastName6); // Find member by firstname && lastname

                    //User MemberCollection.GetMemberByFullName to find the member information and display it
                            if (rmember != null)
                           {
                                WriteLine($"Member Found:\r\n" +
                                                $"First Name: {rmember.FirstName}\r\n" +
                                                $"Last Name: {rmember.LastName}\r\n" +
                                                $"Phone Number: {rmember.PhoneNumber}\r\n"); //print member information
                                Write("Enter any key to return to Staff Menu ==>  ");
                                ReadLine();
                                DisplayStaffMenu();
                                break;
                            }
                            else
                            {
                                Write("Enter any key to return to Staff Menu ==>  ");
                                ReadLine();
                                DisplayStaffMenu();
                                break;
                            }
                    break;

                    //Find members who are currently renting a particular movie
                    case "7":
                    rmember = mcollection.GetMemberByName(loggedInUsername); // Find member by loggedin usename
                    Write("Enter Movie Title ==> ");
                    string movieTitle7 = ReadLine();
                    Movie movie7 = collection.FindMovieByTitle(movieTitle7);

                    //Find Movie by movie title if movie does exist in hashtable collection
                    if (movie7 != null)
                    {
                        WriteLine($"Found movie: \r\n" + "\r\n" +
                                       $"Title: {movie7.Title}\r\n" +
                                       $"Borrowed Times: {movie7.BorrowedTimes}\r\n");
                                       rmember.DisplayRentingMembers();
                    }
                    else
                    //Print movie not found if movie title movie title does not exist in hashtable collection
                    {
                        WriteLine($"We cannot find the movie '{movieTitle7}'.");
                    }

                    //Enter any key to return to Staff Menu
                    Write("Enter any key to return to Staff Menu ==>  ");
                    ReadLine();
                    DisplayStaffMenu();
                    break;

                    //Display all the member inforamtion for the staff
                    case "8":
                        WriteLine();
                        mcollection.Print();
                        Write("Enter any key to return to Staff Menu ==>  ");
                        ReadLine();
                        DisplayStaffMenu();
                        break;

                case "9":
                    WriteLine();
                    collection.Print();
                    Write("Enter any key to return to Staff Menu ==>  ");
                    ReadLine();
                    DisplayStaffMenu();
                    break;

                //Return to Staff Menu
                default:
                        DisplayStaffMenu();
                        break;
                }
            }

            static void DisplayMemberMenu()
            {
                Clear();
                //MemberMenu
                WriteLine("Member Menu");
                WriteLine("--------------------------------------------------------");
                WriteLine("1. Browse all the movies"); //Done
                WriteLine("2. Display all the information about a movie, given the title of the movie"); //Done
                WriteLine("3. Borrow a movie DVD"); //Done
                WriteLine("4. Return a movie DVD"); //Done
                WriteLine("5. List current borrowing movies"); //Done
                WriteLine("6. Display the top 3 movies rented by the members"); //Done
                WriteLine("0. Return to main menu & Logout"); //Done
                WriteLine();

                Write("Enter your choice ==> ");
                string choice = ReadLine();

                switch (choice)
                {
                    //Display Main Menu
                    case "0":
                        DisplayMainMenu();
                        break;

                    //Browse all the movies
                    case "1":
                        WriteLine();
                        collection.Print();
                        Write("Enter any key to return to Member Menu ==>  ");
                        ReadLine();
                        DisplayMemberMenu();
                        break;

                    //Display all the information about a movie, given the title of the movie
                    case "2":
                        Write("Enter Movie Title ==> ");
                        string movieTitle = ReadLine();
                        Movie movie = collection.FindMovieByTitle(movieTitle);

                        //Find Movie by movie title if movie does exist in hashtable collection
                        if (movie != null)
                        {
                            WriteLine($"Found movie: \r\n" + "\r\n" +
                           $"Title: {movie.Title}\r\n" +
                           $"DVD Quantity: {movie.DVDQuantity} \r\n" +
                           $"Genre: {movie.Genre} \r\n" +
                           $"Classification: {movie.Classification} \r\n" +
                           $"Duration: {movie.Duration} \r\n" +
                           $"Borrowed Times: {movie.BorrowedTimes}\r\n");
                        }
                        else
                        //Print movie not found if movie title movie title does not exist in hashtable collection
                        {
                            WriteLine($"We cannot find the movie '{movieTitle}'.");
                        }

                        //Enter any key to return to Member Menu
                        Write("Enter any key to return to Member Menu ==>  ");
                        ReadLine();
                        DisplayMemberMenu();
                        break;

                    //Borrow a movie DVD
                    case "3":
                        Write("Enter Movie Title ==> ");
                        string movieTitle3 = ReadLine();
                        Movie movie3 = collection.FindMovieByTitle(movieTitle3);

                        //Find Movie by movie title if movie does exist in hashtable collection
                        if (movie3 != null)
                        {
                            WriteLine($"Found movie: \r\n" + "\r\n" +
                                            $"Title: {movie3.Title}\r\n" +
                                            $"DVD Quantity: {movie3.DVDQuantity} \r\n" +
                                            $"Genre: {movie3.Genre} \r\n" +
                                            $"Classification: {movie3.Classification} \r\n" +
                                            $"Duration: {movie3.Duration} \r\n" +
                                            $"Borrowed Times: {movie3.BorrowedTimes}\r\n");

                            Write($"Do you want to borrow a DVD of '{movieTitle3}'(Y or N) ==> ");
                            var choice3 = ReadLine();
                            if (choice3 == "Y")
                                {
                                        rmember = mcollection.GetMemberByName(loggedInUsername); // Find member by loggedin usename
                                        rmember.BorrowMovie(movie3);
                                        //Enter any key to return to Member Menu
                                        Write("Enter any key to return to Member Menu ==>  ");
                                        ReadLine();
                                        DisplayMemberMenu();
                                        break;
                                }
                            else
                                {
                                    DisplayMemberMenu();
                                    break;
                                }
                        }
                        else
                        //Print movie not found if movie title movie title does not exist in hashtable collection
                        {
                            WriteLine($"We cannot find the movie '{movieTitle3}'.");
                            //Enter any key to return to Member Menu
                            Write("Enter any key to return to Member Menu ==>  ");
                            ReadLine();
                            DisplayMemberMenu();
                            break;
                        }

                    //Return a movie DVD
                    case "4":
                        Write("Enter Movie Title ==> ");
                        string movieTitle4 = ReadLine();
                        Movie movie4 = collection.FindMovieByTitle(movieTitle4);

                        //Find Movie by movie title if movie does exist in hashtable collection
                        if (movie4 != null)
                        {
                            WriteLine($"Found movie: \r\n" + "\r\n" +
                                            $"Title: {movie4.Title}\r\n" +
                                            $"DVD Quantity: {movie4.DVDQuantity} \r\n" +
                                            $"Genre: {movie4.Genre} \r\n" +
                                            $"Classification: {movie4.Classification} \r\n" +
                                            $"Duration: {movie4.Duration} \r\n" +
                                            $"Borrowed Times: {movie4.BorrowedTimes}\r\n");

                            Write($"Do you want to return the DVD of '{movieTitle4}'(Y or N) ==> ");
                            var choice4 = ReadLine();
                            if (choice4 == "Y")
                            {
                                rmember = mcollection.GetMemberByName(loggedInUsername); // Find member by loggedin usename
                                rmember.ReturnMovie(movie4);
                                //Enter any key to return to Member Menu
                                Write("Enter any key to return to Member Menu ==>  ");
                                ReadLine();
                                DisplayMemberMenu();
                                break;
                            }
                            else
                            {
                                DisplayMemberMenu();
                                break;
                            }
                        }
                        else
                        //Print movie not found if movie title movie title does not exist in hashtable collection
                        {
                            WriteLine($"We cannot find the movie '{movieTitle4}'.");
                            //Enter any key to return to Member Menu
                            Write("Enter any key to return to Member Menu ==>  ");
                            ReadLine();
                            DisplayMemberMenu();
                            break;
                        }

                    //List current borrowing movies
                    case "5":
                        //Display current borrowing movies
                        rmember = mcollection.GetMemberByName(loggedInUsername); // Find member by username
                        rmember.CurrentBorrowedMovies();
                        Write("Enter any key to return to Member Menu ==>  ");
                        ReadLine();
                        DisplayMemberMenu();
                        break;

                    //Display the top 3 movies rented by the members
                    case "6":
                    rmember = mcollection.GetMemberByName(loggedInUsername); // Find member by username
                    collection.DisplayTop3Movies();
                    Write("Enter any key to return to Member Menu ==>  ");
                    ReadLine();
                    DisplayMemberMenu();
                    break;

                    //Return to Member Menu
                    default:
                        DisplayMemberMenu();
                        break;
                }
            }

        //Initialise movie set
        static void InitialMovies()
            {                                    
                //Add Initialise Movies
                collection.AddMovie("Dune", 5, "Action, Adventure, Drama", "PG-13", "2h 35min");
                collection.AddMovie("No Time to Die", 5, "Action, Adventure, Thriller", "PG-13", "2h 43min");
                collection.AddMovie("Eternals", 5, "Action, Adventure, Drama", "PG-13", "2h 37min");
                collection.AddMovie("The Matrix Resurrections", 5, "Action, Sci-Fi", "R", "2h 28min");
                collection.AddMovie("The Matrix", 5, "Action, Sci-Fi", "R", "2h 16min");
                collection.AddMovie("Forrest Gump", 5, "Drama, Romance", "PG-13", "2h 22min");
                collection.AddMovie("The Silence of the Lambs", 5, "Crime, Drama, Thriller", "R", "1h 58min");
            }

        //Initialise member set
        static void InitialMembers()
            {
                //Add Initialise members
                mcollection.AddMember("John", "Doe", 1234, 987654321);
                mcollection.AddMember("Jane", "Smith", 5678, 123456789);
                mcollection.AddMember("Emily", "Brown", 8765, 123459876);
        }
        }
    }
