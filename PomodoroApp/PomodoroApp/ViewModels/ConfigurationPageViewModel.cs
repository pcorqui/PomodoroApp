using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PomodoroApp.ViewModels
{
    public class ConfigurationPageViewModel: NotificationObject
    {
        //Exponemos una propiedad
        private ObservableCollection<int> pomodoroDuration;

        private const string PomodoroDuration = "PomodoroDuration";
        private const string BreakDuration = "BreakDuration";

        public ObservableCollection<int> PomodoroDurations
        {
            get { return pomodoroDuration; }
            set
            {
                pomodoroDuration = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<int> breakDurations;

        public ObservableCollection<int> BreakDurations
        {
            get { return breakDurations; }
            set
            {
                breakDurations = value;
                OnPropertyChanged();
            }
        }


        private int selectedPomodoroDuration;

        public int SelectedPomodoroDuration
        {
            get { return selectedPomodoroDuration; }
            set 
            {
                selectedPomodoroDuration = value;
                OnPropertyChanged();
            
            }
        }

        private int selectedBreakDuration;

        public int SelectedBreakDuration
        {
            get { return selectedBreakDuration; }
            set
            {
                selectedBreakDuration = value;
                OnPropertyChanged();

            }
        }

        public ConfigurationPageViewModel()
        {
            LoadPomodoroDurations();
            LoadBreakDuration();
            SaveCommand = new Command(SaveCommandExcute);
            LoadConfiguration();
        }

        private void LoadBreakDuration()
        {
            BreakDurations = new ObservableCollection<int>();
            BreakDurations.Add(1);
            BreakDurations.Add(5);
            BreakDurations.Add(10);
            BreakDurations.Add(25);
        }

        private void LoadPomodoroDurations()
        {
            PomodoroDurations = new ObservableCollection<int>();
            pomodoroDuration.Add(1);
            pomodoroDuration.Add(5);
            pomodoroDuration.Add(10);
            pomodoroDuration.Add(25);
        }

        private void LoadConfiguration()
        {
            if (Application.Current.Properties.ContainsKey(PomodoroDuration))
            {
                SelectedPomodoroDuration = (int)Application.Current.Properties[PomodoroDuration];
            }

            if (Application.Current.Properties.ContainsKey(BreakDuration))
            {
                SelectedBreakDuration = (int)Application.Current.Properties[BreakDuration];
            }
        }


        public ICommand SaveCommand
        {
            get;set;
        }

        private async void SaveCommandExcute()
        {
            Application.Current.Properties[PomodoroDuration] = SelectedPomodoroDuration;
            Application.Current.Properties[BreakDuration] = SelectedBreakDuration;

            await Application.Current.SavePropertiesAsync();
        }

    }
}
