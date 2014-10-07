namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.Validator
{
    /// <summary>
    ///   Data Annotations based entity validator factory
    /// </summary>
    public class DataAnnotationsEntityValidatorFactory : IEntityValidatorFactory
    {
        #region IEntityValidatorFactory Members

        /// <summary>
        ///   Create a entity validator
        /// </summary>
        /// <returns> </returns>
        public IEntityValidator Create()
        {
            return new DataAnnotationsEntityValidator();
        }

        #endregion
    }
}