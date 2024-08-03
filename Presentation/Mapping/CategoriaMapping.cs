using Model.DataModel;
using Model.DataModel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Mapping;

public static class CategoriaMapping
{
    public static CategoriaDto ToCategoriaDto(this Categoria categoria)
    {
        return new CategoriaDto(categoria.Icon, categoria.Color);
    }
}
