using System.ComponentModel;

namespace PO_project.Enums
{
    public enum Matura
	{
        [Description("Matematyka")]
		Matematyka = 0,

        [Description("Język polski")]
		JezykPolski = 1,

        [Description("Biologia")]
        Biologia = 2,

        [Description("Chemia")]
        Chemia = 3,

        [Description("Historia")]
        Historia = 4,

        [Description("Wiedza o społeczeństwie")]
        WiedzaOSpoleczenstwie = 5,

        [Description("Fizyka")]
        Fizyka = 6,

        [Description("Informatyka")]
        Informatyka = 7,

        [Description("Geografia")]
        Geografia = 8,

        [Description("Język obcy")]
        JezykObcy = 9
	}
}
