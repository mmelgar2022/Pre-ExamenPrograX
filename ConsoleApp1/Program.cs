using System;

namespace Refactorizacion.DesignPatterns.AbstractFactory.Conceptual
{
        public interface IFabrica
    {
        IProductoA CreateProductA();

        IProductoB CreateProductB();
    }

    class Fabrica1 : IFabrica
    {
        public IProductoA CreateProductA()
        {
            return new Producto1();
        }

        public IProductoB CreateProductB()
        {
            return new ConcreteProductB1();
        }
    }
      
    class ConcreteFactory2 : IFabrica
    {
        public IProductoA CreateProductA()
        {
            return new CproductoA2();
        }

        public IProductoB CreateProductB()
        {
            return new CproductoB2();
        }
    }

    public interface IProductoA
    {
        string UsefulFunctionA();
    }

       class Producto1 : IProductoA
    {
        public string UsefulFunctionA()
        {
            return "El resultado del producto A1.";
        }
    }

    class CproductoA2 : IProductoA
    {
        public string UsefulFunctionA()
        {
            return "El resultado del producto A2.";
        }
    }
    public interface IProductoB
    {
             string UsefulFunctionB();

        string AnotherUsefulFunctionB(IProductoA collaborator);
    }

    class ConcreteProductB1 : IProductoB
    {
        public string UsefulFunctionB()
        {
            return "El resultado del producto B1.";
        }
        public string AnotherUsefulFunctionB(IProductoA collaborator)
        {
            var result = collaborator.UsefulFunctionA();

            return $"El resultado de la B1 colaborando con({result})";
        }
    }

    class CproductoB2 : IProductoB
    {
        public string UsefulFunctionB()
        {
            return "El resultado del producto B2.";
        }

             public string AnotherUsefulFunctionB(IProductoA collaborator)
        {
            var result = collaborator.UsefulFunctionA();

            return $"El resultado de la B2 colaborando con  ({result})";
        }
    }

      class Client
    {
        public void Main()
        {
           Console.WriteLine("Cliente: Probando el código del cliente con el primer tipo de fábrica....");
            ClientMethod(new Fabrica1());
            Console.WriteLine();

            Console.WriteLine("Cliente: Probando el mismo código de cliente con el segundo tipo de fábrica...");
            ClientMethod(new ConcreteFactory2());
        }

        public void ClientMethod(IFabrica factory)
        {
            var productA = factory.CreateProductA();
            var productB = factory.CreateProductB();

            Console.WriteLine(productB.UsefulFunctionB());
            Console.WriteLine(productB.AnotherUsefulFunctionB(productA));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}