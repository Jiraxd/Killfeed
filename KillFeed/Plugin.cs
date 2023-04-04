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
            bool killfeedmain = cause == EDeathCause.GUN && limb == ELimb.SKULL;
            if (killfeedmain)
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
                    xd = string.Format("<size={0}><color={8}>{1} </color><color={2}>[{3}HP]</color> <color={10}>{4}</color> H <color={9}>[{5}m]</color><color={7}> {6}</color></size>", new object[]
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
                bool zbrancause = cause == EDeathCause.GUN;
                if (zbrancause)
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
                        xd = string.Format("<size={0}><color={8}>{1} </color><color={2}>[{3}HP]</color> <color={10}>{4}</color> <color={9}>[{5}m]</color><color={7}> {6}</color></size>", new object[]
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
                bool meleexd = cause == EDeathCause.MELEE;
                if (meleexd)
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
                        ItemAsset weaponAssetxd = unturnedPlayer.Player.equipment.asset;
                        xd = string.Format("<size={0}><color={8}>{1} </color><color={2}>[{3}HP]</color> <color={10}>{4}</color> <color={9}>[{5}m]</color><color={7}> {6}</color></size>", new object[]
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
                }

                bool zombik = cause == EDeathCause.ZOMBIE;
                if (zombik)
                {
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
                }
                bool auto = cause == EDeathCause.ROADKILL;
                if (auto)
                {
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
                }
                bool punch = cause == EDeathCause.PUNCH;
                if (punch)
                {
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
                    xd = string.Format("<size={0}>{1}<color={2}> [{3}HP] has punched </color>￹<color=red>{4}</color></size>", new object[]
                    {
                        size,
                        unturnedPlayer.CharacterName,
                        barva3,
                        unturnedPlayer.Health,
                        player.CharacterName
                    });
                }
                bool sentry = cause == EDeathCause.SENTRY;
                if (sentry)
                {
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
                }
                bool bleed = cause == EDeathCause.BLEEDING;
                if (bleed)
                {
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
                }
                bool infec = cause == EDeathCause.INFECTION;
                if (infec)
                {
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
                }
                bool mis = cause == EDeathCause.MISSILE;
                if (mis)
                {
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
                }
                bool splash = cause == EDeathCause.SPLASH;
                if (splash)
                {
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
                }
                bool water = cause == EDeathCause.WATER;
                if (water)
                {
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
                }
                bool food = cause == EDeathCause.FOOD;
                if (food)
                {
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
                }
                bool animal = cause == EDeathCause.ANIMAL;
                if (animal)
                {
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
                }
                bool land = cause == EDeathCause.LANDMINE;
                if (land)
                {
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
                }
                bool breath = cause == EDeathCause.BREATH;
                if (breath)
                {
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
                }
                bool veh = cause == EDeathCause.VEHICLE;
                if (veh)
                {
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
                }
                bool smrt = cause == EDeathCause.SUICIDE;
                if (smrt)
                {
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
                }
                this.UpdateKills(xd);
            }
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
