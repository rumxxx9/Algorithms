using System;
using static System.Console;

namespace CommunityLibrarySystem
{
    public class MovieCollection
    {
        private int count; //the number of key-and-value pairs currently stored in the hashtable
        private int buckets; //number of buckets
        private Movie[] collection; //a table storing key-and-value pairs
        public int DVDQuantity { get; private set; }

        // constructor
        public MovieCollection(int buckets)
        {
            if (buckets > 0)
                this.buckets = buckets;
            count = 0;
            collection = new Movie[buckets];
            for (int i = 0; i < buckets; i++)
                collection[i] = null;
        }

        public int Count
        {
            get { return count; }
        }

        public int Capacity
        {
            get { return buckets; }
            set { buckets = Capacity; }
        }

        /* pre:  the hashtable is not full
         * post: return the bucket for inserting the title
         */
        private int Find_Insertion_Bucket(string title)
        {
            int bucket = Hashing(title);

            int i = 0;
            int offset = 0;
            while (i < buckets && collection[(bucket + offset) % buckets] != null && collection[(bucket + offset) % buckets].Title != "deleted")
            //++offset; //linear probing
            {
                i++;
                offset++;
            }
            return (offset + bucket) % buckets;
        }

        private int Hashing(string title)
        {
            int intTitle = Math.Abs(title.GetHashCode());
            return intTitle % buckets;
        }

        /* pre:  true
        * post: return the bucket where the title is stored
        *		 if the given title in the hashtable;
        *		 otherwise, return -1.
        */
        public void AddMovie(string title, int dvdquantity, string genre, string classification, string duration)
        {
            if ((Count < collection.Length))
            {
                int bucket = Find_Insertion_Bucket(title);
                collection[bucket] = new Movie(title, dvdquantity, genre, classification, duration, 0); // add
                count++;
            }
            else
                WriteLine("The collection is full");
        }

        /* pre:  nil
         * post: the given title has been removed from the hashtable if the given title is in the hashtable
        */
        public void RemoveMovie(string title)
        {
            int bucket = Find_Insertion_Bucket(title);
            Movie movie = collection[bucket];
            // Movie can been removed by enter it's name or reduce it's DVDQuantity to 0
            if (bucket != 1 || movie.DVDQuantity <= 0)
            {
                collection[bucket] = null;
                count--;
                WriteLine($"The DVD of movie '{title}' has been removed from the collection.");
                }
            else
            {
                WriteLine($"We cannot find the movie '{title}'.");
            }
        }

        /* pre:  nil
         * post: print all the elements in the hashtable
        */
        public void Print()
        {
            bool isEmpty = true;
            var sortedMovies = collection.Where(movie => movie != null && movie.DVDQuantity > 0)
                                                .OrderBy(movie => movie.Title);

            foreach (var movie in sortedMovies)
            {
                WriteLine(movie);
                WriteLine();
                isEmpty = false;
            }

            if (isEmpty)
            {
                WriteLine("--------------------------------------------------------");
                WriteLine("Empty\r\n");
                WriteLine("--------------------------------------------------------");
            }
        }

        //Find Movie By Title
        public Movie FindMovieByTitle(string title)
        {
            int bucket = Hashing(title);
            int i = 0;
            int offset = 0;
            while (i < buckets && collection[(bucket + offset) % buckets] != null)
            {
                Movie movie = collection[(bucket + offset) % buckets];
                //++offset; //linear probing
                if (movie.Title == title && movie.DVDQuantity > 0)
                {
                    return movie;
                }
                i++;
                offset = i * i;
            }
            return null;
        }

        //Display Top 3 Movies borrowed by member method
        public void DisplayTop3Movies()
        {
            WriteLine("Top 3 movies borrowed by you:\r\n");

            Movie[] sortedMovies = collection.Where(movie => movie != null)
                                                 .OrderByDescending(movie => movie.BorrowedTimes)
                                                 .Take(3)
                                                 .ToArray();

            if (sortedMovies.Length > 0)
            {
                for (int i = 0; i < sortedMovies.Length; i++)
                {
                    WriteLine($"{i + 1}. {sortedMovies[i].Title}    Borrowed Times: {sortedMovies[i].BorrowedTimes}\r\n");
                }
            }
            else
            {
                //If this section is empty print empty
                WriteLine("Empty\r\n");
            }
            WriteLine("--------------------------------------------------------");
        }
    }
}
