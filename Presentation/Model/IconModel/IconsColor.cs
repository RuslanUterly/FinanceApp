﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.IconModel;

public class IconsColor1
{
    public IconsColor1()
    {
        Color = GetColors();
    }

    public Dictionary<string, string> Color { get; private set; }

    private Dictionary<string, string> GetColors()
    {
        return new Dictionary<string, string>()
            {
                { "#BFC094", "#999A77" },
                { "#AC94C0", "#80779A" },
                { "#949CC0", "#77839A" },
                { "#C09494", "#9A7787" },
                { "#94C0BE", "#779A99" },
                { "#C094C0", "#9A7798" },
                { "#94B2C0", "#778F9A" },

                { "#999A77", "#BFC094" },
                { "#80779A", "#AC94C0" },
                { "#77839A", "#949CC0" },
                { "#9A7787", "#C09494" },
                { "#779A99", "#94C0BE" },
                { "#9A7798", "#C094C0" },
                { "#778F9A", "#94B2C0" },
            };
    }
}