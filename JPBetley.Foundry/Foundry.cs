using System;

namespace JPBetley.Foundry
{
    public class Foundry
    {
        private static Foundry _instance;
        private static Foundry Instance
        {
            get { return _instance ?? (_instance = new Foundry()); }
        }

        private readonly Forge forge;

        private Foundry()
        {
            forge = new Forge(new Crucible());
        }

        public static T Cast<T>()
        {
            return Cast<T>(x => { });
        }

        public static T Cast<T>(Action<T> overrides)
        {
            return Instance.forge.Cast(overrides);
        }
    }
}
