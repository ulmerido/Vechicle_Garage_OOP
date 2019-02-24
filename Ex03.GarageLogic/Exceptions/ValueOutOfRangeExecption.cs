using System;

namespace Ex03.GarageLogic
{
   public class ValueOutOfRangeExecption : Exception
    {
        private const string   k_MsgError = "Error: Value should be in range of [{0},{1}]";
        private readonly float r_MaxVal;
        private readonly float r_MinVal;
 
        public ValueOutOfRangeExecption(float i_MinVal, float i_MaxVal) : base(string.Format(k_MsgError, i_MinVal, i_MaxVal))
        {
            r_MaxVal = i_MaxVal;
            r_MinVal = i_MinVal;
        }
    }
}
