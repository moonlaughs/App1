using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using App1.ViewModel;

namespace App1.Model
{
    public class Person
    {
        private string _name;
        private int _age;

        public string Name
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Person()
        { 
        }

        public override string ToString()
        {
            return $"{Name}{Age}";
        }
    }
}
