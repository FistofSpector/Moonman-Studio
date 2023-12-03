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
                        var skin = ModAPI.LoadTexture("Assets/People/Deckard/Deckard.png");
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(skin, null, null, 1);

                        LimbBehaviour[] limbs = person.Limbs;
                        LimbBehaviour firstLimb = limbs[1];

                        GameObject cape = new GameObject("Coat");
                        cape.transform.SetParent(firstLimb.transform, false);
                        cape.transform.localPosition = new Vector2(0f, 0f);
                        cape.transform.localScale = new Vector2(1f, 1f);
                        cape.transform.localRotation = Quaternion.identity;

                        SpriteRenderer capeSpriteRenderer = cape.AddComponent<SpriteRenderer>();
                        capeSpriteRenderer.sprite = ModAPI.LoadSprite("Assets/People/Rick Deckard/Rick Deckard/Coat.png");
                        capeSpriteRenderer.sortingLayerName = "Foreground";
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
                        var skin = ModAPI.LoadTexture("Assets/People/Officer K/Officer K.png");
                        var person = Instance.GetComponent<PersonBehaviour>();
                        person.SetBodyTextures(skin, null, null, 1);

                        LimbBehaviour[] limbs = person.Limbs;
                        LimbBehaviour firstLimb = limbs[1];

                        GameObject cape = new GameObject("Coat");
                        cape.transform.SetParent(firstLimb.transform, false);
                        cape.transform.localPosition = new Vector2(0f, 0f);
                        cape.transform.localScale = new Vector2(1f, 1f);
                        cape.transform.localRotation = Quaternion.identity;

                        SpriteRenderer capeSpriteRenderer = cape.AddComponent<SpriteRenderer>();
                        capeSpriteRenderer.sprite = ModAPI.LoadSprite("Assets/People/Officer K/Officer K/Coat.png");
                        capeSpriteRenderer.sortingLayerName = "Foreground";
                    }
                }
            );
        }
    }
}
