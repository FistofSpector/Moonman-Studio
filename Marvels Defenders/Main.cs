using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Defenders
{
    public class Mod
    {
        public static string DefendersTag = "<color=red>[Defenders]</color> ";
        public static string ItemsTag = "<color=grey>[Items]</color> ";

        public static void Main()
        {
            CategoryBuilder.Create("Marvel's 616", "", ModAPI.LoadSprite("Assets/Category Icon.png"));

            // Characters
            var Daredevil = ModAPI.LoadTexture("Assets/People/Daredevil/Skin.png");
            var Punisher = ModAPI.LoadTexture("Assets/People/Punisher/Skin.png");
            var Elektra = ModAPI.LoadTexture("Assets/People/Elektra/Skin.png");
            var IronFist = ModAPI.LoadTexture("Assets/People/Iron Fist/Skin.png");
            var LukeCage = ModAPI.LoadTexture("Assets/People/Luke Cage/Skin.png");
            var HandAgent = ModAPI.LoadTexture("Assets/People/Hand Agent/Skin.png");
            var Bullseye = ModAPI.LoadTexture("Assets/People/Bullseye/Skin.png");
            
            // Skins
            var MattMurdock = ModAPI.LoadTexture("Assets/People/Daredevil/Skins/Matt Murdock.png");
            var DaredevilNetflix = ModAPI.LoadTexture("Assets/People/Daredevil/Skins/Netflix.png");
            var DaredevilOG = ModAPI.LoadTexture("Assets/People/Daredevil/Skins/OG.png");
            var DaredevilManWithoutFear = ModAPI.LoadTexture("Assets/People/Daredevil/Skins/Man Without Fear.png");

            var FrankCastle = ModAPI.LoadTexture("Assets/People/Punisher/Skins/Frank Castle.png");

            var ElektraNatchios = ModAPI.LoadTexture("Assets/People/Elektra/Skins/Elektra Natchios.png");
            var ElektraNetflix = ModAPI.LoadTexture("Assets/People/Elektra/Skins/Netflix.png");
            var ElektraDaredevil = ModAPI.LoadTexture("Assets/People/Elektra/Skins/Netflix.png");

            var DannyRand = ModAPI.LoadTexture("Assets/People/Iron Fist/Skins/Danny Rand.png");
            var IronFistImmortalWeapon = ModAPI.LoadTexture("Assets/People/Iron Fist/Skins/Netflix.png");

            var LukeCageCasual = ModAPI.LoadTexture("Assets/People/Luke Cage/Skins/Luke Cage.png");
            

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = DefendersTag + "Daredevil",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Marvel's 616"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Daredevil/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(Daredevil);

                        SkinManager skinManager = Instance.GetOrAddComponent<SkinManager>();
                        skinManager.AddSkin(Daredevil);
                        skinManager.AddSkin(MattMurdock);
                        skinManager.AddSkin(DaredevilManWithoutFear);
                        skinManager.AddSkin(DaredevilNetflix);
                        skinManager.AddSkin(DaredevilOG);
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = DefendersTag + "The Punisher",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Marvel's 616"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Punisher.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(Punisher);

                        SkinManager skinManager = Instance.GetOrAddComponent<SkinManager>();
                        skinManager.AddSkin(Punisher);
                        skinManager.AddSkin(FrankCastle);
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = DefendersTag + "Elektra",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Marvel's 616"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Elektra/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(Elektra);

                        SkinManager skinManager = Instance.GetOrAddComponent<SkinManager>();
                        skinManager.AddSkin(Elektra);
                        skinManager.AddSkin(ElektraNetflix);
                        skinManager.AddSkin(ElektraDaredevil);
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = DefendersTag + "Iron Fist",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Marvel's 616"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Iron Fist/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(IronFist);

                        SkinManager skinManager = Instance.GetOrAddComponent<SkinManager>();
                        skinManager.AddSkin(IronFist);
                        skinManager.AddSkin(IronFistImmortalWeapon);
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = DefendersTag + "Luke Cage",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Marvel's 616"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Luke Cage/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(LukeCage);
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = DefendersTag + "Hand Agent",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Marvel's 616"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Hand Agent/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(HandAgent);
                    }
                }
            );
        }
    }
}