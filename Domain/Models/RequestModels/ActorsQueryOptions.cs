
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.RequestModels;

public class ActorsQueryOptions
{
    [StringLength(50)]
    public string? Name { get; set; }
    [Range(0, 1000)]
    public int? MinRank { get; set; }
    [Range(1, 1000)]

    public int? MaxRank { get; set; }
    [Range(1, 100)]
    public int Take { get; set; } = 10;
    public int Skip { get; set; } = 0;
    [StringLength(20)]
    public string? Provider { get; set; }
}