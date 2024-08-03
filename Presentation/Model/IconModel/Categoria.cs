using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.IconModel;

public class Categoria1
{
    public Categoria1(string name, string icon, string color = "Transparent")
    {
        Name = name;
        Icon = icon;
        Color = color;
    }

    public string Name { get; set; }
    public string Icon { get; set; }
    public string Color { get; set; }
}
