﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPBetley.Foundry.Test.BadTestStubs
{
    class MulitpleCastingOne : CastingMold<Multiple>
    {
        public override Multiple Cast()
        {
            throw new NotImplementedException();
        }
    }
}
