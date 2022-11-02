using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAcademy.CSharp.StressTest
{
    public enum Material
    {
        StainlessSteel,
        Aluminium,
        ReinforcedConcrete,
        Composite,
        Titanium,
    }

    public enum CrossSection
    {
        IBeam,
        Box,
        ZShaped,
        CShaped,
    }

    public enum TestResult
    {
        Pass,
        Fail,
    }
}
