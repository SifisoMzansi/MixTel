using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixAssessment2
{
    public class Result : IComparable
    {
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Result OtherResult = obj as Result;
            if (OtherResult != null)
                return this._distance.CompareTo(OtherResult._distance);
            else
                throw new ArgumentException("cannot recognize object");
        }

        protected double _distance;

        public double Distance
        {
            get
            {
                return this._distance;
            }
            set
            {
                this._distance = value;
            }
        }
        public ICoordinate ClosestCoordinates { set; get; }
    }
}
