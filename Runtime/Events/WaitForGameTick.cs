using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A custom yield instruction to wait for the next game tick.
    /// </summary>
    public class WaitForGameTick : CustomYieldInstruction
    {
        /// <inheritdoc/>
        public override bool keepWaiting => tickSystem.count - startTick <= 0;

        private TickSystem tickSystem;
        private int startTick;

        private WaitForGameTick() {}

        /// <summary>
        /// Creates a new yield instruction to wait for the next game tick.
        /// </summary>
        /// <param name="tickSystem">The system handling game ticks to wait on.</param>
        public WaitForGameTick(TickSystem tickSystem)
        {
            this.tickSystem = tickSystem;
            startTick = tickSystem.count;
        }

        /// <inheritdoc/>
        public override void Reset()
        {
            startTick = tickSystem.count;
        }

        ~WaitForGameTick()
        {
            tickSystem = null;
        }

    }

}
