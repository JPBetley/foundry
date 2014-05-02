using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPBetley.Foundry.Test.GoodTestStubs
{
    class TestClass
    {
        public string _testValue = "test";
        public string TestValue 
        {
            get { return _testValue; }
            set { _testValue = value; }
        }

        public int Id { get; set; }
    }
}
