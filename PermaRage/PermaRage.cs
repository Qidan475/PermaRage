using System;
using Exiled.API.Features;

namespace PermaRage
{
    public class PermaRage: Plugin<Config>
    {
        public override string Name => "PermaRage";

        public override string Author => "Qidan475";

        public override Version Version { get; } = new Version(1, 0, 0);

        public override Version RequiredExiledVersion { get; } = new Version(5, 2, 1);

        internal static PermaRage Instance { get; private set; }


        private EventHandlers evHandlers;

        public override void OnEnabled()
        {
            Instance = this;
            evHandlers = new EventHandlers();

            Exiled.Events.Handlers.Scp096.CalmingDown += evHandlers.OnTryingToCalm;
            Exiled.Events.Handlers.Scp096.ChargingPlayer += evHandlers.OnCharge;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Scp096.CalmingDown -= evHandlers.OnTryingToCalm;
            Exiled.Events.Handlers.Scp096.ChargingPlayer -= evHandlers.OnCharge;

            evHandlers = null;
            Instance = null;

            base.OnDisabled();
        }
    }
}
