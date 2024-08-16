using Model.Enum;

namespace Model.DataModel;

public record Element(Mode? Mode, Categoria? Categoria)
{
    public Element(decimal sum, Mode mode, Categoria categoria) : this(mode, categoria)
    {
        Sum = sum;
    }

    public Element() : this(null, null) { }

    public decimal Sum { get; set; } = 0;
}
