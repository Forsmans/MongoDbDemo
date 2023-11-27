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
            var person = new PersonModel
            {
                FirstName = "Simon",
                LastName = "Arvidsson",
                Adress = new AdressModel
                {
                    City = "Los Angeles",
                    Street = "Palo Alto Street 123",
                    State = "California",
                }
            };
            db.InsertRecord("Users", person);

            //R
            //All
            var records = db.LoadRecords<PersonModel>("Users");

            foreach (var record in records)
            {
                Console.WriteLine(record.FirstName);
                if (record.Adress != null)
                {
                    Console.WriteLine(record.Adress.Street);
                }
            }

            //One
            var selectedPerson = db.LoadRecordsByID<PersonModel>("Users", new Guid("9524ec75-c513-4220-bc05-10274e6983cd"));
            Console.WriteLine(selectedPerson.FirstName);

            //U
            var selectedPerson = db.LoadRecordsByID<PersonModel>("Users", new Guid("9524ec75-c513-4220-bc05-10274e6983cd"));
            selectedPerson.DateOfBirth = new DateTime(1991, 6, 4, 1, 2, 3, DateTimeKind.Utc);
            db.UpsertRecord("Users", selectedPerson.Id, selectedPerson);


            //D
            var selectedPerson = db.LoadRecordsByID<PersonModel>("Users", new Guid("9524ec75-c513-4220-bc05-10274e6983cd"));
            db.DeleteRecord<PersonModel>("Users", selectedPerson.Id);
        }
    }
}