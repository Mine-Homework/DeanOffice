//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DeanOffice1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Grades
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public double Rate { get; set; }
    
        public virtual Subjects Subjects { get; set; }
        public virtual Students Students { get; set; }
    }
}
