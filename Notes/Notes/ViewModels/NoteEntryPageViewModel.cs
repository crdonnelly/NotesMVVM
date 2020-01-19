using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Notes
{
    class NoteEntryPageViewModel : INotifyPropertyChanged
    {
        public NoteEntryPageViewModel()
        {
            OnSaveButtonClicked = new Command(() =>
            {
                var note = new Note();
            });
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
