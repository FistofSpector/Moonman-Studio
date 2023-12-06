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
            CategoryBuilder.Create("Blade Runner", "", ModAPI.LoadSprite("Thumb.png"));

            // Rick Deckard
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "Rick Deckard",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Blade Runner"),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var skin = ModAPI.LoadTexture("Assets/People/Rick Deckard/Rick Deckard.png");
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(skin, null, null, 1);

                        LimbBehaviour[] limbs = person.Limbs;
                        LimbBehaviour firstLimb = limbs[3];

                        GameObject cape = new GameObject("Coat");
                        cape.transform.SetParent(firstLimb.transform, false);
                        cape.transform.localPosition = new Vector2(0f, 0f);
                        cape.transform.localScale = new Vector2(1f, 1f);
                        cape.transform.localRotation = Quaternion.identity;

                        SpriteRenderer capeSpriteRenderer = cape.AddComponent<SpriteRenderer>();
                        capeSpriteRenderer.sprite = ModAPI.LoadSprite("Assets/People/Rick Deckard/Coat.png");
                        capeSpriteRenderer.sortingLayerName = "Default";
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
                    ThumbnailOverride = ModAPI.LoadSprite("Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var skin = ModAPI.LoadTexture("Assets/People/Officer K/Officer K Jacket.png");
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(skin, null, null, 1);
                        
                        LimbBehaviour[] limbs = person.Limbs;
                        LimbBehaviour firstLimb = limbs[3];

                        GameObject cape = new GameObject("Coat");
                        cape.transform.SetParent(firstLimb.transform, false);
                        cape.transform.localPosition = new Vector2(-0.0421f, -0.37f);
                        cape.transform.localScale = new Vector2(1f, 1f);
                        cape.transform.localRotation = Quaternion.identity;

                        SpriteRenderer capeSpriteRenderer = cape.AddComponent<SpriteRenderer>();
                        capeSpriteRenderer.sprite = ModAPI.LoadSprite("Assets/People/Officer K/Coat.png");
                        capeSpriteRenderer.sortingLayerName = "Top";

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

            // Officer K
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "Officer K W/O Jacket",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Blade Runner"),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var skin = ModAPI.LoadTexture("Assets/People/Officer K/Officer K No Jacket.png");
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(skin, null, null, 1);
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
                    ThumbnailOverride = ModAPI.LoadSprite("Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var skin = ModAPI.LoadTexture("Assets/People/Joi/Joi.png");
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(skin, null, null, 1);

                        foreach (LimbBehaviour limb in person.Limbs)
                        {
                            limb.gameObject.GetOrAddComponent<HologramBehaviour>();
                            limb.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

                            var glow = ModAPI.CreateLight(Instance.transform, Color.red, 1, 5);
                            glow.Color = new Color(0.804f, 0.361f, 0.514f);
                            glow.transform.SetParent(limb.transform, false);
                        }

                        LimbBehaviour[] limbs = person.Limbs;
                        LimbBehaviour firstLimb = limbs[0];

                        GameObject accessory = new GameObject("Hair");
                        accessory.transform.SetParent(firstLimb.transform, false);
                        accessory.transform.localPosition = new Vector2(0f, 0f);
                        accessory.transform.localScale = new Vector2(1f, 1f);
                        accessory.transform.localRotation = Quaternion.identity;

                        SpriteRenderer accessorySpriteRenderer = accessory.AddComponent<SpriteRenderer>();
                        accessorySpriteRenderer.sprite = ModAPI.LoadSprite("Assets/People/Joi/Joi Hair.png");
                        accessorySpriteRenderer.sortingLayerName = "Top";
                    }
                }
            );
        }
    }

    public class HologramBehaviour : MonoBehaviour
    {
        private LimbBehaviour limb;
        private Coroutine transparencyCoroutine;

        private void Start()
        {
            limb = GetComponent<LimbBehaviour>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            LimbBehaviour collidedLimb = collision.gameObject.GetComponent<LimbBehaviour>();

            if (collidedLimb != null)
            {
                //Debug.Log("Collision Detected with Limb: " + limb.name);
                StartTransparencyTransition(0.35f);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            LimbBehaviour collidedLimb = collision.gameObject.GetComponent<LimbBehaviour>();

            if (collidedLimb != null)
            {
                //Debug.Log("Collision Exit with Limb: " + limb.name);
                StartTransparencyTransition(1f);
            }
        }

        private void StartTransparencyTransition(float targetAlpha)
        {
            if (transparencyCoroutine != null)
            {
                StopCoroutine(transparencyCoroutine);
            }

            transparencyCoroutine = StartCoroutine(ChangeAlpha(targetAlpha));
        }

        private IEnumerator ChangeAlpha(float targetAlpha)
        {
            SpriteRenderer spriteRenderer = limb.GetComponent<SpriteRenderer>();
            Color startColor = spriteRenderer.color;

            float elapsedTime = 0f;
            float duration = 0.25f;

            while (elapsedTime < duration)
            {
                float newAlpha = Mathf.Lerp(startColor.a, targetAlpha, elapsedTime / duration);
                spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, targetAlpha);
            transparencyCoroutine = null;
        }
    }
}