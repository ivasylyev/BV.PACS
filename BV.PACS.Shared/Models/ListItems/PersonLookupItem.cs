using System.ComponentModel.DataAnnotations.Schema;

namespace BV.PACS.Shared.Models
{
    public class PersonLookupItem
    {
        [Column("idfEmployee")]
        public string Id { get; set; }

        [Column("FullName")]
        public string FullName { get; set; }

        [Column("Organization")]
        public string Organization { get; set; }

        [Column("Position")]
        public int Position { get; set; }

        [Column("strFirstName")]
        public int FirstName { get; set; }

        [Column("strFamilyName")]
        public int FamilyName { get; set; }

        [Column("strSecondName")]
        public int SecondName { get; set; }


        public override string ToString()
        {
            return $"{FullName} ({Id})";
        }
    }
}