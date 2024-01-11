﻿using PO_project.Models;
using System.Reflection;

namespace PO_project.RecrutationCalc
{
    public static class Bachelore
    {

        public static ValueTuple<double, double> Calculate(String name, double d, double sr, double e, int od)
        {

            MethodInfo? calculatorMethodInfo;
            double points = Bachelore.Base((double)d, (double)sr);
            double pointsKierunek = points;

            if ((calculatorMethodInfo = typeof(Bachelore)
                                    .GetMethods()
                                    .FirstOrDefault(m =>
                                        m.Name == name &&
                                        m.GetParameters().Select(p => p.ParameterType).SequenceEqual(new Type[] { typeof(double), typeof(double) }))) != null)
                pointsKierunek = (double)calculatorMethodInfo!.Invoke(null, new object[] { d, sr })!;
            else if ((calculatorMethodInfo = typeof(Bachelore)
                                    .GetMethods()
                                    .FirstOrDefault(m =>
                                        m.Name == name &&
                                        m.GetParameters().Select(p => p.ParameterType).SequenceEqual(new Type[] { typeof(double), typeof(double), typeof(int) }))) != null)
                pointsKierunek = (double)calculatorMethodInfo!.Invoke(null, new object[] { d, sr, od })!;
            else if ((calculatorMethodInfo = typeof(Bachelore)
                                    .GetMethods()
                                    .FirstOrDefault(m =>
                                        m.Name == name &&
                                        m.GetParameters().Select(p => p.ParameterType).SequenceEqual(new Type[] { typeof(double), typeof(double), typeof(double) }))) != null)
                pointsKierunek = (double)calculatorMethodInfo!.Invoke(null, new object[] { d, sr, e })!;
            else if ((calculatorMethodInfo = typeof(Bachelore)
                                    .GetMethods()
                                    .FirstOrDefault(m =>
                                        m.Name == name &&
                                        m.GetParameters().Select(p => p.ParameterType).SequenceEqual(new Type[] { typeof(double), typeof(double), typeof(double), typeof(int) }))) != null)
                pointsKierunek = (double)calculatorMethodInfo!.Invoke(null, new object[] { d, sr, e, od })!;

            return (points, pointsKierunek);
        }

        private static double Round(double value)
        {
            return Math.Round(value, 2);
        }

        public static double Base(double d, double sr)
        {
            return Round(d* 10 + sr);
        }

        public static double Budownictwo(double d, double sr, double e, int od )
        {
            return Round(Base(d, sr) + e + od);
        }

        public static double Matematyka(double d, double sr, double e)
        {
            return Round(Base(d, sr) + e);
        }

    }
}
