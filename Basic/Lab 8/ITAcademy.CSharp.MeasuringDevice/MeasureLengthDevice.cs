using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ITAcademy.CSharp.DeviceControl;

namespace ITAcademy.CSharp.MeasuringDevice
{
    public class MeasureLengthDevice : IMeasuringDevice
    {
        private Units unitsToUse;
        private int[] dataCaptured;
        private int mostRecentMeasure;
        private DeviceController controller;
        private DeviceType measurementType { get; } = DeviceType.LENGTH;

        public MeasureLengthDevice(Units unitsToUse) => this.unitsToUse = unitsToUse;

        public int[] GetRawData() => dataCaptured;

        public decimal ImperialValue()
        {
            return unitsToUse == Units.Imperial
                ? mostRecentMeasure
                : (decimal)(mostRecentMeasure * 0.03937);
        }

        public decimal MetricValue()
        {
            return unitsToUse == Units.Metric
                ? mostRecentMeasure
                : (decimal)(mostRecentMeasure * 25.4);
        }

        public void StartCollecting()
        {
            controller = DeviceController.StartDevice(measurementType);
            GetMeasurements();
        }

        private void GetMeasurements()
        {
            dataCaptured = new int[10];
            System.Threading.ThreadPool.QueueUserWorkItem((dummy) =>
            {
                int x = 0; Random timer = new Random();

                while (controller != null)
                {
                    System.Threading.Thread.Sleep(timer.Next(1000, 5000));
                    dataCaptured[x] = controller != null ?
                    controller.TakeMeasurement() : dataCaptured[x];
                    mostRecentMeasure = dataCaptured[x];
                    x++;
                    if (x == 10)
                    {
                        x = 0;
                    }
                }
            });
        }

        public void StopCollecting()
        {
            if (controller != null)
            {
                controller.StopDevice();
                controller = null;
            }
        }
    }
}
