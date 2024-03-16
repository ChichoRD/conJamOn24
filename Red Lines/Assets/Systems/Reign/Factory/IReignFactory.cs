namespace ReignSystem.Factory
{
    public interface IReignFactory<out TReign>
    {
        TReign Create();
    }
}