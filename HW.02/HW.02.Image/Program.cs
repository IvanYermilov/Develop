using System;
using System.IO;

namespace HW._02.Image
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Initialize a new instance of the StreamReader class for the stream, with the specified byte order mark detection option.
            //2. Read all characters from the current position to the end of the stream.
            //3. Release all resources used by the StreamReader object.
            //4. Split a string into substrings based on delimiting character ' '.
            //5. Initialize a new byte array required for storing converted substrings.
            //6. Convert substrings of splitted string to byte and write them to initialized byte array. 
            //7. Create a new file, writes the byte array to the file, and then close the file.
            StreamReader textReader = new StreamReader(@"E:\c#rep\HW.02\HW.02.Image\image.txt", true);
            string textReaderResult = textReader.ReadToEnd();
            textReader.Dispose();
            string[] arrayOfTextResult = textReaderResult.Split(' ');
            byte[] imageBytes = new byte[arrayOfTextResult.Length-1];
            for (int i = 0; i< arrayOfTextResult.Length-1; i++)
            {
                byte binary = Convert.ToByte(arrayOfTextResult[i],2);
                imageBytes[i] = binary;
            }
            File.WriteAllBytes(@"E:\c#rep\HW.02\HW.02.Image\image.png", imageBytes);
        }
    }
}
