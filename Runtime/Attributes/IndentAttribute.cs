using System;
using UnityEngine;

namespace Zigurous.Architecture
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class IndentAttribute : PropertyAttribute
    {
        public int indentLevel { get; private set; }

        public IndentAttribute(int indentLevel = 1)
        {
            this.indentLevel = indentLevel;
        }

    }

}
