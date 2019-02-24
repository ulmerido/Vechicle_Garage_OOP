using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicalGarageCreator
    {            
        public static Vehicle CreateVehicleForGarage(HoldAddGarageVehicleParams i_UserParams, params float[] i_VehicelParams)
        {
            Vehicle     myVehicle = null;
            Engine      engine = getEngine(i_UserParams.Engine);
            List<Wheel> wheels = new List<Wheel>();
            
            try
            {
                for(int i = 0; i < i_UserParams.Wheels.AmountOfWheels; i++)
                {
                    wheels.Add(new Wheel(i_UserParams.Wheels.WheelManufacturerName, i_UserParams.Wheels.MaxManufacturerPressure, i_UserParams.Wheels.WheelPressureStatus));
                }

                HoldVehicleParams vehicleParams = new HoldVehicleParams(i_UserParams.VehicleModel, i_UserParams.LicencePlate, engine, wheels);
                switch (i_UserParams.VehicleType)
                {
                    case eVehicleTypes.Car:
                        myVehicle = new Car((Car.eColors)i_VehicelParams[0], (Car.eNumOfDoors)i_VehicelParams[1], vehicleParams);
                        break;

                    case eVehicleTypes.Motorcycle:
                        myVehicle = new Motorcycle((uint)i_VehicelParams[0], vehicleParams, (Motorcycle.eMotorcycleLicenceType)i_VehicelParams[1]);
                        break;

                    case eVehicleTypes.Truck:
                        bool coldTrank = i_VehicelParams[0] == 1;
                        myVehicle = new Truck(coldTrank, (float)i_VehicelParams[1], vehicleParams);
                        break;
                }

                if (!isVehicleSupported(myVehicle))
                {
                    myVehicle = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return myVehicle;
        }

        private static bool isVehicleSupported(Vehicle i_Vehicle)
        {
            bool isSupported = false;
            if (i_Vehicle != null)
            {
                if (i_Vehicle is Car)
                {
                    isSupported = checkIfSpescificVehicleSupported(i_Vehicle, SupportedParameters.k_MaxElectricCarEnergy, SupportedParameters.k_MaxFuelCarTank, SupportedParameters.k_MaxCarWheelPressure, eEngineEnergyTypes.Octan98);
                }
                else if (i_Vehicle is Motorcycle)
                {
                    isSupported = checkIfSpescificVehicleSupported(i_Vehicle, SupportedParameters.k_MaxElectricMotorcycleEnergy, SupportedParameters.k_MaxFuelMotorcycleTank, SupportedParameters.k_MaxMotorcycleWheelPressure, eEngineEnergyTypes.Octan96);
                }
                else if (i_Vehicle is Truck)
                {
                    isSupported = checkIfSpescificVehicleSupported(i_Vehicle, 0, SupportedParameters.k_MaxTruckFuelTank, SupportedParameters.k_MaxTruckWheelPressure, eEngineEnergyTypes.Soler);
                }
            }

            return isSupported;
        }

        private static bool checkIfSpescificVehicleSupported(Vehicle i_Vehicle, float i_ElectricMaxEnergy, float i_MaxFuel, float i_MaxWheelPressure, eEngineEnergyTypes i_Fuel)
        {
            bool isSupported = false;
            bool wheelSupported = true;

            if (i_Vehicle.VehicleWheels != null)
            {
                foreach (Wheel wheel in i_Vehicle.VehicleWheels)
                {
                    if (wheel.MaxManufacturerPressure > i_MaxWheelPressure)
                    {
                        wheelSupported = false;
                        break;
                    }
                }

                if (wheelSupported)
                {
                    if ((i_Vehicle.GetEngine.GetEngineType == eEngineEnergyTypes.Electric && i_Vehicle.GetEngine.GetMaxEnergy() <= i_ElectricMaxEnergy)
                            || (i_Vehicle.GetEngine.GetEngineType == i_Fuel && i_Vehicle.GetEngine.GetMaxEnergy() <= i_MaxFuel))
                    {
                        isSupported = true;
                    }
                }
            }

            return isSupported;
        }

        private static Engine getEngine(HoldEngineParams i_engine)
        {
            Engine res;
            try
            {    
                if (i_engine.EngineType == eEngineEnergyTypes.Electric)
                {
                    res = new ElectricEngine(i_engine);
                }
                else
                {
                    res = new FuelEngine(i_engine);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return res;
        }
    }
}
