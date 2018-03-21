﻿using System;
using System.Collections.Generic;

namespace protofx.gl
{
    class Text : Object
    {
        public string Body { get; private set; }

        /// <summary>
        /// Generic constructor used to build the scene objects.
        /// </summary>
        /// <param name="params">A class containing all the parameters
        /// needed to instantiate the class. The GLText class requires a
        /// <code>Compiler.Block</code> object of the respective part in the code
        /// and a <code>Dictionary&lt;string, object&gt;</code> object containing
        /// the scene objects.</param>
        public Text(object @params)
            : this(@params.GetFieldValue<Compiler.Block>(),
                   @params.GetFieldValue<Dictionary<string, object>>())
        {
        }

        /// <summary>
        /// Create OpenGL object. Standard object constructor for ProtoFX.
        /// </summary>
        /// <param name="block"></param>
        /// <param name="scene"></param>
        /// <param name="debugging"></param>
        private Text(Compiler.Block block, Dictionary<string, object> scene)
            : base(block.Name, block.Anno)
        {
            Body = block.Body;
        }
    }
}