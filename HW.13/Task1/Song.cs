using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.WebSockets;
using System.Text;

namespace Task1
{
    class Song
    {
        private string _title;
        private uint _duration;
        private string _author;
        private uint _yearMade;
        private MusicGenres _genre;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public uint Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public uint YearMade
        {
            get { return _yearMade; }
            set { _yearMade = value; }
        }

        public MusicGenres Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }

        public Song(string title, uint duration, string author, uint yearMade, MusicGenres genre)
        {
            Title = title;
            Duration = duration;
            Author = author;
            YearMade = yearMade;
            Genre = genre;
        }

        public static Song GetSongInstance()
        {
            Console.Write("Input song's title: ");
            string title = Console.ReadLine();
            Console.Write("Input song's duration: ");
            uint duration = GetUintValue();
            Console.Write("Input song's author: ");
            string author = Console.ReadLine();
            Console.Write("Input song's Year Made: ");
            uint yearMade = GetUintValue();
            Console.Write("Input song's Genre: ");
            string inputtedGenre;
            inputtedGenre = Console.ReadLine();
            if (!(Enum.TryParse(inputtedGenre, true, out MusicGenres genre) && Enum.IsDefined(typeof(MusicGenres), genre))) genre = MusicGenres.None;
            return new Song(title, duration, author, yearMade, genre);
        }

        public static uint GetUintValue()
        {
            for (; ; )
            {
                string inputtedUintValue = Console.ReadLine();
                if (uint.TryParse(inputtedUintValue, out uint UintValue)) return UintValue;
                Console.WriteLine("Programm cannot parse inputted data. Try again: ");
            }
        }

        public static dynamic GetSongData(Song song)
        {
            string songGenre = song.Genre.ToString();
            return new {song.Title, song.Duration, song.Author, song.YearMade, songGenre};
        }
    }
}
