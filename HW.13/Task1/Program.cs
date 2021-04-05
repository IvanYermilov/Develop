using System;
using Newtonsoft;
using Newtonsoft.Json;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Song song = Song.GetSongInstance();
            var songInfo = Song.GetSongData(song);
            Console.WriteLine(JsonConvert.SerializeObject(songInfo, Formatting.Indented));
        }
    }
}
