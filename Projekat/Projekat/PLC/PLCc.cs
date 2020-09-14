using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PLC
{
    public class PLCc
    {
        private Dictionary<string, double> addressValues;
        private object locker = new object();

        public PLCc()
        {
            addressValues = new Dictionary<string, double>();

            addressValues.Add("ADDR000", 0);
            addressValues.Add("ADDR001", 0);
            addressValues.Add("ADDR002", 0);
            addressValues.Add("ADDR003", 0);
            addressValues.Add("ADDR004", 0);
            addressValues.Add("ADDR005", 0);
            addressValues.Add("ADDR006", 0);
            addressValues.Add("ADDR007", 0);
            addressValues.Add("ADDR008", 0);
            addressValues.Add("ADDR009", 0);
            addressValues.Add("ADDR010", 0);
            addressValues.Add("ADDR011", 0);
            addressValues.Add("ADDR012", 0);
            addressValues.Add("ADDR013", 0);
            addressValues.Add("ADDR014", 0);
            addressValues.Add("ADDR015", 0);
        }

        public void PLCstart()
        {
            Thread t1 = new Thread(GeneratingAnalogInputs);
            t1.Start();

            Thread t2 = new Thread(GeneratingDigitalInputs);
            t2.Start();
        }

        private void GeneratingAnalogInputs()
        {
            while (true)
            {
                Thread.Sleep(100);

                lock (locker)
                {
                    addressValues["ADDR008"] = 100 * Math.Cos((double)DateTime.Now.Second / 60 * Math.PI);
                    addressValues["ADDR009"] = 100 * Math.Sin((double)DateTime.Now.Second / 60 * Math.PI); //SINE
                    addressValues["ADDR010"] = 100 * DateTime.Now.Second / 60; //RAMP
                    addressValues["ADDR011"] = 50 * Math.Sin((double)DateTime.Now.Second / 60 * Math.PI);
                }

                
            }
        }

        private void GeneratingDigitalInputs()
        {
            while (true)
            {
                Thread.Sleep(200);

                lock (locker)
                {
                    if (addressValues["ADDR000"] == 0)
                    {
                        addressValues["ADDR000"] = 1;
                    }
                    else
                    {
                        addressValues["ADDR000"] = 0;
                    }

                    if (addressValues["ADDR001"] == 0)
                    {
                        addressValues["ADDR001"] = 1;
                    }
                    else
                    {
                        addressValues["ADDR001"] = 0;
                    }

                    if (addressValues["ADDR002"] == 0)
                    {
                        addressValues["ADDR002"] = 1;
                    }
                    else
                    {
                        addressValues["ADDR002"] = 0;
                    }

                    if (addressValues["ADDR003"] == 0)
                    {
                        addressValues["ADDR003"] = 1;
                    }
                    else
                    {
                        addressValues["ADDR003"] = 0;
                    }
                }

                
            }

        }
        public double GetAnalogInputValue(string adress)
        {
            return addressValues[adress];
        }

        public double GetDigitalInputValue(string adress)
        {
            return addressValues[adress];
        }

        
    }
}

