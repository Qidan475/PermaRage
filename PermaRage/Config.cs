using System.ComponentModel;
using Exiled.API.Interfaces;

namespace PermaRage
{
    public class Config: IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("Can 096 hurt players that didn't saw his face (e.g. when charging)")]
        public bool CanHurtOtherPlayers { get; set; } = false;

        [Description("Will 096 stop enraging if no targets left in the same zone as 096 (heavy and entrance zones considered as one big zone)")]
        public bool StopIfNoTargetsInArea { get; set; } = false;

        [Description("Stop enrage as soon as possible if no targets left. Might interfere with command \"enrage\"")]
        public bool StopInstantlyIfNoTargetsLeft { get; set; } = true;
    }
}