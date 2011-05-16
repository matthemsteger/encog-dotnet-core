using System;
using System.Text;
using Encog.Engine.Network.Activation;

namespace Encog.Neural.Flat
{
    /// <summary>
    /// Used to configure a flat layer. Flat layers are not kept by a Flat Network,
    /// beyond setup.
    /// </summary>
    ///
    public class FlatLayer
    {
        /// <summary>
        /// The neuron count.
        /// </summary>
        ///
        private readonly int count;

        /// <summary>
        /// The bias activation, usually 1 for bias or 0 for no bias.
        /// </summary>
        ///
        private double biasActivation;

        /// <summary>
        /// The layer that feeds this layer's context.
        /// </summary>
        ///
        private FlatLayer contextFedBy;

        /// <summary>
        /// Construct a flat layer.
        /// </summary>
        ///
        /// <param name="activation_0">The activation function.</param>
        /// <param name="count_1">The neuron count.</param>
        /// <param name="biasActivation_2">The bias activation.</param>
        public FlatLayer(IActivationFunction activation_0, int count_1,
                         double biasActivation_2)
        {
            Activation = activation_0;
            count = count_1;
            biasActivation = biasActivation_2;
            contextFedBy = null;
        }


        /// <value>the activation to set</value>
        public IActivationFunction Activation { /// <returns>the activation</returns>
            get; /// <param name="activation_0">the activation to set</param>
            set; }


        /// <summary>
        /// Set the bias activation.
        /// </summary>
        ///
        /// <value>The bias activation.</value>
        public double BiasActivation
        {
            /// <returns>Get the bias activation.</returns>
            get
            {
                if (HasBias())
                {
                    return biasActivation;
                }
                else
                {
                    return 0;
                }
            }
            /// <summary>
            /// Set the bias activation.
            /// </summary>
            ///
            /// <param name="a">The bias activation.</param>
            set { biasActivation = value; }
        }


        /// <value>The number of neurons our context is fed by.</value>
        public int ContextCount
        {
            /// <returns>The number of neurons our context is fed by.</returns>
            get
            {
                if (contextFedBy == null)
                {
                    return 0;
                }
                else
                {
                    return contextFedBy.Count;
                }
            }
        }


        /// <summary>
        /// Set the layer that this layer's context is fed by.
        /// </summary>
        ///
        /// <value>The layer feeding.</value>
        public FlatLayer ContextFedBy
        {
            /// <returns>The layer that feeds this layer's context.</returns>
            get { return contextFedBy; }
            /// <summary>
            /// Set the layer that this layer's context is fed by.
            /// </summary>
            ///
            /// <param name="from">The layer feeding.</param>
            set { contextFedBy = value; }
        }


        /// <value>the count</value>
        public int Count
        {
            /// <returns>the count</returns>
            get { return count; }
        }


        /// <value>The total number of neurons on this layer, includes context, bias
        /// and regular.</value>
        public int TotalCount
        {
            /// <returns>The total number of neurons on this layer, includes context, bias
            /// and regular.</returns>
            get
            {
                if (contextFedBy == null)
                {
                    return Count + ((HasBias()) ? 1 : 0);
                }
                else
                {
                    return Count + ((HasBias()) ? 1 : 0)
                           + contextFedBy.Count;
                }
            }
        }


        /// <returns>the bias</returns>
        public bool HasBias()
        {
            return Math.Abs(biasActivation) > EncogFramework.DEFAULT_DOUBLE_EQUAL;
        }

        /// <summary>
        /// 
        /// </summary>
        ///
        public override sealed String ToString()
        {
            var result = new StringBuilder();
            result.Append("[");
            result.Append(GetType().Name);
            result.Append(": count=");
            result.Append(count);
            result.Append(",bias=");

            if (HasBias())
            {
                result.Append(biasActivation);
            }
            else
            {
                result.Append("false");
            }
            if (contextFedBy != null)
            {
                result.Append(",contextFed=");
                if (contextFedBy == this)
                {
                    result.Append("itself");
                }
                else
                {
                    result.Append(contextFedBy);
                }
            }
            result.Append("]");
            return result.ToString();
        }
    }
}