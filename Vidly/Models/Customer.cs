using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSubscribedToNewsletter { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public MembershipType MembershipType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}