using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Watchmen
{
    public class Mod
    {
        public static string WatchmenTag = "<color=yellow>[Watchmen]</color> ";
        public static string ItemsTag = "<color=grey>[Items]</color> ";

        public static void Main()
        {
            CategoryBuilder.Create("The Watchmen", "", ModAPI.LoadSprite("Assets/Category Icon.png"));

            List<Sprite> expressions = new List<Sprite>()
            {
                ModAPI.LoadSprite("Assets/People/Rorschach/Masks/Resting.png"),
                ModAPI.LoadSprite("Assets/People/Rorschach/Masks/Transition1.png"),
                ModAPI.LoadSprite("Assets/People/Rorschach/Masks/Transition2.png"),
                ModAPI.LoadSprite("Assets/People/Rorschach/Masks/Transition3.png"),
                ModAPI.LoadSprite("Assets/People/Rorschach/Masks/Angry.png"),
                ModAPI.LoadSprite("Assets/People/Rorschach/Masks/Transition4.png"),
                ModAPI.LoadSprite("Assets/People/Rorschach/Masks/Transition5.png"),
                ModAPI.LoadSprite("Assets/People/Rorschach/Masks/Transition6.png"),
                ModAPI.LoadSprite("Assets/People/Rorschach/Masks/Happy.png"),
                ModAPI.LoadSprite("Assets/People/Rorschach/Masks/Transition7.png"),
                ModAPI.LoadSprite("Assets/People/Rorschach/Masks/Transition8.png"),
                ModAPI.LoadSprite("Assets/People/Rorschach/Masks/Transition9.png"),
            };
            
            var Rorschach = ModAPI.LoadTexture("Assets/People/Rorschach/Rorschach.png");
            var WalterKovacs = ModAPI.LoadTexture("Assets/People/Rorschach/Walter Kovacs.png");
            var KovacsPrisoner = ModAPI.LoadTexture("Assets/People/Rorschach/Prisoner.png");
            var DrManhattan = ModAPI.LoadTexture("Assets/People/Dr Manhattan/Dr Manhattan.png");
            var TheComedianOld = ModAPI.LoadTexture("Assets/People/The Comedian/The Comedian Old.png");
            var TheComedianBathrobe = ModAPI.LoadTexture("Assets/People/The Comedian/The Comedian Bathrobe.png");
            var TheComedianYoung = ModAPI.LoadTexture("Assets/People/The Comedian/The Comedian Young.png");
            var EdwardBlake = ModAPI.LoadTexture("Assets/People/The Comedian/Edward Blake.png");
            var Ozymandias = ModAPI.LoadTexture("Assets/People/Ozymandias/Ozymandias.png");
            var OzymandiasCape = ModAPI.LoadSprite("Assets/People/Ozymandias/Cape.png");
            var AdrianVeidt = ModAPI.LoadTexture("Assets/People/Ozymandias/Adrian Veidt.png");
            var NightOwlII = ModAPI.LoadTexture("Assets/People/Night Owl II/Night Owl II.png");
            var DanDreiberg = ModAPI.LoadTexture("Assets/People/Night Owl II/Dan Dreiberg.png");
            var Prisoner1 = ModAPI.LoadTexture("Assets/People/Prisoners/Prisoner 1.png");
            var Prisoner2 = ModAPI.LoadTexture("Assets/People/Prisoners/Prisoner 2.png");
            var Prisoner3 = ModAPI.LoadTexture("Assets/People/Prisoners/Prisoner 3.png");
            var Criminal1 = ModAPI.LoadTexture("Assets/People/Criminals/Criminal 1.png");
            var Criminal2 = ModAPI.LoadTexture("Assets/People/Criminals/Criminal 2.png");
            var Criminal3 = ModAPI.LoadTexture("Assets/People/Criminals/Criminal 3.png");

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = WatchmenTag + "Rorschach",
                    DescriptionOverride = "\"Never compromise. Not even in the face of Armageddon.\"",
                    CategoryOverride = ModAPI.FindCategory("The Watchmen"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Rorschach/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(Rorschach);

                        SkinManager skinManager = Instance.GetOrAddComponent<SkinManager>();
                        skinManager.AddSkin(Rorschach);
                        skinManager.AddAccessoryToSkin(Rorschach, person.Limbs[0], ModAPI.LoadSprite("Assets/People/Rorschach/Fedora.png"), new Vector2(0f, 0f));
                        skinManager.AddAccessoryToSkin(Rorschach, person.Limbs[3], ModAPI.LoadSprite("Assets/People/Rorschach/Coat.png"), new Vector2(0f, 0f));
                        skinManager.AddSkin(WalterKovacs);
                        skinManager.AddSkin(KovacsPrisoner);

                        MaskBehaviour maskBehaviour = Instance.AddComponent<MaskBehaviour>();
                        maskBehaviour.AddMaskBehaviour(person, expressions);
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = WatchmenTag + "Dr Manhattan",
                    DescriptionOverride = "\"I feel fear for the last time.\"",
                    CategoryOverride = ModAPI.FindCategory("The Watchmen"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Dr Manhattan/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(ModAPI.LoadTexture("Assets/People/Dr Manhattan/Dr Manhattan.png"));

                        //DuplicationAbility(person, person.Limbs[0]);

                        foreach (LimbBehaviour limb in person.Limbs)
                        {
                            limb.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Incredible");
                            limb.GetComponent<PhysicalBehaviour>().BulletPenetration = false;
                            limb.ImmuneToDamage = true;

                            var glow = ModAPI.CreateLight(Instance.transform, Color.blue, 1f, 1);
                            glow.Color = new Color(0.42f, 0.706f, 1f);
                            glow.transform.SetParent(limb.transform, false);
                        }
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = WatchmenTag + "The Comedian",
                    DescriptionOverride = "\"Once you figure out what a joke everything is, being the Comedian's the only thing that makes sense.\"",
                    CategoryOverride = ModAPI.FindCategory("The Watchmen"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/The Comedian/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(TheComedianOld);
                        
                        SkinManager skinManager = Instance.GetOrAddComponent<SkinManager>();
                        skinManager.AddSkin(TheComedianOld);
                        skinManager.AddSkin(TheComedianYoung);
                        skinManager.AddSkin(EdwardBlake);
                        skinManager.AddSkin(TheComedianBathrobe);
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = WatchmenTag + "Ozymandias",
                    DescriptionOverride = "\"The only person with whom I felt any kinship with died three hundred years before the birth of Christ. Alexander of Macedonia, or Alexander the Great, as you know him.\"",
                    CategoryOverride = ModAPI.FindCategory("The Watchmen"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Ozymandias/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(Ozymandias);

                        new CapeBehaviour().AddToggleButton(person, OzymandiasCape, true);

                        SkinManager skinManager = Instance.GetOrAddComponent<SkinManager>();
                        skinManager.AddSkin(Ozymandias);
                        skinManager.AddSkin(AdrianVeidt);
                    }
                }
            );
            
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = WatchmenTag + "Night Owl II",
                    DescriptionOverride = "\"What's happened to America? What's happened to the American dream?\"",
                    CategoryOverride = ModAPI.FindCategory("The Watchmen"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Night Owl II/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(NightOwlII);

                        SkinManager skinManager = Instance.GetOrAddComponent<SkinManager>();
                        skinManager.AddSkin(NightOwlII);
                        skinManager.AddAccessoryToSkin(NightOwlII, person.Limbs[0], ModAPI.LoadSprite("Assets/People/Night Owl II/Ears.png"), new Vector2 (0f, 0f));
                        skinManager.AddSkin(DanDreiberg);
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "Criminals",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("The Watchmen"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Criminals/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(Criminal1);

                        SkinManager skinManager = Instance.GetOrAddComponent<SkinManager>();
                        skinManager.AddSkin(Criminal1);
                        skinManager.AddSkin(Criminal2);
                        skinManager.AddSkin(Criminal3);
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "Prisoners",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("The Watchmen"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Prisoners/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(Prisoner1);

                        SkinManager skinManager = Instance.GetOrAddComponent<SkinManager>();
                        skinManager.AddSkin(Prisoner1);
                        skinManager.AddSkin(Prisoner2);
                        skinManager.AddSkin(Prisoner3);
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Stick"),
                    NameOverride = ItemsTag + "Sign",
                    DescriptionOverride = "The end is nigh..",
                    CategoryOverride = ModAPI.FindCategory("The Watchmen"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/Items/Sign/Sign.png"),
                    AfterSpawn = (Instance) =>
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Assets/Items/Sign/Sign.png");
                        Instance.FixColliders();
                    }
                }
            );

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Blue cathode light"),
                    NameOverride = ItemsTag + "Light",
                    DescriptionOverride = "The end is nigh..",
                    CategoryOverride = ModAPI.FindCategory("The Watchmen"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/Items/Light.png"),
                    AfterSpawn = (Instance) =>
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Assets/Items/Light.png");
                        Instance.FixColliders();
                    }
                }
            );
        }

        // public static void DuplicationAbility(PersonBehaviour person, LimbBehaviour limb)
        // {
        //     limb.gameObject.AddComponent<UseEventTrigger>().Action = () =>
        //     {
        //         GameObject newHuman = Object.Instantiate(humanPrefab, person.transform.position, Quaternion.identity);
                
        //         ModAPI.Notify("Duplication ability activated!");
        //     };
        // }
    }

    public class MaskBehaviour : MonoBehaviour
    {
        private PersonBehaviour person;
        private List<Sprite> expressions;
        private Sprite originalSprite;

        private bool isAnimating = false;

        public void Start()
        {
            if (person != null)
            {
                person.Limbs[0].gameObject.GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("Toggle Mask", "Toggle Mask", "Toggle Mask", new UnityAction[1]
                {
                    (UnityAction) (() =>
                    {
                        ToggleMaskAnimation();
                    })
                }));
            }
        }

        public void AddMaskBehaviour(PersonBehaviour thePerson, List<Sprite> theExpressions)
        {
            person = thePerson;
            expressions = theExpressions;

            originalSprite = person.Limbs[0].SkinMaterialHandler.renderer.sprite;
        }

        private IEnumerator ResetSprite()
        {
            int currentIndex = expressions.IndexOf(person.Limbs[0].SkinMaterialHandler.renderer.sprite);

            for (int j = currentIndex; j >= 0; j--)
            {
                person.Limbs[0].SkinMaterialHandler.renderer.sprite = expressions[j];

                // Check if the current expression is resting, angry, or happy
                if (j == 0 || j == 4 || j == 8)
                {
                    yield return new WaitForSeconds(0f);
                }
                else
                {
                    yield return new WaitForSeconds(.15f);
                }
            }
        }

        private void ToggleMaskAnimation()
        {
            if (!isAnimating)
            {
                isAnimating = true;
                StartCoroutine(AnimateMask());
            }
            else
            {
                isAnimating = false;
                StartCoroutine(ResetSprite());
            }
        }

        private IEnumerator AnimateMask()
        {
            int currentIndex = 0;
            int transitionCount = expressions.Count - 3;

            while (isAnimating)
            {
                for (int i = 0; i < expressions.Count && isAnimating; i++)
                {
                    person.Limbs[0].SkinMaterialHandler.renderer.sprite = expressions[i];
                    
                    // Check if the current expression is resting, angry, or happy
                    if (i == 0 || i == 4 || i == 8)
                    {
                        yield return new WaitForSeconds(2.5f);
                    }
                    else
                    {
                        yield return new WaitForSeconds(.15f);
                    }
                }
            }
        }
    }

    // public class HatBehaviour : MonoBehaviour
    // {
    //     private PersonBehaviour person;
    //     private LimbBehaviour limb;
    //     private bool attached = false;

    //     private void OnCollisionEnter2D(Collision2D collision)
    //     {
    //         if (!attached)
    //         {
    //             LimbBehaviour limb = collision.gameObject.GetComponent<LimbBehaviour>();

    //             if (limb != null && limb.gameObject.name.Contains("Head"))
    //             {
    //                 Debug.Log("Attached to limb");
    //                 AttatchHat(limb);
    //             }
    //         }
    //     }

    //     public void AddHat(PersonBehaviour thePerson, LimbBehaviour theLimb)
    //     {
    //         person = thePerson;
    //         limb = theLimb;

    //         GameObject hat = new GameObject("Hat");
    //         hat.transform.SetParent(person.transform.Find("Head"));
    //         hat.transform.localPosition = new Vector2(0f, 0f);
    //         hat.transform.localScale = new Vector2(1f, 1f);
    //         hat.transform.localRotation = Quaternion.identity;
            
    //         SpriteRenderer hatRenderer = hat.AddComponent<SpriteRenderer>();
    //         hatRenderer.sprite = ModAPI.LoadSprite("Assets/People/Rorschach/Fedora.png");
    //         hatRenderer.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
    //         hatRenderer.GetComponent<SpriteRenderer>().sortingOrder = 1;
    //     }

    //     private void AttatchHat(LimbBehaviour limb)
    //     {
    //         FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
    //         joint.connectedBody = limb.GetComponent<Rigidbody2D>();
    //         joint.autoConfigureConnectedAnchor = false;
    //         joint.connectedAnchor = Vector2.zero;

    //         attached = true;
    //     }
    // }
}