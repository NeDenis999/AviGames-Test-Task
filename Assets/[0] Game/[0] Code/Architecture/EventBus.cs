using System;

namespace Game
{
    public static class EventBus
    {
        public static Action<int, int> DifferenceUpgrade;
        public static Action Lose;
    }
}