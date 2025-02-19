using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientMangementApi.PensionManagement.Domain
{
    public class BaseEntity
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set;}
        public bool IsDeleted { get; set; } = false;
    }
}