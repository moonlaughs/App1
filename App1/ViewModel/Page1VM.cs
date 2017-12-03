using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Model;
using App1.Persistancy;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace App1.ViewModel
{
    class Page1VM : NotifyPropertyChange
    {
        private readonly Singleton _singleton;
        private FrameNAvigate _frame = new FrameNAvigate();
        public RelayCommand BackCommand { get; set; }

        //public RelayCommand GetName { get; set; }
        //private ObservableCollection<Person> Person { get; set; }

        private ObservableCollection<Person> _persons;

        public ObservableCollection<Person> Persons { get { return _persons; } set { _persons = value; OnPropertyChanged(nameof(Persons)); } }


        private Facade2 _facade;

        public string Name { get; set; }

        public Page1VM()
        {
            //Person = _singleton.peroson;
            Persons = new ObservableCollection<Person>();

            _facade = new Facade2();
            _singleton = Singleton.GetInstance();
            _frame = new FrameNAvigate();

            BackCommand = new RelayCommand(BackPage);

            //GetName = new RelayCommand(GetNamefromLastPage);

            Name = _singleton.GetName();

            LoadPerson();

        }

        //public async void GetNamefromLastPage()
        //{
        //    await _facade.LoadPersons(Person);
        //    Name = _singleton.GetName();
        //}

        public async void BackPage()
        {
            Type type = typeof(MainPage);
            _frame.ActivateFrameNavigation(type);
            await _facade.LoadPersons();
        }

        //load DESIRIALIZATION!!!!!!!!!!!!!!!!!111
        public async void LoadPerson()
        {
            try
            {
                Persons = await _facade.LoadPersons();
            }
            catch (Exception ex)
            {
               Persons.Clear(); 
            }
        }
    }
}
