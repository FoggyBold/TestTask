namespace TestTask.Data.Entities;

public class ActivityArea
{
    public int ID { get; set; }
    public string Name { get; set; }

    public List<Organization> Organizations { get; set; }
}