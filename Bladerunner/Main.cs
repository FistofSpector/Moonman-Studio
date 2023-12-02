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
    public class Mod
    {
        public static void Main() 
        {
            
    CategoryBuilder.Create("Blade Runner", "Blade Runner", ModAPI.LoadSprite("thumb.png"));

   ModAPI.Register(
   new Modification()
   {
       //Rick Beckard
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = "Rick Deckard", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("Blade Runner"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Deckard/thumb.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {
       
           //load textures for each layer (see Human textures folder in this repository)
           var skin = ModAPI.LoadTexture("People/Deckard/Skin.png");
           var flesh = ModAPI.LoadTexture("People/Base/Flesh.png");
           var bone = ModAPI.LoadTexture("People/Base/Bone.png");

           //get person
           var person = Instance.GetComponent<PersonBehaviour>();
       person.SetBodyTextures(skin, flesh, bone, 1);
       }
   }  
        );

        }
}
}