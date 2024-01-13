using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using FrameworkFunctions;
namespace Mod
{
    // _________ _______  _______  _______            _________ _        _______  _______  _       
    // \__   __/(  ____ \(  ___  )(       )  |\     /|\__   __/( \      (  ____ \(  ___  )( (    /|  
    //    ) (   | (    \/| (   ) || () () |  | )   ( |   ) (   | (      | (    \/| (   ) ||  \  ( |  
    //    | |   | (__    | (___) || || || |  | | _ | |   | |   | |      | (_____ | |   | ||   \ | |  
    //    | |   |  __)   |  ___  || |(_)| |  | |( )| |   | |   | |      (_____  )| |   | || (\ \) |  
    //    | |   | (      | (   ) || |   | |  | || || |   | |   | |            ) || |   | || | \   |  
    //    | |   | (____/\| )   ( || )   ( |  | () () |___) (___| (____/\/\____) || (___) || )  \  |  
    //    )_(   (_______/|/     \||/     \|  (_______)\_______/(_______/\_______)(_______)|/    )_)  
    //
    // This framework was created by Team Wilson and is allowed to be used in any mod as long as The Power Pack Framework is a required mod (otherwise may be errors).
    // Link to PPF: https://steamcommunity.com/sharedfiles/filedetails/?id=2506978276
    // Framework coded by 🥧 Camdog74 🥧
    // VERSION 2.0.0


