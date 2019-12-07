using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// layer of neurons;
/// </summary>
namespace Neyros
{
   public class LayerNeyrons
    {
        public List<Neyron> Neurons { get; }
        
        public int CountNeurons => Neurons?.Count ?? 0;

        public LayerNeyrons(List<Neyron> neurons, NeuronType type = NeuronType.Normal)
        {
            foreach(var neuron in neurons)
            {
                if(neuron.NeuronType!=type)
                {
                    throw new InvalidProgramException(string.Format("neyrons doesn't equal of type {0}",type));
                }
                Neurons = neurons;
            }

        }

        public List<double> GetOutputSignals()
        {
            var result = new List<double>();
            foreach(var neuron in Neurons)
            {
                result.Add(neuron.Output);
            }
            return result;
        }

    }
}
