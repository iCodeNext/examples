using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.E3
{
    public interface IShipping
    {
      
    }

    public class Air : IShipping
    {
     
    }


    public class Ship : IShipping
    {
        private readonly string _origin;
        private readonly string _destination;

        public Ship(string origin, string destination)
        {
            _origin = origin;
            _destination = destination;
        }
    }


    public class Train : IShipping
    {
    
    }
    public class Truck : IShipping
    {
     
    }

    public interface IShippingFactory
    {
        IShipping CreateShipping();
    }

    public class AirFactory : IShippingFactory
    {
        private static Air _air;

        public IShipping CreateShipping()
        {
            if (_air == null)
            {
                _air = new Air();
            }

            return _air;
        }
    }

    public class ShipFactory : IShippingFactory
    {

        private readonly string _origin;
        private readonly string _destination;

        public ShipFactory(string origin, string destination)
        {
            _origin = origin;
            _destination = destination;
        }

        public IShipping CreateShipping()
        {
            return new Ship(_origin, _destination);
        }

    }
    public class TrainFactory : IShippingFactory
    {

        public IShipping CreateShipping()
        {
            Train train = new Train();
            Call();
            return train;
        }
        private void Call()
        {
        }
    }
    public class TruckFactory : IShippingFactory
    {
        public IShipping CreateShipping()
        {
            return new Truck();
        }
    }

    public class Cargo
    {
        private IShippingFactory _shippingFactory;
        public Cargo(IShippingFactory shippingFactory)
        {
            _shippingFactory = shippingFactory;
        }

        public IShipping ShipProduct()
        {
            return _shippingFactory.CreateShipping();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var airCargo = new Cargo(new AirFactory()).ShipProduct();

            var shipCargo = new Cargo(new ShipFactory("A", "B")).ShipProduct();

            var trainCargo = new Cargo(new TrainFactory()).ShipProduct();
        }
    }


}

