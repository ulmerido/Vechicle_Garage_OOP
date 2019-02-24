using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_VehicleModel;
        protected readonly string r_LicensePlate;
        protected readonly Engine r_Engine;
        protected float           m_RemainingEnergyPercentage;
        protected List<Wheel>     m_VehicleWheels;

        protected Vehicle(HoldVehicleParams i_Vehicle)
        {
            r_Engine = i_Vehicle.Engine;
            m_RemainingEnergyPercentage = r_Engine.GetRemainingEnergyPercentage();
            r_VehicleModel = i_Vehicle.VehicleModel;
            r_LicensePlate = i_Vehicle.LicensePlate;
            m_VehicleWheels = i_Vehicle.Wheels;
        }

        public string LicensePlate
        {
            get
            {
                return r_LicensePlate;
            }
        }

        public float RemainingEnergyPercentage
        {
            get
            {
                m_RemainingEnergyPercentage = r_Engine.GetRemainingEnergyPercentage();
                return m_RemainingEnergyPercentage;
            }
        }

        public void FillEnergy(eEngineEnergyTypes i_EngineType, float i_AmountToAdd)
        {
            try
            {
                r_Engine.FillEnergy(i_EngineType, i_AmountToAdd);
                m_RemainingEnergyPercentage = r_Engine.GetRemainingEnergyPercentage();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Wheel> VehicleWheels
        {
            get
            {
                return m_VehicleWheels;
            }
        }

        public Engine GetEngine
        {
            get
            {
                return r_Engine;
            }
        }

        public void InflateWheelsPressure()
        {
            float amountToAdd = 0;
            foreach (Wheel wheel in m_VehicleWheels)
            {
                try
                {
                    amountToAdd = wheel.MaxManufacturerPressure - wheel.WheelPressureStatus;
                    wheel.AddAirPressureToWheel(amountToAdd);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder strBuild = new StringBuilder();
            strBuild.Append("License Plate:            ");
            strBuild.AppendLine(r_LicensePlate);
            strBuild.Append("Model:                    ");
            strBuild.AppendLine(r_VehicleModel);
            strBuild.AppendFormat("Energy Remaining:        {0}% {1}", m_RemainingEnergyPercentage, Environment.NewLine);
            strBuild.Append(m_VehicleWheels[0].ToString());
            strBuild.Append(r_Engine.ToString());
            return strBuild.ToString();
        }
    }
}  