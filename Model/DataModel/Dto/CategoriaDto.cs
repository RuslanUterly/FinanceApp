using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModel.Dto;

public class CategoriaDto
{
    public CategoriaDto(string icon, string color = "Transparent")
    {
        Icon = icon;
        Color = color;
    }

    public string Icon { get; set; }
    public string Color { get; set; }
}
