namespace LightstoneApp.Domain.MainModule.Entities
{
    /// <summary>
    ///     A Product Entity in domain main module
    /// </summary>
    public partial class Product
    {
        /// <summary>
        ///     Check if this product exist in stock
        /// </summary>
        /// <returns>True if exist stock of this product</returns>
        public virtual bool ExistStock()
        {
            return AmountInStock > 0;
        }
    }
}