using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Core.Model;
[PrimaryKey("Id")]
public class Event
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MinLength(5)]
    [MaxLength(50)]
    public string Title { get; set; }
    [Required]
    [MinLength(20)]
    [MaxLength(150)]
    public string Description { get; set; }
    [Required]
    public DateTime Date{get;set;}
    [Required]
    [MinLength(5)]
    [MaxLength(50)]
    public string Location { get; set; }
    public Speaker Speaker { get; set; }
}