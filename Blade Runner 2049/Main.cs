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
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Rick Deckard/Thumb.png"),
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
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Officer K/Thumb.png"),
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
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Officer K/Thumb.png"),
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

            // Wallace Agent 1
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "Wallace Agent 1",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Blade Runner"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Wallace Agents/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var skin = ModAPI.LoadTexture("Assets/People/Wallace Agents/Agent 1.png");
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
                        capeSpriteRenderer.sprite = ModAPI.LoadSprite("Assets/People/Wallace Agents/Coat.png");
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

            // Roy Batty
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "Roy Batty",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Blade Runner"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Roy Batty/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var skin = ModAPI.LoadTexture("Assets/People/Roy Batty/Roy Batty.png");
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
                        capeSpriteRenderer.sprite = ModAPI.LoadSprite("Assets/People/Roy Batty/Coat.png");
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
            // Luv
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "Luv",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Blade Runner"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Luv/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var skin = ModAPI.LoadTexture("Assets/People/Luv/Luv.png");
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(skin, null, null, 1);

                        person.Limbs[0].SkinMaterialHandler.renderer.sprite = ModAPI.LoadSprite("Assets/People/Luv/Head.png");
                        person.Limbs[0].SkinMaterialHandler.renderer.material.SetTexture("_FleshTex", ModAPI.LoadTexture("Assets/Other/flesh1.png"));
                        person.Limbs[0].SkinMaterialHandler.renderer.material.SetTexture("_BoneTex", ModAPI.LoadTexture("Assets/Other/bone1.png"));
                    }
                }
            );
            // Pris
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "Pris",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Blade Runner"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Pris/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var skin = ModAPI.LoadTexture("Assets/People/Pris/Pris.png");
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(skin, null, null, 1);

                    }
                }
            );
            // Variant 1
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "Variant 1",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Blade Runner"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Variant 1/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var skin = ModAPI.LoadTexture("Assets/People/Variant 1/Variant 1.png");
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
                        capeSpriteRenderer.sprite = ModAPI.LoadSprite("Assets/People/Variant 1/Coat.png");
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
            // Variant 2
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "Variant 2",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Blade Runner"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Variant 2/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var skin = ModAPI.LoadTexture("Assets/People/Variant 2/Variant 2.png");
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(skin, null, null, 1);

                    }
                }
            );
            // Variant 3
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "Variant 3",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Blade Runner"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Variant 3/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var skin = ModAPI.LoadTexture("Assets/People/Variant 3/Variant 3.png");
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(skin, null, null, 1);

                        person.Limbs[0].SkinMaterialHandler.renderer.sprite = ModAPI.LoadSprite("Assets/People/Variant 3/Head.png");
                        person.Limbs[0].SkinMaterialHandler.renderer.material.SetTexture("_FleshTex", ModAPI.LoadTexture("Assets/Other/flesh1.png"));
                        person.Limbs[0].SkinMaterialHandler.renderer.material.SetTexture("_BoneTex", ModAPI.LoadTexture("Assets/Other/bone1.png"));

                    }
                }
            );
            // Gaff
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "Gaff",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Blade Runner"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Gaff/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var skin = ModAPI.LoadTexture("Assets/People/Gaff/Gaff.png");
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(skin, null, null, 1);

                        person.Limbs[0].SkinMaterialHandler.renderer.sprite = ModAPI.LoadSprite("Assets/People/Gaff/Head.png");
                        person.Limbs[0].SkinMaterialHandler.renderer.material.SetTexture("_FleshTex", ModAPI.LoadTexture("Assets/Other/flesh1.png"));
                        person.Limbs[0].SkinMaterialHandler.renderer.material.SetTexture("_BoneTex", ModAPI.LoadTexture("Assets/Other/bone1.png"));

                        LimbBehaviour[] limbs = person.Limbs;
                        LimbBehaviour firstLimb = limbs[3];

                        GameObject cape = new GameObject("Coat");
                        cape.transform.SetParent(firstLimb.transform, false);
                        cape.transform.localPosition = new Vector2(-0.0421f, -0.37f);
                        cape.transform.localScale = new Vector2(1f, 1f);
                        cape.transform.localRotation = Quaternion.identity;

                        SpriteRenderer capeSpriteRenderer = cape.AddComponent<SpriteRenderer>();
                        capeSpriteRenderer.sprite = ModAPI.LoadSprite("Assets/People/Gaff/Coat.png");
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
            // Freysa
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "Freysa Sadeghpour",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Blade Runner"),
                    ThumbnailOverride = ModAPI.LoadSprite("Assets/People/Freysa/Thumb.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var skin = ModAPI.LoadTexture("Assets/People/Freysa/Freysa.png");
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
                        capeSpriteRenderer.sprite = ModAPI.LoadSprite("Assets/People/Freysa/Coat.png");
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
