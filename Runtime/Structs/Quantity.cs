using System;
using UnityEngine;

namespace Zigurous.Architecture.Structs
{
    /// <summary>
    /// Stores a quantity of a given entity type.
    /// </summary>
    /// <typeparam name="T">The type of entity being counted.</typeparam>
    [System.Serializable]
    public struct Quantity<T> : IEquatable<Quantity<T>> where T : IEquatable<T>
    {
        /// <summary>
        /// The entity being counted.
        /// </summary>
        [Tooltip("The entity being counted.")]
        public T entity;

        /// <summary>
        /// The number of entities.
        /// </summary>
        [Tooltip("The number of entities.")]
        public int amount;

        /// <summary>
        /// Creates a new quantity with the specified amount of a given entity.
        /// </summary>
        /// <param name="entity">The entity being counted.</param>
        /// <param name="amount">The amount of entities.</param>
        public Quantity(T entity, int amount)
        {
            this.entity = entity;
            this.amount = amount;
        }

        /// <summary>
        /// Determines if the quantity is equal to another quantity.
        /// </summary>
        /// <param name="other">The quantity to compare to.</param>
        /// <returns>True if the quantities are equal, false otherwise.</returns>
        public bool Equals(Quantity<T> other)
        {
            return this.entity.Equals(other.entity) &&
                   this.amount == other.amount;
        }

        /// <summary>
        /// Determines if the quantity is equal to another quantity.
        /// </summary>
        /// <param name="other">The object to compare to.</param>
        /// <returns>True if the quantities are equal, false otherwise.</returns>
        public override bool Equals(object other)
        {
            if (other is Quantity<T> quantity) {
                return Equals(quantity);
            } else {
                return false;
            }
        }

        /// <summary>
        /// Returns the hash code of the quantity.
        /// </summary>
        /// <returns>The hash code of the quantity.</returns>
        public override int GetHashCode()
        {
            return (entity, amount).GetHashCode();
        }

        /// <summary>
        /// Converts the quantity to a string.
        /// </summary>
        /// <returns>The quantity as a string.</returns>
        public override string ToString()
        {
            return $"{amount.ToString()} {entity.ToString()}";
        }

        /// <summary>
        /// Determines if two quantities are equal.
        /// </summary>
        /// <param name="lhs">The first quantity to compare.</param>
        /// <param name="rhs">The second quantity to compare.</param>
        /// <returns>True if the quantities are equal, false otherwise.</returns>
        public static bool operator ==(Quantity<T> lhs, Quantity<T> rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Determines if two quantities are not equal.
        /// </summary>
        /// <param name="lhs">The first quantity to compare.</param>
        /// <param name="rhs">The second quantity to compare.</param>
        /// <returns>True if the quantities are not equal, false otherwise.</returns>
        public static bool operator !=(Quantity<T> lhs, Quantity<T> rhs) => !lhs.Equals(rhs);

    }

}