    //This is where you store all of your assets like your sprites, textures and sounds. (power icons too)
    public class Mod
    {
        public static string WpTag = "[Weapon]";
        public static string DFTag = "[Defender]";
        public static void Main() 
        {
            
    CategoryBuilder.Create("616", "A Marvel Universe", ModAPI.LoadSprite("thumb.png"));
            var MattMurdock = ModAPI.LoadTexture("People/Daredevil/Skins/Matt Murdock.png");
            var DaredevilUnmasked = ModAPI.LoadTexture("People/Daredevil/Skins/Unmasked.png");
            var ManWithoutFear = ModAPI.LoadTexture("People/Daredevil/Skins/Man Without Fear.png");
            var ManWithoutFearhead = ModAPI.LoadSprite("People/Daredevil/Skins/Man Without Fear Head.png");
            var DDNetflixSuit = ModAPI.LoadTexture("People/Daredevil/Skins/Netflix.png");
            var YellowSuit = ModAPI.LoadTexture("People/Daredevil/Skins/OG.png");
            var BlackRed = ModAPI.LoadTexture("People/Daredevil/Skins/Black Red.png");
            var KingDaredevil = ModAPI.LoadTexture("People/Daredevil/Skins/King Daredevil.png");
            var DaredevilBeard = ModAPI.LoadSprite("People/Daredevil/Skins/King Daredevil Beard.png");
            var Daredevil = ModAPI.LoadTexture("People/Daredevil/Skin.png");
            var LukeCage = ModAPI.LoadTexture("People/Luke Cage/Skin.png");
            var Bullseye = ModAPI.LoadTexture("People/Bullseye/Skin.png");
            var Kingpin = ModAPI.LoadTexture("People/Kingpin/Skin.png");
            var KingpinCoat = ModAPI.LoadSprite("People/Kingpin/Coat.png");
            var Echo = ModAPI.LoadTexture("People/Echo/Skin.png");
            var EchoHair = ModAPI.LoadSprite("People/Echo/Hair.png");
            var Ironfist = ModAPI.LoadTexture("People/Iron Fist/Skin.png");
            var IronfistHead = ModAPI.LoadSprite("People/Iron Fist/Head.png");
            var IronfistWhite = ModAPI.LoadTexture("People/Iron Fist/Skins/White.png");
            var TheHand = ModAPI.LoadTexture("People/Hand Agent/Skin.png");
            var TheHandHead = ModAPI.LoadSprite("People/Hand Agent/Head.png");
            var Elektra = ModAPI.LoadTexture("People/Elektra/Skin.png");
            var ElekrtaDaredevil = ModAPI.LoadTexture("People/Elektra/Skins/Daredevil.png");
            var ElekrtaDaredevilHair = ModAPI.LoadSprite("People/Elektra/Skins/Hair.png");
            ModAPI.Register(
   new Modification()
   {
       //Daredevil
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = DFTag + "Daredevil", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("616"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Daredevil/thumb.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {

           //load textures for each layer (see Human textures folder in this repository)
           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(Daredevil);

           //get person
           var skinManager = Instance.AddComponent<SkinManager>();
           skinManager.AddSkin(DaredevilUnmasked);
           skinManager.AddSkin(MattMurdock);
           skinManager.AddSkin(ManWithoutFear);
           skinManager.AddAccessory(ManWithoutFear, person.Limbs[0], ManWithoutFearhead, new Vector2(0f, .01f));
           skinManager.AddSkin(DDNetflixSuit);
           skinManager.AddSkin(YellowSuit);
           skinManager.AddSkin(BlackRed);
           skinManager.AddSkin(KingDaredevil);
           skinManager.AddAccessory(KingDaredevil, person.Limbs[0], DaredevilBeard, new Vector2(-.0121f, .0451f));
           skinManager.AddSkin(Daredevil);

           foreach (var Limbs in Instance.GetComponent<PersonBehaviour>().Limbs)
           {
               if (Limbs.gameObject.name.Contains("ArmFront"))
               {
                   Limbs.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
               }
           }
           }
   }  
        );
                           ModAPI.Register(
   new Modification()
   {
       //Luke Cage
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = DFTag + "Luke Cage", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("616"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Luke Cage/thumb.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {

           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(LukeCage);

       }
   }  
        );
                                       ModAPI.Register(
   new Modification()
   {
       //Bullseye
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = DFTag + "Bullseye", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("616"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Bullseye/thumb.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {


           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(Bullseye);

       }
   }  
        );
                                                   ModAPI.Register(
   new Modification()
   {
       //Kingpin
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = DFTag + "Kingpin", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("616"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Kingpin/thumb.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {


           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(Kingpin);

           var skinManager = Instance.AddComponent<SkinManager>();

           skinManager.CreateAccessoryOnLimb(person.Limbs[3], KingpinCoat, new Vector2(-0.0421f, -0.37f));

           foreach (var Limbs in Instance.GetComponent<PersonBehaviour>().Limbs)
           {
               if (Limbs.gameObject.name.Contains("ArmFront"))
               {
                   Limbs.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
               }
           }

       }
   }  
        );
                                                               ModAPI.Register(
   new Modification()
   {
       //Iron Fist
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = DFTag + "Iron Fist", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("616"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Iron fist/thumb.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {


           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(Ironfist);

           var skinManager = Instance.AddComponent<SkinManager>();

           skinManager.CreateAccessoryOnLimb(person.Limbs[0], IronfistHead, new Vector2(0f, 0f));

           skinManager.AddSkin(IronfistWhite);
           skinManager.AddAccessory(IronfistWhite, person.Limbs[0], IronfistHead, new Vector2(0f, .01f));

           foreach (var Limbs in Instance.GetComponent<PersonBehaviour>().Limbs)
           {
               if (Limbs.gameObject.name.Contains("ArmFront"))
               {
                   Limbs.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
               }
           }

       }
   }  
        );
                                                                           ModAPI.Register(
   new Modification()
   {
       //Echo
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = DFTag + "Echo", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("616"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Echo/thumb.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {


           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(Echo);

           var skinManager = Instance.AddComponent<SkinManager>();

           skinManager.CreateAccessoryOnLimb(person.Limbs[0], EchoHair, new Vector2(0f, 0f));

           foreach (var Limbs in Instance.GetComponent<PersonBehaviour>().Limbs)
           {
               if (Limbs.gameObject.name.Contains("ArmFront"))
               {
                   Limbs.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
               }
           }

       }
   }  
        );
                                                                                       ModAPI.Register(
   new Modification()
   {
       //The Hand Ninja
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = DFTag + "The Hand Ninja", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("616"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Hand Agent/thumb.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {


           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(TheHand);

           var skinManager = Instance.AddComponent<SkinManager>();

           skinManager.CreateAccessoryOnLimb(person.Limbs[0], TheHandHead, new Vector2(0f,0f));

           foreach (var Limbs in Instance.GetComponent<PersonBehaviour>().Limbs)
           {
               if (Limbs.gameObject.name.Contains("ArmFront"))
               {
                   Limbs.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
               }
           }

       }
   }  
        );
        }
}
}