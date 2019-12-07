using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neyros
{
   public class NeuronNetwork
    {
        public List<LayerNeyrons> Layers;


        public Topology Topology { get; }

        public NeuronNetwork(Topology topology)
        {
            Topology = topology;
            Layers = new List<LayerNeyrons>();

            CreateInputLayer();
            CreateHiddenLayers();
            CreateOutputLayer();
        }

        /// <summary>
        /// created output layer in network
        /// </summary>

        private void CreateOutputLayer()
        {
            var outputNeurons = new List<Neyron>();
            var lastLayer = Layers.Last();
            for (int i = 0; i < Topology.OutputNetworkCount; ++i)
            {
                outputNeurons.Add(new Neyron(lastLayer.CountNeurons, NeuronType.Output));
            }
            var outputLayer = new LayerNeyrons(outputNeurons, NeuronType.Output);
            Layers.Add(outputLayer);

        }

        /// <summary>
        /// created hidden layers with counted neyrons
        /// </summary>
        private void CreateHiddenLayers()
        {
            for (int j = 0; j < Topology.HiddenLayersCount.Count; ++j)
            {
                var hiddenNeurons = new List<Neyron>();
                var lastLayer = Layers.Last();
                for (int i = 0; i < Topology.HiddenLayersCount[j]; i++)
                {
                    hiddenNeurons.Add(new Neyron(lastLayer.CountNeurons));
                }
                var hiddenLayer = new LayerNeyrons(hiddenNeurons);
                Layers.Add(hiddenLayer);
            }
        }

        /// <summary>
        /// input signal to network inputs and throw its thrue the network
        /// </summary>
        /// <param name="inputSgnals"></param>
        /// <returns></returns>

        public Neyron FeedForwardNetwork(List<double> inputSgnals)
        {
            if(Topology.InputNetworkCount!=inputSgnals.Count)
            {
                throw new Exception(string.Format("input signals count {0} not equal network topology inputs{1}", inputSgnals.Count,Topology.InputNetworkCount));
            }

            SendSignalsToInputNeurons(inputSgnals);
            FeedForwardAllLayersAfterInput();
            if(Topology.OutputNetworkCount==1)
            {
                return Layers.Last().Neurons[0];
            }
            else
            {
                return Layers.Last().Neurons.OrderByDescending(n => n.Output).First();

            }
        }

        
        private void FeedForwardAllLayersAfterInput()
        {
            for (int i = 1; i < Layers.Count; i++)
            {

                var layer = Layers[i];
                var previusLayerSignals = Layers[i - 1].GetOutputSignals();
                foreach (var neuron in layer.Neurons)
                {
                    neuron.FeedForward(previusLayerSignals);

                }
            }
        }

        private void SendSignalsToInputNeurons(List<double> inputSgnals)
        {
            for (int i = 0; i < inputSgnals.Count; i++)
            {
                var signal = new List<double> { inputSgnals[i] };
                var neuron = Layers[0].Neurons[i];
                neuron.FeedForward(signal);
            }
        }

        /// <summary>
        /// created input Layer in Network
        /// </summary>
        private void CreateInputLayer()
        {
            var inputNeurons = new List<Neyron>();
            for (int i = 0; i < Topology.InputNetworkCount; ++i)
            {
                inputNeurons.Add( new Neyron(1, NeuronType.Input));
            }
            var inputLayer = new LayerNeyrons(inputNeurons, NeuronType.Input);
            Layers.Add(inputLayer);
        }
    }
}
