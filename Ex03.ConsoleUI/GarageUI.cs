using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        private const string k_FuelAmountFormat = "Fuel In Litters";
        private const string k_ElecAmountFormat = "of remaining power in minutes";
        private const string k_InvalidInput = "Invalid Input";
        private const string k_EnergyAddedSuccessfully = "Energy was successfully added";
        private Garage       m_Grage;

        public GarageUI()
        {
            m_Grage = new Garage();
        }

        public void Run()
        {
            int  userInput;
            bool esc = false;
            while (!esc)
            {
                try
                {
                    printMenu();
                    userInput = int.Parse(Console.ReadLine()); // we didnt use tryparse here to demonstrate catching FormatException
                    switch (userInput)
                    {
                        case 1:
                            optionAddVehicle();
                            break;
                        case 2:
                            optionShowLicenseByStatus();
                            break;
                        case 3:
                            changeStatusOfCarInGarage();
                            break;
                        case 4:
                            optionOnflateTireToMax();
                            break;
                        case 5:
                            optionFillFuelEnergy();
                            break;
                        case 6:
                            optionFillElictricEnergy();
                            break;
                        case 7:
                            optionShowAllDetailsByPlate();
                            break;
                        case 8:
                            clearScreen();
                            break;
                        case 9:
                            esc = true;
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                catch (ValueOutOfRangeExecption ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }

        private void clearScreen()
        {
            Console.Clear();
        }

        private void optionShowLicenseByStatus()
        {
            int  userInput = 0;
            bool tryparse = false;
            try
            {
                while ((!tryparse) || (userInput < 1) || (userInput > Enum.GetNames(typeof(Garage.eVehicleStatus)).Length))
                {
                    Console.WriteLine(@"
Choose Status For displaying list:
1. Paid
2. Repairing
3. Fixed
4. All");
                    tryparse = int.TryParse(Console.ReadLine(), out userInput);
                }

                Console.WriteLine("The List:");
                Console.WriteLine(m_Grage.ListOfVehiclesPlatesInGarageByStatus((Garage.eVehicleStatus)userInput));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void optionShowAllDetailsByPlate()
        {
            Console.WriteLine("Enter Plate");
            try
            {
                Console.WriteLine(m_Grage.PrintVehicleInfoByPlate(Console.ReadLine()));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string getSomeName(string i_MsgToUser)
        {
            string clientName = null;
            bool validName = false;
            while (!validName)
            {
                Console.WriteLine(i_MsgToUser);
                clientName = Console.ReadLine();
                validName = isEmptyName(clientName);
                if(!validName)
                {
                    Console.WriteLine("UnValid Input");
                }
            }

            return clientName;
        }

        private string getPhoneNumber()
        {
            bool validPhoneNumber = false;
            string phoneNumber = null;
            while (!validPhoneNumber)
            {
                Console.WriteLine("Enter your phone number:");
                phoneNumber = Console.ReadLine();
                validPhoneNumber = checkIfPhoneNumber(phoneNumber);
                if (!validPhoneNumber)
                {
                    Console.WriteLine("Invalid phone number");
                }
            }

            return phoneNumber;
        }

        private bool isEmptyName(string i_Name)
        {
            bool allSpaces = false;
            foreach (char ch in i_Name)
            {
                if (ch != ' ')
                {
                    allSpaces = true;
                    break;
                }
            }

            return allSpaces;
        }

        private void getVehicleParams(out string o_Plate, out string o_ClientName, out string o_PhoneNumber, out string o_VehicleModel, out eSupportedVehicels o_SupportedVehicle)
        {
            try
            {
                o_Plate = getSomeName("Enter License Plate:");
                m_Grage.VehicleExits(o_Plate);
                o_ClientName = getSomeName("Enter Owner Name:");
                o_PhoneNumber = getPhoneNumber();
                o_VehicleModel = getSomeName("Enter Vehicle Model Name");
                o_SupportedVehicle = chooseSupportedVehicle();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void optionAddVehicle()
        { 
            string phoneNumber = null;
            string plate = null;
            string clientName = null;
            string vehicleModel = null;
            eSupportedVehicels supportedVehicle;
            try
            {
                getVehicleParams(out plate, out clientName, out phoneNumber, out vehicleModel, out supportedVehicle);

                switch (supportedVehicle)
                {
                    case eSupportedVehicels.RegularMotorcycle:
                        {
                            addMotorcycle(clientName, phoneNumber, plate, vehicleModel, eEngineEnergyTypes.Octan96, SupportedParameters.k_MaxFuelMotorcycleTank, k_FuelAmountFormat);
                            break;
                        }

                    case eSupportedVehicels.ElectricMotorcycle:
                        {
                            addMotorcycle(clientName, phoneNumber, plate, vehicleModel, eEngineEnergyTypes.Electric, SupportedParameters.k_MaxElectricMotorcycleEnergy, k_ElecAmountFormat);
                            break;
                        }

                    case eSupportedVehicels.RegularCar:
                        {
                            addCar(clientName, phoneNumber, plate, vehicleModel, eEngineEnergyTypes.Octan98, SupportedParameters.k_MaxFuelCarTank, k_FuelAmountFormat);
                            break;
                        }

                    case eSupportedVehicels.ElectricCar:
                        {
                            addCar(clientName, phoneNumber, plate, vehicleModel, eEngineEnergyTypes.Electric, SupportedParameters.k_MaxElectricCarEnergy, k_ElecAmountFormat);
                            break;
                        }

                    case eSupportedVehicels.Truck:
                        {
                            addTruck(clientName, phoneNumber, plate, vehicleModel);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void printMenu()
        {
            Console.Write(
 @"  __  __                  
 |  \/  | ___ _ __  _   _ 
 | |\/| |/ _ \ '_ \| | | |
 | |  | |  __/ | | | |_| |
 |_|  |_|\___|_| |_|\__,_|
___________________________

1. Add a vehicle to garage.
2. Display plate license of vehicles in the garage their status.
3. Change a vehicle status.
4. Inflate wheels of a vehicle.
5. Add Fuel to vehicle.
6. Charge electric vehicle.
7. Display details of a vehicle by a plate number.
8. Clear Screen
9. Exit
");
        }

        private eSupportedVehicels chooseSupportedVehicle()
        {
            int  numberOfOptions = Enum.GetNames(typeof(eSupportedVehicels)).Length;
            int  userInput = -1;
            bool tryParse = false;
            try
            {
                while ((!tryParse) || (userInput > numberOfOptions) || (userInput < 1))
                {
                    Console.WriteLine("Choose a vehicle:");
                    foreach (eSupportedVehicels vechileType in Enum.GetValues(typeof(eSupportedVehicels)))
                    {
                        Console.WriteLine("{0}. {1}", (int)vechileType, ESupportedVehicelsToText.AsText(vechileType));
                    }

                    tryParse = int.TryParse(Console.ReadLine(), out userInput);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (eSupportedVehicels)userInput;
        }

        private HoldWheelParams getWheelParams(float i_MaxManufacturerPressure, uint i_NumOfWheels)
        {
            bool            tryParse = false;
            float           wheelPressureStatus = -1;
            HoldWheelParams wheelParams = null;
            try
            {
                string wheelManufacturerName = getSomeName("Enter wheel manufacturer name:");
                while (!tryParse || wheelPressureStatus < 0 || wheelPressureStatus > i_MaxManufacturerPressure)
                {
                    Console.WriteLine("Enter wheel pressure status, should be between [0, {0}]:", i_MaxManufacturerPressure);
                    tryParse = float.TryParse(Console.ReadLine(), out wheelPressureStatus);
                }

                wheelParams = new HoldWheelParams(wheelManufacturerName, i_MaxManufacturerPressure, i_NumOfWheels, wheelPressureStatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return wheelParams;
        }

        private HoldEngineParams getEngine(eEngineEnergyTypes i_EngineType, float i_MaxEnergy, string i_AmountFormat)
        {
            bool             tryParse = false;
            float            amountOfEnergy = -1;
            HoldEngineParams engine;
            try
            {
                while (!tryParse || amountOfEnergy < 0 || amountOfEnergy > i_MaxEnergy)
                {
                    Console.WriteLine("Enter Current Amount of {0}, should be between [0,{1}]", i_AmountFormat, i_MaxEnergy);
                    tryParse = float.TryParse(Console.ReadLine(), out amountOfEnergy);
                }

                engine = new HoldEngineParams(i_EngineType, i_MaxEnergy, amountOfEnergy);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return engine;
        }

        private void addMotorcycle(string i_Name, string i_Phone, string i_Plate, string i_VehicleModel, eEngineEnergyTypes i_EngineType, float i_MaxEnergy, string i_EnergyFormat)
        {
            HoldWheelParams                   wheels = getWheelParams(SupportedParameters.k_MaxMotorcycleWheelPressure, (uint)eNumOfWheels.TwoWheeledMotorcycle);
            HoldEngineParams                  engine = getEngine(i_EngineType, i_MaxEnergy, i_EnergyFormat);
            Motorcycle.eMotorcycleLicenceType license;
            int                               numberOfOptions = Enum.GetNames(typeof(Motorcycle.eMotorcycleLicenceType)).Length;
            int                               userInput = -1;
            bool                              tryParse = false;
            float                             engineVolume = 0;
            try
            {
                while ((!tryParse) || (userInput > numberOfOptions) || (userInput < 1))
                {
                    Console.WriteLine("Choose a License Type:");
                    foreach (Motorcycle.eMotorcycleLicenceType licenseType in Enum.GetValues(typeof(Motorcycle.eMotorcycleLicenceType)))
                    {
                        Console.WriteLine("{0}. {1}", (int)licenseType, licenseType.ToString());
                    }

                    tryParse = int.TryParse(Console.ReadLine(), out userInput);
                }

                license = (Motorcycle.eMotorcycleLicenceType)userInput;
                tryParse = false;

                while (!tryParse)
                {
                    Console.WriteLine("Enter Engine Volume");
                    tryParse = float.TryParse(Console.ReadLine(), out engineVolume);
                }

                HoldAddGarageVehicleParams garageParams = new HoldAddGarageVehicleParams(i_Name, i_Phone, i_VehicleModel, i_Plate, wheels, engine, Garage.eVehicleStatus.Repairing, eVehicleTypes.Motorcycle);
                m_Grage.AddVehicleToGarage(garageParams, (float)engineVolume, (float)license);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void addCar(string i_Name, string i_Phone, string i_Plate, string i_VehicleModel, eEngineEnergyTypes i_EngineType, float i_MaxEnergy, string i_EnergyFormat)
        {
            HoldWheelParams  wheels = getWheelParams(SupportedParameters.k_MaxCarWheelPressure, (uint)eNumOfWheels.FourWheeledCar);
            HoldEngineParams engine = getEngine(i_EngineType, i_MaxEnergy, i_EnergyFormat);
            Car.eColors      color;
            Car.eNumOfDoors  numOfDoors;
            int              numberOfOptions = Enum.GetNames(typeof(Car.eColors)).Length;
            int              userInput = -1;
            bool             tryParse = false;

            while ((!tryParse) || (userInput > numberOfOptions) || (userInput < 1))
            {
                Console.WriteLine("Choose a Color:");
                foreach (Car.eColors colorsType in Enum.GetValues(typeof(Car.eColors)))
                {
                    Console.WriteLine("{0}. {1}", (int)colorsType, colorsType.ToString());
                }

                tryParse = int.TryParse(Console.ReadLine(), out userInput);
            }

            color = (Car.eColors)userInput;
            numberOfOptions = Enum.GetNames(typeof(Car.eNumOfDoors)).Length;
            userInput = -1;
            tryParse = false;
            while ((!tryParse) || (userInput > numberOfOptions) || (userInput < 1))
            {
                Console.WriteLine("Choose Number of Doors:");
                foreach (Car.eNumOfDoors doorsType in Enum.GetValues(typeof(Car.eNumOfDoors)))
                {
                    Console.WriteLine("{0}. {1}", (int)doorsType, doorsType.ToString());
                }

                tryParse = int.TryParse(Console.ReadLine(), out userInput);
            }

            numOfDoors = (Car.eNumOfDoors)userInput;

            try
            {
                HoldAddGarageVehicleParams garageParams = new HoldAddGarageVehicleParams(i_Name, i_Phone, i_VehicleModel, i_Plate, wheels, engine, Garage.eVehicleStatus.Repairing, eVehicleTypes.Car);
                m_Grage.AddVehicleToGarage(garageParams, (float)color, (float)numOfDoors);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void addTruck(string i_Name, string i_Phone, string i_Plate, string i_VehicleModel)
        {
            HoldWheelParams  wheels = getWheelParams(SupportedParameters.k_MaxTruckWheelPressure, (uint)eNumOfWheels.TwelveWheeledTruck);
            HoldEngineParams engine = getEngine(eEngineEnergyTypes.Soler, SupportedParameters.k_MaxTruckFuelTank, k_FuelAmountFormat);
            float            isRegregerated = -1;
            bool             tryParse = false;
            float            trunkVolume = 0;

            while ((!tryParse) || (isRegregerated > 1) || (isRegregerated < 0))
            {
                Console.WriteLine(@"Is the Refrigerated?
Type '1' for Yes:
Type '0' or No");

                tryParse = float.TryParse(Console.ReadLine(), out isRegregerated);
            }

            tryParse = false;

            while ((!tryParse) || (trunkVolume < 0))
            {
                Console.WriteLine("Enter Trunk Volume in m^3");
                tryParse = float.TryParse(Console.ReadLine(), out trunkVolume);
            }

            try
            {
                HoldAddGarageVehicleParams garageParams = new HoldAddGarageVehicleParams(i_Name, i_Phone, i_VehicleModel, i_Plate, wheels, engine, Garage.eVehicleStatus.Repairing, eVehicleTypes.Truck);
                m_Grage.AddVehicleToGarage(garageParams, (float)isRegregerated, (float)trunkVolume);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void changeStatusOfCarInGarage() // 3
        {
            string  license = null;
            bool    tryParse = false;
            int     userInput = -1;
            int     numberOfOptions = Enum.GetNames(typeof(Garage.eVehicleStatus)).Length;

            Console.WriteLine("Enter a vehicle license:");
            license = Console.ReadLine();
            while ((!tryParse) || (userInput > numberOfOptions) || (userInput < 1))
            {
                Console.WriteLine("Choose a new status:");
                Console.WriteLine("1.{0}", Garage.eVehicleStatus.Paid.ToString());
                Console.WriteLine("2.{0}", Garage.eVehicleStatus.Repairing.ToString());
                Console.WriteLine("3.{0}", Garage.eVehicleStatus.Fixed.ToString());
                tryParse = int.TryParse(Console.ReadLine(), out userInput);
            }

            m_Grage.ChangeStatusOfListedCar(license, (Garage.eVehicleStatus)userInput);
            Console.WriteLine("Status had been updated to {0}", ((Garage.eVehicleStatus)userInput).ToString());
        }

        private void optionOnflateTireToMax() // 4
        {
            Console.WriteLine("Enter a vehicle license:");
            string license = Console.ReadLine();
            m_Grage.InflateTireInGarage(license);
            Console.WriteLine("Tires were successfully inflated");
        }

        private void optionFillFuelEnergy() // 5
        {
            string license;
            bool   tryParse = false;
            float  amountToAdd = 0;
            int    userEnergyType = -1;
            int    numberOfOptions = Enum.GetNames(typeof(eEngineEnergyTypes)).Length;

            Console.WriteLine("Enter a vehicle license:");
            license = Console.ReadLine();
            while ((!tryParse) || (userEnergyType > numberOfOptions - 1) || (userEnergyType < 1))
            {
                Console.WriteLine("Please enter vehicle fuel type:");
                Console.WriteLine("1.{0}", eEngineEnergyTypes.Octan95.ToString());
                Console.WriteLine("2.{0}", eEngineEnergyTypes.Octan96.ToString());
                Console.WriteLine("3.{0}", eEngineEnergyTypes.Octan98.ToString());
                Console.WriteLine("4.{0}", eEngineEnergyTypes.Soler.ToString());
                tryParse = int.TryParse(Console.ReadLine(), out userEnergyType);

                if ((!tryParse) || (userEnergyType > numberOfOptions - 1) || (userEnergyType < 1))
                {
                    Console.WriteLine(k_InvalidInput);
                }
            }

            tryParse = false;
            while (!tryParse)
            {
                Console.WriteLine("Enter fuel to add in Liters");
                tryParse = float.TryParse(Console.ReadLine(), out amountToAdd);
                if (!tryParse)
                {
                    Console.WriteLine(k_InvalidInput);
                }
            }

            try
            {
                m_Grage.FillEnergyInGarage(license, (eEngineEnergyTypes)userEnergyType, amountToAdd);
                Console.WriteLine(k_EnergyAddedSuccessfully);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void optionFillElictricEnergy() // 6
        {
            string license;
            bool   tryParse = false;
            float  amountToAdd = 0;

            Console.WriteLine("Enter a vehicle license:");
            license = Console.ReadLine();
            tryParse = false;
            while (!tryParse)
            {
                Console.WriteLine("Enter Energy to add in Minutes");
                tryParse = float.TryParse(Console.ReadLine(), out amountToAdd);
                if (!tryParse)
                {
                    Console.WriteLine(k_InvalidInput);
                }
            }

            try
            {
                m_Grage.FillEnergyInGarage(license, eEngineEnergyTypes.Electric, amountToAdd);
                Console.WriteLine(k_EnergyAddedSuccessfully);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool checkIfPhoneNumber(string i_phoneNumber)
        {
            bool result = true;
            for (int i = 0; i < i_phoneNumber.Length; i++)
            {
                if ((i_phoneNumber[i] < '0') || (i_phoneNumber[i] > '9'))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}
