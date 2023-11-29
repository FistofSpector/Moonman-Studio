//hallo, add this to the afterspawn function:
  //var head = Instance.transform.Find("Head");
//head.gameObject.AddComponent<Reawake>();
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

 public class Reawake : MonoBehaviour
        {
            public bool activateReawake = false;
            public void Update()
            {

      
                if (!gameObject.GetComponent<LimbBehaviour>().Person.IsAlive())
                {
                    if(activateReawake == false)
                    {

                        activateReawake = true;
                        StartCoroutine(Revivee());
                    }
                   

                }
            }
            

           


                public IEnumerator Revivee()
            {
                yield return new WaitForSeconds(5f);
                Revive();
                yield return new WaitForSeconds(1f);
                Revive();
            }

            public void Revive()
            {
                var person = gameObject.GetComponent<LimbBehaviour>().Person;

                foreach (var jmc in person.Limbs)
                {
                    jmc.IsZombie = false;
                    jmc.Health = jmc.InitialHealth;
                    jmc.Numbness = 0f;
                    jmc.HealBone();

                    jmc.Person.Braindead = false;
                    jmc.Person.BrainDamaged = false;
                    jmc.Person.Consciousness = 1f;
                    jmc.Person.ShockLevel = 0f;
                    jmc.Person.PainLevel = 0f;
                    jmc.Person.OxygenLevel = 1f;
                    jmc.Person.AdrenalineLevel = 0f;

                    CirculationBehaviour circulationBehaviour = jmc.CirculationBehaviour;
                    float amount = circulationBehaviour.GetAmount(jmc.GetOriginalBloodType());
                    if (amount < 0.1f)
                    {
                        circulationBehaviour.AddLiquid(jmc.GetOriginalBloodType(), 1f - amount);
                    }
                    circulationBehaviour.BloodFlow = 1f;
                    circulationBehaviour.HealBleeding();
                    circulationBehaviour.BleedingRate = 0f;
                    circulationBehaviour.IsPump = circulationBehaviour.WasInitiallyPumping;
                }
                activateReawake = false;
            }
        }
        }