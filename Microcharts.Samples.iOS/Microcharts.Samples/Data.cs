namespace Microcharts.Samples
{
        using SkiaSharp;
        using System.Linq;

        public static class Data
        {
                #region Colors

                public static readonly SKColor TextColor = SKColors.Gray;

                public static readonly SKColor[] Colors =
                {
                        SKColor.Parse("#266489"),
                        SKColor.Parse("#68B9C0"),
                        SKColor.Parse("#90D585"),
                        SKColor.Parse("#F3C151"),
                        SKColor.Parse("#F37F64"),
                        SKColor.Parse("#424856"),
                        SKColor.Parse("#8F97A4"),
                        SKColor.Parse("#DAC096"),
                        SKColor.Parse("#76846E"),
                        SKColor.Parse("#DABFAF"),
                        SKColor.Parse("#A65B69"),
                        SKColor.Parse("#97A69D"),
                };

                private static int ColorIndex = 0;

                public static SKColor NextColor()
                {
                        var result = Colors[ColorIndex];
                        ColorIndex = (ColorIndex + 1) % Colors.Length;
                        return result;
                }

                #endregion

                public static (string label, int value)[] PositiveData =
                {
                        ("January",         400),
                        ("February",    600),
                        ("March",       900),
                        ("April",       100),
                        ("May",         200),
                        ("June",        500),
                        ("July",        300),
                        ("August",      200),
                        ("September",   200),
                        ("October",     800),
                        ("November",    950),
                        ("December",    700),

                };

                public static (string label, int value)[] MixedData =
                {
                        ("January",         -400),
                        ("February",    600),
                        ("March",       900),
                        ("April",       100),
                        ("May",         -200),
                        ("June",        500),
                        ("July",        300),
                        ("August",      -200),
                        ("September",   200),
                        ("October",     800),
                        ("November",    950),
                        ("December",    -700),

                };

                public static (string label, int value)[] NegativeData =
                {
                        ("January",     -400),
                        ("February",    -600),
                        ("March",       -900),
                        ("April",       -100),
                        ("May",         -200),
                        ("June",        -500),
                        ("July",        -300),
                        ("August",      -200),
                        ("September",   -200),
                        ("October",     -800),
                        ("November",    -950),
                        ("December",    -700),

                };

                public static Chart[] CreateXamarinSample()
                {
                    var entries = new[]
                    {
                         new Entry(212)
                        {
                            Label = "UWP",
                            ValueLabel = "212",
                            Color = SKColor.Parse("#2c3e50")
                        },
                        new Entry(248)
                        {
                            Label = "Android",
                            ValueLabel = "248",
                            Color = SKColor.Parse("#77d065")
                        },
                        new Entry(128)
                        {
                            Label = "iOS",
                            ValueLabel = "128",
                            Color = SKColor.Parse("#b455b6")
                        },
                        new Entry(514)
                        {
                            Label = "Shared",
                            ValueLabel = "514",
                            Color = SKColor.Parse("#3498db")
                        }
                    };

                    return new Chart[]
                    {
                        new BarChart() { Entries = entries },
                        new PointChart() { Entries = entries },
                        new LineChart() 
                        { 
                            Entries = entries,
                            LineMode = LineMode.Straight,
                            LineSize = 8,
                            PointMode = PointMode.Square,
                            PointSize = 18,
                        },
                        new DonutChart() { Entries = entries },
                        new RadialGaugeChart() { Entries = entries },
                        new RadarChart() { Entries = entries },
                    };
                }

                public static Chart[] CreateQuickstart()
                {
                        var entries = new[]
                        {
                                new Entry(200)
                                {
                                        Label = "شنبه",
                                        ValueLabel = "200",
                                        Color = SKColor.Parse("#266489"),
                                },
                                new Entry(405430)
                                {
                                        Label = "یکشنبه",
                                        ValueLabel = "405430",
                                        Color = SKColor.Parse("#68B9C0"),
                                },
                                new Entry(132400)
                                {
                                        Label = "دوشبنه",
                                        ValueLabel = "132400",
                                        Color = SKColor.Parse("#90D585"),
                                },
                                 new Entry(234200)
                                {
                                        Label = "سهشنبه",
                                        ValueLabel = "234200",
                                        Color = SKColor.Parse("#266489"),
                                },
                                new Entry(43400)
                                {
                                        Label = "چهارشنبه",
                                        ValueLabel = "43400",
                                        Color = SKColor.Parse("#68B9C0"),
                                },
                                new Entry(10000)
                                {
                                        Label = "پنجشنبه",
                                        ValueLabel = "10000",
                                        Color = SKColor.Parse("#90D585"),
                                },
                                new Entry(0)
                                {
                                        Label = "جمعه",
                                        ValueLabel = "0",
                                        Color = SKColor.Parse("#90D585"),
                                },
                        };

                        return new Chart[]
                        {
                                new BarChart() { Entries = entries, LabelTextSize=35f },
                                new PointChart() { Entries = entries, LabelTextSize=35f  },
                                new LineChart() { Entries = entries, LabelTextSize=35f  },
                                new DonutChart() { Entries = entries , LabelTextSize=35f },
                                new RadialGaugeChart() { Entries = entries, LabelTextSize=35f  },
                                new RadarChart() { Entries = entries , LabelTextSize=35f },
                        };
                }

                public static Entry[] CreateEntries(int values, bool hasPositiveValues, bool hasNegativeValues, bool hasLabels, bool hasValueLabel, bool isSingleColor)
                {
                        ColorIndex = 0;

                        (string label, int value)[] data;

                        if(hasPositiveValues && hasNegativeValues)
                        {
                                data = MixedData;
                        }
                        else if(hasPositiveValues)
                        {
                                data = PositiveData;
                        }
                        else if (hasNegativeValues)
                        {
                                data = NegativeData;
                        }
                        else 
                        {
                                data = new (string label, int value)[0];
                        }

                        data = data.Take(values).ToArray();

                        return data.Select(d => new Entry(d.value) 
                        { 
                                Label = hasLabels ? d.label : null, 
                                ValueLabel = hasValueLabel ? d.value.ToString() : null, 
                                TextColor = TextColor, 
                                Color = isSingleColor ? Colors[2] : NextColor(),
                        }).ToArray();
                }
        }
}
