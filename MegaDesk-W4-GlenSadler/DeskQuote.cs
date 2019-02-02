using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_3_GlenSadler
{
    class DeskQuote
    {
        #region Object member variables
        /*private string CustomerName;
        private DateTime QuoteDate;
        private Desk Desk = new Desk();
        private int RushDays;*/
        private int QuoteAmount;
        #endregion

        #region local variables

        #endregion

        public const int PRICE_BASE = 200;
        private const int SIZE_THRESHOLD = 1000;
        private const int PRICE_PER_DRAWER = 50;
        private const int PRICE_PER_SURFACE_AREA = 1;
        private const int RUSH_7DAY = 7;
        private const int RUSH_5DAY = 5;
        private const int RUSH_3DAY = 3;
        private const int RUSH_14DAY = 0;
        private const int SIZE_MAX = 2000;

        public DateTime QuoteDate { get; set; }
        public string CustomerName { get; set; }
        public int RushDays { get; set; }
        public Desk Desk = new Desk();
        public int MaterialCost { get; set; }
        public int RushOrderCost { get; set; }
        /*public DeskQuote(string customerName, DateTime quoteDate, int width, int depth, int drawers, string material, int rushDays)
        {
            CustomerName = customerName;
            QuoteDate = quoteDate;
            RushDays = rushDays;
            Desk.Width = width;
            Desk.Depth = depth;
            Desk.NumberOfDrawers = drawers;
            Desk.DeskTopMaterial = material;
            Desk.SurfaceArea = Desk.Width * Desk.Depth;
        }*/

        public int CalculateQuoteTotal()
        {
            QuoteAmount = PRICE_BASE + SurfaceAreaCost() + DrawerCost() + DeskTopMaterialCost() +  RushDaysCost();
            return QuoteAmount;
        }

        public int SurfaceAreaCost()
        {
            if (Desk.SurfaceArea > SIZE_THRESHOLD)
            {
                return (Desk.SurfaceArea - SIZE_THRESHOLD) * PRICE_PER_SURFACE_AREA;
            } else
            {
                return 0;
            }
             
        }

        // calculate drawer cost
        public int DrawerCost()
        {
            int drawersCost = Desk.NumberOfDrawers * PRICE_PER_DRAWER;
            return drawersCost;
        }

        // calculate desktop material cost
        public int DeskTopMaterialCost()
        {
            switch (Desk.DeskTopMaterial)           {
                case DeskTopMaterial.Oak:
                    MaterialCost = 200;
                    break;
                case DeskTopMaterial.Laminate:
                    MaterialCost = 100;
                    break;
                case DeskTopMaterial.Pine:
                    MaterialCost = 50;
                    break;
                case DeskTopMaterial.Rosewood:
                    MaterialCost = 300;
                    break;
                case DeskTopMaterial.Veneer:
                    MaterialCost = 125;
                    break;
                default:
                    MaterialCost = 50;
                    break;
            }
            return MaterialCost;
        }

        // calculate the shipping costs
        public int RushDaysCost()
        {
            if (RushDays == RUSH_3DAY)
            {
                if (Desk.SurfaceArea < SIZE_THRESHOLD)
                {
                    RushOrderCost = 60;
                }
                else if (Desk.SurfaceArea <= SIZE_MAX)
                {
                    RushOrderCost = 70;
                }
                else
                {
                    RushOrderCost = 80;
                }
            }
            if (RushDays == RUSH_5DAY)
            {
                if (Desk.SurfaceArea < SIZE_THRESHOLD)
                {
                    RushOrderCost = 40;
                }
                else if (Desk.SurfaceArea <= SIZE_MAX)
                {
                    RushOrderCost = 50;
                }
                else
                {
                    RushOrderCost = 60;
                }
            }
            if (RushDays == RUSH_7DAY)
            {
                if (Desk.SurfaceArea < SIZE_THRESHOLD)
                {
                    RushOrderCost = 30;
                }
                else if (Desk.SurfaceArea <= SIZE_MAX)
                {
                    RushOrderCost = 35;
                }
                else
                {
                    RushOrderCost = 40;
                }
            }

            if (RushDays == RUSH_14DAY)
            {
                RushOrderCost = 0;
            }

            return RushOrderCost;
        }

    }
}
