using System;

namespace CommunityLibrarySystem
{
    public class Movie
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Classification { get; set; }
        public string Duration { get; set; }
        public int DVDQuantity { get; set; }
        public int BorrowedTimes { get; set; }

        public Movie(string title, int dvdquantity, string genre, string classification, string duration, int borrowedtimes)
        {
            Title = title;
            DVDQuantity = dvdquantity;
            Genre = genre;
            Classification = classification;
            Duration = duration;
            BorrowedTimes = borrowedtimes;

        }
        public override string ToString()
        {
            return $"Title: {Title} \r\n" +
                       $"DVD Quantity: {DVDQuantity} \r\n" +
                       $"Genre: {Genre} \r\n" +
                       $"Classification: {Classification} \r\n" +
                       $"Duration: {Duration} \r\n" +
                       $"Borrowed Times: {BorrowedTimes}";
        }
    }
}
