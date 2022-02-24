using RestWithASPNET.Model;

namespace RestWithASPNET.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            // TODO: ...
        }

        public List<Person> FindAll()
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                people.Add(person);
            }

            return people;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name" + id,
                LastName = "Person Last Name",
                Address = "Some Address",
                Gender = "Female"
            };
        }

        public Person Update(Person person)
        {
            //TODO: ... 

            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name" + i,
                LastName = "Person Last Name",
                Address = "Some Address",
                Gender = "Female"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
