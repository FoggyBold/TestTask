namespace TestTask.WEB.ViewModels;

using System.ComponentModel.DataAnnotations;

public class ActivityAreaModel
{
    [Required(ErrorMessage = "Не указано наименование")]
    public string Name { get; set; }
}