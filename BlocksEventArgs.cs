using System;

namespace ADCinvoice
{
    public class BlocksEventArgs<R, T> : EventArgs
    {

        public BlocksEventArgs(R b, T r)
        {
            blok = b;
            res = r;
        }
        private R blok;
        private T res;
        public T result()
        {
            return res;
        }
        public R block()
        {
            return blok;
        }
    }

    public class BlockEventsArgs<R, T, K> : EventArgs
    {

        public BlockEventsArgs(R t, T r, K p)
        {
            txt = t;
            rect = r;
            pat = p;
        }
        private R txt;
        private T rect;
        private K pat;
        public R text()
        {
            return txt;
        }
        public T rectangle()
        {
            return rect;
        }
        public K patternId()
        {
            return pat;
        }
    }

    /*public class BlockEventArgs<R> : EventArgs
    {
        public BlockEventArgs(R r)
        {
            res = r;
        }
        private R res;
        public R result()
        {
            return res;
        }
    }*/

    static class EventExtensions
    {
        /*public static void Raise<R>(this EventHandler<BlockEventArgs<R>> theEvent,
                                    object sender, R block)
        {
            if (theEvent != null)
                theEvent(sender, new BlockEventArgs<R>(block));
        }*/
        public static void Raise<R, T>(this EventHandler<BlocksEventArgs<R, T>> theEvent,
                                    object sender, R block, T result)
        {
            if (theEvent != null)
                theEvent(sender, new BlocksEventArgs<R, T>(block, result));
        }

        public static void Raise<R, T, K>(this EventHandler<BlockEventsArgs<R, T, K>> theEvent,
                                    object sender, R text, T rectId, K patternId)
        {
            if (theEvent != null)
                theEvent(sender, new BlockEventsArgs<R, T, K>(text, rectId, patternId));
        }
    }
}
