using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObanStarRacersDoubleTwo_Prototype
{
    interface ITypeOfRace
    {
        void RainMap(object object1);
        void SunMap(object object1);
        void NightMap(object object1);
        void DangerMap(object object1);
    }
}
