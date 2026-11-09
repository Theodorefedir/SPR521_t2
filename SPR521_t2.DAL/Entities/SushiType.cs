namespace SPR521_t2.DAL.Entities;

public class SushiType
{
    public int Id { set; get; }
    public string Name { set; get; }
    public ICollection<SushiSet> SushiSets { set; get; }
}
