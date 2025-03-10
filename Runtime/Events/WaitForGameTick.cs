using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A custom yield instruction to wait for the next game tick.
    /// </summary>
    public class WaitForGameTick : CustomYieldInstruction
    {
        /// <inheritdoc/>
        public override bool keepWaiting => tickSystem.currentTick - startTick <= 0;

        private TickSystem tickSystem;
        private int startTick;

        public WaitForGameTick(TickSystem tickSystem)
        {
            this.tickSystem = tickSystem;
            startTick = tickSystem.currentTick;
        }

        /// <inheritdoc/>
        public override void Reset()
        {
            startTick = tickSystem.currentTick;
        }

        ~WaitForGameTick()
        {
            tickSystem = null;
        }

    }

}
