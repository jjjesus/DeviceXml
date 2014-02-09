using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JohnJesus.DeviceViewModel
{
    /// <summary>
    /// Defines a list of messages that the ViewModels use to communicate with each other
    /// </summary>
    public static class Messages
    {
        /// <summary>
        /// Message to notify that an item is selected
        /// </summary>
        public const string SelectViewModel = "selectViewModel";
    }
}
