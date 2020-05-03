using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ObjectLibrary;

public delegate List<List<string>> ParseData(List<List<string>> data);

namespace FileParser {
    
    //public class Person { }  // temp class delete this when Person is referenced from dll
    
    public class PersonHandler {
        public List<Person> People;

        /// <summary>
        /// Converts List of list of strings into Person objects for People attribute.
        /// </summary>
        /// <param name="people"></param>
        public PersonHandler(List<List<string>> people) {
            People = new List<Person>();

            DataParser dp = new DataParser();

            ParseData parsedata = new ParseData(dp.StripQuotes);
            parsedata += dp.StripWhiteSpace;
            parsedata += dp.StripHashes;

            parsedata.Invoke(people);

            for (int i = 1; i < people.Count; i++)
            {
                People.Add(new Person(int.Parse(people[i][0]), people[i][1], people[i][2], new DateTime(long.Parse(people[i][3]))));
            }
        }

        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest() {

            List<Person> entry = People.OrderBy(person => person.Dob).ToList();

            return new List<Person> { entry[0], entry[1] }; //-- return result here
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id) {

            return "string";  //-- return result here
        }

        public List<Person> GetOrderBySurname() {
            return People.OrderBy(person => person.Surname).ToList();  //-- return result here
        }

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive) {

            if (!caseSensitive)
                searchTerm = searchTerm.ToUpper()[0] + searchTerm.Substring(1, searchTerm.Length - 1).ToLower();

            int Results = 0;

            foreach(Person p in People)
            {
                if (p.Surname.StartsWith(searchTerm))
                    Results++;
            }

            return Results;  //-- return result here
        }
        
        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAmountBornOnEachDate() {
            List<string> result = new List<string>();

            var x = People.GroupBy(person => person.Dob).OrderBy(i => i.Key);
            foreach(var y in x)
            {
                result.Add(y.Key.ToString("dd/MM/yyyy") + " " + y.Count());
            }
            return result;  //-- return result here
        }
    }
}