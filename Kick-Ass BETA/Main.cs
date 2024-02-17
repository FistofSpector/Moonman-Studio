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
        public static string WpTag = "[Weapon]";
        public static string AMTag = "[Armor]";
        public static string CBTag = "[Comics]";
        public static string MVTag = "[Movies]";
        public static void Main() 
        {
            
    CategoryBuilder.Create("Kick-Ass", "The Comics", ModAPI.LoadSprite("thumb.png"));
            var KickAss = ModAPI.LoadTexture("People/Kick Ass/Skin.png");
            var Todd = ModAPI.LoadTexture("People/Todd Haynes/Skin.png");
            var ToddCape = ModAPI.LoadSprite("People/Todd Haynes/Cape.png");
            var Thug1 = ModAPI.LoadTexture("People/Thug/Thug 1.png");
            var Thug2 = ModAPI.LoadTexture("People/Thug/Thug 2.png");
            var Thug3 = ModAPI.LoadTexture("People/Thug/Thug 3.png");
            var HitGirlMovie = ModAPI.LoadTexture("People/Hit-Girl/Skin2.png");
            var HitGirl = ModAPI.LoadTexture("People/Hit-Girl/Skin.png");
            var HitGirlPonyTail = ModAPI.LoadSprite("People/Hit-girl/Head.png");
            var BigDaddy = ModAPI.LoadTexture("People/Big Daddy/Skin.png");
            var BigDaddyCoat = ModAPI.LoadSprite("People/Big Daddy/Coat.png");
            var BigDaddyMovie = ModAPI.LoadTexture("People/Big Daddy/Skins/Movie.png");
            var BigDaddyMovieHead = ModAPI.LoadSprite("People/Big Daddy/Skins/MovieHead.png");
            var MotherF = ModAPI.LoadTexture("People/Mother F'er/Skin.png");
            var FrankDamico = ModAPI.LoadTexture("People/Frank D'amico /Skin.png");
            var NightBitch = ModAPI.LoadTexture("People/Night Bitch/Skin.png");
            var MotherFComic = ModAPI.LoadTexture("People/Mother F'er/Skins/Comic.png");
            var MotherFBeard = ModAPI.LoadSprite("People/Mother F'er/Beard.png");
            var MotherFCape = ModAPI.LoadSprite("People/Mother F'er/Cape.png");
            var MotherFMovie = ModAPI.LoadTexture("People/Mother F'er/Skins/Movie.png");
            var BlackDeath = ModAPI.LoadTexture("People/Black Death/Skin.png");
            var Tumor = ModAPI.LoadTexture("People/Tumor/Skin.png");

            ModAPI.Register(
   new Modification()
   {
       //Kick-Ass
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = CBTag + "Kick-Ass", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "What's the difference between Spider-Man and Peter Parker? Spider-Man gets the girl. - Kick-Ass", //new item description
       CategoryOverride = ModAPI.FindCategory("Kick-Ass"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Kick Ass/thumb.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {
           //load textures for each layer (see Human textures folder in this repository)
           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(KickAss);
           foreach (LimbBehaviour Limb in person.Limbs)
           {
               Limb.BreakingThreshold *= 200f;
               Limb.ImpactPainMultiplier = 0f;
               Limb.Vitality *= 200f;
               Limb.Health *= 200f;
               Limb.InitialHealth *= 200f;
           }
        }
   }  
        );
                        ModAPI.Register(
   new Modification()
   {
       //Thug
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = MVTag + "Thug", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("Kick-Ass"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Thug/thumb.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {

           //load textures for each layer (see Human textures folder in this repository)
           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(Thug1);

       }
   }  
        ); 
                                    ModAPI.Register(
   new Modification()
   {
       //Thug 2
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = MVTag + "Thug 2", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("Kick-Ass"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Thug/thumb2.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {

           //load textures for each layer (see Human textures folder in this repository)
           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(Thug2);

       }
   }  
        ); 

                                    ModAPI.Register(
   new Modification()
   {
       //Thug 3
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = MVTag + "Thug 3", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("Kick-Ass"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Thug/thumb3.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {

           //load textures for each layer (see Human textures folder in this repository)
           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(Thug3);

       }
   }  
        ); 
                                       ModAPI.Register(
   new Modification()
   {
       //Big Daddy CB
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = CBTag + "Big Daddy", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("Kick-Ass"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Big Daddy/Thumb.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {

           //get person
           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(BigDaddy);

           foreach (var Limbs in person.Limbs)
           {
               Limbs.transform.root.localScale *= 1.01f;
           }
           var HG = new GameObject("HG");
           HG.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
           HG.transform.localPosition = new Vector3(-0.0421f, -0.37f);
           HG.transform.localScale = new Vector3(1f, 1f);
           var HGSprite = HG.AddComponent<SpriteRenderer>();
           HGSprite.sprite = ModAPI.LoadSprite("People/Big Daddy/Coat.png");
           HG.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

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
       //Frank D'amico 
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = MVTag + "Frank D'amico ", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("Kick-Ass"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Frank D'amico/thumb.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {

           //load textures for each layer (see Human textures folder in this repository)
           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(FrankDamico);

       }
   }  
        );
                                                   ModAPI.Register(
   new Modification()
   {
       //Big Daddy Movies
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = MVTag + "Big Daddy", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("Kick-Ass"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Big Daddy/Thumb2.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {

           //get person
           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(BigDaddyMovie);

           foreach (var Limbs in person.Limbs)
           {
               Limbs.transform.root.localScale *= 1.01f;
           }
           var HG = new GameObject("HG");
           HG.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
           HG.transform.localPosition = new Vector3(0.0142f, 0f);
           HG.transform.localScale = new Vector3(1f, 1f);
           var HGSprite = HG.AddComponent<SpriteRenderer>();
           HGSprite.sprite = ModAPI.LoadSprite("People/Todd Haynes/Cape.png");
           HG.GetComponent<SpriteRenderer>().sortingLayerName = "Top";


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
       //Hit-Girl
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = CBTag + "Hit-Girl", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("Kick-Ass"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Hit-Girl/thumb.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {
           //load textures for each layer (see Human textures folder in this repository)
           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(HitGirl);
           foreach (var Limbs in person.Limbs)
           {
               Limbs.transform.root.localScale *= 0.991f;
           }
         
          
           var KA = new GameObject("TC");
           KA.transform.SetParent(Instance.transform.Find("Head"));
           KA.transform.localPosition = new Vector3(-0.0101f, 0.0401f);
           KA.transform.localScale = new Vector3(1f, 1f);
           var KASprite = KA.AddComponent<SpriteRenderer>();
           KASprite.sprite = ModAPI.LoadSprite("People/Hit-girl/Head.png");
           KA.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

           var HG = new GameObject("HG");
           HG.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
           HG.transform.localPosition = new Vector3(0.0142f, 0f);
           HG.transform.localScale = new Vector3(1f, 1f);
           var HGSprite = HG.AddComponent<SpriteRenderer>();
           HGSprite.sprite = ModAPI.LoadSprite("People/Todd Haynes/Cape.png");
           HG.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
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
       //Hit-Girl
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = MVTag + "Hit-Girl Movies", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("Kick-Ass"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Hit-Girl/thumb2.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {
           //load textures for each layer (see Human textures folder in this repository)
           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(HitGirlMovie);
           foreach (var Limbs in person.Limbs)
           {
               Limbs.transform.root.localScale *= 0.991f;
           }

           var HG = new GameObject("HG");
           HG.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
           HG.transform.localPosition = new Vector3(0.0142f, 0f);
           HG.transform.localScale = new Vector3(1f, 1f);
           var HGSprite = HG.AddComponent<SpriteRenderer>();
           HGSprite.sprite = ModAPI.LoadSprite("People/Todd Haynes/Cape.png");
           HG.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
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
       //Todd Haynes
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = CBTag + "Todd Haynes", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("Kick-Ass"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Todd Haynes/Thumb.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {
           //load textures for each layer (see Human textures folder in this repository)
           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(Todd);
         

           var HG = new GameObject("HG");
           HG.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
           HG.transform.localPosition = new Vector3(0.0142f, 0f);
           HG.transform.localScale = new Vector3(1f, 1f);
           var HGSprite = HG.AddComponent<SpriteRenderer>();
           HGSprite.sprite = ModAPI.LoadSprite("People/Todd Haynes/Cape.png");
           HG.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

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
       //Mother F'er
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = CBTag + "Mother F'er", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("Kick-Ass"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Mother F'er/Thumb2.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {
           //load textures for each layer (see Human textures folder in this repository)
           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(MotherFComic);
          

           var KA = new GameObject("TC");
           KA.transform.SetParent(Instance.transform.Find("Head"));
           KA.transform.localPosition = new Vector3(-0.0142f, 0.06f);
           KA.transform.localScale = new Vector3(1f, 1f);
           var KASprite = KA.AddComponent<SpriteRenderer>();
           KASprite.sprite = ModAPI.LoadSprite("People/Mother F'er/Beard.png");
           KA.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

           var HG = new GameObject("HG");
           HG.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
           HG.transform.localPosition = new Vector3(0.0142f, 0f);
           HG.transform.localScale = new Vector3(1f, 1f);
           var HGSprite = HG.AddComponent<SpriteRenderer>();
           HGSprite.sprite = ModAPI.LoadSprite("People/Mother F'er/Cape.png");
           HG.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

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
       //Mother F'er
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = MVTag + "Mother F'er", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("Kick-Ass"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Mother F'er/Thumb.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {
           //load textures for each layer (see Human textures folder in this repository)
           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(MotherF);

           var HG = new GameObject("HG");
           HG.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
           HG.transform.localPosition = new Vector3(0.0142f, 0f);
           HG.transform.localScale = new Vector3(1f, 1f);
           var HGSprite = HG.AddComponent<SpriteRenderer>();
           HGSprite.sprite = ModAPI.LoadSprite("People/Todd Haynes/Cape.png");
           HG.GetComponent<SpriteRenderer>().sortingLayerName = "Top";


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
       //Night Bitch
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = MVTag + "Night Bitch", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("Kick-Ass"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Night Bitch/thumb.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {
           //load textures for each layer (see Human textures folder in this repository)
           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(NightBitch);
           var KA = new GameObject("TC");
           KA.transform.SetParent(Instance.transform.Find("Head"));
           KA.transform.localPosition = new Vector3(-0.0101f, 0.0401f);
           KA.transform.localScale = new Vector3(1f, 1f);
           var KASprite = KA.AddComponent<SpriteRenderer>();
           KASprite.sprite = ModAPI.LoadSprite("People/Night Bitch/Head.png");
           KA.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

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
       //Black Death
       OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
       NameOverride = MVTag + "Black Death", //new item name with a suffix to assure it is globally unique
       DescriptionOverride = "", //new item description
       CategoryOverride = ModAPI.FindCategory("Kick-Ass"), //new item category
       ThumbnailOverride = ModAPI.LoadSprite("People/Black Death/Thumb.png"), //new item thumbnail (relative path)
       AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
       {

           //get person
           var person = Instance.GetComponent<PersonBehaviour>();
           person.SetBodyTextures(BlackDeath);

           var HG = new GameObject("HG");
           HG.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
           HG.transform.localPosition = new Vector3(-0.0421f, -0.37f);
           HG.transform.localScale = new Vector3(1f, 1f);
           var HGSprite = HG.AddComponent<SpriteRenderer>();
           HGSprite.sprite = ModAPI.LoadSprite("People/Black Death/Coat.png");
           HG.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

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
            //Weapons
            ModAPI.Register(
               new Modification()
               {
                   OriginalItem = ModAPI.FindSpawnable("Sword"), //item to derive from
                   NameOverride = "Hit-Girls Sword", //new item name with a suffix to assure it is globally unique
                   DescriptionOverride = "Hit-Girls Sword.", //new item description
                   CategoryOverride = ModAPI.FindCategory("Kick-Ass"), //new item category
                   ThumbnailOverride = ModAPI.LoadSprite("Weapons/Sword/Thumb.png"), //new item thumbnail (relative path)
                   AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
                   {
                       //setting the sprite
                       Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Weapons/Sword/Art.png");

                       Instance.FixColliders();
                   }
               }
           );
                        ModAPI.Register(
               new Modification()
               {
                   OriginalItem = ModAPI.FindSpawnable("Baseball Bat"), //item to derive from
                   NameOverride = "Kick-Asses Batons", //new item name with a suffix to assure it is globally unique
                   DescriptionOverride = "Kick-Asses Batons.", //new item description
                   CategoryOverride = ModAPI.FindCategory("Kick-Ass"), //new item category
                   ThumbnailOverride = ModAPI.LoadSprite("Weapons/Baton/Thumb.png"), //new item thumbnail (relative path)
                   AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
                   {
                       //setting the sprite
                       Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Weapons/Baton/Art.png", 1);

                       Instance.FixColliders();
                   }
               }
           );
            //Armor
            ModAPI.Register(
new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Bulletproof Sheet"),
        NameOverride = AMTag + MVTag + "Big Daddys Movie Armor", 
        NameToOrderByOverride = "KA",
        DescriptionOverride = "Big Daddys Armor", 
        CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
        ThumbnailOverride = ModAPI.LoadSprite("Armor/Big Daddy/Thumb.png"),
        AfterSpawn = (Instance) => 
        {
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/Big Daddy/Armor/Helmet.png");
            Instance.GetComponent<PhysicalBehaviour>().HoldingPositions = new Vector3[0];
            Instance.GetComponent<PhysicalBehaviour>().InitialMass = 0.01f;
            Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = 0.01f;

            int PartCount = 14;

            if (!Instance.GetComponent<ArmorBehaviour>())
            Instance.AddComponent<ArmorBehaviour>();

            ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
            ArmorProperties prop = new ArmorProperties();
            ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

            prop.armorPiece = "Head";
            prop.armorTier = 3;
            prop.scaleOffset = new Vector3(0f, 0f);
            prop.offset = new Vector3(-0.0142f, 0.0425f);
            prop.sprite = "Armor/Big Daddy/Armor/Helmet.png";
            armor.stabResistance = 15f;

            armProp[0].armorPiece = "UpperBody";
            armProp[0].armorTier = 3;
            armProp[0].scaleOffset = new Vector3(0f, 0f);
            armProp[0].offset = new Vector3(0f, 0f);
            armProp[0].sprite = "Armor/Big Daddy/Armor/UpperBody.png";
     

            armProp[1].armorPiece = "MiddleBody";
            armProp[1].armorTier = 3;
            armProp[1].scaleOffset = new Vector3(0f, 0f);
            armProp[1].offset = new Vector3(0f, 0f);
            armProp[1].sprite = "Armor/Big Daddy/Armor/MiddleBody.png";

            armProp[2].armorPiece = "LowerBody";
            armProp[2].armorTier = 3;
            armProp[2].scaleOffset = new Vector3(0f, 0f);
            armProp[2].offset = new Vector3(0.0f, 0f);
            armProp[2].sprite = "Armor/Big Daddy/Armor/LowerBody.png";

            armProp[3].armorPiece = "UpperArm";
            armProp[3].armorTier = 3;
            armProp[3].scaleOffset = new Vector3(0f, 0f);
            armProp[3].offset = new Vector3(0f, 0f);
            armProp[3].sprite = "Armor/Big Daddy/Armor/UpperArm.png";

            armProp[4].armorPiece = "LowerArm";
            armProp[4].armorTier = 3;
            armProp[4].scaleOffset = new Vector3(0f, 0f);
            armProp[4].offset = new Vector3(0f, -0f);
            armProp[4].sprite = "Armor/Big Daddy/Armor/LowerArm.png";

            armProp[5].armorPiece = "UpperLeg";
            armProp[5].armorTier = 3;
            armProp[5].scaleOffset = new Vector3(0f, 0f);
            armProp[5].offset = new Vector3(0f, 0f);
            armProp[5].sprite = "Armor/Big Daddy/Armor/UpperLeg.png";

            armProp[6].armorPiece = "LowerLeg";
            armProp[6].armorTier = 3;
            armProp[6].scaleOffset = new Vector3(0f, 0f);
            armProp[6].offset = new Vector3(0f, 0f);
            armProp[6].sprite = "Armor/Big Daddy/Armor/LowerLeg.png";

            armProp[7].armorPiece = "UpperArmFront";
            armProp[7].armorTier = 3;
            armProp[7].scaleOffset = new Vector3(.08f, .08f);
            armProp[7].offset = new Vector3(0f, 0f);
            armProp[7].sprite = "Armor/Big Daddy/Armor/UpperArm.png";
   
            armProp[8].armorPiece = "UpperLegFront";
            armProp[8].armorTier = 3;
            armProp[8].scaleOffset = new Vector3(0f, 0f);
            armProp[8].offset = new Vector3(0f, 0f);
            armProp[8].sprite = "Armor/Big Daddy/Armor/UpperLeg.png";

            armProp[9].armorPiece = "LowerLegFront";
            armProp[9].armorTier = 3;
            armProp[9].scaleOffset = new Vector3(0f, 0f);
            armProp[9].offset = new Vector3(0f, 0f);
            armProp[9].sprite = "Armor/Big Daddy/Armor/LowerLeg.png";

            armProp[10].armorPiece = "Foot";
            armProp[10].armorTier = 3;
            armProp[10].scaleOffset = new Vector3(0f, 0f);
            armProp[10].offset = new Vector3(0f, 0f);
            armProp[10].sprite = "Armor/Big Daddy/Armor/Foot.png";

            armProp[11].armorPiece = "FootFront";
            armProp[11].armorTier = 3;
            armProp[11].scaleOffset = new Vector3(0f, 0f);
            armProp[11].offset = new Vector3(0f, 0f);
            armProp[11].sprite = "Armor/Big Daddy/Armor/Foot.png";

            armProp[12].armorPiece = "LowerArmFront";
            armProp[12].armorTier = 3;
            armProp[12].scaleOffset = new Vector3(0f, 0f);
            armProp[12].offset = new Vector3(0f, 0f);
            armProp[12].sprite = "Armor/Big Daddy/Armor/LowerArm.png";

            armor.prop = prop;
            armor.SetProperties();
            if (armor.spawn)
            {
                armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                armor.SpawnOtherParts(armProp);
            }


            Instance.FixColliders();
      }
   }
);
                    
            ModAPI.Register(
new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Bulletproof Sheet"),
        NameOverride = AMTag + CBTag + "Hit Girls Movie Armor", 
        NameToOrderByOverride = "KA",
        DescriptionOverride = "Big Daddys Armor", 
        CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
        ThumbnailOverride = ModAPI.LoadSprite("Armor/Hit Girl/Thumb.png"),
        AfterSpawn = (Instance) => 
        {
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/Hit Girl/Armor/Mask.png");
            Instance.GetComponent<PhysicalBehaviour>().HoldingPositions = new Vector3[0];
            Instance.GetComponent<PhysicalBehaviour>().InitialMass = 0.01f;
            Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = 0.01f;

            int PartCount = 14;

            if (!Instance.GetComponent<ArmorBehaviour>())
            Instance.AddComponent<ArmorBehaviour>();

            ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
            ArmorProperties prop = new ArmorProperties();
            ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

            prop.armorPiece = "Head";
            prop.armorTier = 1;
            prop.scaleOffset = new Vector3(0f, 0f);
            prop.offset = new Vector3(0f, 0f);
            prop.sprite = "Armor/Hit Girl/Armor/Mask.png";
            armor.stabResistance = 15f;

            armProp[0].armorPiece = "UpperBody";
            armProp[0].armorTier = 1;
            armProp[0].scaleOffset = new Vector3(0f, 0f);
            armProp[0].offset = new Vector3(0f, 0f);
            armProp[0].sprite = "Armor/Hit Girl/Armor/UpperBody.png";
     

            armProp[1].armorPiece = "MiddleBody";
            armProp[1].armorTier = 1;
            armProp[1].scaleOffset = new Vector3(0f, 0f);
            armProp[1].offset = new Vector3(0f, 0f);
            armProp[1].sprite = "Armor/Hit Girl/Armor/MiddleBody.png";

            armProp[2].armorPiece = "LowerBody";
            armProp[2].armorTier = 1;
            armProp[2].scaleOffset = new Vector3(0f, 0f);
            armProp[2].offset = new Vector3(0f, 0f);
            armProp[2].sprite = "Armor/Hit Girl/Armor/LowerBody.png";

            armProp[3].armorPiece = "UpperArm";
            armProp[3].armorTier = 1;
            armProp[3].scaleOffset = new Vector3(0f, 0f);
            armProp[3].offset = new Vector3(0f, 0f);
            armProp[3].sprite = "Armor/Hit Girl/Armor/UpperArm.png";

            armProp[4].armorPiece = "LowerArm";
            armProp[4].armorTier = 1;
            armProp[4].scaleOffset = new Vector3(0f, 0f);
            armProp[4].offset = new Vector3(0f, -0f);
            armProp[4].sprite = "Armor/Hit Girl/Armor/LowerArm.png";

            armProp[5].armorPiece = "UpperLeg";
            armProp[5].armorTier = 1;
            armProp[5].scaleOffset = new Vector3(0f, 0f);
            armProp[5].offset = new Vector3(0f, 0f);
            armProp[5].sprite = "Armor/Hit Girl/Armor/UpperLeg.png";

            armProp[6].armorPiece = "LowerLeg";
            armProp[6].armorTier = 1;
            armProp[6].scaleOffset = new Vector3(0f, 0f);
            armProp[6].offset = new Vector3(0f, 0f);
            armProp[6].sprite = "Armor/Hit Girl/Armor/LowerLeg.png";

            armProp[7].armorPiece = "UpperArmFront";
            armProp[7].armorTier = 1;
            armProp[7].scaleOffset = new Vector3(.08f, .08f);
            armProp[7].offset = new Vector3(0f, 0f);
            armProp[7].sprite = "Armor/Hit Girl/Armor/UpperArm.png";
   
            armProp[8].armorPiece = "UpperLegFront";
            armProp[8].armorTier = 1;
            armProp[8].scaleOffset = new Vector3(0f, 0f);
            armProp[8].offset = new Vector3(0f, 0f);
            armProp[8].sprite = "Armor/Hit Girl/Armor/UpperLeg.png";

            armProp[9].armorPiece = "LowerLegFront";
            armProp[9].armorTier = 1;
            armProp[9].scaleOffset = new Vector3(0f, 0f);
            armProp[9].offset = new Vector3(0f, 0f);
            armProp[9].sprite = "Armor/Hit Girl/Armor/LowerLeg.png";

            armProp[10].armorPiece = "Foot";
            armProp[10].armorTier = 1;
            armProp[10].scaleOffset = new Vector3(0f, 0f);
            armProp[10].offset = new Vector3(0f, 0f);
            armProp[10].sprite = "Armor/Hit Girl/Armor/Foot.png";

            armProp[11].armorPiece = "FootFront";
            armProp[11].armorTier = 1;
            armProp[11].scaleOffset = new Vector3(0f, 0f);
            armProp[11].offset = new Vector3(0f, 0f);
            armProp[11].sprite = "Armor/Hit Girl/Armor/Foot.png";

            armProp[12].armorPiece = "LowerArmFront";
            armProp[12].armorTier = 1;
            armProp[12].scaleOffset = new Vector3(0f, 0f);
            armProp[12].offset = new Vector3(0f, 0f);
            armProp[12].sprite = "Armor/Hit Girl/Armor/LowerArm.png";

            armor.prop = prop;
            armor.SetProperties();
            if (armor.spawn)
            {
                armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                armor.SpawnOtherParts(armProp);
            }


            Instance.FixColliders();
      }
   }
);
                        ModAPI.Register(
new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Bulletproof Sheet"),
        NameOverride = AMTag + CBTag + "Hit Girls Comic Armor", 
        NameToOrderByOverride = "KA",
        DescriptionOverride = "Hit Girls Comic Armor", 
        CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
        ThumbnailOverride = ModAPI.LoadSprite("Armor/Hit Girl CB/Thumb.png"),
        AfterSpawn = (Instance) => 
        {
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/Hit Girl CB/Armor/Mask.png");
            Instance.GetComponent<PhysicalBehaviour>().HoldingPositions = new Vector3[0];
            Instance.GetComponent<PhysicalBehaviour>().InitialMass = 0.01f;
            Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = 0.01f;

            int PartCount = 14;

            if (!Instance.GetComponent<ArmorBehaviour>())
            Instance.AddComponent<ArmorBehaviour>();

            ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
            ArmorProperties prop = new ArmorProperties();
            ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

            prop.armorPiece = "Head";
            prop.armorTier = 1;
            prop.scaleOffset = new Vector3(0f, 0f);
            prop.offset = new Vector3(0f, 0f);
            prop.sprite = "Armor/Hit Girl CB/Armor/Mask.png";
            armor.stabResistance = 15f;

            armProp[0].armorPiece = "UpperBody";
            armProp[0].armorTier = 1;
            armProp[0].scaleOffset = new Vector3(0f, 0f);
            armProp[0].offset = new Vector3(0f, 0f);
            armProp[0].sprite = "Armor/Hit Girl CB/Armor/UpperBody.png";
     

            armProp[1].armorPiece = "MiddleBody";
            armProp[1].armorTier = 1;
            armProp[1].scaleOffset = new Vector3(0f, 0f);
            armProp[1].offset = new Vector3(0f, 0f);
            armProp[1].sprite = "Armor/Hit Girl CB/Armor/MiddleBody.png";

            armProp[2].armorPiece = "LowerBody";
            armProp[2].armorTier = 1;
            armProp[2].scaleOffset = new Vector3(0f, 0f);
            armProp[2].offset = new Vector3(0f, 0f);
            armProp[2].sprite = "Armor/Hit Girl CB/Armor/LowerBody.png";

            armProp[3].armorPiece = "UpperArm";
            armProp[3].armorTier = 1;
            armProp[3].scaleOffset = new Vector3(0f, 0f);
            armProp[3].offset = new Vector3(0f, 0f);
            armProp[3].sprite = "Armor/Hit Girl CB/Armor/UpperArm.png";

            armProp[4].armorPiece = "LowerArm";
            armProp[4].armorTier = 1;
            armProp[4].scaleOffset = new Vector3(0f, 0f);
            armProp[4].offset = new Vector3(0f, -0f);
            armProp[4].sprite = "Armor/Hit Girl CB/Armor/LowerArm.png";

            armProp[5].armorPiece = "UpperLeg";
            armProp[5].armorTier = 1;
            armProp[5].scaleOffset = new Vector3(0f, 0f);
            armProp[5].offset = new Vector3(0f, 0f);
            armProp[5].sprite = "Armor/Hit Girl CB/Armor/UpperLeg.png";

            armProp[6].armorPiece = "LowerLeg";
            armProp[6].armorTier = 1;
            armProp[6].scaleOffset = new Vector3(0f, 0f);
            armProp[6].offset = new Vector3(0f, 0f);
            armProp[6].sprite = "Armor/Hit Girl CB/Armor/LowerLeg.png";

            armProp[7].armorPiece = "UpperArmFront";
            armProp[7].armorTier = 1;
            armProp[7].scaleOffset = new Vector3(.08f, .08f);
            armProp[7].offset = new Vector3(0f, 0f);
            armProp[7].sprite = "Armor/Hit Girl CB/Armor/UpperArm.png";
   
            armProp[8].armorPiece = "UpperLegFront";
            armProp[8].armorTier = 1;
            armProp[8].scaleOffset = new Vector3(0f, 0f);
            armProp[8].offset = new Vector3(0f, 0f);
            armProp[8].sprite = "Armor/Hit Girl CB/Armor/UpperLeg.png";

            armProp[9].armorPiece = "LowerLegFront";
            armProp[9].armorTier = 1;
            armProp[9].scaleOffset = new Vector3(0f, 0f);
            armProp[9].offset = new Vector3(0f, 0f);
            armProp[9].sprite = "Armor/Hit Girl CB/Armor/LowerLeg.png";

            armProp[10].armorPiece = "Foot";
            armProp[10].armorTier = 1;
            armProp[10].scaleOffset = new Vector3(0f, 0f);
            armProp[10].offset = new Vector3(0f, 0f);
            armProp[10].sprite = "Armor/Hit Girl CB/Armor/Foot.png";

            armProp[11].armorPiece = "FootFront";
            armProp[11].armorTier = 1;
            armProp[11].scaleOffset = new Vector3(0f, 0f);
            armProp[11].offset = new Vector3(0f, 0f);
            armProp[11].sprite = "Armor/Hit Girl CB/Armor/Foot.png";

            armProp[12].armorPiece = "LowerArmFront";
            armProp[12].armorTier = 1;
            armProp[12].scaleOffset = new Vector3(0f, 0f);
            armProp[12].offset = new Vector3(0f, 0f);
            armProp[12].sprite = "Armor/Hit Girl CB/Armor/LowerArm.png";

            armor.prop = prop;
            armor.SetProperties();
            if (armor.spawn)
            {
                armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                armor.SpawnOtherParts(armProp);
            }


            Instance.FixColliders();
      }
   }
);


        }
}
}