namespace ReignSystem.Modifier
{
    public interface IReignModifier<out TReign, in TData>
    {
        TReign Modify(TData value);
    }
}