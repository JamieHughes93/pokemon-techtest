using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonFinder.Tests.Helpers
{
    public class RateLimiterHelperFake
    {
        private int _hourlyLimit;
        private int _dailyLimit;
        private Queue<DateTime> _hourlyTokens;
        private Queue<DateTime> _dailyTokens;

        public RateLimiterHelperFake(int hourlyLimit, int dailyLimit)
        {
            _hourlyLimit = hourlyLimit;
            _dailyLimit = dailyLimit;
            _hourlyTokens = new Queue<DateTime>();
            _dailyTokens = new Queue<DateTime>();
        }

        public bool CanMakeRequest()
        {
            DateTime currentTime = DateTime.Now;

            // Remove expired hourly tokens
            while (_hourlyTokens.Count > 0 && (currentTime - _hourlyTokens.Peek()).TotalHours >= 1)
            {
                _hourlyTokens.Dequeue();
            }

            // Remove expired daily tokens
            while (_dailyTokens.Count > 0 && (currentTime - _dailyTokens.Peek()).TotalDays >= 1)
            {
                _dailyTokens.Dequeue();
            }

            // Check if limits are reached
            if (_hourlyTokens.Count >= _hourlyLimit || _dailyTokens.Count >= _dailyLimit)
            {
                return false; // Limit exceeded, request not allowed
            }

            // Add tokens for the current request
            _hourlyTokens.Enqueue(currentTime);
            _dailyTokens.Enqueue(currentTime);

            return true; // Request allowed
        }
    }
}
