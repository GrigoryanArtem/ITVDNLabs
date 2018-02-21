using System.Collections.Generic;

namespace LAB4_PART1_Strings.Model
{
    internal static class PageParserConstants
    {
        internal static Dictionary<string, string> MobileOperatorsCodes => new Dictionary<string, string> {
            {"039", "Golden Telecom"},
            {"050", "MTS"},
            {"063", "life:)"},
            {"066", "MTS"},
            {"067", "Kyivstar"},
            {"068", "Beeline"},
            {"091", "Utel"},
            {"092", "PEOPLEnet"},
            {"093", "life:)"},
            {"094", "Intertelecom"},
            {"095", "MTS"},
            {"096", "Kyivstar"},
            {"097", "Kyivstar"},
            {"098", "Kyivstar"},
            {"099", "MTS"},
            {"048", "CITY(ODESSA)"}
        };

        internal static string NullMobileOperator => "NONE";
    }
}
