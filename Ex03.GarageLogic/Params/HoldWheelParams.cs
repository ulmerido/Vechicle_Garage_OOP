using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class HoldWheelParams
    {
        private string m_WheelManufacturerName;
        private float  m_MaxManufacturerPressure;
        private float  m_WheelPressureStatus;
        private uint   m_AmountOfWheels;

        public HoldWheelParams(string i_WheelManufacturerName, float i_MaxManufacturerPressure, uint i_AmountOfWheels, float i_WheelPressureStatus = 0)
        {
            m_WheelManufacturerName = i_WheelManufacturerName;
            m_MaxManufacturerPressure = i_MaxManufacturerPressure;
            m_WheelPressureStatus = i_WheelPressureStatus;
            m_AmountOfWheels = i_AmountOfWheels;
        }

        public string WheelManufacturerName
        {
            get
            {
                return m_WheelManufacturerName;
            }
        }

        public float MaxManufacturerPressure
        {
            get
            {
                return m_MaxManufacturerPressure;
            }
        }

        public float WheelPressureStatus
        {
            get
            {
                return m_WheelPressureStatus;
            }
        }

        public uint AmountOfWheels
        {
            get
            {
                return m_AmountOfWheels;
            }
        }
    }
}
