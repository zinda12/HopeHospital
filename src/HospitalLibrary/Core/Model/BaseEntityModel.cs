using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.Core.Model
{
    public class BaseEntityModel
    {
        [Key]
        public virtual int Id { get; set; }
    }
}
