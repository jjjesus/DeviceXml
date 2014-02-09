using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rtn.Mvvm
{
    /// <summary>
    /// Colleague that can register to messages from the Mediator
    /// </summary>
    public interface IColleague
    {
        /// <summary>
        /// Notification from the Mediator
        /// </summary>
        /// <param name="message">The message type</param>
        /// <param name="args">Arguments for the message</param>
        void MessageNotification(string message, object args);
    }
}
