using System;
using System.Collections;
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
                        if (unturnedPlayer != null)
                        {
                            string barva = "";
                            if (unturnedPlayer.Health <= 100)
                            {
                                barva = "green";
                            }
                            if (unturnedPlayer.Health <= 50)
                            {
                                barva = "orange";
                            }
                            if (unturnedPlayer.Health <= 30)
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
                        }
                        break;
                    }
                    else
                    {
                        bool muzu = unturnedPlayer != null;
                        if (muzu)
                        {
                            string barva2 = "";
                            if (unturnedPlayer.Health <= 100)
                            {
                                barva2 = "green";
                            }
                            if (unturnedPlayer.Health <= 50)
                            {
                                barva2 = "orange";
                            }
                            if (unturnedPlayer.Health <= 30)
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
                        break;
                    }
                case EDeathCause.MELEE:
                    if (unturnedPlayer != null)
                    {
                        string barva2 = "";
                        if (unturnedPlayer.Health <= 100)
                        {
                            barva2 = "green";
                        }
                        if (unturnedPlayer.Health <= 50)
                        {
                            barva2 = "orange";
                        }
                        if (unturnedPlayer.Health <= 30)
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
                        "</color> ",
                        Plugin.Instance.Configuration.Instance.zombieformat,
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
                        "</color> ",
                        Plugin.Instance.Configuration.Instance.vehicleformat,
                        " </size>"
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
                        "</color> ",
                        Plugin.Instance.Configuration.Instance.sentryformat,
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
                        "</color> ",
                        Plugin.Instance.Configuration.Instance.bleedingformat,
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
                        "</color> ",
                        Plugin.Instance.Configuration.Instance.radiationformat,
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
                        "</color> ",
                        Plugin.Instance.Configuration.Instance.acidformat,
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
                        "</color> ",
                        Plugin.Instance.Configuration.Instance.missileformat,
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
                        "</color> ",
                        Plugin.Instance.Configuration.Instance.waterformat,
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
                        "</color> ",
                        Plugin.Instance.Configuration.Instance.foodformat,
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
                        "</color> ",
                        Plugin.Instance.Configuration.Instance.landmineformat,
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
                        "</color> ",
                        Plugin.Instance.Configuration.Instance.animalformat,
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
                        "</color> ",
                        Plugin.Instance.Configuration.Instance.oxygenformat,
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
                        "</color> ",
                        Plugin.Instance.Configuration.Instance.vehicleexploformat,
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
                        "</color> ",
                        Plugin.Instance.Configuration.Instance.suicideformat,
                        "</size>"
});
                    break;

                default:
                    Rocket.Core.Logging.Logger.Log("----------------------------------------------------");
                    Rocket.Core.Logging.Logger.Log("------------- Simple Killfeed ----------------------");
                    Rocket.Core.Logging.Logger.Log("-- Unhandled kill in killfeed, contact Jira (dev) --");
                    Rocket.Core.Logging.Logger.Log("----------------------------------------------------");
                    break;
            }
            this.UpdateKills(xd);
        }

        IEnumerator RemoveKills()
        {
            yield return new WaitForSeconds(Configuration.Instance.TimeToRemoveKill);
            if (this.Kills.Count >= 1)
            {
                this.Kills.Remove(this.Kills[0]);
                EffectManager.sendUIEffect(Configuration.Instance.EffectID, 445, true, string.Join("\n", this.Kills));
            }
        }

        public void UpdateKills(string text)
        {
            if (this.Kills.Count >= 5)
            {
                this.Kills.RemoveAt(0);
                this.Kills.Add(text);
            }
            else
            {
                this.Kills.Add(text);
            }
            StartCoroutine(RemoveKills());
            EffectManager.sendUIEffect(Configuration.Instance.EffectID, 445, true, string.Join("\n", this.Kills));
        }

        public static Plugin Instance;

        public List<string> Kills = new List<string>();
    }
}
