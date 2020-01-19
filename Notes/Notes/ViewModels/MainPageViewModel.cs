using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Notes
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        private string _filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");
        private string _editorText = string.Empty;

        public MainPageViewModel()
        {
            if (File.Exists(_filename))
            {
                EditorText = File.ReadAllText(_filename);
            }

            OnSaveButtonClicked = new Command(() =>
            {
                File.WriteAllText(_filename, _editorText);
            });

            OnDeleteButtonClicked = new Command(() =>
            {
                if (File.Exists(_filename))
                {
                    File.Delete(_filename);
                }
                EditorText = string.Empty;
            });
        }

        public string EditorText
        {
            get => _editorText;
            set
            {
                _editorText = value;
                OnPropertyChanged(nameof(EditorText));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Command OnSaveButtonClicked { get; }
        public Command OnDeleteButtonClicked { get; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
