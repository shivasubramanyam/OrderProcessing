namespace OrderProcessing.Business.Constants
{
    /// <summary>
    /// Defines services for which payments can be made
    /// </summary>
    public enum PaymentServiceFor
    {
        /// <summary>
        /// Payment for physical product
        /// </summary>
        PhysicalProduct,

        /// <summary>
        /// Payment for book
        /// </summary>
        Book,

        /// <summary>
        /// Payment for membership
        /// </summary>
        Membership,

        /// <summary>
        /// Payment for membership upgrade
        /// </summary>
        UpgradeMembership,

        /// <summary>
        /// Payment for learning ski
        /// </summary>
        LearningSki,
    }
}
