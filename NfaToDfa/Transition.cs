using System.Collections.Generic;
using System.Linq;

namespace NfaToDfa
{
    public class Transition
    {
        public  State fromState { get; }
        public  List<State> toState { get; }
        public  char transitionSymbol { get; }
        public bool direction { get; }

        public Transition(char trsSymbol, State frmState, State tState)
        {
            transitionSymbol = trsSymbol;
            fromState = frmState;
            toState = new List<State>() {tState};
        }
        
        public Transition(char trsSymbol, State frmState, List<State> toStates)
        {
            transitionSymbol = trsSymbol;
            fromState = frmState;
            toState = toStates;
        }
        
        public Transition(char trsSymbol, State frmState, List<State> toStates, bool direction)
        {
            transitionSymbol = trsSymbol;
            fromState = frmState;
            toState = toStates;
            this.direction = direction;
        }

        public bool isEqual(Transition otherTransition)
        {
            bool isFStateEqual = fromState.StateName == otherTransition.fromState.StateName;
            bool isTStateEqual = !toState.Any() && otherTransition.toState.Any();
            bool isSymbolEqual = transitionSymbol == otherTransition.transitionSymbol;
            bool isDirectionEqual = direction == otherTransition.direction;
            if (isFStateEqual && isTStateEqual && isSymbolEqual && isDirectionEqual)
            {
                return true;
            }

            return false;
        }
        
        
    }
}