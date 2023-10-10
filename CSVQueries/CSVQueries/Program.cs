//Comma Separated Values (CSV) Demo
//1, Eda, Yavuz,542-251-7764

// First let's do a little reading about the library we're about to use: https://joshclose.github.io/CsvHelper/getting-started/


using CsvHelper; // to be able to use this library, "dotnet add package CsvHelper" command

using System.Globalization;
using System.Formats.Asn1;

// Declare paths for the input and output file
string inputFile = "C:\\Users\\e.yavuz\\source\\repos\\CSVHandle\\CSVHandle\\people-1000.csv";
string outputFile = "C:\\Users\\e.yavuz\\source\\repos\\CSVHandle\\CSVHandle\\filtered-people.csv";

// Declare a list using the PersonModel class
List<PersonModel> outputRecords = new List<PersonModel>();

// Declare Stream reader objects
// There are two different ways of defining a StreamReader object.

using var reader = new StreamReader(inputFile); // "using" is saying when you get to the end of the current context, close this object correctly.


// Declare csvreader object with the directory and cultureinfo parameters.
using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

/* C# CultureInfo
CultureInfo provides information about a specific culture.
The information includes the names for the culture, the writing system,
the calendar used, the sort order of strings,
and formatting for dates and numbers. Read more at this link:
https://zetcode.com/csharp/cultureinfo/

InvariantCulture is associated with English for historical reasons.
*/

// read the lines in the csv file.
var records = csv.GetRecords<PersonModel>();



foreach (var item in records)
{
    // print the lines one by one on the console.
    Console.WriteLine(item.FirstName + " " + item.LastName);


    //writing linq query for the names starts with A

    /* var nameQuery = (  from p in records
                       where p.FirstName.StartsWith('A')
                       select p);
    foreach (var person in nameQuery)
    {
        outputRecords.Add(person);
    } 

    // linq query for female people older than 29. 
    var ageAndSexQuery = (from p in records
                          where p.DateOfBirth.Year > 1993 && p.Sex.Equals("Female")
                          select p ) ;
    
    // Writing each item of the query result to a new csv file.
    foreach (var person in ageAndSexQuery)
    {
        outputRecords.Add(person);
    } */


    var occupationQuery = (from p in records
                          where p.JobTitle.Equals("barber")
                          select p);

    Console.WriteLine(occupationQuery);
    foreach (var person in occupationQuery)
    {
        outputRecords.Add(person);
    } 
}


// declare a StreamWriter Object
using var writer = new StreamWriter(outputFile);
// declare a CsvWriter object with the new csv file.
using var csvOut = new CsvWriter(writer, CultureInfo.InvariantCulture);

// pass the items into the csvout file.
csvOut.WriteRecords(outputRecords);


// PERSON MODEL

public class PersonModel
{
    // Index property
public int Index { get; set; }

// User Id property
public string UserId { get; set; }

// First Name property
public string FirstName { get; set; }

// Last Name property
public string LastName { get; set; }

// Sex property
public string Sex { get; set; }

// Email property
public string Email { get; set; }

// Phone property
public string Phone { get; set; }

// Date of Birth property
public DateTime DateOfBirth { get; set; }

// Job Title property
public string JobTitle { get; set; }

}
