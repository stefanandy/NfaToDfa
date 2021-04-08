using System;

namespace NfaToDfa
{
    public class State
    {
        public  bool InitialState { get; }
        public  bool FinalState { get;}
        public  string StateName { get;}

        public State(string stateName, bool initialState, bool finalState)
        {
            InitialState = initialState;
            FinalState = finalState;
            StateName = stateName;
        }

        public override string ToString()
        {
            return StateName;
        }
        
        
    }
}