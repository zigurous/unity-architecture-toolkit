using System;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// An attribute that prevents a field from being changed in the editor,
    /// i.e., it is read-only.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ReadOnlyAttribute : PropertyAttribute
    {
    }

}
