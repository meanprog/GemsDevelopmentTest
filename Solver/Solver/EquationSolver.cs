using System;

namespace Solver
{
    public class EquationSolver
    {
        public static (double? x1, double? x2) SolveQuadratic(double a, double b, double c)
        {
            if (a == 0)
            {
                throw new ArgumentException("Коэффициент 'a' не может быть равен нулю для квадратного уравнения.");
            }

            double discriminant = b * b - 4 * a * c;

            if (discriminant > 0)
            {
                double sqrtDiscriminant = Math.Sqrt(discriminant);
                double x1 = (-b + sqrtDiscriminant) / (2 * a);
                double x2 = (-b - sqrtDiscriminant) / (2 * a);
                return (x1, x2);
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                return (x, x);
            }
            else
            {
                return (null, null); // Комплексные корни
            }
        }
    }
}