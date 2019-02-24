using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const string         k_ErrNumOfWheels = "Error: Car only can have 4 four wheels";
        private readonly eColors     r_CarColor;
        private readonly eNumOfDoors r_CarNumOfDoors;

        public enum eColors
        {
            Gray = 1,
            Blue,
            White,
            Black,
        }

        public enum eNumOfDoors
        {
            Two = 1,
            Three,
            Four,
            Five,
        }

        public Car(eColors i_CarColor, eNumOfDoors i_NumOfDoors, HoldVehicleParams i_MyVehicle) : base(i_MyVehicle)
        {
            r_CarColor = i_CarColor;
            r_CarNumOfDoors = i_NumOfDoors;
            if (i_MyVehicle.Wheels.Count > (int) eNumOfWheels.FourWheeledCar)
            {
                throw new ArgumentException(k_ErrNumOfWheels);
            }
        }

        public override string ToString()
        {
            StringBuilder strBuild = new StringBuilder();
            strBuild.AppendLine(base.ToString());
            strBuild.AppendFormat("Car Properties:{0}{1}", Environment.NewLine, Environment.NewLine);
            strBuild.AppendFormat("Car Color:                {0} {1}", r_CarColor.ToString(), Environment.NewLine);
            strBuild.AppendFormat("Number of doors:          {0} {1}", r_CarNumOfDoors, Environment.NewLine);
            return strBuild.ToString(); 
        }
    }
}
