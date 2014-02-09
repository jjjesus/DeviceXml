using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Rtn.Mvvm;

namespace JohnJesus.DeviceViewModel
{
    public class BaseViewModel : IColleague, INotifyPropertyChanged
    {
        public BaseViewModel()
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
        }

        bool _isSelected;
        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is selected.
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    this.OnPropertyChanged("IsSelected");

                    if (value == true) SelectedDeviceChanged();
                }
            }
        }

        public void SelectedDeviceChanged()
        {
            Mediator.Instance.NotifyColleagues(Messages.SelectViewModel, this);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
