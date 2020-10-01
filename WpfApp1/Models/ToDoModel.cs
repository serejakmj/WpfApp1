using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class ToDoModel
    {
        private string _Name;
        private string _StartTime;
        private string _Link;
        private int _Day;


        public string StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }
        public string Link
        {
            get { return _Link; }
            set { _Link = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public int Day
        {
            get { return _Day; }
            set { _Day = value; }
        }
    }
}
