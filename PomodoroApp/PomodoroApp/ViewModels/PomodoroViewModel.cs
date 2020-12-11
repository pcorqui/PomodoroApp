using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;

namespace PomodoroApp.ViewModels
{
    public class PomodoroViewModel: NotificationObject
    {
        private Timer timer ;
        private TimeSpan ellapsed;

        public TimeSpan Ellapsed
        {
            get { return ellapsed; }
            set { ellapsed = value; OnPropertyChanged()}
        }

        private bool isRunning;

        public bool IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; OnPropertyChanged(); }
        }


        public ICommand StartOrPauseCommand { get; set; }

        public PomodoroViewModel()
        {
            InitializeTimer();
            StartOrPauseCommand = new Command(StartOrPauseCommandExecute);
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Ellapsed = Ellapsed.Add(TimeSpan.FromSeconds(1));
        }

        private void StartTimer() 
        {
            timer.Start();
            IsRunning = true;
        }

        private void StopTimer()
        {
            timer.Stop();
            IsRunning = false;
        }

        private void StartOrPauseCommandExecute()
        {
            if (IsRunning)
            {
                StopTimer();
            }
            else
            {
                StartTimer();
            }
        }
    }
}
