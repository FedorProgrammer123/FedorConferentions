//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrganisationConferention
{
    using System;
    using System.Collections.Generic;
    
    public partial class Participants
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Participants()
        {
            this.ShortInformation = new HashSet<ShortInformation>();
        }
    
        public int ID_Participant { get; set; }
        public string FIO { get; set; }
        public Nullable<int> Gender { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DateBirthday { get; set; }
        public Nullable<int> Country { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
    
        public virtual Countries Countries { get; set; }
        public virtual Gendre Gendre { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShortInformation> ShortInformation { get; set; }
    }
}
