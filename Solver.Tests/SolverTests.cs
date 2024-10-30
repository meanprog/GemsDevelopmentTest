using System;
using Xunit;
using Solver;

namespace Solver.Tests
{
    public class EquationSolverTests
    {
        [Fact]
        public void SolveQuadratic_DiscriminantGreaterThanZero_ReturnsTwoRoots()
        {
            var result = EquationSolver.SolveQuadratic(1, -3, 2);
            Assert.Equal(2, result.x1); // 2
            Assert.Equal(1, result.x2); // 1
        }

        [Fact]
        public void SolveQuadratic_DiscriminantEqualsZero_ReturnsOneRoot()
        {
            var result = EquationSolver.SolveQuadratic(1, -2, 1);
            Assert.Equal(1, result.x1); // 1
            Assert.Equal(1, result.x2); // 1
        }

        [Fact]
        public void SolveQuadratic_DiscriminantLessThanZero_ReturnsNoRealRoots()
        {
            var result = EquationSolver.SolveQuadratic(1, 0, 1);
            Assert.Null(result.x1); // нет корней
            Assert.Null(result.x2);
        }

        [Fact]
        public void SolveQuadratic_AEqualsZero_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => EquationSolver.SolveQuadratic(0, 2, 1));
        }

        [Theory]
        [InlineData(2, 5, -3.5, 0.5700274723201295, -3.0700274723201293)]
        [InlineData(1, 4, 1, -0.2679, -3.7321)]
        public void SolveQuadratic_ValidInputs_ReturnsExpectedRoots(double a, double b, double c, double expectedX1, double expectedX2)
        {
            var result = EquationSolver.SolveQuadratic(a, b, c);
            Assert.Equal(expectedX1, (result.x1.Value), 4);
            Assert.Equal(expectedX2, result.x2.Value, 4);
        }
    }
}