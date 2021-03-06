﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

using System.Linq;
using System.Text;

using JohnJesus.DeviceModel;
using JohnJesus.DataService;
using Rtn.Mvvm;

namespace JohnJesus.DeviceViewModel
{
    public class SystemViewModel : BaseViewModel, IColleague
    {
        public List<RackViewModel> ChildViewModelList { get; set; }

        public SystemViewModel()
        {
            //register to the mediator for the SelectDevice message
            Mediator.Instance.Register(this, new[]
            {
                Messages.SelectViewModel
            });

            DeviceDataService.Load();
            ChildViewModelList = new List<RackViewModel>();

            foreach (Rack rack in Rack.RackList)
            {
                ChildViewModelList.Add(new RackViewModel(rack));
            }
        }
        /// <summary>
        /// Notification from the Mediator
        /// </summary>
        /// <param name="message">The message type</param>
        /// <param name="args">Arguments for the message</param>
        public void MessageNotification(string message, object args)
        {
        }
    }
}
