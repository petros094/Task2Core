using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrudCore.Models.Repositories
{
    public class Repositry : IRepository<Person, int>
    {
        PersonContext dbContext;
        public Repositry(PersonContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public Person Get(int id)
        {
            var person = dbContext.People.Find(id);
            return person;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            var person = await dbContext.People.ToListAsync();
            return person;
        }

        public void Add(Person person)
        {
            dbContext.People.Add(person);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            //int personID = 0;
            //var person = dbContext.People.FirstOrDefault(b => b.PersonId == id);
            //if (person != null)
            //{
            //    dbContext.People.Remove(person);
            //    personID = dbContext.SaveChanges();
            //}
            //return personID;
            var person = dbContext.People.Find(id);
            dbContext.People.Remove(person);
            dbContext.SaveChanges();
        }

        public void Update(Person person)
        {
            //int personID = 0;
            //var person = dbContext.People.Find(id);
            //if (person != null)
            //{
            //    person.FirstName = item.FirstName;
            //    person.LastName = item.LastName;
            //    person.PhoneNumber = item.PhoneNumber;
            //    person.Email = item.Email;

            //    personID = dbContext.SaveChanges();
            //}

            dbContext.Entry(person).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

    }
}
