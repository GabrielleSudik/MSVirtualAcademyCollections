using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSVirtualAcademyCollections

    //Collections and intro to LINQ

{
    class Program
    {
        static void Main(string[] args)
        {
            //lists and dictionaries
            //there are other collections for specific uses
            //L&Ds cover most things

            //let's start with creating some instances of some classes

            Car car1 = new Car();
            car1.Make = "Oldsmobile";
            car1.Model = "Cutlas Supreme";
            car1.VIN = "A1";

            Car car2 = new Car();
            car2.Make = "Geo";
            car2.Model = "Prism";
            car2.VIN = "C3";

            Book b1 = new Book();
            b1.Title = "Microsoft .NET XML";
            b1.Author = "Robert Tabor";
            b1.ISBN = "0-000-00000-0";

            //now let's do an arrayList
            //they sort, remove, etc

            ArrayList myArrayList = new ArrayList();
            myArrayList.Add(car1);
            myArrayList.Add(car2);
            //the .Add method is how you can put objects into the array

            //BUT there is a flaw...
            //what if you accidentally did:
            myArrayList.Add(b1);

            //oops you added a book!

            myArrayList.Remove(b1);

            foreach (Car car in myArrayList)
            {
                Console.WriteLine(car.Make);
                //if you left the book in the array,
                //you get an exception because the book doesn't have a Make!
            }

            Console.ReadLine();

            //so how do we make a list/collection that can only add specific items?

            List<Car> myCarList = new List<Car>();
            myCarList.Add(car1);
            myCarList.Add(car2);
            //myCarList.Add(b1); //oops! it won't let us! (that's what we want)

            foreach (Car car in myCarList)
            {
                Console.WriteLine(car.Model);
            }

            Console.ReadLine();

            //and now we'll learn Dictionaries.
            //they are lists of key and value pairs.
            //Dictionary <TKey, TValue>
            //key is unique; value doesn't have to be

            Dictionary<string, Car> myCarDictionary = new Dictionary<string, Car>();
            myCarDictionary.Add(car1.VIN, car1);
            myCarDictionary.Add(car2.VIN, car2);

            //that set the VINs as keys (unique) and the make/model as value (not unique)

            Console.WriteLine(myCarDictionary["C3"].Make);
            //that will print the Make of whatever car has C3 as its key

            Console.ReadLine();

            //remember how to initialize arrays? :
            string[] names = { "Bob", "Steve", "John", "Mike" };

            //it's similar for new instances of a class:

            Car car3 = new Car() { Make = "BMW", Model = "750li", VIN = "E5" };
            Car car4 = new Car() { Make = "Chevy", Model = "Chevette", VIN = "G7" };

            //and here's how to do it with collections:
            //we'll do all steps together, but you could do it step by step

            List<Car> myCars = new List<Car>()
            {
                new Car{Make = "Porshe", Model = "911", VIN = "XY", Year = 1995},
                new Car{Make = "Nissan", Model = "Quest", VIN = "YZ", Year = 2002},
                new Car{Make = "Ford", Model = "Edsel", VIN = "LOL", Year = 1999},
                new Car{Make = "Honda", Model = "Civic", VIN = "HC", Year = 2010},
                new Car{Make = "Nissan", Model = "S", VIN = "TS", Year = 2017}
            };

            //moving on to LINQ!
            //there's a lot of overlapping text here
            //basically, Bob is showing how the same instructions can be written
            //using either a query and method
            //or just a method
            

            //LINQ query
            
            var nissans = from car in myCars
                          where car.Make == "Nissan"
            select car;

            var orderedCars = from car in myCars
                              orderby car.Year descending
                              select car;
            

            //LINQ methods

            //the p => p. stuff is a lambda method

            var nissans2 = myCars.Where(p => p.Make == "Nissan");


            foreach (var car in nissans)
            {
                Console.WriteLine($"{car.Model} and {car.VIN}.");
            }

            Console.ReadLine();

            foreach (var car in nissans2)
            {
                Console.WriteLine($"{car.Model} and {car.Year}.");
            }

            Console.ReadLine();

            foreach (var car in orderedCars)
            {
                Console.WriteLine($"{car.Model} and {car.Year}.");
            }

            Console.ReadLine();

            var orderedCars2 = myCars.OrderByDescending(p => p.Year);

            foreach (var car in orderedCars2)
            {
                Console.WriteLine($"{car.Make}, {car.Model} and {car.Year}.");
            }

            Console.ReadLine();

            var firstNissan = myCars.First(p => p.Make == "Nissan");

            Console.WriteLine($"First Nissan in list is {firstNissan.Model}.");

            Console.ReadLine();

            myCars.ForEach(p => Console.WriteLine(p.VIN + " " + p.Year));
            //see how tighter that is than "foreach" loop

            myCars.ForEach(p => Console.WriteLine(   p.Year += 5));
            //you can do stuff, like add 5 years, etc...

            Console.ReadLine();

            //learning more about "var":

            Console.WriteLine(myCars.GetType());

            var orderedCars3 = myCars.OrderByDescending(p => p.Year);
            Console.WriteLine(orderedCars3.GetType());

            var nissans3 = myCars.Where(p => p.Make == "Nissan");
            Console.WriteLine(nissans3.GetType());

            //Bob's point is, var is useful when your data type is complicated
            //those three examples were all things modified by methods
            //ie, not simple strings or ints, etc.

            //Bob seems to prefer using LINQ methods to queries
            //in part because methods can do queries and more
            //but more efficiently than using both together

            Console.ReadLine();
        }
    }

    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string VIN { get; set; }
        public int Year { get; set; }
        public double StickerPrice { get; set; }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
    }
}
