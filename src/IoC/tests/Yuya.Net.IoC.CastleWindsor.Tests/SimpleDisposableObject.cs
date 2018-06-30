using System;
using System.Collections.Generic;
using System.Text;

namespace Yuya.Net.IoC.CastleWindsor.Tests
{
    public class SimpleDisposableObject : IDisposable
    {
        public int MyData { get; set; }

        public int DisposeCount { get; set; }

        public SimpleDisposableObject()
        {

        }

        public SimpleDisposableObject(int myData)
        {
            MyData = myData;
        }

        public void Dispose()
        {
            DisposeCount++;
        }

        public int GetMyData()
        {
            return MyData;
        }
    }
}
