using System;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// An attribute that changes the indent level of a field in the editor.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class IndentAttribute : PropertyAttribute
    {
        /// <summary>
        /// The indent level to set for the field.
        /// </summary>
        public int indentLevel;

        /// <summary>
        /// Creates a new IndentAttribute with the given indent level.
        /// </summary>
        /// <param name="indentLevel">The indent level to set for the field.</param>
        public IndentAttribute(int indentLevel = 1)
        {
            this.indentLevel = indentLevel;
        }

    }

}
