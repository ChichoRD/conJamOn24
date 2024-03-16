using ReignCollectionSystem;
using ReignSystem;
using ReignSystem.Modifier;

namespace ReignBorderSystem
{
    public interface IBorder
    {
        bool PlaceIn(ReignLayout reignLayout, ReignLayoutType reignLayoutType);
    }

    public interface IBorder<in TData> : IBorder
    {
        bool IBorder.PlaceIn(ReignLayout reignLayout, ReignLayoutType reignLayoutType) =>
            reignLayout.ModifyReign<IReignModifier<Reign, TData>, TData>(reignLayoutType, ReignModifier);

        IReignModifier<Reign, TData> ReignModifier { get; }
    }
}