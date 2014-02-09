using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rtn.Mvvm
{
    /// <summary>
    /// Mediator for all sub ViewModels. Singleton.
    /// </summary>
    public class Mediator
    {
        /// <summary>
        /// Allocate ourselves.
        /// We have a private constructor, so no one else can.
        /// </summary>
        static readonly Mediator _instance = new Mediator();

        /// <summary>
        /// Access SiteStructure.Instance to get the singleton object.
        /// Then call methods on that instance.
        /// </summary>
        public static Mediator Instance
        {
	        get { return _instance; }
        }

        /// <summary>
        /// This is a private constructor, meaning no outsiders have access.
        /// </summary>
        private Mediator()
        {
	    // Initialize members here.
        }
        
        MultiDictionary<string, IColleague> internalList
            = new MultiDictionary<string, IColleague>();

        /// <summary>
        /// Registers a Colleague to a specific message
        /// </summary>
        /// <param name="colleague">The colleague to register</param>
        /// <param name="messages">The message to register to</param>
        public void Register(IColleague colleague, IEnumerable<string> messages)
        {
            foreach (string message in messages)
                internalList.AddValue(message, colleague);
        }

        /// <summary>
        /// Notify all colleagues that are registed to the specific message
        /// </summary>
        /// <param name="message">The message for the notify by</param>
        /// <param name="args">The arguments for the message</param>
        public void NotifyColleagues(string message, object args)
        {
            if (internalList.ContainsKey(message))
            {
                //forward the message to all listeners
                foreach (IColleague colleague in internalList[message])
                    colleague.MessageNotification(message, args);
            }
        }
    }
}
