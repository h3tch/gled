﻿using System;
using System.Collections.Generic;

namespace App
{
    class GLException : Exception
    {
        private List<string> callstack = new List<string>();
        private List<string> messages = new List<string>();

        public GLException() : base()
        {
        }

        public GLException(string message) : base(message)
        {
        }

        // compile call stack into a single string
        private string callstackstring
        {
            get
            {
                string str = "";
                foreach (var s in callstack)
                    str += s + ": ";
                return str;
            }
        }

        // compile all messages into a single string
        private string messagestring
        {
            get
            {
                string str = "";
                foreach (var msg in messages)
                    str += msg + '\n';
                return str;
            }
        }

        public void Add(string message)
        {
            messages.Add(callstackstring + message);
        }

        public void PushCall(string text)
        {
            callstack.Add(text);
        }

        public void PopCall()
        {
            if (callstack.Count > 0)
                callstack.RemoveAt(callstack.Count - 1);
        }

        public bool HasErrors()
        {
            return messages.Count > 0;
        }

        public void Throw(string message)
        {
            throw new GLException(callstackstring + message);
        }
    }
}