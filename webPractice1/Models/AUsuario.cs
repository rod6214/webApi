//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webPractice1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AUsuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AUsuario()
        {
            this.APersona = new HashSet<APersona>();
        }
    
        public int id { get; set; }
        public string usuario { get; set; }
        public string pass { get; set; }
        public string urole { get; set; }
        public Nullable<bool> isonline { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APersona> APersona { get; set; }
    }
}
