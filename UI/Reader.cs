using System;
using System.IO;

namespace UI
{
    public static class Reader
    {
        public static string Read(string filePath)
        {
            try
            {
                using (var sr = new StreamReader(filePath))
                {
                    string data="";
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        data += line;
                        data += "\n";
                    }

                    return data;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return null;
        }
    }
}