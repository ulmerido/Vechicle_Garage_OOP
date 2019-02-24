using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eSupportedVehicels
    {        
        RegularMotorcycle = 1,
        ElectricMotorcycle,
        RegularCar,
        ElectricCar,
        Truck,
    }

    public class ESupportedVehicelsToText
    {
        public static string AsText(eSupportedVehicels eSupport)
        {
            string enumDescripton = "null";
            switch (eSupport)
            {
                case eSupportedVehicels.RegularMotorcycle:
                    {
                        enumDescripton = "Regular Motorcycle";
                        break;
                    }    

                case eSupportedVehicels.ElectricMotorcycle:
                    {
                        enumDescripton = "Electric Motorcycle";
                        break;
                    }

                case eSupportedVehicels.RegularCar:
                    {
                        enumDescripton = "Regular Car";
                        break;
                    }

                case eSupportedVehicels.ElectricCar:
                    {
                        enumDescripton = "Electric Car";
                        break;
                    }

                case eSupportedVehicels.Truck: 
                    {
                        enumDescripton = "Truck";
                        break;
                    }
            }

            return enumDescripton;
        }
    }
}
