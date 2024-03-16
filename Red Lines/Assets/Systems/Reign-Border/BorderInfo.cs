using ReignCollectionSystem;

namespace ReignBorderSystem
{
    internal readonly struct BorderInfo
    {
        public readonly ReignLayoutType from;
        public readonly ReignLayoutType to;

        public BorderInfo(ReignLayoutType from, ReignLayoutType to)
        {
            this.from = from;
            this.to = to;
        }
    }
}