using System;
using static System.Console;

namespace CommunityLibrarySystem
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Password { get; set; }
        public int PhoneNumber { get; set; }
        public Movie[] BorrowedMovies { get; set; }
        public Member[] BorrowedMembers { get; set; }

        int count;

        public Member(string firstName, string lastName, int password, int phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            PhoneNumber = phoneNumber;

            //New array
            BorrowedMovies = new Movie[5];
            BorrowedMembers = new Member[1000];
            count = 0;
        }

        public override string ToString()
        {
            return $"FirstName: {FirstName} \r\n" +
                       $"LastName: {LastName} \r\n" +
                       $"Password: {Password} \r\n" +
                       $"PhoneNumber: {PhoneNumber}";
        }

        //Borrow Movie method
        public void BorrowMovie(Movie originalMovie)
        {
            // Check if the member has already borrowed the movie
            foreach (Movie movie in BorrowedMovies)
            {
                if (movie != null && movie.Title == originalMovie.Title)
                {
                    WriteLine("You have already borrowed this movie and have not yet returned it.");
                    return;
                }
            }

            // Add movie into BorrowedMovies
            for (int i = 0; i < BorrowedMovies.Length; i++)
            {
                if (BorrowedMovies[i] == null)
                {
                    //Create movie information copy and add it in the borrowedmovie[]
                    Movie movie = new Movie(originalMovie.Title, originalMovie.DVDQuantity, originalMovie.Genre, originalMovie.Classification, originalMovie.Duration, originalMovie.BorrowedTimes);
                    BorrowedMovies[i] = movie;
                    movie.BorrowedTimes++;
                    originalMovie.DVDQuantity--;
                    originalMovie.BorrowedTimes++;
                    WriteLine("Movie DVD borrowed successfully.");

                    // Add member information into BorrowedMembers
                    int borrowedMembersCount = BorrowedMembers.Count(member => member != null);
                    Member[] newBorrowedMembers = new Member[borrowedMembersCount + 1];

                    for (int j = 0; j < borrowedMembersCount; j++)
                    {
                        newBorrowedMembers[j] = BorrowedMembers[j];
                    }

                    newBorrowedMembers[borrowedMembersCount] = this;
                    BorrowedMembers = newBorrowedMembers;

                    return;
                }
            }
            WriteLine("You cannot borrow more movies because you have already borrowed 5 movies. Please return some before you borrow another one.");
        }


        //DisplayRentingMembers method
        public void DisplayRentingMembers()
        {
            //Display members information under borrowedmovie
            WriteLine($"Members currently renting the movie:\r\n");
            foreach (Member member in BorrowedMembers)
            {
                if (member != null)
                {
                    WriteLine($"- {member.FirstName}  {member.LastName}    Phone: {member.PhoneNumber}\r\n");
                }
            }
        }

        //Return Movie method
        public void ReturnMovie(Movie originalMovie)
        {
            bool foundMovie = false;
            for (int i = 0; i < BorrowedMovies.Length; i++)
            {
                //return movie
                Movie movie = BorrowedMovies[i];
                if (movie != null && movie.Title == originalMovie.Title)
                {
                    originalMovie.DVDQuantity++; 
                    BorrowedMovies[i] = null;
                    WriteLine($"Movie '{originalMovie.Title}' has been returned.");
                    foundMovie = true;
                    break;
                }
            }

            //Check if the movie title is valid
            if (!foundMovie)
            {
                WriteLine($"Movie '{originalMovie.Title}' not found in your current borrowed movies.");
            }
        }

        //CurrentBorrowedMovies method
        public void CurrentBorrowedMovies()
        {
            WriteLine("Current Borrowed Movies:\r\n");
            //Check if the currentborrowedmovies is empty
            bool isEmpty = true;

            //Get and print the currentborrowed movie from the borrowedmovie[]
            foreach (Movie movie in BorrowedMovies)
            {
                if (movie != null)
                {
                    WriteLine($"Title: {movie.Title} \r\n" +
                                   $"Genre: {movie.Genre} \r\n" +
                                   $"Classification: {movie.Classification} \r\n" +
                                   $"Duration: {movie.Duration} \r\n" +
                                   $"Borrowed Times: {movie.BorrowedTimes}");
                    WriteLine("--------------------------------------------------------");
                    isEmpty = false;
                }
            }
            if (isEmpty) //if it is empty print empty
            {
                WriteLine("Empty\r\n");
                WriteLine("--------------------------------------------------------");
            }
        }
    }
}
  
