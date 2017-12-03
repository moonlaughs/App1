using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using App1.Model;

namespace App1.Persistancy
{
    class Facade2
    {
        private ObservableCollection<Person> _persons;
        private static string personfilename = "Person.txt";

        private StorageFile file;


        // Serialization Object
        public async void SavePersons(ObservableCollection<Person> savePerson)
        {


            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            if (file == null)
            {
                file = await localFolder.GetFileAsync(personfilename);
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Person>));

            try
            {

                using (Stream stream = await file.OpenStreamForWriteAsync())

                {

                    xmlSerializer.Serialize(stream, savePerson);

                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        //deSerialization
        public async Task<ObservableCollection<Person>> LoadPersons()
        {
            //StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            //StorageFile file = await localFolder.GetFileAsync(personfilename);
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Person>));

            //using (Stream stream = await file.OpenStreamForReadAsync())
            //{
            //    //foreach (var x in _persons)
            //    //{
            //    //    _persons.Add(x);
            //    //}
            //    _persons = xmlSerializer.Deserialize(stream) as ObservableCollection<Person>;
                
            //}

            //return _persons;
            return new ObservableCollection<Person>();
        }
    }
}
