using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// topology of all network
/// </summary>
namespace Neyros
{
   public class Topology
    {
        /// <summary>
        /// number of inputs in Network
        /// </summary>
        public int InputNetworkCount { get; }

        /// <summary>
        /// Number of Outputs 
        /// </summary>
        public int OutputNetworkCount { get; }

        /// <summary>
        /// Number of Neuron layers in Network
        /// </summary>
        public List<int> HiddenLayersCount { get; }

        public Topology(int inputs, int outputs, params int[] layers)
        {
            InputNetworkCount = inputs;
            OutputNetworkCount = outputs;
            HiddenLayersCount.AddRange(layers);


        }
    }
}
