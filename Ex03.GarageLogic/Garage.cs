using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {        
        private const string                                 k_ErrVehicleExsit = "Vehicle exits, and now is in repairing";
        private const string                                 k_ErrVehicleNotSupported = "Vehicle Not Supported in this garage";
        private const string                                 k_GarageEmptyMsg = "No Vehicles Found";
        private readonly Dictionary<string, VehicleInGarage> r_VehiclesDataBase;
        private readonly string                              r_GrageName;

        public enum eVehicleStatus
        {
            Paid = 1,
            Repairing,
            Fixed,
            Undefined,
        }

        public Garage(string i_Name = "Ido & Shai inc.")
        {
            r_GrageName = i_Name;
            r_VehiclesDataBase = new Dictionary<string, VehicleInGarage>();
        }       

        // car:        i_VehicelParams = (  enum color,                 enum num_OfDoors)
        // motorcycle: i_VehicelParams = (  float engine volume,        enum licence)
        // Truck:      i_VehicelParams = (  bool IsTruckRefrigerated,   float TrunkSize)
        public void AddVehicleToGarage(HoldAddGarageVehicleParams i_UserParams, params float[] i_VehicelParams) // (1) in menu
        {
            Vehicle         myVehicle = null;
            VehicleInGarage vehicleInGarage;
            bool            vehicleExist = r_VehiclesDataBase.TryGetValue(i_UserParams.LicencePlate, out vehicleInGarage);
            if (vehicleExist)
            {
                this.ChangeStatusOfListedCar(i_UserParams.LicencePlate, eVehicleStatus.Repairing);
                throw new ArgumentException(k_ErrVehicleExsit);
            }
            else
            {
                try
                {
                    myVehicle = VehicalGarageCreator.CreateVehicleForGarage(i_UserParams, i_VehicelParams);
                    if(myVehicle == null)
                    { 
                        throw new ArgumentException(k_ErrVehicleNotSupported);
                    }
                    else
                    {
                        vehicleInGarage = new VehicleInGarage(myVehicle, i_UserParams.ClientName, i_UserParams.PhoneNumber);
                        r_VehiclesDataBase.Add(i_UserParams.LicencePlate, vehicleInGarage);
                    }           
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string ListOfVehiclesPlatesInGarageByStatus(eVehicleStatus i_Status) // 2
        {
            string          res;
            StringBuilder   strBuilderList = new StringBuilder();
            VehicleInGarage VehicleValue;
            bool            keyFound;

            if (r_VehiclesDataBase != null)
            {
                foreach (string key in r_VehiclesDataBase.Keys)
                {
                    keyFound = r_VehiclesDataBase.TryGetValue(key, out VehicleValue);                                
                    if (keyFound && ((i_Status == VehicleValue.VehicleStatus) || (i_Status == eVehicleStatus.Undefined)))
                    {
                      strBuilderList.AppendLine(VehicleValue.MyVehicle.LicensePlate);
                    }                  
                }
            }

            if(r_VehiclesDataBase == null || strBuilderList.Length < 1 )
            {
                res = k_GarageEmptyMsg;
            }
            else
            {
                res = strBuilderList.ToString();
            }

            return res;
        }

        public void ChangeStatusOfListedCar(string i_LisenceNumber, eVehicleStatus i_NewStatus)  // 3
        {
            VehicleInGarage vehicleInGarage;
            bool             VehicleExist = r_VehiclesDataBase.TryGetValue(i_LisenceNumber, out vehicleInGarage);

            if (VehicleExist)
            {
                vehicleInGarage.VehicleStatus = i_NewStatus;
            }
            else
            {
                throw new ArgumentException(k_GarageEmptyMsg);
            }
        }

        public void InflateTireInGarage(string i_LisenceNumber) // 4 
        {
            VehicleInGarage vehicleInGarage;
            bool            VehicleExist = r_VehiclesDataBase.TryGetValue(i_LisenceNumber, out vehicleInGarage);

            if (VehicleExist)
            {
                vehicleInGarage.MyVehicle.InflateWheelsPressure();
            }
            else
            {
                throw new ArgumentException(k_GarageEmptyMsg);
            }
        }

        public void FillEnergyInGarage(string i_LisenceNumber, eEngineEnergyTypes i_EnergyType, float i_AmountToAdd) // 5-6
        {
            VehicleInGarage vehicleInGarage;
            bool            VehicleExist = r_VehiclesDataBase.TryGetValue(i_LisenceNumber, out vehicleInGarage);

            try
            {
                if (VehicleExist)
                {
                    vehicleInGarage.MyVehicle.FillEnergy(i_EnergyType, i_AmountToAdd);
                }
                else
                {
                    throw new ArgumentException(k_GarageEmptyMsg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string PrintVehicleInfoByPlate(string i_License)
        {
            VehicleInGarage vehicleInGarage;
            string          res;
            bool            VehicleExist = r_VehiclesDataBase.TryGetValue(i_License, out vehicleInGarage);

            if (VehicleExist)
            {
                res = vehicleInGarage.ToString();
            }
            else
            {
                res = k_GarageEmptyMsg;
            }

            return res;
        }

        public bool VehicleExits(string i_plate)
        {
            VehicleInGarage x;
            bool vehicleExist = r_VehiclesDataBase.TryGetValue(i_plate, out x);

            if (vehicleExist)
            {
                this.ChangeStatusOfListedCar(i_plate, eVehicleStatus.Repairing);
                throw new ArgumentException(k_ErrVehicleExsit);
            }

            return vehicleExist;
        }
    }
}
