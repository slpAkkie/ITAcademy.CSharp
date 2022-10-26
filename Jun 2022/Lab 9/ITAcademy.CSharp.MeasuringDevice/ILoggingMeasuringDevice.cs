using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITAcademy.CSharp.MeasuringDevice
{
    public interface ILoggingMeasuringDevice : IMeasuringDevice
    {
        string GetLoggingFile();
    }
}
