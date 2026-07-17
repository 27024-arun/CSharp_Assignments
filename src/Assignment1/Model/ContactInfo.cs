namespace Assignment1.Model
{
    /// <summary>
    /// ContactInfo class is used to store the contact information such as name,phone, email and notes
    /// </summary>
    public class ContactInfo
    {
        /// <summary>
        /// Gets or sets guid for the contact which is unique for each user
        /// </summary>
        /// <value>The Guid of the contact for identification of each user</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user
        /// </summary>
        /// <value>The name of the user</value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the phone of the user
        /// </summary>
        /// <value>The phone number is stored here</value>
        public string? Phone { get; set; }

        /// <summary>
        /// Gets or sets the email of the user
        /// </summary>
        /// <value>The email is stored here</value>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets notes for Contact
        /// </summary>
        /// <value>The ntoes is stored here</value>
        public string? Notes { get; set; }
    }
}
