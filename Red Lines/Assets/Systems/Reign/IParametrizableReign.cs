namespace ReignSystem
{
    public interface IParametrizableReign<out TParameter>
    {
        TParameter Parameter { get; }
    }
}