using System.Diagnostics;
using System.Windows;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;
using System;
using System.Linq;

namespace BackgroundTaskAgent
{
    public class ScheduledAgent : ScheduledTaskAgent
    {
        /// <remarks>
        /// ScheduledAgent constructor, initializes the UnhandledException handler
        /// </remarks>
        static ScheduledAgent()
        {
            // Subscribe to the managed exception handler
            Deployment.Current.Dispatcher.BeginInvoke(delegate
            {
                Application.Current.UnhandledException += UnhandledException;
            });
        }

        /// Code to execute on Unhandled Exceptions
        private static void UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                Debugger.Break();
            }
        }

        /// <summary>
        /// Agent that runs a scheduled task
        /// </summary>
        /// <param name="task">
        /// The invoked task
        /// </param>
        /// <remarks>
        /// This method is called when a periodic or resource intensive task is invoked
        /// </remarks>
        protected override void OnInvoke(ScheduledTask task)
        {
            // preparing content for update Live Tile
            int count = 0;
            string currentTime = DateTime.Now.ToString();

            UpdatePrimaryTile(count, currentTime);


            NotifyComplete();
        }

        /// <summary>
        /// Updates primary live tile
        /// </summary>
        /// <param name="count">Count value</param>
        /// <param name="content">Content</param>
        public void UpdatePrimaryTile(int count, string content)
        {
            FlipTileData primaryTileData = new FlipTileData();
            primaryTileData.Title = content;
            primaryTileData.Count = count;
            primaryTileData.BackContent = content;
            primaryTileData.BackTitle = "Back side";

            ShellTile primaryTile = ShellTile.ActiveTiles.First();
            primaryTile.Update(primaryTileData);
        }

        /// <summary>
        /// Shows notification
        /// </summary>
        public void ShowNotification(ScheduledTask task)
        {
            ShellToast toast = new ShellToast();
            toast.Title = "Background Agent";
            toast.Content = "Periodic background task";
            toast.Show();

            // If debugging is enabled, launch the agent again in one minute.
#if DEBUG
            ScheduledActionService.LaunchForTest(task.Name, TimeSpan.FromSeconds(60));
#endif
        }
    }
}