using DataGridToDo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridToDo.Services
{
    class FileIOService
    {
        private readonly string PAHT;

        public FileIOService(string path)
        {
            PAHT = path;
        }


        public BindingList<ToDoModel> LoadData()
        {
            var fileExists = File.Exists(PAHT);
            if (!fileExists)
            {
                File.CreateText(PAHT).Dispose();
                return new BindingList<ToDoModel>();
            }
            using(var reader=File.OpenText(PAHT))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject <BindingList< ToDoModel >> (fileText);
            }

        }


        public void SaveData(object toDoDataList)
        {
            using(StreamWriter writer=File.CreateText(PAHT))
            {
                string output = JsonConvert.SerializeObject(toDoDataList);
                writer.Write(output);
            }
        }
    }
}
