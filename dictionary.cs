using System;
using System.Collections.Generic;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {   // Declare a dictionary.
            var months = new Dictionary<int, string> 
            // Add items Inline
            {
                {1,"Jan"},
                {2,"Feb"},
                {3,"Mar"},
                {4,"Apr"},
            };

            // Add items with Index notation
            months[5] = "May";
            months[6] = "Jun";

            // Add items with Add() method
            months.Add(7, "Jul");
            months.Add(8, "Aug");
            months.Add(9, "Sep");
            months.Add(10, "Oct");
            months.Add(11, "Nov");
            months.Add(12, "Dec");

            // And what if we try adding the different value with the same key?

            // Task 1: TRY to add Your name as the 5th month of the year. And share your findings with the rest of the class.

            // retrieve an individual item.
            string birth = months[8];
            Console.WriteLine("My birthday is in {0}", birth);

            // Enumarate (print) all items.
            foreach (var kvp in months)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }

            // What if the key we're looking for does not exist?
            // Well, in this case we're going to use TryGetValue() method

            // Let's first delete December in line 29

            var dec = months.TryGetValue(12, out string value); // the first parameter is the key and second is the value
            Console.WriteLine(dec);

            //let's look for the key that exists. I'm going to remove comment in line 29 and run the code again.

            // let's make this meaningful by adding a feature to our program that checks
            // if the item exists and prompts user that if it isn't.

            if (months.TryGetValue(13, out value))
            {
                Console.WriteLine("The month you're looking for is {0}", 13);
            }
            else
            {
                Console.WriteLine("The month you're looking for does not exist!!!");
            }

            //There's an easier way to do this. It's called ContainsKey() or ContainsValue() method.
            if (months.ContainsKey(3))
            {
                Console.WriteLine("This key exists.");
            }
            // Similarly you can do this for value.

            // Now lets try and remove an item from our dictionary using Remove() method. 

            //months.Remove(10);

            // But it's important to check if this key exists before we try to remove it.

            if (months.ContainsKey(10))
            {
                months.Remove(10);
            }

            // Before we run the code let's move our if code block to the line before the enumaration, so we see the effect.

            // If we want to delete all the items in our dictionary we will use Clear() method.
        }
    }
}