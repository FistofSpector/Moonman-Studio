﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Defenders
{
    public class SkinManager : MonoBehaviour
    {
        [SkipSerialisation]
        public class SkinData
        {
            public Texture2D Texture { get; set; }
            public List<AccessoryData> Accessories { get; set; } = new List<AccessoryData>();
        }

        [SkipSerialisation]
        public class AccessoryData
        {
            public LimbBehaviour Limb { get; set; }
            public Sprite Sprite { get; set; }
            public Vector2 Position { get; set; }
        }

        public int currentIndex = 0;
        [SkipSerialisation]
        public List<SkinData> skins = new List<SkinData>();
        [SkipSerialisation]
        public PersonBehaviour person;
        
        private void Start()
        {
            person = GetComponent<PersonBehaviour>();
            UpdateSkin();

            person.Limbs[0].gameObject.GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("Next Skin", "Next Skin", "Next Skin", new UnityAction[1]
            {
                (UnityAction) (() =>
                {
                    NextSkin();
                })
            }));

            person.Limbs[0].gameObject.GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("Previous Skin", "Previous Skin", "Previous Skin", new UnityAction[1]
            {
                (UnityAction) (() =>
                {
                    PreviousSkin();
                })
            }));
        }

        private void NextSkin()
        {
            currentIndex = (currentIndex + 1) % skins.Count;
            UpdateSkin();
        }

        private void PreviousSkin()
        {
            currentIndex = (currentIndex - 1 + skins.Count) % skins.Count;
            UpdateSkin();
        }

        private void UpdateSkin()
        {
            person.SetBodyTextures(skins[currentIndex].Texture);

            foreach (LimbBehaviour limb in person.Limbs)
            {
                foreach (Transform child in limb.transform)
                {
                    if (child.name == "Accessory")
                    {
                        Destroy(child.gameObject);
                    }
                }
            }

            foreach (AccessoryData accessoryData in skins[currentIndex].Accessories)
            {
                AddAccessory(accessoryData.Limb, accessoryData.Sprite, accessoryData.Position);
            }

            ModAPI.Notify("Skin Index: " + (currentIndex + 1) + " / " + skins.Count);
        }

        public void AddSkin(Texture2D skinTexture)
        {
            skins.Add(new SkinData { Texture = skinTexture });
        }

        public void AddAccessoryToSkin(Texture2D skinTexture, LimbBehaviour accessoryLimb, Sprite accessorySprite, Vector2 accessoryPosition)
        {
            SkinData skinData = skins.Find(skin => skin.Texture == skinTexture);

            if (skinData != null)
            {
                skinData.Accessories.Add(new AccessoryData { Limb = accessoryLimb, Sprite = accessorySprite, Position = accessoryPosition });
            }
        }

        private void AddAccessory(LimbBehaviour accessoryLimb, Sprite accessorySprite, Vector2 accessoryPosition)
        {
            GameObject accessory = new GameObject("Accessory");
            accessory.transform.SetParent(accessoryLimb.transform, false);
            accessory.transform.localPosition = accessoryPosition;
            accessory.transform.localScale = new Vector2(1f, 1f);
            accessory.transform.localRotation = Quaternion.identity;

            SpriteRenderer accessoryRenderer = accessory.AddComponent<SpriteRenderer>();
            accessoryRenderer.sprite = accessorySprite;
            accessoryRenderer.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
            accessoryRenderer.GetComponent<SpriteRenderer>().sortingOrder = 1;
            accessory.AddComponent<Optout>();
        }
    }
}