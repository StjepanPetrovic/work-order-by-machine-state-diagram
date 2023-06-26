using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STATE_RadniNalog
{
    internal class Transition
    {
        public ActivationEvents ActivationEvents { get; set; }
        public ProjectStates ProjectStates { get; set; }

        public Transition(ProjectStates projectStates, ActivationEvents activationEvents)
        {
            ActivationEvents = activationEvents;
            ProjectStates = projectStates;
        }

        public override bool Equals(object obj)
        {
            return obj is Transition transition &&
                   ActivationEvents == transition.ActivationEvents &&
                   ProjectStates == transition.ProjectStates;
        }

        public override int GetHashCode()
        {
            int hashCode = -633424548;
            hashCode = hashCode * -1521134295 + ActivationEvents.GetHashCode();
            hashCode = hashCode * -1521134295 + ProjectStates.GetHashCode();
            return hashCode;
        }
    }
}
