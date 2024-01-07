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
    public class Mod
    {
        public static void Main()
        {
            CategoryBuilder.Create("Blade Runner", "", ModAPI.LoadSprite("Thumbnails/Category.png"));

            var joi = ModAPI.LoadTexture("Assets/People/Joi/Joi.png");
            var joiHair = ModAPI.LoadSprite("Assets/People/Joi/Joi Hair.png");
            var rickDeckard = ModAPI.LoadTexture("Assets/People/Rick Deckard/Rick Deckard 2049.png");
            var rickDeckardOG = ModAPI.LoadTexture("Assets/People/Rick Deckard/Rick Deckard.png");
            var rickDeckardCoat = ModAPI.LoadSprite("Assets/People/Rick Deckard/Coat.png");
            var HanSolo = ModAPI.LoadTexture("Assets/People/Rick Deckard/Han Solo.png");
            var officerKenCoat = ModAPI.LoadSprite("Assets/People/Officer K/Ken Coat.png");
            var officerKen = ModAPI.LoadTexture("Assets/People/Officer K/Ken Jacket.png");
            var officerKJacket = ModAPI.LoadTexture("Assets/People/Officer K/Officer K Jacket.png");
            var officerKCoat = ModAPI.LoadSprite("Assets/People/Officer K/Coat.png");
            var officerKNoJacket = ModAPI.LoadTexture("Assets/People/Officer K/Officer K No Jacket.png");
            var agent1 = ModAPI.LoadTexture("Assets/People/Wallace Agents/Agent 1.png");
            var LAPDDrone = ModAPI.LoadSprite("Assets/Items/LAPD Drone/LAPD Drone.png");

            // Rick Deckard
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "Rick Deckard",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Blade Runner"),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/Category.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(rickDeckard);

                        var skinManager = Instance.AddComponent<SkinManager>();

                        skinManager.AddSkin(rickDeckard);
                        skinManager.AddSkin(rickDeckardOG);
                        skinManager.AddAccessory(rickDeckardOG, person.Limbs[3], rickDeckardCoat, new Vector2(-0.0421f, -0.37f));
                        skinManager.AddSkin(HanSolo);

                    }
                }
            );

            // Officer K
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "Officer K",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Blade Runner"),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/Category.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(officerKJacket);
                       

                        var skinManager = Instance.AddComponent<SkinManager>();
                        skinManager.AddSkin(officerKNoJacket);
                        skinManager.AddSkin(officerKen);
                        skinManager.AddAccessory(officerKen, person.Limbs[3], officerKenCoat, new Vector2(-0.0421f, -0.37f));
                        skinManager.AddSkin(officerKJacket);
                        skinManager.AddAccessory(officerKJacket, person.Limbs[3], officerKCoat, new Vector2(-0.0421f, -0.37f));
                    }
                }
            );

            // Joi
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "Joi",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Blade Runner"),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/Category.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(joi);

                        foreach (LimbBehaviour limb in person.Limbs)
                        {
                            var glow = ModAPI.CreateLight(Instance.transform, Color.red, 1, 5);
                            glow.Color = new Color(0.804f, 0.361f, 0.514f);
                            glow.transform.SetParent(limb.transform, false);
                        }
                    }
                }
            );

            // Spinner
            // ModAPI.Register(
            //     new Modification()
            //     {
            //         OriginalItem = ModAPI.FindSpawnable("Car"),
            //         NameOverride = "Spinner",
            //         DescriptionOverride = "",
            //         CategoryOverride = ModAPI.FindCategory("Blade Runner"),
            //         ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/Category.png"),
            //         AfterSpawn = (Instance) =>
            //         {
            //             var body = Instance.transform.GetChild(0);
            //             var randomCarTextureBehaviour = body.gameObject.GetComponent<RandomCarTextureBehaviour>();

            //             var CarSprite = new RandomCarTextureBehaviour.CarSprites();
            //             CarSprite.Body = Spinner;

            //             randomCarTextureBehaviour.Textures = new RandomCarTextureBehaviour.CarSprites[]
            //             {
            //                     CarSprite
            //             };
            //         }
            //     }
            // );

            // LAPD Drone
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"),
                    NameOverride = "LAPD Drone",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Blade Runner"),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/Category.png"),
                    AfterSpawn = (Instance) =>
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = LAPDDrone;
                        Instance.FixColliders();
                        Instance.AddComponent<DroneBehaviour>();
                    }
                }
            );
        }
    }

    public class DroneBehaviour : MonoBehaviour
    {
        private bool activated = false;
        private Rigidbody2D rigidBody;
        
        public float moveSpeed = 1.0f;
        public float smoothness = 5.0f;
        public float offset = 50.0f;

        void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }

        public void Use()
        {
            activated = !activated;

            if (activated)
            {
                rigidBody.isKinematic = true;
            }
            else
            {
                rigidBody.isKinematic = false;
            }

            ModAPI.Notify("LAPD Drone has been " + (activated ? "activated!" : "deactivated!"));
        }

        void Update()
        {
            if (activated)
            {
                Vector2 targetPosition = GetMouseWorldPositionWithOffset();
                SmoothlyMoveTo(targetPosition);
            }
        }

        public Vector2 GetMouseWorldPositionWithOffset()
        {
            Vector2 mousePosition = Input.mousePosition;
            mousePosition.x += offset;
            mousePosition.y -= offset;
            return Camera.main.ScreenToWorldPoint(mousePosition);
        }

        public void SmoothlyMoveTo(Vector2 targetPosition)
        {
            transform.position = Vector2.Lerp(transform.position, targetPosition, moveSpeed * smoothness * Time.deltaTime);
        }
    }
}
