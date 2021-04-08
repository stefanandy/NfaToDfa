using System.Collections.Generic;
using System.Linq;
using NfaToDfa;
using NUnit.Framework;

namespace NfaToDfaTesting
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_ReturnsDFAAutomata_When_ConvertNFAToDFA_WithValidNFA()
        {
            List<char> alphabet = new List<char> { '0', '1' };
            FiniteAutomata nfaTest = new FiniteAutomata(AutomataType.NFA, alphabet);

            _ = nfaTest.AddState("A", isInitialState: true,false); //A
            _ = nfaTest.AddState("B",false,false);         //B
            _ = nfaTest.AddState("C", false, isFinalState: true);   //C

            _ = nfaTest.AddTransition('0', "A", "A");     // TR: A '0' 
            _ = nfaTest.AddTransition('1', "A", "B,C");   // TR: A '1' 

            _ = nfaTest.AddTransition('0', "B", "A");     // TR: B '0' 
            _ = nfaTest.AddTransition('1', "B", "A,C");   // TR: B '1'

            _ = nfaTest.AddTransition('0', "C", "A,B");   // TR: C '0' 
            _ = nfaTest.AddTransition('1', "C", "C");     // TR: C '1'

            FiniteAutomata dfaTest = new FiniteAutomata(AutomataType.DFA, alphabet);
            _ = dfaTest.AddState("A", isInitialState: true);
            _ = dfaTest.AddState("B&C", isFinalState: true);
            _ = dfaTest.AddState("A&B", false,false);
            _ = dfaTest.AddState("A&C", isFinalState: true);
            _ = dfaTest.AddState("A&B&C", isFinalState: true);

            _ = dfaTest.AddTransition('0', "A", "A");
            _ = dfaTest.AddTransition('1', "A", "B&C");

            _ = dfaTest.AddTransition('0', "B&C", "A&B");
            _ = dfaTest.AddTransition('1', "B&C", "A&C");

            _ = dfaTest.AddTransition('0', "A&B", "A");
            _ = dfaTest.AddTransition('1', "A&B", "A&B&C");

            _ = dfaTest.AddTransition('0', "A&C", "A&B");
            _ = dfaTest.AddTransition('1', "A&C", "B&C");

            _ = dfaTest.AddTransition('0', "A&B&C", "A&B");
            _ = dfaTest.AddTransition('1', "A&B&C", "A&B&C");


            Convertor automataConverter = new Convertor();
            FiniteAutomata converterDFA = automataConverter.NFAToDFA(nfaTest);

            if (converterDFA.InitialState().StateName == dfaTest.InitialState().StateName
                && converterDFA.FinalState().Count() == dfaTest.FinalState().Count()
                && converterDFA.states.Count() == dfaTest.states.Count()
                && converterDFA.transitions.Count() == dfaTest.transitions.Count()
                && converterDFA.transitions.Last().transitionSymbol == dfaTest.transitions.Last().transitionSymbol)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }
    }
}