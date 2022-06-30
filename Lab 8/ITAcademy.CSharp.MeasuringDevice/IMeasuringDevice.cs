﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAcademy.CSharp.MeasuringDevice
{
    public interface IMeasuringDevice
    {
        decimal MetricValue();

        decimal ImperialValue();

        void StartCollecting();

        void StopCollecting();

        int[] GetRawData();
    }
}
