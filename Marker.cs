using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gokart_vanal
{
    class Marker
    {
        string name;
        public int frameA { get; private set; }
        public int frameB { get; private set; }

        public Marker(string name, int frameA, int frameB)
        {
            this.name = name;
            this.frameA = frameA;
            this.frameB = frameB;
        }

        public string Display
        {
            get
            {
                return $"{this.name} ({this.frameA}/{this.frameB})";
            }
        }

    }
}
