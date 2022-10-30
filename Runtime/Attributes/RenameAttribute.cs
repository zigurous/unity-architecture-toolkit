using System;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// An attribute that renames a field in the editor.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class RenameAttribute : PropertyAttribute
    {
        /// <summary>
        /// The new name of the field.
        /// </summary>
        public string newName;

        /// <summary>
        /// Creates a new RenameAttribute with the given name.
        /// </summary>
        public RenameAttribute(string newName)
        {
            this.newName = newName;
        }

    }

}
