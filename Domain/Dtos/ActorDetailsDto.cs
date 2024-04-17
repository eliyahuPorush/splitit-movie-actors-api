using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class ActorDetailsDto
{
    public Guid Id { get; set;}
    [Required]
    [StringLength(50)]
    public string Name { get; set;}
    [Required]
    [Range(0, 1000)]
    public int Rank { get; set;}
    [StringLength(100)]
    [Required]
    public string Type { get; set;}
    [StringLength(200)]
    public string Movie { get; set;}
    [StringLength(30)]
    [Required]
    public string Source { get; set;}
}