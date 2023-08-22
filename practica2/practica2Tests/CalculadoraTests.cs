using Microsoft.VisualStudio.TestTools.UnitTesting;
using practica2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica2.Tests
{
    [TestClass()]
    public class CalculadoraTests
    {
        [TestMethod()]
        public void DivisionPorCeroTest()
        {
            // Arrange
            int numero = 10;
            int divisor = 0;

            // Act
            Action act = () => Calculadora.DivisionPorCero(numero, divisor);

            //assert
            Assert.ThrowsException<Exception>(act);
        }

        [TestMethod()]
        public void DivisionTest()
        {
            //Arrange
            int dividendo = 20;
            int divisor = 2;
            int resultadoEsperado = 10;
            int resultado;

            //act
            resultado = Calculadora.Division(dividendo, divisor);

            //assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod()]
        public void Division_ThrowsException()
        {
            //Arrange
            int dividendo = 20;
            int divisor = 0;

            //act y assert
            Assert.ThrowsException<Exception>(() => Calculadora.Division(dividendo, divisor));

        }
    }
}