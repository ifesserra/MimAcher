//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MimAcher.Dominio
{
    using System;
    using System.Collections.Generic;
    
    public partial class MA_USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MA_USUARIO()
        {
            this.MA_NAC = new HashSet<MA_NAC>();
            this.MA_PARTICIPANTE = new HashSet<MA_PARTICIPANTE>();
        }
    
        public int cod_usuario { get; set; }
        public string e_mail { get; set; }
        public string senha { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MA_NAC> MA_NAC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MA_PARTICIPANTE> MA_PARTICIPANTE { get; set; }
    }
}
