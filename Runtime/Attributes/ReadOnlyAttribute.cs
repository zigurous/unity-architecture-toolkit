using System;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// An attribute that prevents a field from being modified in the editor.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ReadOnlyAttribute : PropertyAttribute
    {
    }

}
