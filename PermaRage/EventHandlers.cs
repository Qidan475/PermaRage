using Exiled.Events.EventArgs;
using Exiled.API.Features.Roles;

namespace PermaRage
{
    internal class EventHandlers
    {
        public void OnTryingToCalm(CalmingDownEventArgs ev)
        {
            if (ev.Player.Role.As<Scp096Role>().Targets.Count > 0)
                ev.IsAllowed = false;
        }

        public void OnCharge(ChargingPlayerEventArgs ev)
        {
            if (!ev.IsTarget && !PermaRage.Instance.Config.CanHurtOtherPlayers)
                ev.IsAllowed = false;
        }
    }
}
