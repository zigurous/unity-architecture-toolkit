// Source - https://stackoverflow.com/a/5486729
// Posted by Steven, modified by community. See post 'Timeline' for change history
// Retrieved 2026-08-14, License - CC BY-SA 4.0

using System;
using System.Collections.Generic;

namespace Zigurous.Architecture
{
    public struct StructEnumerator<T>
    {
        private readonly List<T> list;
        private int index;

        public StructEnumerator(List<T> list)
        {
            this.list = list;
            this.index = -1;
        }

        public readonly T Current
        {
            get
            {
                if (list == null || index < 0 || index >= list.Count) {
                    throw new InvalidOperationException();
                }

                return list[index];
            }
        }

        public bool MoveNext()
        {
            index++;
            return list != null && index < list.Count;
        }

        public void Reset()
        {
            index = -1;
        }

    }

}
