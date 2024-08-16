using Model.DataModel;
using System.Collections.ObjectModel;

namespace Model.IconModel;

public class IconModel
{
    public ObservableCollection<Categoria> IconCosts { get; set; } = new ObservableCollection<Categoria>
    {
        new Categoria("Продукты",  "shop.svg",       "#BFC094"),
        new Categoria("ЖКХ",       "jkh.svg",        "#AC94C0"),
        new Categoria("Одежда",    "close.svg",      "#949CC0"),
        new Categoria("Услуги",    "services.svg",   "#C09494"),
        new Categoria("Рестораны", "rest.svg",       "#94C0BE"),
        new Categoria("Здоровье",  "health.svg",     "#C094C0"),
        new Categoria("Транспорт", "car.svg",        "#A6C094"),
        new Categoria("Прочее",    "other.svg",      "#94B2C0"),
    };

    public ObservableCollection<Categoria> IconProfit { get; set; } = new ObservableCollection<Categoria>
    {
        new Categoria("Зарплата",  "salary.svg",    "#BFC094"),
        new Categoria("Инвестиции","invest.svg",    "#AC94C0"),
        new Categoria("Подарок",   "gift.svg",      "#949CC0"),
        new Categoria("Прочее",    "other.svg",     "#94B2C0"),
    };
}
