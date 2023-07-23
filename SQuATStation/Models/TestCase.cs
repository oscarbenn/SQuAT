using System.ComponentModel.DataAnnotations;
namespace SQuATStation;
public class TestCase
{
    public int Id {get; set;}
    public string? Title {get; set;}
    public int TestSuiteId {get; set;}
    public int TestProjectId {get; set;}
    [DataType(DataType.Date)]
    public DateTime CreatedDate {get; set;}
}