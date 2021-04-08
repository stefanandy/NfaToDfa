using System;
using System.Collections.Generic;
using System.Linq;

namespace NfaToDfa
{
    public enum AutomataType
    {
        DFA=0,
        NFA=1
    }
    
    public class FiniteAutomata
    {
        public readonly AutomataType type;

        public List<char> alphabet = new List<char>();
        public List<State> states = new List<State>();
        public List<Transition> transitions = new List<Transition>();

        public FiniteAutomata(AutomataType type, List<char> chars)
        {
            this.type = type;
            alphabet = chars;
        }

        public bool isDFA()
        {
            bool hasInitialState = InitialState() != null;
            bool hasFinalState = FinalState().Count() > 0;
            
            foreach (var state in states)
            {
                foreach (var c in alphabet)
                {
                    bool haveTransition =
                        transitions.Where(x => x.fromState.StateName == state.StateName && x.transitionSymbol == c)
                            .Count() == 1;
                    if (!haveTransition)
                    {
                        return false;
                    }
                }
            }

            if (!hasFinalState || !hasInitialState)
            {
                return false;
            }

            return true;
        }

        public bool isNFA()
        {
            bool hasInitialState = InitialState() != null;
            bool hasFinalState = FinalState().Count() > 0;

            if (!hasInitialState || !hasFinalState)
            {
                return false;
            }

            return true;
        }
        
        public State InitialState()
        {
            var state = states.FirstOrDefault(x => x.InitialState == true);
            return state;
        }

        public List<State> FinalState()
        {
            var finalStates = states.Where(x => x.FinalState == true).ToList();
            return finalStates;
        }

        public State GetStateByName(string name)
        {
            var state = states.FirstOrDefault(x => x.StateName.ToLower() == name.ToLower());
            return state;
        }

        public bool AddState(string name, bool isInitialState = false, bool isFinalState = false)
        {
            State state = new State(name, isInitialState, isFinalState);
            states.Add(state);

            return true;
        }

        public bool AddState(State state)
        {
            if (state is null)
            {
                return false;
            }

            if (states.Contains(state))
            {
                return false;
            }
            
            states.Add(state);

            return true;
        }

        public void UpdateState(State state)
        {
            State prvState = GetStateByName(state.StateName);
            states.Remove(prvState);
            states.Add(state);
        }

        public bool AddTransition(char symbol, string fromStateName, string toStateName, int direction = -1)
        {
            string[] toStateArray = toStateName.Split(',');
            if (type == AutomataType.DFA  && toStateArray.Length > 1)
            {
                return false;
            }

            if (!alphabet.Contains(symbol))
            {
                return false;
            }

            State fromState = GetStateByName(fromStateName);
            if (fromState == null)
            {
                return false;
            }

            List<State> toStateList = new List<State>();
            foreach (var selectedState in toStateArray)
            {
                State toState = GetStateByName(selectedState);
                if (toState == null )
                {
                    return false;
                }
                toStateList.Add(toState);
            }

            Transition transitionsModel = null;
            if (direction == 0 || direction == 1)
            {
                transitionsModel = new Transition(symbol, fromState, toStateList, direction == 1);
            }
            else
            {
                transitionsModel = new Transition(symbol, fromState, toStateList);
            }

            bool haveTransition = transitions.Any(x => x.isEqual(transitionsModel) == true);
            if (haveTransition)
            {
                return false;
            }
            
            transitions.Add(transitionsModel);
            return true;
        }

        public bool AddTransition(Transition transition)
        {
            if (transition is null)
            {
                return false;
            }

            if (type == AutomataType.DFA && transitions.Count()>1)
            {
                return false;
            }

            if (!alphabet.Contains(transition.transitionSymbol))
            {
                return false;
            }

            bool haveTransition = transitions.Any(x => x.isEqual(transition) == true);
            if (haveTransition)
            {
                return false;
            }
            
            transitions.Add(transition);
            return true;
        }
        
        public (bool,string) Run(string input)
        {
            if (isDFA()==false || isNFA()==false)
            {
                return (false,null);
            }

            string output = "";

            State currentState = InitialState();
            Transition currentTransition;
            foreach (char letter in input)
            {
                string write = $"Transition {letter} - {currentState.StateName} >>> ";
                output += write;

                currentTransition = this.transitions.FirstOrDefault(x => x.fromState.StateName == currentState.StateName && x.transitionSymbol == letter);
                currentState = currentTransition.toState.RandomState();
                output += currentState.StateName + '\n';
            }

            string secondWrite = $"Current State is {currentState.StateName}.(Final State: {(currentState.FinalState ? "Yes" : "No")})";
            output += secondWrite+'\n';
            
            if (currentState.FinalState)
            {
                return (true, output);
            }

            return (false,null);
        }
    }
}