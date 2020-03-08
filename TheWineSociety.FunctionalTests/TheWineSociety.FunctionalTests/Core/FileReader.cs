using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWineSociety.FunctionalTests.Core
{
    public class FileReader
    {




        public FileReader()
        {

        }
        public string getCurrentTestResult()
        {
            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return Environment.CurrentDirectory = Directory.GetDirectories("../../Resources")[2];

        }
        public string getCurrentDriverPath()
        {
            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            return Environment.CurrentDirectory = Directory.GetDirectories("../../Resources")[0];

        }
        public string readFile(string env)
        {
            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            Environment.CurrentDirectory = Directory.GetDirectories("../../Resources")[1];

            string path = Environment.CurrentDirectory + "\\" + env + "_ENV.properties";
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                string createText = "Hello and Welcome" + Environment.NewLine;
                File.WriteAllText(path, createText);
            }
            return path;



        }
        public string readCSVFile(string env)
        {
            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            Environment.CurrentDirectory = Directory.GetDirectories("../../Resources")[1];

            string path = Environment.CurrentDirectory + "\\" + env;
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                string createText = "Hello and Welcome" + Environment.NewLine;
                File.WriteAllText(path, createText);
            }
            return path;



        }


        public void witeToFile(string env, string value)
        {
            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            Environment.CurrentDirectory = Directory.GetDirectories("../../Resources")[1];

            string path = Environment.CurrentDirectory + "\\" + env + "_ENV.properties";

            File.WriteAllText(path, value.ToString());


        }
        public void witeToCSVFile(string filename, int value)
        {
            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            Environment.CurrentDirectory = Directory.GetDirectories("../../Resources")[1];

            string path = Environment.CurrentDirectory + "\\" + filename;
            List<string> list = new List<string>(File.ReadAllLines(path));
            list.RemoveAt(value);

            File.WriteAllLines(path, list.ToArray());


        }


    }
}
