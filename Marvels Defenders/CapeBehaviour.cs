using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Defenders
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
                isCapeEnabled = true;
            }

            person.Limbs[1].gameObject.GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("Toggle Cape", "Toggle Cape", "Toggle Cape", new UnityAction[1]
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
            cape.transform.localPosition = new Vector2(-0.0428f, -0.657f);
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