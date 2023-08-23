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
    public class LogicTests
    {
        [TestMethod()]
        public void MetodoConExcepcionTest()
        {
            //arrange 
            // No hay configuracion de estado arrange ya que no se aplica para esta prueba.

            // act llama al metodo que lanza la excepcion
            // La excepcion sale automaticamente cuando se llama al metodo!!! NO OLVIDAR, CLAVE

            Assert.ThrowsException<InvalidOperationException>(() => Logic.MetodoConExcepcion());
        }
        [TestMethod()]
        public void MetodoCustomExceptionTest()
        {
            //arrange 
            // No hay configuracion de estado arrange ya que no se aplica para esta prueba.

            // Act: Lo mismo que el metodo anterior

            Assert.ThrowsException<CustomException>(() => Logic.MetodoCustomException());
        }
    }
}