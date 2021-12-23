using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SantaClauseConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Question1();
            Question2();
            Question3();
            Question4();
            Question5();
            Question6();
        }

        static void Question1()
        {
            System.Console.WriteLine("~~~~ Question 1 ~~~~\n");
            // Initialise the Letter objects
            Letter letter1 = new Letter(new System.DateTime(2021, 12, 15), new List<Item>());
            Letter letter2 = new Letter(new System.DateTime(2021, 12, 13), new List<Item>());
            Letter letter3 = new Letter(new System.DateTime(2021, 12, 11), new List<Item>());

            // Initialise the Child objects 
            Child child1 = new Child("Peter Parker", new System.DateTime(2008, 6, 21), 
                "79 Hoke Smith Dr, Claxton, Georgia(GA), 30417", BehaviorEnum.Good, letter1);
            Child child2 = new Child("Corey Taylor", new System.DateTime(2012, 8, 17),
                "56 A Paine Ave #5, Irvington, New Jersey(NJ), 07111", BehaviorEnum.Bad, letter2);
            Child child3 = new Child("Michael Myers", new System.DateTime(2010, 10, 31),
                "14 Sinsinawa Ave, East Dubuque, Illinois(IL), 61025", BehaviorEnum.Good, letter3);

            // Initialise the Item objects 
            Item item1 = new Item("Sweets");
            Item item2 = new Item("Legos");
            Item item3 = new Item("Computer games");
            Item item4 = new Item("Toys");
            Item item5 = new Item("Teddy bear");

            // Adding items to the Letter objects
            letter1.addItem(item1);
            letter1.addItem(item2);
            letter2.addItem(item1);
            letter2.addItem(item3);
            letter3.addItem(item4);
            letter3.addItem(item5);

            System.Console.WriteLine(child1);
            System.Console.WriteLine(child2);
            System.Console.WriteLine(child3);

            System.Console.WriteLine(letter1);
            System.Console.WriteLine(letter2);
            System.Console.WriteLine(letter3);

            System.Console.WriteLine(item1);
            System.Console.WriteLine(item2);
            System.Console.WriteLine(item3);
            System.Console.WriteLine(item4);
            System.Console.WriteLine(item5 + "\n");
        }

        static void Question2()
        {
            System.Console.WriteLine("~~~~ Question 2 ~~~~\n");
            SantaClaus sc = SantaClaus.getInstance();
            sc.ReadLetter(string.Join(@"\", System.AppContext.BaseDirectory.Split(@"\")[0..^4]) + @"\letter1.txt", out Child child1, out Letter letter1);
            sc.ReadLetter(string.Join(@"\", System.AppContext.BaseDirectory.Split(@"\")[0..^4]) + @"\letter2.txt", out Child child2, out Letter letter2);
            sc.ReadLetter(string.Join(@"\", System.AppContext.BaseDirectory.Split(@"\")[0..^4]) + @"\letter3.txt", out Child child3, out Letter letter3);
            System.Console.WriteLine("Child no 1 name: " + child1.Name + '\n');
            System.Console.WriteLine("Child no 2 name: " + child2.Name + '\n');
            System.Console.WriteLine("Child no 3 name: " + child3.Name + "\n\n");
        }

        

        static void Question3()
        {
            System.Console.WriteLine("~~~~ Question 3 ~~~~\n");
            SantaClaus sc = SantaClaus.getInstance();
            sc.clear();
            // Question 1 sample data
            Letter letter1 = new Letter(new System.DateTime(2021, 12, 15), new List<Item>());
            Letter letter2 = new Letter(new System.DateTime(2021, 12, 13), new List<Item>());
            Letter letter3 = new Letter(new System.DateTime(2021, 12, 11), new List<Item>());

            Child child1 = new Child("Peter Parker", new System.DateTime(2008, 6, 21),
                "79 Hoke Smith Dr, Claxton, Georgia(GA), 30417", BehaviorEnum.Good, letter1);
            Child child2 = new Child("Corey Taylor", new System.DateTime(2012, 8, 17),
                "56 A Paine Ave #5, Irvington, New Jersey(NJ), 07111", BehaviorEnum.Bad, letter2);
            Child child3 = new Child("Michael Myers", new System.DateTime(2010, 10, 31),
                "14 Sinsinawa Ave, Claxton, Illinois(IL), 61025", BehaviorEnum.Good, letter3);

            Item item1 = new Item("Sweets");
            Item item2 = new Item("Legos");
            Item item3 = new Item("Computer games");
            Item item4 = new Item("Toys");
            Item item5 = new Item("Teddy bear");

            letter1.addItem(item1);
            letter1.addItem(item2);
            letter2.addItem(item1);
            letter2.addItem(item3);
            letter3.addItem(item4);
            letter3.addItem(item5);

            sc.addChild(child1);
            sc.addChild(child2);
            sc.addChild(child3);
            sc.GenerateLetters("generated_letter");
            System.Console.WriteLine("Project's folder now contains(you can see the generated letters there):");
            foreach (string file in Directory.GetFiles(string.Join(@"\", System.AppContext.BaseDirectory.Split(@"\")[0..^4]), "*.*"))
            {
                System.Console.WriteLine(file);
            }
        }

        static void Question4()
        {
            System.Console.WriteLine("~~~~ Question 4 ~~~~\n");
            SantaClaus sc = SantaClaus.getInstance();
            /// no need for this read anymore because we used singleton pattern
            //foreach (string file in Directory.GetFiles(string.Join(@"\", System.AppContext.BaseDirectory.Split(@"\")[0..^4]), "*letter*"))
            //{
            //    if (!file.Contains("template"))
            //        sc.ReadLetter(file, out Child child, out Letter letter);
            //}
            System.Console.WriteLine("Generated report:");
            System.Console.WriteLine(sc.createReport());
        }

        static void Question5()
        {
            System.Console.WriteLine("~~~~ Question 5 ~~~~\n");
            System.Console.WriteLine("Find the explanation commented in method Question5()\n");

            /*
             - Can you apply Singleton Pattern in the current implementation? Please insert a comment explaining your choice

             *  Considering that Singleton Pattern implies that a class has only one instance, while providing a global
             access point to that instance, we could make use of that with SantaClaus class.
                I have instantiated multiple times Santa Claus objects, even if it would be better to have a common instance
             for all the questions. By doing that, I wouldn't have to read each time the objects from file and also I would
             have a stricter control over the object than in the case of a global variable or even a field in Program class.
                So the changes i should make would be to make the constructor of SantaClaus private and add a SantaClaus field
             that holds the "global" instance of the class. Also, I would have to create a public function getInstance() 
             which would check if the SantaClaus instance is already created. If it is so, then just return the already existing
             instance and if not, call the private constructor and create that instance.
             */
        }

        static void Question6()
        {
            System.Console.WriteLine("~~~~ Question 6 ~~~~");
            SantaClaus sc = SantaClaus.getInstance();
            Dictionary<string, List<string>> itinerary = sc.createTravelItinerary();

            StringBuilder itineraryString = new StringBuilder();
            // iterate through the dicitonary first by city, and after that by address
            foreach (KeyValuePair<string, List<string>> pair in itinerary)
            {
                itineraryString.Append($"\n{pair.Key} city:\n");
                foreach (string address in pair.Value)
                {
                    itineraryString.Append(address + "->\n");
                }
            }
            itineraryString.Remove(itineraryString.Length - 3, 3);
            File.WriteAllText(string.Join(@"\", System.AppContext.BaseDirectory.Split(@"\")[0..^4]) + @"\itinerary.txt", itineraryString.ToString());
            System.Console.WriteLine(itineraryString.ToString());
        }
    }
}
