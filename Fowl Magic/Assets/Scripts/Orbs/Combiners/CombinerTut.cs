using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinerTut : Combiner
{

    private GameObject TutorialManager;

    public override void Combine(Element OrbElement, Tier OrbTier, GameObject ExactOrb)
    {
        if (TutorialManager == null)
        {
            TutorialManager = GameObject.FindGameObjectWithTag("TutorialManager");
        }

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
            if ((Element1 == Element.Fire && Element2 == Element.Water) || (Element1 == Element.Water && Element2 == Element.Fire))
            {
                TutorialManager.GetComponent<TutorialManager>().ProgressTut(false);
                SpawnThenDestroyParticle(DestructionParticle, Orb1Transform);
                SpawnThenDestroyParticle(DestructionParticle, Orb2Transform);
            }
            if ((Element1 == Element.Plant && Element2 == Element.Water) || (Element1 == Element.Water && Element2 == Element.Plant))
            {
                TutorialManager.GetComponent<TutorialManager>().ProgressTut(false);
                SpawnOrb(Element.Swamp, Orb1Transform, Orb2Transform);
            }
            if ((Element1 == Element.Swamp && Element2 == Element.Fire) || (Element1 == Element.Fire && Element2 == Element.Swamp))
            {
                TutorialManager.GetComponent<TutorialManager>().ProgressTut(false);
                SpawnThenDestroyParticle(DestructionParticle, Orb1Transform);
                SpawnThenDestroyParticle(DestructionParticle, Orb2Transform);
            }
            if ((Element1 == Element.Swamp && Element2 == Element.Lava) || (Element1 == Element.Lava && Element2 == Element.Swamp))
            {
                TutorialManager.GetComponent<TutorialManager>().ProgressTut(false);
                SpawnOrb(Element.Urban, Orb1Transform, Orb2Transform);
            }
            if ((Element1 == Element.Urban && Element2 == Element.Air) || (Element1 == Element.Air && Element2 == Element.Urban))
            {
                TutorialManager.GetComponent<TutorialManager>().ProgressTut(false);
                SpawnOrb(Element.GreyMatter, Orb1Transform, Orb2Transform);
            }


            //Clear Lists
            ElementList.Clear();
            TierList.Clear();
            OrbLocationList.Clear();



        }
    }

    private void SpawnOrb(Element OrbResult, Transform Orb1Transform, Transform Orb2Transform)
    {
        //Create New Orb at Second Orb Location
        OrbTypeToSpawn = OrbResult;
        GameObject SpawnedOrb = Instantiate(OrbPrefab, new Vector2(Orb2Transform.position.x, Orb2Transform.position.y), Orb2Transform.rotation);
        SpawnedOrb.GetComponent<Orb>().SetElement(OrbTypeToSpawn);

        if (OrbTypeToSpawn == Element.GreyMatter)
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

    

}
