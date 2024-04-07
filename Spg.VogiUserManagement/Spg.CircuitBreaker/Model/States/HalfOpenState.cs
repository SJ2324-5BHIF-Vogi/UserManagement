using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.CircuitBreaker.Model.States
{
    public class HalfOpenState : CircuitBreakerState
    {
        private readonly DateTime _openDateTime;

        public HalfOpenState(CircuitBreaker circuitBreaker)
            : base(circuitBreaker)
        {
            _openDateTime = DateTime.UtcNow;
        }

        public override CircuitBreaker ProtectedCodeIsExecuting()
        {
            base.ProtectedCodeIsExecuting();
            Update();
            return _circuitBreaker;
        }

        public override CircuitBreakerState Update()
        {
            base.Update();
            if (DateTime.UtcNow >= _openDateTime + _circuitBreaker.Timeout)
            {
                return _circuitBreaker.MoveToHalfOpenState();
            }
            return this;
        }
    }
}
