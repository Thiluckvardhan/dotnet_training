namespace ScienceLib
{
    public class AeroScience
    {
        public double CalculateLift(double area, double liftCoefficient, double airDensity, double velocity)
        {
            // Lift = 0.5 * airDensity * velocity^2 * area * liftCoefficient
            return 0.5 * airDensity * velocity * velocity * area * liftCoefficient;
        }
    }
}
