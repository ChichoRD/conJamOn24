using ReignSystem;

namespace ReignBorderSystem.Factory
{
    public interface IBorderFactory
    {
        IBorder CreateBetween(Reign from, Reign to);
    }
}
