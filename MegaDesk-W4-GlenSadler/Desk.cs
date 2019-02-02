using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_3_GlenSadler
{
    class Desk
    {
        public int Width { get; set; }
        public int Depth { get; set; }
        public int NumberOfDrawers { get; set; }
        public int SurfaceArea { get { return Width * Depth; } }
        public DeskTopMaterial DeskTopMaterial { get; set; }
        


        // Desk contraints
        public const int MINWIDTH = 24;
        public const int MAXWIDTH = 96;
        public const int MINDEPTH = 12;
        public const int MAXDEPTH = 48;
        public const int MINDRAWERS = 0;
        public const int MAXDRAWERS = 7;
    }

    public enum DeskTopMaterial
    {
        Oak = 200,
        Laminate = 100,
        Pine = 50,
        Rosewood =  300,
        Veneer = 125
    }
}
