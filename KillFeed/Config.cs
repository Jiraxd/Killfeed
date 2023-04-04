using System;
using Rocket.API;

namespace KillFeed
{
    public class Config : IRocketPluginConfiguration, IDefaultable
    {
        public void LoadDefaults()
        {
            this.Size = 25;
            this.killercolor = "#ffffff";
            this.victimcolor = "#ff0000";
            this.rangecolor = "#ffff00";
            this.guncolor = "#bfff00";
            this.playercolor = "#ff0000";
        }

        public ushort Size;
        public string killercolor;
        public string victimcolor;
        public string rangecolor;
        public string guncolor;
        public string playercolor;
    }
}
