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
            this.zombieformat = "has been killed by a zombie";
            this.vehicleformat = "has been killed by a vehicle";
            this.sentryformat = "has been killed by a sentry";
            this.bleedingformat = "has bled out";
            this.radiationformat = "has died to radiation";
            this.acidformat = "has died to acid";
            this.missileformat = "has been blown up by a missile";
            this.waterformat = "has died to dehydratation";
            this.foodformat = "has died to starvation";
            this.landmineformat = "has died to a landmine";
            this.animalformat = "has died to an animal";
            this.oxygenformat = "has ran out of oxygen";
            this.vehicleexploformat = "has been blown up by a vehicle";
            this.suicideformat = "has suicided";

        }
        public ushort Size;
        public float TimeToRemoveKill;
        public ushort EffectID;
        public string playercolor;
        public string rangecolor;
        public string guncolor;
        public string victimcolor;
        public string killercolor;
        public string foodformat;
        public string suicideformat;
        public string zombieformat;
        public string radiationformat;
        public string oxygenformat;
        public string animalformat;
        public string sentryformat;
        public string bleedingformat;
        public string vehicleexploformat;
        public string punchformat;
        public string meleeformat;
        public string acidformat;
        public string waterformat;
        public string missileformat;
        public string gunformat;
        public string headshotgunformat;
        public string landmineformat;
        public string vehicleformat;
    }
}
