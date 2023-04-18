using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using UnityEngine;


namespace KillFeed
{
    public class Plugin : RocketPlugin<Config>
    {
        protected override void Load()
        {
            Plugin.Instance = this;
            UnturnedPlayerEvents.OnPlayerDeath += this.Death;
            Rocket.Core.Logging.Logger.Log("-----------------------------------");
            Rocket.Core.Logging.Logger.Log("---Killfeed created by Jira#2500---");
            Rocket.Core.Logging.Logger.Log("-----------------------------------");
        }

        protected override void Unload()
        {
            UnturnedPlayerEvents.OnPlayerDeath -= this.Death;
        }

        public void Death(UnturnedPlayer player, EDeathCause cause, ELimb limb, CSteamID murderer)
        {
            string xd = "";
            string size = base.Configuration.Instance.Size.ToString();
            UnturnedPlayer unturnedPlayer = UnturnedPlayer.FromCSteamID(murderer);
            switch (cause)
            {
                case EDeathCause.GUN:
                    if (limb == ELimb.SKULL)
                    {
                        bool hrac = unturnedPlayer != null;
                        if (hrac)
                        {
                            string barva = "";
                            bool zelena = unturnedPlayer.Health <= 100;
                            if (zelena)
                            {
                                barva = "green";
                            }
                            bool oranzova = unturnedPlayer.Health <= 50;
                            if (oranzova)
                            {
                                barva = "orange";
                            }
                            bool cervena = unturnedPlayer.Health <= 30;
                            if (cervena)
                            {
                                barva = "red";
                            }
                            string range = Vector3.Distance(player.Position, unturnedPlayer.Position).ToString("00");
                            range = Regex.Replace(range, "^0+(?=\\d+$)", "");
                            ItemGunAsset itemGunAsset = (ItemGunAsset)Assets.find(EAssetType.ITEM, unturnedPlayer.Player.equipment.itemID);
                            xd = string.Format(Plugin.Instance.Configuration.Instance.headshotgunformat, new object[]
                            {
                        size,
                        unturnedPlayer.CharacterName,
                        barva,
                        unturnedPlayer.Health,
                        itemGunAsset.itemName,
                        range,
                        player.CharacterName,
                        Plugin.Instance.Configuration.Instance.victimcolor,
                        Plugin.Instance.Configuration.Instance.killercolor,
                        Plugin.Instance.Configuration.Instance.rangecolor,
                        Plugin.Instance.Configuration.Instance.guncolor
                            });
                            this.UpdateKills(xd);
                        }
                    }
                    else
                    {
                        bool muzu = unturnedPlayer != null;
                        if (muzu)
                        {
                            string barva2 = "";
                            bool ex = unturnedPlayer.Health <= 100;
                            if (ex)
                            {
                                barva2 = "green";
                            }
                            bool ex2 = unturnedPlayer.Health <= 50;
                            if (ex2)
                            {
                                barva2 = "orange";
                            }
                            bool ex3 = unturnedPlayer.Health <= 30;
                            if (ex3)
                            {
                                barva2 = "red";
                            }
                            string range2 = Vector3.Distance(player.Position, unturnedPlayer.Position).ToString("00");
                            range2 = Regex.Replace(range2, "^0+(?=\\d+$)", "");
                            ItemGunAsset itemGunAsset2 = (ItemGunAsset)Assets.find(EAssetType.ITEM, unturnedPlayer.Player.equipment.itemID);
                            xd = string.Format(Plugin.Instance.Configuration.Instance.gunformat, new object[]
                            {
                            size,
                            unturnedPlayer.CharacterName,
                            barva2,
                            unturnedPlayer.Health,
                            itemGunAsset2.itemName,
                            range2,
                            player.CharacterName,
                                                    Plugin.Instance.Configuration.Instance.victimcolor,
                        Plugin.Instance.Configuration.Instance.killercolor,
                        Plugin.Instance.Configuration.Instance.rangecolor,
                        Plugin.Instance.Configuration.Instance.guncolor
                            });
                        }
                    }
                    break;
                case EDeathCause.MELEE:
                    bool muzuxd = unturnedPlayer != null;
                    if (muzuxd)
                    {
                        string barva2 = "";
                        bool ex = unturnedPlayer.Health <= 100;
                        if (ex)
                        {
                            barva2 = "green";
                        }
                        bool ex2 = unturnedPlayer.Health <= 50;
                        if (ex2)
                        {
                            barva2 = "orange";
                        }
                        bool ex3 = unturnedPlayer.Health <= 30;
                        if (ex3)
                        {
                            barva2 = "red";
                        }
                        string range2 = Vector3.Distance(player.Position, unturnedPlayer.Position).ToString("00");
                        range2 = Regex.Replace(range2, "^0+(?=\\d+$)", "");
                        ItemAsset weaponAssetxd = unturnedPlayer.Player.equipment.asset;
                        xd = string.Format(Plugin.Instance.Configuration.Instance.meleeformat, new object[]
                        {
                            size,
                            unturnedPlayer.CharacterName,
                            barva2,
                            unturnedPlayer.Health,
                            weaponAssetxd.itemName,
                            range2,
                            player.CharacterName,
                                                    Plugin.Instance.Configuration.Instance.victimcolor,
                        Plugin.Instance.Configuration.Instance.killercolor,
                        Plugin.Instance.Configuration.Instance.rangecolor,
                        Plugin.Instance.Configuration.Instance.guncolor
                        });
                    }
                    break;
                case EDeathCause.ZOMBIE:
                    xd = string.Concat(new string[]
                   {
                        "<size=",
                        size,
                        ">",
                        "<color=",
                        Plugin.Instance.Configuration.Instance.playercolor,
                        ">",
                        player.CharacterName,
                        "</color>",
                        " has been killed by a zombie",
                        " </size>"
                   });
                    break;
                case EDeathCause.ROADKILL:
                    xd = string.Concat(new string[]
                   {
                        "<size=",
                        size,
                        ">",
                                                "<color=",
                        Plugin.Instance.Configuration.Instance.playercolor,
                        ">",
                        player.CharacterName,
                        "</color>",
                        " has been killed by a vehicle",
                        " ￿</size>"
                   });
                    break;
                case EDeathCause.PUNCH:
                    string barva3 = "";
                    bool barve4 = unturnedPlayer.Health <= 100;
                    if (barve4)
                    {
                        barva3 = "green";
                    }
                    bool barve5 = unturnedPlayer.Health <= 50;
                    if (barve5)
                    {
                        barva3 = "orange";
                    }
                    bool barve6 = unturnedPlayer.Health <= 30;
                    if (barve6)
                    {
                        barva3 = "red";
                    }
                    xd = string.Format(Plugin.Instance.Configuration.Instance.punchformat, new object[]
                    {
                        size,
                        unturnedPlayer.CharacterName,
                        barva3,
                        unturnedPlayer.Health,
                        player.CharacterName
                    });
                    break;
                case EDeathCause.SENTRY:
                    xd = string.Concat(new string[]
                   {
                        "<size=",
                        size,
                        ">",
                                                "<color=",
                        Plugin.Instance.Configuration.Instance.playercolor,
                        ">",
                        player.CharacterName,
                        "</color>",
                        " has been killed by a sentry",
                        "</size>"
                   });
                    break;

                case EDeathCause.BLEEDING:
                    xd = string.Concat(new string[]
                   {
                        "<size=",
                        size,
                        ">",
                                                "<color=",
                        Plugin.Instance.Configuration.Instance.playercolor,
                        ">",
                        player.CharacterName,
                        "</color>",
                        " has bled out",
                        "</size>"
                   });
                    break;

                case EDeathCause.INFECTION:
                    xd = string.Concat(new string[]
                   {
                        "<size=",
                        size,
                        ">",
                                                "<color=",
                        Plugin.Instance.Configuration.Instance.playercolor,
                        ">",
                        player.CharacterName,
                        "</color>",
                        " has died to radiation",
                        "</size>"
                   });
                    break;

                case EDeathCause.SPLASH:
                    xd = string.Concat(new string[]
                    {
                        "<size=",
                        size,
                        ">",
                                                "<color=",
                        Plugin.Instance.Configuration.Instance.playercolor,
                        ">",
                        player.CharacterName,
                        "</color>",
                        " has died to acid",
                        "</size>"
                    });
                    break;

                case EDeathCause.MISSILE:
                    xd = string.Concat(new string[]
{
                        "<size=",
                        size,
                        ">",
                                                "<color=",
                        Plugin.Instance.Configuration.Instance.playercolor,
                        ">",
                        player.CharacterName,
                        "</color>",
                        " has been blown up by a missile",
                        "</size>"
});
                    break;

                case EDeathCause.WATER:
                    xd = string.Concat(new string[]
{
                        "<size=",
                        size,
                        ">",
                                                "<color=",
                        Plugin.Instance.Configuration.Instance.playercolor,
                        ">",
                        player.CharacterName,
                        "</color>",
                        " has died to dehydratation",
                        "</size>"
});
                    break;

                case EDeathCause.FOOD:
                    xd = string.Concat(new string[]
{
                        "<size=",
                        size,
                        ">",
                         "<color=",
                        Plugin.Instance.Configuration.Instance.playercolor,
                        ">",
                        player.CharacterName,
                        "</color>",
                        " has died to starvation",
                        "￻</size>"
});
                    break;

                case EDeathCause.LANDMINE:
                    xd = string.Concat(new string[]
{
                        "<size=",
                        size,
                        ">",
                                                "<color=",
                        Plugin.Instance.Configuration.Instance.playercolor,
                        ">",
                        player.CharacterName,
                        " has died to a landmine",
                        "</color>",
                        "￺</size>"
});
                    break;
                case EDeathCause.ANIMAL:
                    xd = string.Concat(new string[]
{
                        "<size=",
                        size,
                        ">",
                                                "<color=",
                        Plugin.Instance.Configuration.Instance.playercolor,
                        ">",
                        player.CharacterName,
                        "</color>",
                        " has died to an animal",
                        "￹￹￻</size>"
});
                    break;

                case EDeathCause.BREATH:
                    xd = string.Concat(new string[]
{
                        "<size=",
                        size,
                        ">",
                                                "<color=",
                        Plugin.Instance.Configuration.Instance.playercolor,
                        ">",
                        player.CharacterName,
                        "</color>",
                        " has ran out of oxygen",
                        "</size>"
});
                    break;

                case EDeathCause.VEHICLE:
                    xd = string.Concat(new string[]
{
                        "<size=",
                        size,
                        ">",
                                                "<color=",
                        Plugin.Instance.Configuration.Instance.playercolor,
                        ">",
                        player.CharacterName,
                        "</color>",
                        " has been blown up by a vehicle",
                        "</size>"
});
                    break;

                case EDeathCause.SUICIDE:
                    xd = string.Concat(new string[]
{
                        "<size=",
                        size,
                        ">",
                                                "<color=",
                        Plugin.Instance.Configuration.Instance.playercolor,
                        ">",
                        player.CharacterName,
                        "</color>",
                        " has suicided",
                        "</size>"
});
                    break;

                default:
                    Rocket.Core.Logging.Logger.Log("-------------------------------------------");
                    Rocket.Core.Logging.Logger.Log("------------- Simple Killfeed -------------");
                    Rocket.Core.Logging.Logger.Log("-- Error in killfeed, contact Jira (dev) --");
                    Rocket.Core.Logging.Logger.Log("-------------------------------------------");
                    break;
            }
            this.UpdateKills(xd);
        }

        public void FixedUpdate()
        {
            bool cas = (DateTime.Now - this.Time).TotalSeconds >= 5.0;
            if (cas)
            {
                bool killyx = this.Kills.Count >= 1;
                if (killyx)
                {
                    this.Kills.Remove(this.Kills[0]);
                    EffectManager.sendUIEffect(21394, 445, true, string.Join("\n", this.Kills));
                }
                this.Time = DateTime.Now;
            }
        }

        public void UpdateKills(string text)
        {
            bool maxkill = this.Kills.Count >= 5;
            if (maxkill)
            {
                this.Kills.RemoveAt(0);
                this.Kills.Add(text);
            }
            else
            {
                this.Kills.Add(text);
            }
            this.Time = DateTime.Now;
            EffectManager.sendUIEffect(21394, 445, true, string.Join("\n", this.Kills));
        }

        public static Plugin Instance;

        public List<string> Kills = new List<string>();

        public DateTime Time = DateTime.Now;
    }
}
