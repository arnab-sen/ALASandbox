﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraries;
using ProgrammingParadigms;

namespace DomainAbstractions
{
    /// <summary>
    /// <para>Applies a lambda on an input of type T1 and returns an output of type T2.</para>
    /// <para>Ports:</para>
    /// <para>IDataFlow&lt;T1&gt; input: The input to the lambda.</para>
    /// <para>IDataFlow&lt;T2&gt; output: The output from the lambda.</para>
    /// <para>IDataFlowB&lt;Func&lt;T1,T2&gt;&gt; lambdaInput: A lambda can be pulled from an external source through this port.</para>
    /// </summary>
    public class Apply<T1, T2> : IDataFlow<T1> // input
    {
        // Properties
        public string InstanceName { get; set; } = "Default";
        public Func<T1, T2> Lambda;

        // Private fields
        private T1 lastInput = default;
        private T2 storedValue;

        // Ports
        private IDataFlow<T2> output;

        /// <summary>
        /// <para>Applies a lambda on an input of type T1 and returns an output of type T2.</para>
        /// </summary>
        public Apply() { }

        // IDataFlow<T1> implementation
        T1 IDataFlow<T1>.Data
        {
            get => lastInput;
            set
            {
                lastInput = value;
                
                storedValue = Lambda(lastInput);

                if (output != null && storedValue != null) output.Data = storedValue;
            } 
        }

    }
}