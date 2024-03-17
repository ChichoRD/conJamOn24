using ReignSystem;

namespace ReignBorderSystem.Factory
{
    public interface IBorderFactory
    {
        IBorder CreateBetween(in Reign from, in Reign to);
    }
}
