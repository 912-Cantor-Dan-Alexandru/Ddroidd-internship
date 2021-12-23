using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SantaClauseConsoleApp
{
    public class SantaClaus
    {
        private List<Child> childrenList; 
        private static SantaClaus instanceOfSanta; // static instance of the singleton class
        private SantaClaus()
        {
            Name = "Santa Claus";
            childrenList = new List<Child>();
        }

        // Function that gets called(instead of constructor) when we need a SantaClaus object
        public static SantaClaus getInstance() 
        {
            if (instanceOfSanta == null)
                instanceOfSanta = new SantaClaus();
            return instanceOfSanta;
        }

        public string Name { get; set; }
        // GenerateLetters(string) -> is used for Question 3 and it creates a letter string that replaces the mock data with actual details of child and letter
        public void GenerateLetters(string filename) 
        {
            StringBuilder letterText = new StringBuilder();
            for (int i = 0; i < childrenList.Count; ++i)
            {
                letterText.Clear();
                letterText.Append("Dear Santa,\n");
                letterText.Append($"I am {childrenList[i].Name}\n");
                letterText.Append($"I am {DateTime.Now.Year - childrenList[i].DateOfBirth.Year} years old.");
                letterText.Append($" I live at {childrenList[i].Address}. ");
                letterText.Append($"I have been a very {(childrenList[i].Behavior == BehaviorEnum.Bad ? "bad" : "good")} child this year\n");
                letterText.Append("What I would like the most this Christmas is:\n");
                foreach (Item item in childrenList[i].Letter.ItemsList)
                {
                    letterText.Append($"{item.ItemName}, ");
                }
                letterText.Remove(letterText.Length - 2, 2); // remove the ", " from the last item
                if (filename == "")     // if an empty string was given as filename, generate a file with the name correspondin to current time
                    File.WriteAllText(string.Join(@"\", System.AppContext.BaseDirectory.Split(@"\")[0..^4]) + @"\" + $"letter_from_{DateTime.Now.ToString("MM/dd/yyyy_HH:ss")}.txt", letterText.ToString());
                else
                    File.WriteAllText(string.Join(@"\", System.AppContext.BaseDirectory.Split(@"\")[0..^4]) + $@"\{filename}{i+1}.txt", letterText.ToString());

            }
        }

        public void ReadLetter(string filename, out Child child, out Letter letter)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            letter = new Letter(System.DateTime.Now, GetWishlist(lines[4]));
            child = new Child(GetName(lines[1]), GetBirthDate(lines[2]), GetAddress(lines[2]),
                            GetBehavior(lines[2]), letter);
            childrenList.Add(child);
        }

        private static List<Item> GetWishlist(string line)
        {
            string[] itemsString = line.Split(",");
            Item item;
            List<Item> itemList = new List<Item>();
            foreach (string name in itemsString)
            {
                if (name[0] == ' ')
                {
                    item = new Item(name[1..^0]);
                    itemList.Add(item);
                }
                else
                {
                    item = new Item(name);
                    itemList.Add(item);
                }
            }
            return itemList;

        }

        private static BehaviorEnum GetBehavior(string line)
        {
            string[] sentences = line.Split(".");
            string[] words = sentences[2].Split(" ");
            string behavior = words[5];
            return (behavior == "good" ? BehaviorEnum.Good : BehaviorEnum.Bad);
        }

        private static string GetAddress(string line)
        {
            string[] sentences = line.Split(".");
            string[] words = sentences[1].Split(" ");
            StringBuilder address = new StringBuilder();
            for (int i = 4; i < words.Length - 1; ++i)
            {
                address.Append(words[i] + " ");
            }
            address.Append(words[words.Length - 1]);
            return address.ToString();
        }

        private static DateTime GetBirthDate(string line)
        {
            string[] words = line.Split(" ");
            int age = Int32.Parse(words[2]);
            DateTime dateNow = DateTime.Now;
            DateTime dateFinal = new DateTime(dateNow.Year - age, dateNow.Month, dateNow.Day);
            return dateFinal;
        }

        private static string GetName(string line)
        {
            string[] words = line.Split(" ");
            StringBuilder name = new StringBuilder();
            for (int i = 2; i < words.Length - 1; ++i)
            {
                name.Append(words[i] + " ");
            }
            name.Append(words[words.Length - 1]);
            return name.ToString();
        }

        public void addChild(Child child)
        {
            childrenList.Add(child);
        }

        // createReport() : string -> Used for Question 4, it builds a string corresponding to the required report of items
        public string createReport()
        {
            Dictionary<string, int> itemsDict = new Dictionary<string, int>();  // itemsDict -> a frequency dictionary
            foreach (Child child in childrenList)
            {
                foreach (Item item in child.Letter.ItemsList)
                {
                    if (itemsDict.ContainsKey(item.ItemName))
                        itemsDict[item.ItemName]++;
                    else
                        itemsDict.Add(item.ItemName, 1);
                }
            }
            Dictionary<string, int> sortedDict = (from entry in itemsDict
                                                 orderby entry.Value descending
                                                 select entry).ToDictionary(x => x.Key, x => x.Value);  // used linq to sort descending by the frequency
            StringBuilder reportString = new StringBuilder();
            foreach (KeyValuePair<string, int> entry in sortedDict)
            {
                reportString.Append($"{entry.Key} - {entry.Value}\n");
            }
            // I wrote the report in a file named report.txt and also printed it on the console 
            File.WriteAllText(string.Join(@"\", System.AppContext.BaseDirectory.Split(@"\")[0..^4]) + @"\report.txt", reportString.ToString());
            return reportString.ToString();
        }

        public void clear()
        {
            childrenList.Clear();
        }

        // createTravelItinerary() : Dictionary<string, List<string>> -> Creates a Multiple Value Dict that groups each address(the values) by its city(the key)
        public Dictionary<string, List<string>> createTravelItinerary()
        {
            Dictionary<string, List<string>> itinerary = new Dictionary<string, List<string>>();
            foreach(Child child in childrenList)
            {
                if (itinerary.ContainsKey(child.getCity()))
                    itinerary[child.getCity()].Add(child.Address);
                else
                {
                    itinerary.Add(child.getCity(), new List<string>());
                    itinerary[child.getCity()].Add(child.Address);
                }
            }
            return itinerary;
            
        }
    }
}