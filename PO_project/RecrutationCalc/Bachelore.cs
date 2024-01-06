namespace PO_project.RecrutationCalc
{
    public class Bachelore
    {
        public double Base(double d, double sr)
        {
            return d* 10 + sr;
        }

        public double Budownictwo(double d, double sr, double e, int od )
        {
            return Base(d, sr) + e + od;
        }

        public double Matematyka(double d, double sr, double e)
        {
            return Base(d, sr) + e;
        }

    }
}
