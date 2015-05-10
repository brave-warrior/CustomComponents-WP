using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Phone.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomComponents.ViewModel
{
    public class BackgroundTaskViewModel : BaseViewModel
    {
        private const string PERIODIC_TASK = "PeriodicTask";

        // handlers
        public RelayCommand StartBackgroundTaskCommand { get; private set; }
        public RelayCommand StopBackgroundTaskCommand { get; private set; }

        public BackgroundTaskViewModel(INavigationService navigationService) : base(navigationService)
        {

            // handlers
            StartBackgroundTaskCommand = new RelayCommand(HandleStartBackgroundTask);
            StopBackgroundTaskCommand = new RelayCommand(HandleStopBackgroundTask);
        }

        /// <summary>
        /// Handles command Start background task
        /// </summary>
        private void HandleStartBackgroundTask()
        {
            StartPeriodicAgent();
        }

        /// <summary>
        /// Handles command Stop background task
        /// </summary>
        private void HandleStopBackgroundTask()
        {
            RemoveAgent(PERIODIC_TASK);
        }

        /// <summary>
        /// Starts periodic task
        /// </summary>
        private void StartPeriodicAgent()
        {
            // Obtain a reference to the period task, if one exists
            PeriodicTask periodicTask = ScheduledActionService.Find(PERIODIC_TASK) as PeriodicTask;

            // If the task already exists and background agents are enabled for the
            // application, you must remove the task and then add it again to update 
            // the schedule
            if (periodicTask != null)
            {
                RemoveAgent(PERIODIC_TASK);
            }

            periodicTask = new PeriodicTask(PERIODIC_TASK);

            // The description is required for periodic agents. This is the string that the user
            // will see in the background services Settings page on the device.
            periodicTask.Description = "This demonstrates a periodic task.";

            // Place the call to Add in a try block in case the user has disabled agents.
            try
            {
                ScheduledActionService.Add(periodicTask);

                // If debugging is enabled, use LaunchForTest to launch the agent in one minute.
#if(DEBUG)
                ScheduledActionService.LaunchForTest(PERIODIC_TASK, TimeSpan.FromSeconds(60));
#endif
            }
            catch (InvalidOperationException exception)
            {
                if (exception.Message.Contains("BNS Error: The action is disabled"))
                {
                    MessageBox.Show("Background agents for this application have been disabled by the user.");
                }

                if (exception.Message.Contains("BNS Error: The maximum number of ScheduledActions of this type have already been added."))
                {
                    // No user action required. The system prompts the user when the hard limit of periodic tasks has been reached.
                }
            }
            catch (SchedulerServiceException)
            {
                // No user action required.
            }
        }

        /// <summary>
        /// Stops background agent
        /// </summary>
        /// <param name="name">Name of the background task</param>
        private void RemoveAgent(string name)
        {
            try
            {
                ScheduledActionService.Remove(name);
            }
            catch (Exception)
            {
            }
        }
    }
}
