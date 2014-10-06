using System.Linq;

namespace LightstoneApp.Domain.MainModule.Entities
{
    /// <summary>
    ///     Orde domain entity
    /// </summary>
    public partial class Order
    {
        /// <summary>
        ///     Get number of items in this order
        ///     For each OrderDetail  sum amount of items
        /// </summary>
        /// <returns>Number of items</returns>
        public int GetNumberOfItems()
        {
            int? numberOfItems = 0;

            if (OrderDetails != null)
                numberOfItems = OrderDetails.Sum(detail => detail.Amount);


            return numberOfItems ?? 0;
        }
    }
}