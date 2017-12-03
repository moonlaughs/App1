using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Persistancy;

namespace App1.Model
{
    class Singleton
    {
        //trying with persistance!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Facade2 _facade = new Facade2();

        public ObservableCollection<Person> peroson { get; set; }
        
        //object instace of my business logic

        public static Person _person;

        //declare obj instance of class SINGLETON

        private static Singleton Instance { get; set; }

        private Singleton()
        {
            _person = new Person();
        }

        //check if instance is not null
        //if it is null create an obj instance

        public static Singleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Singleton();
            }
            return Instance;
        }

        //create methods of your business logic

        public void SetPerson(Person person)
        {
            //await _facade.LoadPersons(peroson);
            _person = person;
            //try
            //{
            //    peroson.Any();
            //}
            //catch (Exception e)
            //{
            //    _facade.LoadPersons(peroson);
            //    throw;
            //}
        }

        public string GetName()
        {
            //_facade.LoadPersons(peroson);
            return _person.Name;
        }

        public int GetAge()
        {
            return _person.Age;
        }

        //public ObservableCollection<Person> list;

        //public Singleton()
        //{
        //    list = new ObservableCollection<Person>()
        //    {
        //        new Person("Grzegorz", 45),
        //        new Person("Anna", 43),
        //        new Person("Mateusz", 16)
        //    };

        //    peroson = new ObservableCollection<Person>();
        //}
    }
}
