using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
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
    public class ResourceStorage : MonoBehaviour
    {
        public Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();
        public Dictionary<string, Sprite> Sprites = new Dictionary<string, Sprite>();
        public Dictionary<string, AudioClip> Sounds = new Dictionary<string, AudioClip>();

        public static Sprite CapeBase = ModAPI.LoadSprite("People/Thor/cape01.png");
        public static Sprite Cape = ModAPI.LoadSprite("People/Thor/cape02.png");




}


    public class Mod
    {
        public static string WpTag = "[Weapon]";
        public static string F4Tag = "[F4]";
        public static string XTag = "[X-Men]";
        public static string AVTag = "[Avenger]";
        public static string GRTag = "[Street Level]";
        public static string InTag = "[Inhuman +]";
        public static string VLTag = "[Villian]";
        public static void Main() 
        {
            
    CategoryBuilder.Create("616", "A Marvel Universe", ModAPI.LoadSprite("thumb.png"));

   ModAPI.Register(
   new Modification()
   {
       //Mr. Fantastic
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = F4Tag + "Mr. Fantastic", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("616"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Reed Richards/thumb.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {
       
           //load textures for each layer (see Human textures folder in this repository)
           var skin = ModAPI.LoadTexture("People/Reed Richards/Skin.png");
           var flesh = ModAPI.LoadTexture("People/Base/Flesh.png");
           var bone = ModAPI.LoadTexture("People/Base/Bone.png");

           //get person
           var person = Instance.GetComponent<PersonBehaviour>();
       person.SetBodyTextures(skin, flesh, bone, 1);
           PPF.PowerPackFrameworkFunctions.AddSkin(person, ModAPI.LoadTexture("People/Reed Richards/Skins/White.png"), "White Suit", "White Suit");
       }
   }  
        );
            ModAPI.Register(
new Modification()
{
    //Ms. Fantastic
    OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = F4Tag + "Ms. Fantastic", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("616"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Sue Storm/thumb.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {
       
           //load textures for each layer (see Human textures folder in this repository)
           var skin = ModAPI.LoadTexture("People/Sue Storm/Skin.png");
           var flesh = ModAPI.LoadTexture("People/Base/Flesh.png");
           var bone = ModAPI.LoadTexture("People/Base/Bone.png");

           //get person
           var person = Instance.GetComponent<PersonBehaviour>();
       person.SetBodyTextures(skin, flesh, bone, 1);
       PPF.PowerPackFrameworkFunctions.AddSkin(person, ModAPI.LoadTexture("People/Sue Storm/Skins/White.png"), "White Suit", "White Suit");
       }
   }  
        );
                                                ModAPI.Register(
            new Modification()
            {
                //The Thing
                OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
                NameOverride = F4Tag + "The Thing", //new item name with a suffix to assure it is globally unique
                DescriptionOverride = "Its Colbering Time - Ben Grimm", //new item description
                CategoryOverride = ModAPI.FindCategory("616"), //new item category
                ThumbnailOverride = ModAPI.LoadSprite("People/Ben Grimm/thumb.png"), //new item thumbnail (relative path)
                AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
                {


                    //get person
                    var person = Instance.GetComponent<PersonBehaviour>();


                    //load textures for each layer (see Human textures folder in this repository)
                    var skin = ModAPI.LoadTexture("People/Ben Grimm/Skin.png");
                    var flesh = ModAPI.LoadTexture("People/Base/Flesh.png");
                    var bone = ModAPI.LoadTexture("People/Base/Bone.png");

                    //use the helper function to set each texture
                    //parameters are as follows: 
                    //  skin texture, flesh texture, bone texture, sprite scale
                    //you can pass "null" to fall back to the original texture
                    person.SetBodyTextures(skin, flesh, bone, 1);

                    foreach (var Limbs in person.Limbs)
                    {
                        Limbs.transform.root.localScale *= 1.01f;
                    }
       PPF.PowerPackFrameworkFunctions.AddSkin(person, ModAPI.LoadTexture("People/Ben Grimm/Skins/White.png"), "White Suit", "White Suit");
                }
            }
        );

        }
}
}