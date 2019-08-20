namespace ExcFerrari
{
    public interface ICar
    {
        string Driver { get; set; }

        string GasPedal();
        string BreakPedal();
    }
}
