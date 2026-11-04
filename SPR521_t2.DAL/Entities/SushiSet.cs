namespace SPR521_t2.DAL.Entities;

public class SushiSet
{
    public int Id { set; get; }
    public string Name { set; get; }
    public decimal Price { set; get; }
    public string Description { set; get; }
    public int Weight { set; get; }
    public int Order { set; get; }
    public int SushiTypeId { set; get; }
    public SushiType SushiType { set; get; }
}
