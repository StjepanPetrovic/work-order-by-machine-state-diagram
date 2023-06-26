using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STATE_RadniNalog
{
    public class StateManager
    {
        public ProjectStates CurrentState { get; set; }
        private Dictionary<Transition, ProjectStates> allowedTransitions;

        public StateManager()
        {
            CurrentState = ProjectStates.OrderCreated;
            SpecifyAllowedTransitions();
        }

        private void SpecifyAllowedTransitions()
        {
            allowedTransitions = new Dictionary<Transition, ProjectStates>();

            allowedTransitions.Add(new Transition(ProjectStates.OrderCreated, ActivationEvents.AllItemsAddedInOrder), ProjectStates.OrderLocked);
            allowedTransitions.Add(new Transition(ProjectStates.OrderLocked, ActivationEvents.ProductionCommited), ProjectStates.PutIntoProduction);
            allowedTransitions.Add(new Transition(ProjectStates.OrderLocked, ActivationEvents.ProductionCommited), ProjectStates.ProductionCanceled);
            allowedTransitions.Add(new Transition(ProjectStates.PutIntoProduction, ActivationEvents.OrderTaken), ProjectStates.ProductionStarted);
            allowedTransitions.Add(new Transition(ProjectStates.ProductionStarted, ActivationEvents.AllItemsFinished), ProjectStates.ProductionFinished);
        }

        public void MakeTransition(ActivationEvents activationEvent)
        {
            Transition transition = new Transition(CurrentState, activationEvent);
            ProjectStates resultingState;

            if (allowedTransitions.TryGetValue(transition, out resultingState) == false)
            {
                throw new ApplicationException();
            }

            CurrentState = resultingState;
        }

        public override string ToString()
        {
            return CurrentState.ToString();
        }
    }
}
