using MongoDbDemo2.Data;
using MongoDbDemo2.Models;

namespace MongoDbDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MongoCRUD db = new MongoCRUD("AdressBook");

            //C
            //var person = new PersonModel { 
            //    FirstName = "Simon", 
            //    LastName = "Arvidsson",
            //    Adress = new AdressModel
            //    {
            //        City = "Los Angeles",
            //        Street = "Palo Alto Street 123",
            //        State = "California",
            //    }
            //};
            //db.InsertRecord("Users", person);

            //R
            var records = db.LoadRecords<PersonModel>("Users");

            foreach(var record in records)
            {
                Console.WriteLine(record.FirstName);
                if(record.Adress != null)
                {
                    Console.WriteLine(record.Adress.Street);
                }
            }
        }
    }
}