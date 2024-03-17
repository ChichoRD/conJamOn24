using ReignCollectionSystem;
using ReignSystem;
using ReignSystem.Modifier;

namespace ReignBorderSystem
{
    public interface IBorder
    {
        bool PlaceIn(ReignLayout reignLayout, ReignLayoutType reignLayoutType);

        public readonly static IBorder NullBoder = NullBorder.Instance;
        private readonly struct NullBorder : IBorder
        {
            public readonly static NullBorder Instance = new NullBorder();
            public bool PlaceIn(ReignLayout reignLayout, ReignLayoutType reignLayoutType) => false;
        }
    }

    public interface IBorder<in TData> : IBorder
    {
        bool IBorder.PlaceIn(ReignLayout reignLayout, ReignLayoutType reignLayoutType) =>
            reignLayout.ModifyReign<IReignModifier<Reign, TData>, TData>(reignLayoutType, ReignModifier);

        IReignModifier<Reign, TData> ReignModifier { get; }
    }
}