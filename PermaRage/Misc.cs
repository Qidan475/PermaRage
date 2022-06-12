using Exiled.API.Features;
using Exiled.API.Enums;

namespace PermaRage
{
    internal static class Misc
    {
        public static bool IsInTheSameZone(this Player player1, Player player2)
        {
            if ((player1.Zone == ZoneType.HeavyContainment || player1.Zone == ZoneType.Entrance) &&
                (player2.Zone == ZoneType.HeavyContainment || player2.Zone == ZoneType.Entrance))
            {
                return true;
            }

            return player1.Zone == player2.Zone;
        }
    }
}
