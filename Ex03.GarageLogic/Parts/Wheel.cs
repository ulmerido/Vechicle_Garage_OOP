using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private const string    k_ErrAddingNegativeMsg = "Reducing air pressure is not allowed";
        private const string    k_CtrErrorMsg = "Current pressure should be positive and lower or equal to max pressure ";
        private readonly string r_ManufacturerName;
        private readonly float  r_MaxManufacturerPressure;
        private float           m_WheelPressureStatus;

        public Wheel(string i_WheelManufacturerName, float i_MaxManufacturerPressure, float i_WheelPressureStatus)
        {
            r_ManufacturerName = i_WheelManufacturerName;
            r_MaxManufacturerPressure = i_MaxManufacturerPressure;
            m_WheelPressureStatus = i_WheelPressureStatus;
            if ((m_WheelPressureStatus > r_MaxManufacturerPressure) || (r_MaxManufacturerPressure <= 0) || (m_WheelPressureStatus < 0))
            {
                throw new ArgumentException(k_CtrErrorMsg);
            }
        }

        public void AddAirPressureToWheel(float i_AirPressureToAdd)
        {
            float sumAirPressure = i_AirPressureToAdd + m_WheelPressureStatus;
            if (i_AirPressureToAdd < 0)
            {
                throw new ArgumentException(k_ErrAddingNegativeMsg);
            }

            if (sumAirPressure <= r_MaxManufacturerPressure)
            {
                m_WheelPressureStatus = sumAirPressure;
            }
            else
            {
                throw new ValueOutOfRangeExecption(0, r_MaxManufacturerPressure - m_WheelPressureStatus);
            }
        }

        public string WheelManufacturerName
        {
            get
            {
                return r_ManufacturerName;
            }
        }

        public float MaxManufacturerPressure
        {
            get
            {
                return r_MaxManufacturerPressure;
            }
        }

        public float WheelPressureStatus
        {
            get
            {
                return m_WheelPressureStatus;
            }
        }

        public override string ToString()
        {
            StringBuilder strBuild = new StringBuilder();
            strBuild.AppendFormat("{0}Wheels Properties:      {1}{2}", Environment.NewLine, Environment.NewLine, Environment.NewLine);
            strBuild.Append("Wheel Pressure:           ");
            strBuild.AppendLine(m_WheelPressureStatus.ToString());
            strBuild.Append("Recommended Max Pressure: ");
            strBuild.AppendLine(r_MaxManufacturerPressure.ToString());
            strBuild.Append("Manufacturer Name:        ");
            strBuild.AppendLine(r_ManufacturerName);
            return strBuild.ToString();
        }
    }
}