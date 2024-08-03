using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.DTO;

public class CategoriaDto1
{
    public CategoriaDto1(string name, string icon, string color = "Transparent")
    {
        Icon = icon;
        Color = color;
    }

    public string Icon { get; set; }
    public string Color { get; set; }
}
