﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridToDo.Models
{
    class ToDoModel:INotifyPropertyChanged
    {
        public DateTime CreatoinDate { get; set; } = DateTime.Now;

        public bool _isDone;
        
        private string _text;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsDone
        {
            get { return _isDone; }
            set 
            {
                if (_isDone == value)
                    return;
            
                _isDone = value;
                OnPropertyChanged("IsDone");
            }
        }

        

        public string Text
        {
            get { return _text; }
            set 
            {
                if (_text == value)
                    return;
                _text = value;
                OnPropertyChanged("Text");
            
            }
        }
 

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            //проверка на null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
