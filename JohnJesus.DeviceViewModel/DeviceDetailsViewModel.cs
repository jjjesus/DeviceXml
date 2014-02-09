using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Rtn.Mvvm;

namespace JohnJesus.DeviceViewModel
{
    public class DeviceDetailsViewModel : BaseViewModel, IColleague
    {
        public BaseViewModel SelectedViewModel { get; set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        public DeviceDetailsViewModel()
        {
            //register to the mediator for the SelectDevice message
            Mediator.Instance.Register(this, new[]
            {
                Messages.SelectViewModel
            });
        }

        /// <summary>
        /// Notification from the Mediator
        /// </summary>
        /// <param name="message">The message type</param>
        /// <param name="args">Arguments for the message</param>
        public void MessageNotification(string message, object args)
        {
            switch (message)
            {
                //change the CurrentDevice to be the newly selected Device
                case Messages.SelectViewModel:
                    SelectedViewModel = (BaseViewModel)args;
                    break;
            }
        }
    }
}
