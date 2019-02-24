using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        private readonly Vehicle      r_Vehicle;
        private readonly string       r_OwnerName;
        private readonly string       r_OwnerCellNumber;
        private Garage.eVehicleStatus m_VehicleStatus;

        public VehicleInGarage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerCellNumber)
        {
            r_Vehicle = i_Vehicle;
            r_OwnerName = i_OwnerName;
            r_OwnerCellNumber = i_OwnerCellNumber;
            m_VehicleStatus = Garage.eVehicleStatus.Repairing;
        }
       
        public Vehicle MyVehicle
        {
            get
            {
                return r_Vehicle;
            }
        }

        public Garage.eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        public override string ToString()
        {
            StringBuilder strBuild = new StringBuilder();           
            strBuild.AppendFormat("Properties:{0}{1}", Environment.NewLine, Environment.NewLine);
            strBuild.Append("Owner Name:               ");
            strBuild.AppendLine(r_OwnerName);
            strBuild.Append("Vehicle Status:           ");
            strBuild.AppendLine(m_VehicleStatus.ToString());     
            strBuild.AppendLine(r_Vehicle.ToString());           
            return strBuild.ToString();
        }
    }
}
