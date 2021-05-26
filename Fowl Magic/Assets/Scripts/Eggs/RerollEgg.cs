using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RerollEgg : EggBasic
{
    protected List<Orb> OrbList = new List<Orb>();

    //Particles
    [Header("Child Particles")]
    [SerializeField]
    protected GameObject ReRollPartilce;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Speaker = GameObject.FindGameObjectWithTag("Speaker");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void SmashEgg()
    {
        
        OrbList.AddRange(FindObjectsOfType<Orb>().ToList());
        SpawnThenDestroyParticle(ReRollPartilce, transform);

        foreach (Orb orb in OrbList)
        {
            if (orb.GetIFSelected() == false)
            {
                Tier Otier;
                Otier = orb.GetTier();

                int RRange = Random.Range(1, 5);

                if (Otier == Tier.Tier1)
                {
                    switch (RRange)
                    {
                        case 1:
                            orb.SetElement(Element.Fire);
                            break;
                        case 2:
                            orb.SetElement(Element.Water);
                            break;
                        case 3:
                            orb.SetElement(Element.Air);
                            break;
                        case 4:
                            orb.SetElement(Element.Plant);
                            break;
                    }
                }
                else if (Otier == Tier.Tier2)
                {
                    switch (RRange)
                    {
                        case 1:
                            orb.SetElement(Element.Cinder);
                            break;
                        case 2:
                            orb.SetElement(Element.Lava);
                            break;
                        case 3:
                            orb.SetElement(Element.Rain);
                            break;
                        case 4:
                            orb.SetElement(Element.Swamp);
                            break;
                    }
                }
                else if (Otier == Tier.Tier3)
                {
                    switch (RRange)
                    {
                        case 1:
                            orb.SetElement(Element.Mystic);
                            break;
                        case 2:
                            orb.SetElement(Element.Spark);
                            break;
                        case 3:
                            orb.SetElement(Element.Obsidian);
                            break;
                        case 4:
                            orb.SetElement(Element.Urban);
                            break;
                    }
                }
            }




        }

        base.SmashEgg();
    }
}
