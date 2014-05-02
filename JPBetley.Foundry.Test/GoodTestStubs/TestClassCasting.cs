using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPBetley.Foundry.Test.GoodTestStubs
{
    class TestClassCasting : CastingMold<TestClass>
    {
        public override TestClass Cast()
        {
            return new TestClass();
        }
    }
}
