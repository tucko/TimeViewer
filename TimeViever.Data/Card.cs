//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimeViever.Data.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Card
    {
        public Card()
        {
            this.PersonCards = new HashSet<PersonCard>();
        }
    
        public int ID { get; set; }
        public string CardNumber { get; set; }
        public int Pin { get; set; }
    
        public virtual ICollection<PersonCard> PersonCards { get; set; }
    }
}
