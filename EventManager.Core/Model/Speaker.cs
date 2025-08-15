using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Core.Model;
[PrimaryKey("Id")]
public class Speaker
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    [MinLength(5)]
    public string Name { get; set; }
    [Required]
    [MaxLength(150)]
    [MinLength(20)]
    public string Biography { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}