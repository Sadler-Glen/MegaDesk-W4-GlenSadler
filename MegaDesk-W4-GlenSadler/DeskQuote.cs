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

        private const int PRICE_BASE = 200;
        private const int SIZE_THRESHOLD = 1000;
        private const int PRICE_PER_DRAWER = 50;
        private const int PRICE_PER_SURFACE_AREA = 1;

        public DateTime QuoteDate { get; set; }
        public string CustomerName { get; set; }
        public int RushDays { get; set; }
        public Desk newDesk = new Desk();

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
            QuoteAmount = PRICE_BASE + SurfaceAreaCost() + DrawerCost() + DeskTopMaterialCost() + RushDaysCost();
            return QuoteAmount;
        }

        public int SurfaceAreaCost()
        {
            if (newDesk.SurfaceArea > SIZE_THRESHOLD)
            {
                return (newDesk.SurfaceArea - SIZE_THRESHOLD) * PRICE_PER_SURFACE_AREA;
            }
            return (SIZE_THRESHOLD - newDesk.SurfaceArea); 
        }

        public int DrawerCost()
        {
            return newDesk.NumberOfDrawers * PRICE_PER_DRAWER;
        }

        // Temporary return of 100
        // Code yet to be written
        public int DeskTopMaterialCost()
        {
            return 100;
        }

        // Temporary return of 100
        // Code yet to be written
        public int RushDaysCost()
        {
            RushDays = 100;

            return RushDays;
        }
    }


}
