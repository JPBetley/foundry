using System;

namespace JPBetley.Foundry
{
    class Forge
    {
        private readonly Crucible crucible;
        public Forge(Crucible crucible)
        {
            this.crucible = crucible;
        } 

        public T Cast<T>()
        {
            return Cast<T>(x => { });
        }

        public T Cast<T>(Action<T> overrides)
        {
            var mold = crucible.FindCastingMold<T>();
            var cast = mold.Cast();
            overrides(cast);
            return cast;
        }
    }
}
