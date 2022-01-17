using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string FullName { get=> $"{firstName} {lastName}"; }
        public bool IsActive { get; set; } = true;
    }
}