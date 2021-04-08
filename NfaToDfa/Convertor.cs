using System.Collections.Generic;
using System.Linq;

namespace NfaToDfa
{
    public class Convertor
    {
        private const char STATE_SEPARATOR = '&';

        public FiniteAutomata ConvertNfaToDfa(FiniteAutomata input)
        {
            if (input.type == AutomataType.DFA)
            {
                return input;
            }

            FiniteAutomata DFA = new FiniteAutomata(AutomataType.DFA, input.alphabet.ToList());

            AddInitialState(input, DFA);

            DFA = Convert(input, DFA);

            return DFA;
        }

        private FiniteAutomata AddInitialState(FiniteAutomata NFA, FiniteAutomata DFA)
        {
            _ = DFA.AddState(NFA.InitialState());

            IEnumerable<Transition> transitions = NFA.transitions.Where(x => x.fromState == NFA.InitialState());
            foreach (var transition in transitions)
            {
                if (transition.toState.Count() == 1)
                {   
                    var toState = transition.toState.First();
                    _ = DFA.AddState(toState);

                    _ = DFA.AddTransition(transition);
                }
                else if (transition.toState.Count() > 1) 
                {
                    IEnumerable<State> toStates = transition.toState;
                    string newStateName = string.Join(STATE_SEPARATOR, toStates);
                    bool isFinalState = toStates.Any(state => state.FinalState == true);

                    var aState = new State(newStateName,false ,finalState: isFinalState);
                    _ = DFA.AddState(aState);

                    _ = DFA.AddTransition(transition.transitionSymbol, transition.fromState.StateName, aState.StateName);
                }
            }

            return DFA;
        }
        
        
        private FiniteAutomata Convert(FiniteAutomata NFA, FiniteAutomata DFA)
        {
            Queue<State> statesQueue = new Queue<State>();

            IEnumerable<State> states = DFA.states.Where(x => !x.InitialState);
            foreach (State state in states)
            {
                statesQueue.Enqueue(state);
            }

            do
            {
                var fromState = statesQueue.Dequeue();

                foreach (char symbol in DFA.alphabet)
                {
                    string[] subStateNames = fromState.StateName.Split(STATE_SEPARATOR);

                    List<string> newStateNames = new List<string>();
                    bool isFinalState = false;

                    foreach (string subStateName in subStateNames)
                    {
                        var subState = NFA.states.First(x => x.StateName == subStateName);
                        Transition subTransition = NFA.transitions.FirstOrDefault(x => x.fromState == subState && x.transitionSymbol == symbol);

                        IEnumerable<State> subToStates = subTransition.toState;
                        newStateNames.AddNotExists(subToStates.Select(x => x.StateName));

                        if (!isFinalState)
                        {
                            isFinalState = subToStates.Any(state => state.FinalState);
                        }
                    }

                    string newStateName = string.Join(STATE_SEPARATOR, newStateNames.OrderBy(x => x));

                    State targetState;
                    if (!DFA.states.Any(x => x.StateName == newStateName))
                    {
                        targetState = new State(newStateName,false , isFinalState);
                        _ = DFA.AddState(targetState);

                        statesQueue.Enqueue(targetState);
                    }
                    else
                    {
                        targetState = DFA.states.First(x => x.StateName == newStateName);
                    }

                    _ = DFA.AddTransition(symbol, fromState.StateName, targetState.StateName);
                }

            }while (statesQueue.Count > 0);

            return DFA;
        }
        
        public FiniteAutomata NFAToDFA(FiniteAutomata input)
        {
            if (input.type == AutomataType.DFA)
            {
                return input;
            }

            FiniteAutomata DFA = new FiniteAutomata(AutomataType.DFA, input.alphabet.ToList());

            DFA = AddInitialState(input, DFA);

            DFA = Convert(input, DFA);

            return DFA;
        }

    }
}