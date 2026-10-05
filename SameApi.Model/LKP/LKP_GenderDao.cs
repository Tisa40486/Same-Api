using SameApi.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SameApi.Model.LKP
{
    [Table("LKP_SameApi_Gender")]
    public class LKP_GenderDao : IModelDao
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
