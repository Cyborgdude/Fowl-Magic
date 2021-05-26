using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combiner2Orbs : Combiner
{



    public override void Combine(Element OrbElement, Tier OrbTier, GameObject ExactOrb)
    {
        base.Combine(OrbElement, OrbTier, ExactOrb);

        if (OrbList.Count == 2)
        {
            foreach (GameObject ListOrb in OrbList)
            {
                Destroy(ListOrb);
            }

            OrbList.Clear();

            Transform Orb1Transform = OrbLocationList[0];
            Transform Orb2Transform = OrbLocationList[1];

            Element Element1 = ElementList[0];
            Element Element2 = ElementList[1];

            Tier Tier1 = TierList[0];
            Tier Tier2 = TierList[1];

            //Combo Logic
            //T1

            //Fire
            if (Element1 == Element.Fire || Element2 == Element.Fire)
            {
                if (Element1 == Element.Fire && Element2 == Element.Fire)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Water || Element2 == Element.Water)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Air || Element2 == Element.Air)
                {
                    SpawnOrb(Element.Cinder, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Plant || Element2 == Element.Plant)
                {
                    SpawnOrb(Element.Lava, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Cinder || Element2 == Element.Cinder)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Lava || Element2 == Element.Lava)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Rain || Element2 == Element.Rain)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Swamp || Element2 == Element.Swamp)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else
                {
                    //Tier Too Diffrent
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
            }

            //Water
            else if (Element1 == Element.Water || Element2 == Element.Water)
            {
                if (Element1 == Element.Water && Element2 == Element.Water)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Air || Element2 == Element.Air)
                {
                    SpawnOrb(Element.Rain, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Plant || Element2 == Element.Plant)
                {
                    SpawnOrb(Element.Swamp, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Cinder || Element2 == Element.Cinder)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Lava || Element2 == Element.Lava)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Rain || Element2 == Element.Rain)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Swamp || Element2 == Element.Swamp)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else
                {
                    //Tier Too Diffrent
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
            }

            //Air
            else if (Element1 == Element.Air || Element2 == Element.Air)
            {
                if (Element1 == Element.Air && Element2 == Element.Air)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Plant || Element2 == Element.Plant)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Cinder || Element2 == Element.Cinder)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Lava || Element2 == Element.Lava)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Rain || Element2 == Element.Rain)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Swamp || Element2 == Element.Swamp)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else
                {
                    //Tier Too Diffrent
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
            }

            //Plant
            else if (Element1 == Element.Plant || Element2 == Element.Plant)
            {
                if (Element1 == Element.Plant && Element2 == Element.Plant)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Cinder || Element2 == Element.Cinder)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Lava || Element2 == Element.Lava)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Rain || Element2 == Element.Rain)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Swamp || Element2 == Element.Swamp)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else
                {
                    //Tier Too Diffrent
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
            }

            //T2

            //Cinder
            else if (Element1 == Element.Cinder || Element2 == Element.Cinder)
            {
                if (Element1 == Element.Cinder && Element2 == Element.Cinder)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Lava || Element2 == Element.Lava)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Rain || Element2 == Element.Rain)
                {
                    SpawnOrb(Element.Mystic, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Swamp || Element2 == Element.Swamp)
                {
                    SpawnOrb(Element.Spark, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Mystic || Element2 == Element.Mystic)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Mystic || Element2 == Element.Mystic)
                {
                    SpawnOrb(Element.Spark, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Obsidian || Element2 == Element.Obsidian)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Urban || Element2 == Element.Urban)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else
                {
                    //Tier Too Diffrent
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
            }

            //Cinder
            else if (Element1 == Element.Lava || Element2 == Element.Lava)
            {
                if (Element1 == Element.Lava && Element2 == Element.Lava)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Rain || Element2 == Element.Rain)
                {
                    SpawnOrb(Element.Obsidian, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Swamp || Element2 == Element.Swamp)
                {
                    SpawnOrb(Element.Urban, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Mystic || Element2 == Element.Mystic)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Spark || Element2 == Element.Spark)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Obsidian || Element2 == Element.Obsidian)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Urban || Element2 == Element.Urban)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else
                {
                    //Tier Too Diffrent
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
            }

            //Rain
            else if (Element1 == Element.Rain || Element2 == Element.Rain)
            {
                if (Element1 == Element.Rain && Element2 == Element.Rain)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Swamp || Element2 == Element.Swamp)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Mystic || Element2 == Element.Mystic)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Spark || Element2 == Element.Spark)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Obsidian || Element2 == Element.Obsidian)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Urban || Element2 == Element.Urban)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else
                {
                    //Tier Too Diffrent
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
            }

            //Swamp
            else if (Element1 == Element.Rain || Element2 == Element.Rain)
            {
                if (Element1 == Element.Rain && Element2 == Element.Rain)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Mystic || Element2 == Element.Mystic)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Spark || Element2 == Element.Spark)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Obsidian || Element2 == Element.Obsidian)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Urban || Element2 == Element.Urban)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else
                {
                    //Tier Too Diffrent
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
            }

            //T3

            //Mystic
            else if (Element1 == Element.Mystic || Element2 == Element.Mystic)
            {
                if (Element1 == Element.Mystic && Element2 == Element.Mystic)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Spark || Element2 == Element.Spark)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Obsidian || Element2 == Element.Obsidian)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Urban || Element2 == Element.Urban)
                {
                    SpawnOrb(Element.Order, Orb1Transform, Orb2Transform);
                }
                else
                {
                    //Tier Too High
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
            }

            //Spark
            else if (Element1 == Element.Spark || Element2 == Element.Spark)
            {
                if (Element1 == Element.Spark && Element2 == Element.Spark)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Obsidian || Element2 == Element.Obsidian)
                {
                    SpawnOrb(Element.Entropy, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Urban || Element2 == Element.Urban)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else
                {
                    //Tier Too High
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
            }

            //Obsidian
            else if (Element1 == Element.Obsidian || Element2 == Element.Obsidian)
            {
                if (Element1 == Element.Obsidian && Element2 == Element.Obsidian)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Urban || Element2 == Element.Urban)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                }
                else
                {
                    //Tier Too High
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
            }

            //Urban
            else if (Element1 == Element.Urban || Element2 == Element.Urban)
            {
                if (Element1 == Element.Urban && Element2 == Element.Urban)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else
                {
                    //Tier Too High
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
            }

            //T4

            //Entropy
            else if (Element1 == Element.Entropy || Element2 == Element.Entropy)
            {
                if (Element1 == Element.Entropy && Element2 == Element.Entropy)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
                else if (Element1 == Element.Order || Element2 == Element.Order)
                {
                    GrantPoints(Tier1, Tier2, Orb1Transform, Orb2Transform);
                    SpawnThenDestroyParticle(Debris1, Orb2Transform);
                }
            }

            //Order
            else if (Element1 == Element.Order || Element2 == Element.Order)
            {
                if (Element1 == Element.Order && Element2 == Element.Order)
                {
                    SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
                }
            }

            else
            {
                Debug.Log("No Element");
            }




                //Clear Lists
                ElementList.Clear();
            TierList.Clear();
            OrbLocationList.Clear();



        }
    }

    private void SpawnOrb(Element OrbResult, Transform Orb1Transform ,Transform Orb2Transform)
    {
        //Create New Orb at Second Orb Location
        OrbTypeToSpawn = OrbResult;
        GameObject SpawnedOrb = Instantiate(OrbPrefab, new Vector2(Orb2Transform.position.x, Orb2Transform.position.y), Orb2Transform.rotation);
        SpawnedOrb.GetComponent<Orb>().SetElement(OrbTypeToSpawn);

        if(OrbTypeToSpawn == Element.GreyMatter)
        {
            SpawnThenDestroyParticle(Negative, Orb2Transform);
            Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXNegative, SoundType.MajorSFX, 1);
        }


        //Spawn Particles
        SpawnThenDestroyParticle(DestructionParticle, Orb1Transform);
        SpawnThenDestroyParticle(TransformParticle, Orb2Transform);
    }

    private void SpawnThenDestroyParticle(GameObject ParticleObject, Transform SpawnTransform)
    {
        GameObject ParticleObjectSpawned = Instantiate(ParticleObject, new Vector2(SpawnTransform.position.x, SpawnTransform.position.y), SpawnTransform.rotation);
        float ParticleObjectSpawnedDuration = ParticleObjectSpawned.GetComponent<ParticleSystem>().main.duration + ParticleObjectSpawned.GetComponent<ParticleSystem>().main.startLifetimeMultiplier;
        Destroy(ParticleObjectSpawned, ParticleObjectSpawnedDuration);
    }

    private void GrantPoints(Tier Orb1Tier, Tier Orb2Tier,Transform Orb1Transform, Transform Orb2Transform)
    {
        
        int PointsToAdd = 0;
        int Tier2Points = (Tier1Points * 2)+ (2 * PointMulti);
        int Tier3Points = (Tier2Points * 2) + (3 * PointMulti);
        int Tier4Points = (Tier3Points * 2) + (4 * PointMulti);


        //print(" Tier1= " + Tier1Points + " Tier2= " + Tier2Points + " Tier3= " + Tier3Points + " Tier4= " + Tier4Points);

        //Point ComboLogic
        //Tier 1
        if(Orb1Tier == Tier.Tier1 || Orb2Tier == Tier.Tier1)
        {
            if(Orb1Tier == Tier.Tier1 && Orb2Tier == Tier.Tier1)
            {
                PointsToAdd = Tier1Points + Tier1Points;
            }
            else if(Orb1Tier == Tier.Tier2 || Orb2Tier == Tier.Tier2)
            {
                PointsToAdd = Tier1Points + Tier2Points;
            }
            else if(Orb1Tier == Tier.Tier3 || Orb2Tier == Tier.Tier3)
            {
                PointsToAdd = Tier1Points + Tier3Points;
            }
            else if(Orb1Tier == Tier.Tier4 || Orb2Tier == Tier.Tier4)
            {
                PointsToAdd = Tier1Points + Tier4Points;
            }
            else
            {
                Debug.Log("Logic Error with Tier1 Point Combo");
            }
        }
        //Tier 2
        else if (Orb1Tier == Tier.Tier2 || Orb2Tier == Tier.Tier2)
        {
            if (Orb1Tier == Tier.Tier2 && Orb2Tier == Tier.Tier2)
            {
                PointsToAdd = Tier2Points + Tier2Points;
            }
            else if (Orb1Tier == Tier.Tier3 || Orb2Tier == Tier.Tier3)
            {
                PointsToAdd = Tier2Points + Tier3Points;
            }
            else if (Orb1Tier == Tier.Tier4 || Orb2Tier == Tier.Tier4)
            {
                PointsToAdd = Tier2Points + Tier4Points;
            }
            else
            {
                Debug.Log("Logic Error with Tier2 Point Combo");
            }
        }
        //Tier 3
       else if (Orb1Tier == Tier.Tier3 || Orb2Tier == Tier.Tier3)
        {
            if (Orb1Tier == Tier.Tier3 && Orb2Tier == Tier.Tier3)
            {
                PointsToAdd = Tier3Points + Tier3Points;
            }
            else if (Orb1Tier == Tier.Tier4 || Orb2Tier == Tier.Tier4)
            {
                PointsToAdd = Tier3Points + Tier4Points;
            }
            else
            {
                Debug.Log("Logic Error with Tier3 Point Combo");
            }
        }
        //Tier 4
        else if (Orb1Tier == Tier.Tier4 || Orb2Tier == Tier.Tier4)
        {
            if (Orb1Tier == Tier.Tier4 && Orb2Tier == Tier.Tier4)
            {
                PointsToAdd = (Tier4Points + Tier4Points)*2;
                int RandomShellAdd = Random.Range(5, 10);
                Game.Current.GData.EggCount = Game.Current.GData.EggCount + RandomShellAdd;
                SpawnThenDestroyParticle(Posotive, Orb2Transform);
                Speaker.GetComponent<Speaker>().PlaySoundFromSpeaker(SFXPosotive, SoundType.MajorSFX, 1);
            }
            else
            {
                Debug.Log("Logic Error with Tier4 Point Combo");
            }
        }


        PointTracker.GetComponent<IPointUpdate>().IAddPoints(PointsToAdd);

        SpawnThenDestroyParticle(DestructionParticle, Orb1Transform);
        SpawnThenDestroyParticle(DestructionParticle, Orb2Transform);
    }

}
