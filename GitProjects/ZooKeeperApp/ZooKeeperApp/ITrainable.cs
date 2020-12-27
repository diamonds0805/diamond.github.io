using System;
using System.Collections.Generic;

namespace ZooKeeperApp
{
    public interface ITrainable
    {
        public Dictionary<string,string> Behaviors { get; set; }
        //the key is the signal the user will use to ask the animal
        //to perform a behavior

        //the value is the behavior the animal will perform when it sees
        //the signal

        public string Perform(string signal);
        //fetch the behavior from the Behaviors dictionary based on the signal
        //should return string describing how the animal performed

        public string Train(string signal, string behavior);
        //will add the behavior to the Behaviors dictionary using the signal as the key
        //should return string describing how the animal has been trained
        //and will respond to the specified signal

    }
}
