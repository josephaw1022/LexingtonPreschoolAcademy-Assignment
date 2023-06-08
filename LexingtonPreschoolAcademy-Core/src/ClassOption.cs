using System.ComponentModel;

namespace LexingtonPreschoolAcademy_Core;


// User should be able to choose between Art, Math, Science, History, Spanish,
// and P.E.
public enum ClassOption
{
    [Description("Art Class")]
    Art,

    [Description("Math Class")]
    Math,

    [Description("Science Class")]
    Science,

    [Description("History Class")]
    History,

    [Description("Spanish Class")]
    Spanish,

    [Description("P.E. Class")]
    P_E
}
