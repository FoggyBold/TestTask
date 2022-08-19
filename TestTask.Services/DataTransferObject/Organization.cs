namespace TestTask.Services.DataTransferObject;

public class Organization
{
    public int ID { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public string DirectorsFullName { get; set; }
    public double AuthorizedCapital { get; set; }
    public string INN { get; set; }
    public string KPP { get; set; }
    public string OGRN { get; set; }
    public int ActivityAreaId { get; set; }
}