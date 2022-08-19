namespace TestTask.WEB.ViewModels;

using System.ComponentModel.DataAnnotations;

public class OrganizationModel
{
    [Required(ErrorMessage = "Не указано полное наименование")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Не указано краткое наименование")]
    public string ShortName { get; set; }

    [Required(ErrorMessage = "Не указано фио директора")]
    public string DirectorsFullName { get; set; }

    [Required(ErrorMessage = "Не указан уставной капитал")]
    public double AuthorizedCapital { get; set; }

    [Required(ErrorMessage = "Не указан ИНН")]
    public string INN { get; set; }

    [Required(ErrorMessage = "Не указан КПП")]
    public string KPP { get; set; }

    [Required(ErrorMessage = "Не указан ОГРН")]
    public string OGRN { get; set; }

    [Required(ErrorMessage = "Не указана сфера деятельности")]
    public string ActivityArea { get; set; }
}