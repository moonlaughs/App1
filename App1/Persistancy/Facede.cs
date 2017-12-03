using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using App1.Model;
using Newtonsoft.Json;

namespace App1.Persistancy
{
    //class Facede
    //{
    //    //make folder
    //    //private StorageFolder _localFolder = ApplicationData.Current.LocalFolder;

    //    //make collection
    //    private ObservableCollection<Person> _persons = new ObservableCollection<Person>();

    //    //make file in the folder
    //    //private StorageFile _personFile;
    //    private static string peoplefilename = "Person.txt";

    //    //Serialization Object
    //    public async void SavePersons(ObservableCollection<Person> savePersons)
    //    {

    //        // step 1: create folder in the application 
    //        StorageFolder localFolder = ApplicationData.Current.LocalFolder;
    //        // step 2 : create file in this folder
    //        StorageFile file =
    //            await localFolder.CreateFileAsync(peoplefilename, CreationCollisionOption.ReplaceExisting);

    //        //Marcin
    //        var serializedData = JsonConvert.SerializeObject(savePersons);
    //        File.WriteAllText(file.Path, serializedData);

    //        //xml
    //        // step 3 : convert object into xml 
    //        //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Person>));
    //        //// step 4: save the object into xml
    //        //using (Stream stream = await file.OpenStreamForWriteAsync())
    //        //{
    //        //    xmlSerializer.Serialize(stream, savePersons);
    //        //}

    //    }

    //    //deSerialization Marcin
    //    public async Task<ObservableCollection<Person>> LoadPersons(ObservableCollection<Person> persons)
    //    {
    //        StorageFolder localFolder = ApplicationData.Current.LocalFolder;
    //        StorageFile file = await localFolder.GetFileAsync(peoplefilename);

    //        var ser = File.ReadAllText(file.Path);



    //        //foreach (var x in ser)
    //        //    {
    //        //        Person.Add(x);
    //        //    }
    //        var deser = JsonConvert.DeserializeObject<ObservableCollection<Person>>(ser);

    //        return deser;
    //    }

    //    ////load list and serializes into a jason file
    //    //public async Task<ObservableCollection<Person>> LoadPersonFile()
    //    //{
    //    //    _personFile = await _localFolder.GetFileAsync(_peoplefilename);
    //    //    _persons = JsonConvert.DeserializeObject<ObservableCollection<Person>>(File.ReadAllText(_personFile.Path));

    //    //    return (ObservableCollection<Person>) _persons;
    //    //}

    //    //save ppl to file = ser
    //    //public async void SavePersons(Person newPerson)
    //    //{
    //    //    try
    //    //    {
    //    //        _personFile =
    //    //            await _localFolder.CreateFileAsync(_peoplefilename, CreationCollisionOption.ReplaceExisting);
    //    //        File.WriteAllText(_personFile.Path, JsonConvert.SerializeObject(newPerson));
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        string error = ex.Message;
    //    //    }

    //    //}

    //    //deser
    //    //public async Task<ObservableCollection<Person>> LoadPersonFile()
    //    //{
    //    //    _personFile = await _localFolder.GetFileAsync(_peoplefilename);
    //    //    _persons = JsonConvert.DeserializeObject<ObservableCollection<Person>>(File.ReadAllText(_personFile.Path));

    //    //    foreach (var x in _persons)
    //    //    {
    //    //        try
    //    //        {

    //    //        }
    //    //        catch (Exception ex)
    //    //        {
    //    //            string error = ex.Message;
    //    //        }

    //    //    }
    //    //    return (ObservableCollection<Person>)_persons;

    //    //}









    //    //public async void SavePersons(ObservableCollection<Person> savePersons)
    //    //{
    //    //    //Diyana
    //    //    var localFolder = ApplicationData.Current.LocalFolder;
    //    //    var jsonFile = await localFolder.CreateFileAsync("books.json", CreationCollisionOption.ReplaceExisting);
    //    //    var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Person>));
    //    //    using (var stream = await jsonFile.OpenStreamForWriteAsync())
    //    //    {
    //    //        jsonSerializer.WriteObject(stream, _persons);


    //    //    }
    //    //}

    //    ////des Diyana 
    //    //public async void LoadPersons()
    //    //{
    //    //    var localFolder = ApplicationData.Current.LocalFolder;
    //    //    var jsonFile = await localFolder.GetFileAsync("books.json");
    //    //    var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Person>));
    //    //    using (var stream = await jsonFile.OpenStreamForReadAsync())
    //    //    {
    //    //        var listOfBooks = jsonSerializer.ReadObject(stream) as ObservableCollection<Person>;
    //    //        foreach (var x in listOfBooks)
    //    //            Person.Add(x);
    //    //    }
    //    //}

    //    //public async void LoadPersons() //change!!!!!!!!!!!peRSISATNCY
    //    //{
    //    //    StorageFolder localFolder = ApplicationData.Current.LocalFolder;
    //    //    StorageFile file = await localFolder.GetFileAsync(peoplefilename);
    //    //    XmlSerializer xmlSerializer = new
    //    //        XmlSerializer(typeof(ObservableCollection<Person>));
    //    //    using (Stream stream = await file.OpenStreamForReadAsync())
    //    //    {
    //    //        _persons = xmlSerializer.Deserialize(stream) as ObservableCollection<Person>;
    //    //        foreach (var p in _persons)
    //    //        {
    //    //            this._persons.Add(p);
    //    //        }
    //    //    }
    //    //}
    //}

}
