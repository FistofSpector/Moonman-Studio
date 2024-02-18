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
        public static string WPTag = "<color=yellow>[Weapon]</color> ";
        public static string AMTag = "<color=grey>[Armor]</color> ";
        public static string CBTag = "<color=red>[Comics]</color> ";
        public static string MVTag = "<color=blue>[Movies]</color> ";

        public static void Main() 
        {    
            CategoryBuilder.Create("Kick-Ass", "", ModAPI.LoadSprite("Assets/Thumbnails/Category Thumb.png"));

            var DefaultCape = ModAPI.LoadSprite("Assets/Templates/Cape.png");
            var KickAss = ModAPI.LoadTexture("Assets/People/Kick-Ass/Skin.png");
            var Todd = ModAPI.LoadTexture("Assets/People/Todd Haynes/Skin.png");
            var Thug1 = ModAPI.LoadTexture("Assets/People/Thugs/Thug 1.png");
            var Thug2 = ModAPI.LoadTexture("Assets/People/Thugs/Thug 2.png");
            var Thug3 = ModAPI.LoadTexture("Assets/People/Thugs/Thug 3.png");
            var HitGirlMovie = ModAPI.LoadTexture("Assets/People/Hit-Girl/Skin2.png");
            var HitGirl = ModAPI.LoadTexture("Assets/People/Hit-Girl/Skin.png");
            var BigDaddy = ModAPI.LoadTexture("Assets/People/Big Daddy/Skin.png");
            var MotherFuckerCape = ModAPI.LoadSprite("Assets/People/Mother Fucker/Cape.png");
            var BigDaddyMovie = ModAPI.LoadTexture("Assets/People/Big Daddy/Skins/Movie.png");
            var MotherFucker = ModAPI.LoadTexture("Assets/People/Mother Fucker/Skin.png");
            var MotherFuckerComic = ModAPI.LoadTexture("Assets/People/Mother Fucker/Skins/Comic.png");
            var RedMist = ModAPI.LoadTexture("Assets/People/Mother Fucker/Skins/Movie.png");
            var Frank = ModAPI.LoadTexture("Assets/People/Frank D'Amico/Skin.png");
            var NightBitch = ModAPI.LoadTexture("Assets/People/Night Bitch/Skin.png");
            var TheTumor = ModAPI.LoadTexture("Assets/People/The Tumor/Skin.png");
            var BlackDeath = ModAPI.LoadTexture("Assets/People/Black Death/Skin.png");
            var LieutenantStripes = ModAPI.LoadTexture("Assets/People/Lieutenant Stripes/Skin.png");
            var GenghisCarnage = ModAPI.LoadTexture("Assets/People/Genghis Carnage/Skin.png");

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = CBTag + "Kick-Ass",
                    DescriptionOverride = "\"Come on, be honest with yourself. At some point in our lives, we all wanna be a superhero.\"",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Kick-Ass/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(KickAss);
                    }
                }  
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = MVTag + "Thug",
                    DescriptionOverride = "\"Whoa! It's only me, boss. Everything's under control.\"",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Thugs/thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(Thug1);
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = MVTag + "Thug 2",
                    DescriptionOverride = "\"I always wanted to say this. Say hello to my little friend!\"",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Thugs/thumb2.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(Thug2);
                    }
                }  
            ); 

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = MVTag + "Thug 3",
                    DescriptionOverride = "\"Fuck this shit, I'm getting the bazooka!\"",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Thugs/thumb3.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(Thug3);
                    }
                }
            );
            
            ModAPI.Register(
                new Modification()
                    {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = CBTag + "Big Daddy",
                    DescriptionOverride = "\"Mindy? No more homework, baby doll. It's time for Frank D'Amico to go bye-bye.\"",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Big Daddy/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(BigDaddy);

                        foreach (LimbBehaviour limb in person.Limbs)
                        {
                            limb.transform.root.localScale *= 1.01f;
                        }

                        var coat = new GameObject("Coat");
                        coat.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
                        coat.transform.localPosition = new Vector3(-0.0421f, -0.37f);
                        coat.transform.localScale = new Vector3(1f, 1f);
                        coat.transform.localRotation = Quaternion.identity;

                        var coatRenderer = coat.AddComponent<SpriteRenderer>();
                        coatRenderer.sprite = ModAPI.LoadSprite("Assets/People/Big Daddy/Coat.png");
                        coatRenderer.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

                        foreach (LimbBehaviour limb in person.Limbs)
                        {
                            if (limb.name.Contains("ArmFront"))
                            {
                                limb.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
                            }
                        }
                    }
                }  
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = MVTag + "Big Daddy",
                    DescriptionOverride = "\"Mindy? No more homework, baby doll. It's time for Frank D'Amico to go bye-bye.\"",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Big Daddy/Thumb2.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(BigDaddyMovie);

                        foreach (LimbBehaviour limb in person.Limbs)
                        {
                            limb.transform.root.localScale *= 1.01f;
                        }

                        new CapeBehaviour().AddToggleButton(person, DefaultCape, false);

                        foreach (LimbBehaviour limb in person.Limbs)
                        {
                            if (limb.name.Contains("ArmFront"))
                            {
                                limb.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
                            }
                        }
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = CBTag + "Hit-Girl",
                    DescriptionOverride = "\"If I ever catch you robbing again, shit-burger, I'm going to go to Saudi Arabia on your ass and cut your hand off.\"",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Hit-Girl/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(HitGirl);

                        foreach (LimbBehaviour limb in person.Limbs)
                        {
                            limb.transform.root.localScale *= 1.01f;
                        }

                        var hair = new GameObject("Hair");
                        hair.transform.SetParent(Instance.transform.Find("Head"));
                        hair.transform.localPosition = new Vector3(-0.0101f, 0.0401f);
                        hair.transform.localScale = new Vector3(1f, 1f);
                        hair.transform.localRotation = Quaternion.identity;

                        var hairRenderer = hair.AddComponent<SpriteRenderer>();
                        hairRenderer.sprite = ModAPI.LoadSprite("Assets/People/Hit-Girl/Hair.png");
                        hairRenderer.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

                        new CapeBehaviour().AddToggleButton(person, DefaultCape, false);

                        foreach (LimbBehaviour limb in person.Limbs)
                        {
                            if (limb.name.Contains("ArmFront"))
                            {
                                limb.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
                            }
                        }
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = MVTag + "Hit-Girl",
                    DescriptionOverride = "\"If I ever catch you robbing again, shit-burger, I'm going to go to Saudi Arabia on your ass and cut your hand off.\"",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Hit-Girl/thumb2.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(HitGirlMovie);

                        foreach (LimbBehaviour limb in person.Limbs)
                        {
                            limb.transform.root.localScale *= 1.01f;
                        }

                        new CapeBehaviour().AddToggleButton(person, DefaultCape, true);

                        foreach (LimbBehaviour limb in person.Limbs)
                        {
                            if (limb.name.Contains("ArmFront"))
                            {
                                limb.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
                            }
                        }
                    }
                }
            );
            
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = CBTag + "Todd Haynes",
                    DescriptionOverride = "\"Maybe it's a porn tape, He doesn't have a porn tape.\"",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Todd Haynes/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(Todd);

                        new CapeBehaviour().AddToggleButton(person, DefaultCape, true);

                        foreach (LimbBehaviour limb in person.Limbs)
                        {
                            if (limb.name.Contains("ArmFront"))
                            {
                                limb.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
                            }
                        }
                    }
                }  
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = CBTag + "Mother Fucker",
                    DescriptionOverride = "\"You made this real. You started it, and I'm going to end it! I'll be immortal, like an evil Jesus!\"",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Mother Fucker/Thumb2.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(MotherFuckerComic);

                        var beard = new GameObject("Beard");
                        beard.transform.SetParent(Instance.transform.Find("Head"));
                        beard.transform.localPosition = new Vector3(0f, 0f);
                        beard.transform.localScale = new Vector3(1f, 1f);
                        beard.transform.localRotation = Quaternion.identity;

                        var beardRenderer = beard.AddComponent<SpriteRenderer>();
                        beardRenderer.sprite = ModAPI.LoadSprite("Assets/People/Mother Fucker/Beard.png");
                        beardRenderer.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

                        new CapeBehaviour().AddToggleButton(person, MotherFuckerCape, true);

                        foreach (LimbBehaviour limb in person.Limbs)
                        {
                            if (limb.name.Contains("ArmFront"))
                            {
                                limb.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
                            }
                        }
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = MVTag + "Mother Fucker",
                    DescriptionOverride = "\"You made this real. You started it, and I'm going to end it! I'll be immortal, like an evil Jesus!\"",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Mother Fucker/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(MotherFucker);

                        new CapeBehaviour().AddToggleButton(person, DefaultCape, true);

                        foreach (LimbBehaviour limb in person.Limbs)
                        {
                            if (limb.name.Contains("ArmFront"))
                            {
                                limb.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
                            }
                        }
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = MVTag + "Red Mist",
                    DescriptionOverride = "\"As a great man once said.. \"Wait'll they get a load of me.\"\"",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Mother Fucker/Thumb3.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(RedMist);

                        new CapeBehaviour().AddToggleButton(person, MotherFuckerCape, true);

                        foreach (LimbBehaviour limb in person.Limbs)
                        {
                            if (limb.name.Contains("ArmFront"))
                            {
                                limb.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
                            }
                        }
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = MVTag + "Frank D'Amico",
                    DescriptionOverride = "\"I gotta send a public service message to the people out there that being a superhero is bad for your health.\"",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Frank D'Amico/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(Frank);
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = MVTag + "The Tumor",
                    DescriptionOverride = "\"Go ahead and shoot me, you little bitch. There's nothing you can do to make me talk.\"",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/The Tumor/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(TheTumor);
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = MVTag + "Black Death",
                    DescriptionOverride = "\"..\"",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Black Death/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(BlackDeath);

                        var coat = new GameObject("Coat");
                        coat.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
                        coat.transform.localPosition = new Vector3(-0.0421f, -0.37f);
                        coat.transform.localScale = new Vector3(1f, 1f);
                        coat.transform.localRotation = Quaternion.identity;

                        var coatRenderer = coat.AddComponent<SpriteRenderer>();
                        coatRenderer.sprite = ModAPI.LoadSprite("Assets/People/Black Death/Coat.png");
                        coatRenderer.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

                        foreach (LimbBehaviour limb in person.Limbs)
                        {
                            if (limb.name.Contains("ArmFront"))
                            {
                                limb.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
                            }
                        }
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = MVTag + "Night Bitch",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Night Bitch/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(NightBitch);

                        var hair = new GameObject("Hair");
                        hair.transform.SetParent(Instance.transform.Find("Head"));
                        hair.transform.localPosition = new Vector3(-0.0101f, 0.0401f);
                        hair.transform.localScale = new Vector3(1f, 1f);
                        hair.transform.localRotation = Quaternion.identity;

                        var hairRenderer = hair.AddComponent<SpriteRenderer>();
                        hairRenderer.sprite = ModAPI.LoadSprite("Assets/People/Night Bitch/Hair.png");
                        hairRenderer.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

                        foreach (LimbBehaviour limb in person.Limbs)
                        {
                            if (limb.name.Contains("ArmFront"))
                            {
                                limb.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
                            }
                        }
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = MVTag + "Genghis Carnage",
                    DescriptionOverride = "\"Leave it to Mother Russia..\"",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Genghis Carnage/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(GenghisCarnage);
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = MVTag + "Insect man",
                    DescriptionOverride = "\"I've been bullied my whole life for being gay; so, now I stand up for the defenseless.\"",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Insect Man/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(GenghisCarnage);
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = CBTag + "Lieutenant Stripes",
                    DescriptionOverride = "\"Try to have fun. Otherwise, what's the point?\"",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Lieutenant Stripes/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(LieutenantStripes);

                        foreach (LimbBehaviour limb in person.Limbs)
                        {
                            limb.transform.root.localScale *= 1.007f;
                        }

                        var mask = new GameObject("Mask");
                        mask.transform.SetParent(Instance.transform.Find("Head"));
                        mask.transform.localPosition = new Vector3(-0.0101f, 0.0401f);
                        mask.transform.localScale = new Vector3(1f, 1f);
                        mask.transform.localRotation = Quaternion.identity;

                        var maskRenderer = mask.AddComponent<SpriteRenderer>();
                        maskRenderer.sprite = ModAPI.LoadSprite("Assets/People/Lieutenant Stripes/Mask.png");
                        maskRenderer.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

                        foreach (LimbBehaviour limb in person.Limbs)
                        {
                            if (limb.name.Contains("ArmFront"))
                            {
                                limb.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
                            }
                        }
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Sword"),
                    NameOverride = WPTag + "Hit-Girl's Sword",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/Weapons/Sword/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Assets/Weapons/Sword/Art.png");
                        Instance.FixColliders();
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Baseball Bat"),
                    NameOverride = WPTag + "Kick-Ass's Batons",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/Weapons/Baton/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Assets/Weapons/Baton/Art.png", 1);
                        Instance.FixColliders();
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Bulletproof Sheet"),
                    NameOverride = AMTag + "Big Daddy's", 
                    NameToOrderByOverride = "KA",
                    DescriptionOverride = "", 
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/Armor/Big Daddy/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Assets/Armor/Big Daddy/Armor/Helmet.png");
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
                        prop.sprite = "Assets/Armor/Big Daddy/Armor/Helmet.png";
                        armor.stabResistance = 15f;

                        armProp[0].armorPiece = "UpperBody";
                        armProp[0].armorTier = 3;
                        armProp[0].scaleOffset = new Vector3(0f, 0f);
                        armProp[0].offset = new Vector3(0f, 0f);
                        armProp[0].sprite = "Assets/Armor/Big Daddy/Armor/UpperBody.png";

                        armProp[1].armorPiece = "MiddleBody";
                        armProp[1].armorTier = 3;
                        armProp[1].scaleOffset = new Vector3(0f, 0f);
                        armProp[1].offset = new Vector3(0f, 0f);
                        armProp[1].sprite = "Assets/Armor/Big Daddy/Armor/MiddleBody.png";

                        armProp[2].armorPiece = "LowerBody";
                        armProp[2].armorTier = 3;
                        armProp[2].scaleOffset = new Vector3(0f, 0f);
                        armProp[2].offset = new Vector3(0.0f, 0f);
                        armProp[2].sprite = "Assets/Armor/Big Daddy/Armor/LowerBody.png";

                        armProp[3].armorPiece = "UpperArm";
                        armProp[3].armorTier = 3;
                        armProp[3].scaleOffset = new Vector3(0f, 0f);
                        armProp[3].offset = new Vector3(0f, 0f);
                        armProp[3].sprite = "Assets/Armor/Big Daddy/Armor/UpperArm.png";

                        armProp[4].armorPiece = "LowerArm";
                        armProp[4].armorTier = 3;
                        armProp[4].scaleOffset = new Vector3(0f, 0f);
                        armProp[4].offset = new Vector3(0f, -0f);
                        armProp[4].sprite = "Assets/Armor/Big Daddy/Armor/LowerArm.png";

                        armProp[5].armorPiece = "UpperLeg";
                        armProp[5].armorTier = 3;
                        armProp[5].scaleOffset = new Vector3(0f, 0f);
                        armProp[5].offset = new Vector3(0f, 0f);
                        armProp[5].sprite = "Assets/Armor/Big Daddy/Armor/UpperLeg.png";

                        armProp[6].armorPiece = "LowerLeg";
                        armProp[6].armorTier = 3;
                        armProp[6].scaleOffset = new Vector3(0f, 0f);
                        armProp[6].offset = new Vector3(0f, 0f);
                        armProp[6].sprite = "Assets/Armor/Big Daddy/Armor/LowerLeg.png";

                        armProp[7].armorPiece = "UpperArmFront";
                        armProp[7].armorTier = 3;
                        armProp[7].scaleOffset = new Vector3(.08f, .08f);
                        armProp[7].offset = new Vector3(0f, 0f);
                        armProp[7].sprite = "Assets/Armor/Big Daddy/Armor/UpperArm.png";
            
                        armProp[8].armorPiece = "UpperLegFront";
                        armProp[8].armorTier = 3;
                        armProp[8].scaleOffset = new Vector3(0f, 0f);
                        armProp[8].offset = new Vector3(0f, 0f);
                        armProp[8].sprite = "Assets/Armor/Big Daddy/Armor/UpperLeg.png";

                        armProp[9].armorPiece = "LowerLegFront";
                        armProp[9].armorTier = 3;
                        armProp[9].scaleOffset = new Vector3(0f, 0f);
                        armProp[9].offset = new Vector3(0f, 0f);
                        armProp[9].sprite = "Assets/Armor/Big Daddy/Armor/LowerLeg.png";

                        armProp[10].armorPiece = "Foot";
                        armProp[10].armorTier = 3;
                        armProp[10].scaleOffset = new Vector3(0f, 0f);
                        armProp[10].offset = new Vector3(0f, 0f);
                        armProp[10].sprite = "Assets/Armor/Big Daddy/Armor/Foot.png";

                        armProp[11].armorPiece = "FootFront";
                        armProp[11].armorTier = 3;
                        armProp[11].scaleOffset = new Vector3(0f, 0f);
                        armProp[11].offset = new Vector3(0f, 0f);
                        armProp[11].sprite = "Assets/Armor/Big Daddy/Armor/Foot.png";

                        armProp[12].armorPiece = "LowerArmFront";
                        armProp[12].armorTier = 3;
                        armProp[12].scaleOffset = new Vector3(0f, 0f);
                        armProp[12].offset = new Vector3(0f, 0f);
                        armProp[12].sprite = "Assets/Armor/Big Daddy/Armor/LowerArm.png";

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
                    NameOverride = AMTag + "Hit-Girl's", 
                    NameToOrderByOverride = "KA",
                    DescriptionOverride = "", 
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/Armor/Hit-Girl/Thumb.png"),
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Assets/Armor/Hit-Girl/Armor/Mask.png");
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
                        prop.sprite = "Assets/Armor/Hit-Girl/Armor/Mask.png";
                        armor.stabResistance = 15f;

                        armProp[0].armorPiece = "UpperBody";
                        armProp[0].armorTier = 1;
                        armProp[0].scaleOffset = new Vector3(0f, 0f);
                        armProp[0].offset = new Vector3(0f, 0f);
                        armProp[0].sprite = "Assets/Armor/Hit-Girl/Armor/UpperBody.png";

                        armProp[1].armorPiece = "MiddleBody";
                        armProp[1].armorTier = 1;
                        armProp[1].scaleOffset = new Vector3(0f, 0f);
                        armProp[1].offset = new Vector3(0f, 0f);
                        armProp[1].sprite = "Assets/Armor/Hit-Girl/Armor/MiddleBody.png";

                        armProp[2].armorPiece = "LowerBody";
                        armProp[2].armorTier = 1;
                        armProp[2].scaleOffset = new Vector3(0f, 0f);
                        armProp[2].offset = new Vector3(0f, 0f);
                        armProp[2].sprite = "Assets/Armor/Hit-Girl/Armor/LowerBody.png";

                        armProp[3].armorPiece = "UpperArm";
                        armProp[3].armorTier = 1;
                        armProp[3].scaleOffset = new Vector3(0f, 0f);
                        armProp[3].offset = new Vector3(0f, 0f);
                        armProp[3].sprite = "Assets/Armor/Hit-Girl/Armor/UpperArm.png";

                        armProp[4].armorPiece = "LowerArm";
                        armProp[4].armorTier = 1;
                        armProp[4].scaleOffset = new Vector3(0f, 0f);
                        armProp[4].offset = new Vector3(0f, -0f);
                        armProp[4].sprite = "Assets/Armor/Hit-Girl/Armor/LowerArm.png";

                        armProp[5].armorPiece = "UpperLeg";
                        armProp[5].armorTier = 1;
                        armProp[5].scaleOffset = new Vector3(0f, 0f);
                        armProp[5].offset = new Vector3(0f, 0f);
                        armProp[5].sprite = "Assets/Armor/Hit-Girl/Armor/UpperLeg.png";

                        armProp[6].armorPiece = "LowerLeg";
                        armProp[6].armorTier = 1;
                        armProp[6].scaleOffset = new Vector3(0f, 0f);
                        armProp[6].offset = new Vector3(0f, 0f);
                        armProp[6].sprite = "Assets/Armor/Hit-Girl/Armor/LowerLeg.png";

                        armProp[7].armorPiece = "UpperArmFront";
                        armProp[7].armorTier = 1;
                        armProp[7].scaleOffset = new Vector3(.08f, .08f);
                        armProp[7].offset = new Vector3(0f, 0f);
                        armProp[7].sprite = "Assets/Armor/Hit-Girl/Armor/UpperArm.png";
            
                        armProp[8].armorPiece = "UpperLegFront";
                        armProp[8].armorTier = 1;
                        armProp[8].scaleOffset = new Vector3(0f, 0f);
                        armProp[8].offset = new Vector3(0f, 0f);
                        armProp[8].sprite = "Assets/Armor/Hit-Girl/Armor/UpperLeg.png";

                        armProp[9].armorPiece = "LowerLegFront";
                        armProp[9].armorTier = 1;
                        armProp[9].scaleOffset = new Vector3(0f, 0f);
                        armProp[9].offset = new Vector3(0f, 0f);
                        armProp[9].sprite = "Assets/Armor/Hit-Girl/Armor/LowerLeg.png";

                        armProp[10].armorPiece = "Foot";
                        armProp[10].armorTier = 1;
                        armProp[10].scaleOffset = new Vector3(0f, 0f);
                        armProp[10].offset = new Vector3(0f, 0f);
                        armProp[10].sprite = "Assets/Armor/Hit-Girl/Armor/Foot.png";

                        armProp[11].armorPiece = "FootFront";
                        armProp[11].armorTier = 1;
                        armProp[11].scaleOffset = new Vector3(0f, 0f);
                        armProp[11].offset = new Vector3(0f, 0f);
                        armProp[11].sprite = "Assets/Armor/Hit-Girl/Armor/Foot.png";

                        armProp[12].armorPiece = "LowerArmFront";
                        armProp[12].armorTier = 1;
                        armProp[12].scaleOffset = new Vector3(0f, 0f);
                        armProp[12].offset = new Vector3(0f, 0f);
                        armProp[12].sprite = "Assets/Armor/Hit-Girl/Armor/LowerArm.png";

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
                    NameOverride = AMTag + "Misc", 
                    NameToOrderByOverride = "KA",
                    DescriptionOverride = "", 
                    CategoryOverride = ModAPI.FindCategory("Kick-Ass"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/Armor/Misc/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Assets/Armor/Misc/Armor/Mask.png");
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
                        prop.armorTier = 4;
                        prop.scaleOffset = new Vector3(0f, 0f);
                        prop.offset = new Vector3(0f, 0f);
                        prop.sprite = "Assets/Armor/Misc/Armor/Mask.png";
                        armor.stabResistance = 15f;

                        armProp[0].armorPiece = "UpperBody";
                        armProp[0].armorTier = 5;
                        armProp[0].scaleOffset = new Vector3(0f, 0f);
                        armProp[0].offset = new Vector3(0f, 0f);
                        armProp[0].sprite = "Assets/Armor/Misc/Armor/UpperBody.png";
                        
                        armProp[1].armorPiece = "MiddleBody";
                        armProp[1].armorTier = 5;
                        armProp[1].scaleOffset = new Vector3(0f, 0f);
                        armProp[1].offset = new Vector3(0f, 0f);
                        armProp[1].sprite = "Assets/Armor/Misc/Armor/MiddleBody.png";

                        armProp[2].armorPiece = "LowerBody";
                        armProp[2].armorTier = 5;
                        armProp[2].scaleOffset = new Vector3(0f, 0f);
                        armProp[2].offset = new Vector3(0.0f, 0f);
                        armProp[2].sprite = "Assets/Armor/Misc/Armor/LowerBody.png";

                        armProp[3].armorPiece = "UpperArm";
                        armProp[3].armorTier = 5;
                        armProp[3].scaleOffset = new Vector3(0f, 0f);
                        armProp[3].offset = new Vector3(0f, 0f);
                        armProp[3].sprite = "Assets/Armor/Misc/Armor/UpperArm.png";

                        armProp[4].armorPiece = "LowerArm";
                        armProp[4].armorTier = 5;
                        armProp[4].scaleOffset = new Vector3(0f, 0f);
                        armProp[4].offset = new Vector3(0f, -0f);
                        armProp[4].sprite = "Assets/Armor/Misc/Armor/LowerArm.png";

                        armProp[5].armorPiece = "UpperLeg";
                        armProp[5].armorTier = 5;
                        armProp[5].scaleOffset = new Vector3(0f, 0f);
                        armProp[5].offset = new Vector3(0f, 0f);
                        armProp[5].sprite = "Assets/Armor/Misc/Armor/UpperLeg.png";

                        armProp[6].armorPiece = "LowerLeg";
                        armProp[6].armorTier = 5;
                        armProp[6].scaleOffset = new Vector3(0f, 0f);
                        armProp[6].offset = new Vector3(0f, 0f);
                        armProp[6].sprite = "Assets/Armor/Misc/Armor/LowerLeg.png";

                        armProp[7].armorPiece = "UpperArmFront";
                        armProp[7].armorTier = 5;
                        armProp[7].scaleOffset = new Vector3(.08f, .08f);
                        armProp[7].offset = new Vector3(0f, 0f);
                        armProp[7].sprite = "Assets/Armor/Misc/Armor/UpperArm.png";
            
                        armProp[8].armorPiece = "UpperLegFront";
                        armProp[8].armorTier = 5;
                        armProp[8].scaleOffset = new Vector3(0f, 0f);
                        armProp[8].offset = new Vector3(0f, 0f);
                        armProp[8].sprite = "Assets/Armor/Misc/Armor/UpperLeg.png";

                        armProp[9].armorPiece = "LowerLegFront";
                        armProp[9].armorTier = 5;
                        armProp[9].scaleOffset = new Vector3(0f, 0f);
                        armProp[9].offset = new Vector3(0f, 0f);
                        armProp[9].sprite = "Assets/Armor/Misc/Armor/LowerLeg.png";

                        armProp[10].armorPiece = "Foot";
                        armProp[10].armorTier = 5;
                        armProp[10].scaleOffset = new Vector3(0f, 0f);
                        armProp[10].offset = new Vector3(0f, 0f);
                        armProp[10].sprite = "Assets/Armor/Misc/Armor/Foot.png";

                        armProp[11].armorPiece = "FootFront";
                        armProp[11].armorTier = 5;
                        armProp[11].scaleOffset = new Vector3(0f, 0f);
                        armProp[11].offset = new Vector3(0f, 0f);
                        armProp[11].sprite = "Assets/Armor/Misc/Armor/Foot.png";

                        armProp[12].armorPiece = "LowerArmFront";
                        armProp[12].armorTier = 5;
                        armProp[12].scaleOffset = new Vector3(0f, 0f);
                        armProp[12].offset = new Vector3(0f, 0f);
                        armProp[12].sprite = "Assets/Armor/Misc/Armor/LowerArm.png";

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
