namespace Vehicle
{
    public interface IVehicle
    {
        double FuelQuantity { get;}
        double FuelConsumption { get;}
        void Refuel(double liters);
    }
}
