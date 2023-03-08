using System;
using System.Collections.Concurrent;

namespace BlazorServerChess.Data.Services
{
	public class GameClockService
	{
        public ConcurrentDictionary<string, System.Timers.Timer> TimerDictionary { get; set; }
    }
}

