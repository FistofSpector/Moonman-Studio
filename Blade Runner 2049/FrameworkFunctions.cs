using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace FrameworkFunctions
{
    public class SkinManager : MonoBehaviour
    {
        public class SkinData
        {
            public Texture2D Texture { get; set; }
            public List<AccessoryData> Accessories { get; } = new List<AccessoryData>();
        }

        public class AccessoryData
        {
            public LimbBehaviour Limb { get; set; }
            public Sprite AccessorySprite { get; set; }
            public Vector2 AccessoryPosition { get; set; }
        }

        private List<SkinData> skins = new List<SkinData>();
        private int currentIndex = 0;
        private PersonBehaviour person;

        public void Start()
        {
            person = this.gameObject.GetComponent<PersonBehaviour>();
            if (this.gameObject.GetComponent<PersonBehaviour>())
            {
                person = this.gameObject.GetComponent<PersonBehaviour>();
                foreach (var body in GetComponent<PersonBehaviour>().Limbs)
                {
                    ContextMenuButton skinButton = new ContextMenuButton("Switch Skin", "Switch Skin", "Switch Skin", new UnityAction[1]
                    {
                        (UnityAction) (() =>
                        {
                            SwitchSkin();
                        })
                    });

                    body.gameObject.GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(skinButton);
                }
            }
        }

        public void AddSkin(Texture2D texture)
        {
            skins.Add(new SkinData { Texture = texture });
        }
        
        public void SwitchSkin()
        {
            currentIndex = (currentIndex + 1) % skins.Count;
            person.SetBodyTextures(skins[currentIndex].Texture);
            
            foreach (LimbBehaviour limb in person.Limbs)
            {
                foreach (Transform child in limb.transform)
                {
                    if (child.name == "Accessory")
                    {
                        Debug.LogError("Accessory available.");
                        Destroy(child.gameObject);
                    }
                }
            }

            ApplyAccessories();
        }

        public void AddAccessory(Texture2D skinTexture, LimbBehaviour limb, Sprite accessorySprite, Vector2 accessoryPosition)
        {
            SkinData skinData = skins.Find(skin => skin.Texture == skinTexture);

            if (skinData != null)
            {
                skinData.Accessories.Add(new AccessoryData { Limb = limb, AccessorySprite = accessorySprite, AccessoryPosition = accessoryPosition });
            }
        }

        public void ApplyAccessories()
        {
            foreach (AccessoryData accessoryData in skins[currentIndex].Accessories)
            {
                CreateAccessoryOnLimb(accessoryData.Limb, accessoryData.AccessorySprite, accessoryData.AccessoryPosition);
            }
        }

        public void CreateAccessoryOnLimb(LimbBehaviour limb, Sprite accessorySprite, Vector2 accessoryPosition)
        {
            GameObject accessory = new GameObject("Accessory");
            accessory.transform.SetParent(limb.transform, false);
            accessory.transform.localPosition = accessoryPosition;
            accessory.transform.localScale = new Vector2(1f, 1f);
            accessory.transform.localRotation = Quaternion.identity;

            SpriteRenderer accessoryRenderer = accessory.AddComponent<SpriteRenderer>();
            accessoryRenderer.sprite = accessorySprite;
            accessoryRenderer.sortingLayerName = "Top";
        }
    }
}