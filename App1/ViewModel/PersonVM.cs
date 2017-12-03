using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Pwm;
using App1.Model;
using App1.Persistancy;
using App1.View;

namespace App1.ViewModel
{
    public class PersonVM : NotifyPropertyChange
    {
        private Facade2 _facade;

        private readonly FrameNAvigate _frameNavigate;

        private Person _selectedItem;

        //singleton
        private readonly Singleton _userSingleton;

        public ObservableCollection<Person> Persons { get; set; }

        public RelayCommand AddItemCommand { get; set; }
        public RelayCommand DeletItemCommand { get; set; }
        public RelayCommand UpdateItemCommand { get; set; }

        public static Person AddNewPerson { get; set; }

        public Person SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public RelayCommand GoToPage1Command { get; set; }

        //ctor
        public PersonVM()
        {

            AddItemCommand = new RelayCommand(DoAddItem);
            DeletItemCommand = new RelayCommand(DoDeleteItem);
            UpdateItemCommand = new RelayCommand(DoUpdateItem);

            //NEED TO BE INITIALIZED IN THE CTOR:
            //1
            AddNewPerson = new Person();

            //2
            SelectedItem = new Person();

            //3 PERSISTANCY!!!!!!!!!!!!!!!!!
            _facade = new Facade2();

            //4
            Persons = new ObservableCollection<Person>();

            //5
            // Frame Navigate Object instance
            _frameNavigate = new FrameNAvigate();

            //6
            // Page Navigate Command
            GoToPage1Command = new RelayCommand(DoPage1);

            //var showList = new RelayCommand(Show);
            AddNewPerson.ToString();

            _userSingleton = Singleton.GetInstance();

            Task.Run(() => Load());
        }

        public async void Load()
        {
            try
            {
                await _facade.LoadPersons();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            
            _facade.SavePersons(Persons);
        }

        //public void Show()
        //{
        //    _facade.LoadPersons(Persons);
        //    Persons = new ObservableCollection<Person>();
        //}

        public void DoAddItem()
        {
            //_facade.LoadPersons(Persons);
            Task.Run(() => Load());
            var person = new Person(AddNewPerson.Name, AddNewPerson.Age);
            Persons.Add(person);
            //SAVE THE DATA: PERSISTANCY SERIALIZATION!!!!!!!!!!!!!!!!!!!!
            //_facade.LoadPersons();
            _facade.SavePersons(Persons);
        }

        //public void DoAddItem()
        //{
        //    //var person = new Person(AddNewPerson.Name, AddNewPerson.Age);
        //    Persons.Add(AddNewPerson);
        //    //SAVE THE DATA: PERSISTANCY SERIALIZATION!!!!!!!!!!!!!!!!!!!!
        //    //_facade.LoadPersons();
        //    _facade.SavePersons(Persons);
        //    AddNewPerson = new Person();
        //}


        public void DoDeleteItem()
        {
            Persons.Remove(SelectedItem);
            //REMOVE PERSISTANCY!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            _facade.SavePersons(Persons);
        }

        public void DoUpdateItem()
        {
            Persons = new ObservableCollection<Person>
            {
                new Person(SelectedItem.Name, SelectedItem.Age)
            };
            _facade.SavePersons(Persons);
        }

        public void DoPage1()
        {
            _userSingleton.SetPerson(SelectedItem);
            Type type = typeof(Page2);
            _frameNavigate.ActivateFrameNavigation(type);
        }

        
    }
}
