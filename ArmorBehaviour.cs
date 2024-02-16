using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace Mod
{
    public class ArmorBehaviour : MonoBehaviour
    {
        private bool equipped;
        [SerializeField]
        public ArmorProperties prop;
        public string armorPiece;
        public int armorTier;
        public float stabResistance;
        private bool blockingStab;

        public Vector3 offset;
        public Vector3 scaleOffset = new Vector3(1, 1, 1);

        public ArmorBehaviour[] SetPieces = new ArmorBehaviour[0];
        public int pieceCount;
        public bool headCovering;

        [SerializeField]
        public LimbBehaviour attachedLimb;

        [SerializeField]
        public bool spawn = true;
        [SerializeField]
        public Color color = new Color(1, 1, 1);
        [SerializeField]
        public bool decorative;
        [SerializeField]
        public bool grayScale;

        void Start()
        {
            if (grayScale)
                GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite(prop.graySprite);
            ContextMenu();
            SetProperties();
            GetComponent<PhysicalBehaviour>().RefreshOutline();
            if (attachedLimb)
            {
                Attach(attachedLimb);
            }
            ApplyColor(color);

            if (GetComponent<PhysicalBehaviour>())
                GetComponent<PhysicalBehaviour>().HoldingPositions = new Vector3[0];
            ApplyTier();
        }
        public void ApplyColor(Color color)
        {
            GetComponent<SpriteRenderer>().color = color;
        }
        public void ApplyTier()
        {
            switch (armorTier)
            {
                case 0:
                    GetComponent<PhysicalProperties>().Softness = 1;
                    GetComponent<PhysicalProperties>().Brittleness = 1;
                    break;
                case 1:
                    GetComponent<PhysicalProperties>().Softness = 0f;
                    GetComponent<PhysicalProperties>().Brittleness = 0f;
                    GetComponent<PhysicalProperties>().BulletSpeedAbsorptionPower = 10f;
                    break;
                case 2:
                    GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Bulletproof Sheet");
                    GetComponent<PhysicalProperties>().Softness = 0f;
                    GetComponent<PhysicalProperties>().Brittleness = .1f;
                    GetComponent<PhysicalProperties>().BulletSpeedAbsorptionPower = 100f;
                   

                    GetComponent<BoxCollider2D>().size = new Vector3(GetComponent<BoxCollider2D>().size.x * 15, GetComponent<BoxCollider2D>().size.y * 15);
                    break;
                case 3:
                    GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Metal");
                    GetComponent<PhysicalProperties>().Softness = 0f;
                    GetComponent<PhysicalProperties>().Brittleness = 0f;
                    GetComponent<PhysicalProperties>().BulletSpeedAbsorptionPower = 1000f;
                    if (!GetComponent<BoxCollider2D>())
                    {
                        gameObject.AddComponent<BoxCollider2D>();
                    }
                    GetComponent<BoxCollider2D>().size = new Vector3(GetComponent<BoxCollider2D>().size.x * 20, GetComponent<BoxCollider2D>().size.y * 20);
                    break;


                    GetComponent<BoxCollider2D>().size = new Vector3(GetComponent<BoxCollider2D>().size.x * 15, GetComponent<BoxCollider2D>().size.y * 15);
                    break;
                case 4:
                    GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Bus Seat");
                    GetComponent<PhysicalProperties>().Softness = 20f;
                    GetComponent<PhysicalProperties>().Brittleness = 0f;
                    GetComponent<PhysicalProperties>().BulletSpeedAbsorptionPower = 10f;
                    if (!GetComponent<BoxCollider2D>())
                    {
                        gameObject.AddComponent<BoxCollider2D>();
                    }
                    GetComponent<BoxCollider2D>().size = new Vector3(GetComponent<BoxCollider2D>().size.x * 20, GetComponent<BoxCollider2D>().size.y * 20);
                    break;

                case 5:
                    GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Resizeable Housing");
                    GetComponent<PhysicalProperties>().Softness = 20f;
                    GetComponent<PhysicalProperties>().Brittleness = 0f;
                    GetComponent<PhysicalProperties>().BulletSpeedAbsorptionPower = 100f;
                    if (!GetComponent<BoxCollider2D>())
                    {
                        gameObject.AddComponent<BoxCollider2D>();
                    }
                    GetComponent<BoxCollider2D>().size = new Vector3(GetComponent<BoxCollider2D>().size.x * 20, GetComponent<BoxCollider2D>().size.y * 20);
                    break;

                case 6:
                    GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Bowling pin");
                    GetComponent<PhysicalProperties>().Softness = 0f;
                    GetComponent<PhysicalProperties>().Brittleness = 0f;
                    GetComponent<PhysicalProperties>().BulletSpeedAbsorptionPower = 1000f;
                    if (!GetComponent<BoxCollider2D>())
                    {
                        gameObject.AddComponent<BoxCollider2D>();
                    }
                    GetComponent<BoxCollider2D>().size = new Vector3(GetComponent<BoxCollider2D>().size.x * 20, GetComponent<BoxCollider2D>().size.y * 20);
                    break;
                default:
                    ModAPI.Notify("Armor tier " + armorTier.ToString() + " does not exist.");
                    break;
            }
        }
        public void SetProperties()
        {
            GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite(prop.sprite);
            armorPiece = prop.armorPiece;
            armorTier = prop.armorTier;
            offset = prop.offset;
            scaleOffset += prop.scaleOffset;

            if (GetComponent<Optout>())
                Destroy(GetComponent<Optout>());

            if (prop.mass != 0)
            {
                GetComponent<PhysicalBehaviour>().InitialMass = prop.mass;
                GetComponent<PhysicalBehaviour>().TrueInitialMass = prop.mass;
                GetComponent<PhysicalBehaviour>().rigidbody.mass = prop.mass;               
            }
            gameObject.FixColliders();
        }
        public void CloneSelf()
        {
            GameObject other = ModAPI.CreatePhysicalObject("OtherArmor", ModAPI.LoadSprite(prop.sprite));

            other.AddComponent<SerialiseInstructions>().OriginalSpawnableAsset = ModAPI.FindSpawnable("Rod");
            other.transform.position = transform.position;

            PhysicalBehaviour phys = GetComponent<PhysicalBehaviour>();

            other.GetComponent<PhysicalBehaviour>().InitialMass = phys.InitialMass;
            other.GetComponent<PhysicalBehaviour>().TrueInitialMass = phys.TrueInitialMass;
            other.GetComponent<PhysicalBehaviour>().InitialGravityScale = phys.InitialGravityScale;
            other.GetComponent<PhysicalBehaviour>().rigidbody.mass = phys.rigidbody.mass;

            ArmorBehaviour otherArmor = other.AddComponent<ArmorBehaviour>();
            otherArmor.prop = prop;
            otherArmor.prop.armorPiece = prop.armorPiece + "Front";

            otherArmor.offset = offset;
            otherArmor.scaleOffset = scaleOffset;
            otherArmor.SetProperties();
        }
        void ContextMenu()
        {
        this.GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("selectbutt", "Change color", "Change the color of the armor.", new UnityAction[1]
        {
            (UnityAction) (() =>
        {
            DialogBox dialog = (DialogBox) null;
            dialog = DialogBoxManager.TextEntry("Change the color of the object using the following format: 0.0, 0.0, 0.0. Values reach to 1.", "R, G, B", new DialogButton("Apply", true, new UnityAction[1]
            {
                (UnityAction) (() =>
                {
                    if (dialog.EnteredText != "")
                    {;
                        var text = dialog.EnteredText.Split(","[0]);
                        ModAPI.Notify("Color successfully set to " + dialog.EnteredText);
                        color.r = float.Parse(text[0]);
                        color.g = float.Parse(text[1]);
                        color.b = float.Parse(text[2]);
                        ApplyColor(color);
                    }
                    else
                        ModAPI.Notify("You didn't input anything.");
                })
            }),     
            new DialogButton("Cancel", true, new UnityAction[1]
            {
                    (UnityAction) (() => dialog.Close())
            }));
                })
            }));
            GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("incbut", "Increase armor tier", "Increase the defensive capability of the armor.", new UnityAction[1]
            {
                (UnityAction) (() => 
                {
                    if (prop.armorTier < 3)
                    {
                        prop.armorTier++;
                        armorTier = prop.armorTier;
                        ApplyTier();
                    }
                    ModAPI.Notify("Armor tier is at " + armorTier.ToString());
                })
            }));
            GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("decbut", "Decrease armor tier", "Decrease the defensive capability of the armor.", new UnityAction[1]
            {
                (UnityAction) (() => 
                {
                    if (prop.armorTier > 0)
                    {
                        prop.armorTier--;
                        armorTier = prop.armorTier;
                        ApplyTier();
                    }
                    ModAPI.Notify("Armor tier is at " + armorTier.ToString());
                })
            }));
            GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("decoratebut", (Func<string>) (() => !this.decorative ? "Switch to decorative" : "Switch to functional"), "Switch between decorative and functional.", new UnityAction[1]
            {
                (UnityAction) (() => 
                {
                    if (!decorative)
                    {
                        decorative = true;
                        Detach(attachedLimb);
                        foreach(NoCollide nocol in GetComponents<NoCollide>())
                        {
                            Destroy(nocol);
                        }
                    }
                    else
                        decorative = false;
                })
            }));
            GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("detachbut", "Detach armor", "Detach the armor from whatever it is equipped on.", new UnityAction[1]
            {
                (UnityAction) (() => 
                {
                    if (attachedLimb)
                        Detach(attachedLimb);
                    else
                        ModAPI.Notify("The armor is not attached to anything");
                })
            }));
            GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("sortplusbut", "Bring forward", "Bring the sprite of the armor forward.", new UnityAction[1]
            {
                (UnityAction) (() => GetComponent<SpriteRenderer>().sortingOrder++)
            }));
            GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("sortminusbut", "Bring back", "Bring the sprite of the armor back.", new UnityAction[1]
            {
                (UnityAction) (() => GetComponent<SpriteRenderer>().sortingOrder--)
            }));
        }
        public void SpawnOtherParts(ArmorProperties[] properties)
        {
            for (int I = 0; I <= SetPieces.Length - 1; I++)
            {
                GameObject other = ModAPI.CreatePhysicalObject("OtherArmor", GetComponent<SpriteRenderer>().sprite);
                other.transform.position = transform.position;
                other.AddComponent<SerialiseInstructions>().OriginalSpawnableAsset = ModAPI.FindSpawnable("Rod");

                PhysicalBehaviour phys = GetComponent<PhysicalBehaviour>();

                other.GetComponent<PhysicalBehaviour>().InitialMass = phys.InitialMass;
                other.GetComponent<PhysicalBehaviour>().TrueInitialMass = phys.TrueInitialMass;
                other.GetComponent<PhysicalBehaviour>().InitialGravityScale = phys.InitialGravityScale;
                other.GetComponent<PhysicalBehaviour>().rigidbody.mass = phys.rigidbody.mass;

                ArmorBehaviour otherArmor = other.AddComponent<ArmorBehaviour>();
                otherArmor.spawn = false;

                otherArmor.prop = prop;

                otherArmor.offset = offset;
                otherArmor.scaleOffset = scaleOffset;
                SetPieces[I] = otherArmor;
                

            }
            SetPartProperties(properties);
        }
        public void SetPartProperties(ArmorProperties[] properties)
        {
            spawn = false;
            int I = 0;
            foreach (ArmorBehaviour armor in SetPieces)
            {
                armor.prop = properties[I];
                I++;
                armor.SetProperties();
                if (armor.prop.clone)
                    armor.CloneSelf();
            }
        }
        void Update()
        {
            if (equipped && GetComponent<FixedJoint2D>().connectedBody.gameObject.GetComponent<GripBehaviour>() && GetComponent<FixedJoint2D>().connectedBody.gameObject.GetComponent<GripBehaviour>().CurrentlyHolding)
            {
                GripBehaviour grip = GetComponent<FixedJoint2D>().connectedBody.gameObject.GetComponent<GripBehaviour>();
                Nocollide(grip.CurrentlyHolding.gameObject);
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!decorative)
            {
                LimbBehaviour limb = collision.gameObject.GetComponent<LimbBehaviour>();
                ArmorBehaviour arm = collision.gameObject.GetComponent<ArmorBehaviour>();
                if (arm)
                {
                    Nocollide(arm.gameObject);
                }
                if (limb)
                {
                    Nocollide(limb.gameObject);
                    // Bodypart sections are Torso, Head, Arms, and Legs
                    // Bodyparts are UpperBody, MiddleBody, LowerBody etc.
                    if (!equipped && limb.gameObject.name == armorPiece)
                    {
                        Attach(limb);
                    }
                }
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                //ModAPI.Notify(collision.gameObject.layer.ToString());
            }
        }
        public void Nocollide(GameObject col)
        {
            NoCollide noCol = gameObject.AddComponent<NoCollide>();
            noCol.NoCollideSetA = GetComponents<Collider2D>();
            noCol.NoCollideSetB = col.GetComponents<Collider2D>();
        }
        public void Attach(LimbBehaviour limb)
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.sortingOrder = limb.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
            sr.sortingLayerName = limb.gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
            equipped = true;
            GetComponent<Rigidbody2D>().isKinematic = true;
            transform.parent = limb.transform;
            transform.localEulerAngles = new Vector3(0, 0, 0);
            transform.localPosition = offset;
            transform.localScale = scaleOffset;
            transform.parent = null;
            FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
            joint.dampingRatio = 1;
            joint.frequency = 0;
            joint.connectedBody = limb.GetComponent<Rigidbody2D>();
            GetComponent<Rigidbody2D>().isKinematic = false;



            attachedLimb = limb;
        }
        public void Detach(LimbBehaviour limb)
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            equipped = false;
            foreach (FixedJoint2D joint in GetComponents<FixedJoint2D>())
            {
                if (joint.connectedBody = limb.gameObject.GetComponent<Rigidbody2D>())
                    Destroy(joint);
            }
            attachedLimb = null;
        }
    }

    public struct ArmorProperties
    {
        public string sprite;
        public string armorPiece;
        public int armorTier;
        public float mass;
        public bool clone;
        public Vector3 offset;
        public Vector3 scaleOffset;
        public string graySprite;
    }
}
// Originally uploaded by 'kubason'. Do not reupload without their explicit permission.
