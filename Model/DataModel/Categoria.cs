namespace Model.DataModel;

public class Categoria
{
    public Categoria(string name, string icon, string color = "Transparent")
    {
        Name = name;
        Icon = icon;
        Color = color;
    }

    public string Name { get; set; }
    public string Icon { get; set; }
    public string Color { get; set; }
}
