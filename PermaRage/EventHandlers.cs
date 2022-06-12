using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using Exiled.Events.Handlers;
using Exiled.Events.EventArgs;
using Exiled.API.Features.Roles;
using Exiled.API.Features;

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
