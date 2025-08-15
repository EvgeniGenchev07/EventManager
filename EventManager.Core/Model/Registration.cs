using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Core.Model;
[PrimaryKey("Id")]
public class Registration
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public DateTime RegistrationDate { get; set; }
    [Required]
    public Event Event { get; set; }
    [Required]
    public User User { get; set; }
}