using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace arcade
{
    public class EnemyHandler : GameObject
    {
        public int randomNumb = Utils.Random(1, 3); //turn from 1,3 to 1,4
    }
}
