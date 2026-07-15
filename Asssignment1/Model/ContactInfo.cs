using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Model
{
    /// <summary>
    /// Contact Information Class is created
    /// </summary>
    public class ContactInfo
    {
        /// <summary>
        /// Gets or Sets Guid for contact
        /// </summary>
        /// <value>The Guid of the contact</value>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets name for contact
        /// </summary>
        /// <value>The Guid of the contact</value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets Phone for Contact
        /// </summary>
        /// <value>The Guid of the contact</value>
        public string? Phone { get; set; }

        /// <summary>
        /// Gets or sets Email for Contact
        /// </summary>
        /// <value>The Guid of the contact</value>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets notes for Contact
        /// </summary>
        /// <value>The Guid of the contact</value>
        public string? Notes { get; set; }
    }
}
