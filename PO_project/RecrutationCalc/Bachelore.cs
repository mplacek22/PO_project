namespace PO_project.RecrutationCalc
{
    public class Bachelore
    {

        private double Round(double value)
        {
            return Math.Round(value, 2);
        }

        public double Base(double d, double sr)
        {
            return Round(d* 10 + sr);
        }

        public double Budownictwo(double d, double sr, double e, int od )
        {
            return Round(Base(d, sr) + e + od);
        }

        public double Matematyka(double d, double sr, double e)
        {
            return Round(Base(d, sr) + e);
        }

    }
}
