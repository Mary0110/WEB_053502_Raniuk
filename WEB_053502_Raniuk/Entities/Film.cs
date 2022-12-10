namespace WEB_053502_Raniuk.Entities;

public class Film
{

    public int Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }
    public string Category { get; set; }
    public int CategoryId { get; set; }
    public double Duration { get; set; }
    public string Image { get; set; }

}