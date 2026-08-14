// Source - https://stackoverflow.com/a/5486729
// Posted by Steven, modified by community. See post 'Timeline' for change history
// Retrieved 2026-08-14, License - CC BY-SA 4.0

using System.Collections.Generic;

namespace Zigurous.Architecture
{
    public readonly struct StructEnumerable<T>
    {
        private readonly List<T> list;

        public StructEnumerable(List<T> list)
        {
            this.list = list;
        }

        public StructEnumerator<T> GetEnumerator()
        {
            return new StructEnumerator<T>(list);
        }

    }

}
