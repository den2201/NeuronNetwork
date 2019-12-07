using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// class of minipal part o NeyroNetworks
/// </summary>
namespace Neyros
{
   public class Neyron
    {
        //Weights of Inputs
        public List<double> Weights { get; }

        public NeuronType NeuronType { get; }

        //Output of Neuron
        public double Output { get; private set; }

        public Neyron(int inputCount,NeuronType type=NeuronType.Normal)
        {
            if(type==NeuronType.Input)
            {
                NeuronType = type;
                Weights = new List<double>();
                for(int i=0;i<inputCount;++i)
                {
                    Weights.Add(1);
                }
            }
        }

        /// <summary>
        /// Method Gets entering signals to neuron multipl they on weights and returns its sum
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>

        public double FeedForward(List<double> inputs)
        {
            if (inputs.Count != Weights.Count)
                return 0.0;

            var sum = 0.0;
            for(int i=0;i<inputs.Count;i++)
            {
                sum += inputs[i] * Weights[i];
            }

            Output = Sigmoid(sum);
            return Output;
        }

        /// <summary>
        /// Sigmoid func returns result 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private double Sigmoid(double x)
        {
            var result = 1.0 / (1.0 + Math.Pow(Math.E, -x));
            return result;
        }

    }
}
