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
    public class CapeBehaviour
    {
        private GameObject cape;
        private SpriteRenderer capeRenderer;
        private bool isCapeEnabled = false;

        public void AddToggleButton(PersonBehaviour person, Sprite capeSprite, bool isToggled)
        {
            if (isToggled)
            {
                CreateCape(person, capeSprite);
            }

            person.Limbs[1].gameObject.GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("Next Skin", "Next Skin", "Next Skin", new UnityAction[1]
            {
                (UnityAction) (() =>
                {
                    ToggleCape(person, capeSprite);
                })
            }));
        }
        
        private void ToggleCape(PersonBehaviour person, Sprite capeSprite)
        {
            if (isCapeEnabled)
            {
                DestroyCape();
            }
            else
            {
                CreateCape(person, capeSprite);
            }

            isCapeEnabled = !isCapeEnabled;
        }

        private void CreateCape(PersonBehaviour person, Sprite capeSprite)
        {
            cape = new GameObject("Cape");
            cape.transform.SetParent(person.transform.Find("Body").Find("UpperBody"));
            cape.transform.localPosition = new Vector2(0.0142f, 0f);
            cape.transform.localScale = new Vector2(1f, 1f);
            cape.transform.localRotation = Quaternion.identity;
            
            capeRenderer = cape.AddComponent<SpriteRenderer>();
            capeRenderer.sprite = capeSprite;
            capeRenderer.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
            capeRenderer.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }

        private void DestroyCape()
        {
            GameObject.Destroy(cape);
        }
    }
}