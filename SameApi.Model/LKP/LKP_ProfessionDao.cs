using SameApi.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SameApi.Model.LKP
{
    [Table("LKP_SameApi_Profession")]
    public class LKP_ProfessionDao : IModelDao
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<LKP_SchoolDao> Schools { get; set; }
    }
}
