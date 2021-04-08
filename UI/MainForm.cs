using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NfaToDfa;

namespace UI
{
    public partial class Form1 : Form
    {
        private String inputString;
        private String automataConfig;
        private FiniteAutomata NFA;
        private FiniteAutomata DFA;
        
        public Form1()
        {
            InitializeComponent();
            
        }


        private void browseButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var config = Reader.Read(fileDialog.FileName);
                automataConfig = config;
                automataRichTextBox.Text = automataConfig;
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            inputString = inputStringTextBox.Text;
            string[] tokens = automataConfig.Split("\n");
            var splitter = ";";
            List<char> alphabet = new List<char>();
            List<State> states = new List<State>();
            List<Transition> transitions = new List<Transition>();
            string[] transitionData = new string[] { };
            FiniteAutomata automata = null;
            
            for (int i = 0; i < tokens.Length-1; i++)
            {
                if (i==0)
                { 
                    alphabet = tokens[i].Split(splitter).SelectMany(s=>s.ToCharArray()).Distinct().ToList();
                    automata = new FiniteAutomata(AutomataType.NFA, alphabet);
                }
                else if (i==1)
                {
                    var statesNames = tokens[i].Split(splitter);
                    for (int j = 0; j <statesNames.Length ; j++)
                    {
                        if (j==0)
                        {
                            var state = new State(statesNames[j], true, false);
                            automata.AddState(state);
                        }else if (j==statesNames.Length-1)
                        {
                            var state = new State(statesNames[j], false, true);
                            automata.AddState(state);
                        }
                        else
                        {
                            var state = new State(statesNames[j], false, false);
                            automata.AddState(state);
                        }
                    }
                }
                else
                {
                    transitionData = tokens[i].Split(splitter);
                    automata.AddTransition(transitionData[0].ToCharArray()[0], transitionData[1], transitionData[2]);
                }
            }

            var (result, text) = automata.Run(inputString);
            if (result == false)
            {
                Console.WriteLine("Not Valid");
                
            }
            automataOutputRichTextBox.Text = text;
            NFA = automata;
        }

      

        private void runDFAButton_Click(object sender, EventArgs e)
        {
            if (DFA is null)
            {
                Convertor automataConverter = new Convertor();
                FiniteAutomata dfa = automataConverter.NFAToDFA(NFA);

                var (result, text)= dfa.Run(inputString);
                if (result==false)
                {
                    Console.WriteLine("Not Valid");
                }

                automataOutputRichTextBox.Text = text;
            }
            else
            {
                var (result, text)= DFA.Run(inputString);
                if (result==false)
                {
                    Console.WriteLine("Not Valid");
                }

                automataOutputRichTextBox.Text = text;
            }
            

        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            Convertor automataConverter = new Convertor();
            FiniteAutomata converterDFA = automataConverter.NFAToDFA(NFA);
            DFA = converterDFA;
            
        }
    }
}