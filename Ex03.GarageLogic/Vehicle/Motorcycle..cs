using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private const string                    k_ErrNumberOfWheels = "Error: Motorcycle can have only 2 wheels";
        private readonly uint                   r_EngineVolume;  // in cubic centimeter
        private readonly eMotorcycleLicenceType m_MotorcycleLicenceType;

        public enum eMotorcycleLicenceType
        {
            A = 1,
            A1,
            B1,
            B2,
        }

        public Motorcycle(uint i_EngineVolume, HoldVehicleParams i_MyVehicle, eMotorcycleLicenceType i_Licence) : base(i_MyVehicle)
        {
            r_EngineVolume = i_EngineVolume;
            m_MotorcycleLicenceType = i_Licence;

            if (i_MyVehicle.Wheels.Count > (int)eNumOfWheels.TwoWheeledMotorcycle)
            {
                throw new ArgumentException(k_ErrNumberOfWheels);
            }
        }

        public override string ToString()
        {
            StringBuilder strBuild = new StringBuilder();
            strBuild.AppendLine(base.ToString());
            strBuild.AppendFormat("Motorcycle Properties:{0}{1}", Environment.NewLine, Environment.NewLine);
            strBuild.AppendFormat("License Type:           {0} {1}", m_MotorcycleLicenceType.ToString(), Environment.NewLine);           
            strBuild.AppendFormat("Engine Volume:          {0} cc{1}", r_EngineVolume, Environment.NewLine);
            return strBuild.ToString();
        }
    }
}
