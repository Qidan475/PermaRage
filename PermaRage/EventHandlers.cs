using Exiled.Events.EventArgs;
using Exiled.API.Features.Roles;
using MEC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PermaRage
{
    internal class EventHandlers
    {
        private readonly Config _config = PermaRage.Instance.Config;

        private bool _canCalm;

        public void OnEnraging(EnragingEventArgs ev)
        {
            Timing.RunCoroutine(CheckTargets(ev.Player.Role.As<Scp096Role>()));
        }

        public IEnumerator<float> CheckTargets(Scp096Role scp096)
        {
            _canCalm = false;
            do
            {
                int delayInSec = 2;
                for (int i = 0; i < Application.targetFrameRate * delayInSec; i++)
                {
                    yield return Timing.WaitForOneFrame;
                }

                if (scp096 is null || scp096.Owner is null || !scp096.IsValid)
                    yield break;

                int totalTargets = scp096.Targets.Count;
                if (_config.StopIfNoTargetsInArea)
                {
                    totalTargets -= scp096.Targets.Count(target => !target.IsInTheSameZone(scp096.Owner));
                }

                if (totalTargets == 0)
                {
                    _canCalm = true;

                    if (_config.StopInstantlyIfNoTargetsLeft)
                        scp096.Script.EnrageTimeLeft = 0;
                }
            } while (!_canCalm);
        }

        public void OnCharge(ChargingPlayerEventArgs ev)
        {
            if (!ev.IsTarget && !_config.CanHurtOtherPlayers)
                ev.IsAllowed = false;
        }

        public void OnTryingToCalm(CalmingDownEventArgs ev)
        {
            ev.IsAllowed = _canCalm;
        }
    }
}
