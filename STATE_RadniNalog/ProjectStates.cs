﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STATE_RadniNalog
{
	public enum ProjectStates
	{
		OrderCreated,
		OrderLocked,
		PutIntoProduction, 
		ProductionStarted,
		ProductionFinished,
		ProductionCanceled,
	}
}
