namespace SPR521_t2.BLL.Dtos.SushiSet;

public class SushiSetResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Weight { get; set; }
    public int SushiTypeId { get; set; }
}