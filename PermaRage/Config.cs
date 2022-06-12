using System.ComponentModel;
using Exiled.API.Interfaces;

namespace PermaRage
{
    public class Config: IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("Can 096 hurt players that didn't saw his face (e.g. when charging)")]
        public bool CanHurtOtherPlayers { get; set; } = false;
    }
}