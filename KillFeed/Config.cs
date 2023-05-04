using System;
using Rocket.API;

namespace KillFeed
{
    public class Config : IRocketPluginConfiguration, IDefaultable
    {
        public void LoadDefaults()
        {
            this.Size = 19;
            this.EffectID = 21394;
            this.TimeToRemoveKill = 5f;
            this.killercolor = "#ffffff";
            this.victimcolor = "#ff0000";
            this.rangecolor = "#ffff00";
            this.guncolor = "#bfff00";
            this.playercolor = "#ff0000";
            this.headshotgunformat = "<size={0}><color={8}>{1} </color><color={2}>[{3}HP]</color> <color={10}>{4}</color> H <color={9}>[{5}m]</color><color={7}> {6}</color></size>";
            this.gunformat = "<size={0}><color={8}>{1} </color><color={2}>[{3}HP]</color> <color={10}>{4}</color> <color={9}>[{5}m]</color><color={7}> {6}</color></size>";
            this.meleeformat = "<size={0}><color={8}>{1} </color><color={2}>[{3}HP]</color> <color={10}>{4}</color> <color={9}>[{5}m]</color><color={7}> {6}</color></size>";
            this.punchformat = "<size={0}>{1}<color={2}> [{3}HP] has punched</color> <color=red>{4}</color></size>";
        }
        public string punchformat;
        public string meleeformat;
        public string gunformat;
        public string headshotgunformat;
        public ushort Size;
        public string killercolor;
        public string victimcolor;
        public string rangecolor;
        public string guncolor;
        public string playercolor;
        public float TimeToRemoveKill;
        public ushort EffectID;
    }
}
