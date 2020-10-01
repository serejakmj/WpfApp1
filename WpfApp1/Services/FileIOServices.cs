using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    class FileIOServices
    {
        private readonly string PATH;

        public FileIOServices(string path)
        {
            PATH = path;
        }
        public BindingList<ToDoModel> LoadData()
        {
            var fileExist = File.Exists(PATH);
            if (!fileExist)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<ToDoModel>();
            }
            using (var Reader = File.OpenText(PATH))
            {
                var fileText = Reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<ToDoModel>>(fileText);
            }

            
        }

        public void SaveData(BindingList<ToDoModel> ToDoDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string Output = JsonConvert.SerializeObject(ToDoDataList);
                writer.Write(Output);
            }
        }
    }
}
