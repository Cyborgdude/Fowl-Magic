using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combiner : MonoBehaviour
{
    //Points
    [SerializeField]
    protected int Tier1Points;
    [SerializeField]
    protected int PointMulti;

    //Lists
    protected List<GameObject> OrbList;
    protected List<Transform> OrbLocationList;
    protected List<Element> ElementList;
    protected List<Tier> TierList;

    //Managers
    [SerializeField]
    protected GameObject PointTracker;
    [SerializeField]
    protected GameObject Speaker;

    [SerializeField]
    protected GameObject LossArea;

    //Spawnable Objects
    [SerializeField]
    protected GameObject OrbPrefab;

    //Spawnable Particles
    [SerializeField]
    protected GameObject DestructionParticle;
    [SerializeField]
    protected GameObject Posotive;
    [SerializeField]
    protected GameObject Negative;

    //SFX
    [SerializeField]
    protected AudioClip SFXPosotive;
    [SerializeField]
    protected AudioClip SFXNegative;


    [SerializeField]
    protected GameObject Debris1;

    [SerializeField]
    protected GameObject TransformParticle;

    //Results of Combination
    protected int PointsToAdd = 0;
    protected Element OrbTypeToSpawn = Element.Fire;

    // Use this for initialization
    void Start () {

        PointTracker = GameObject.FindGameObjectWithTag("PointTracker");
        LossArea = GameObject.FindGameObjectWithTag("LossArea");
        Speaker = GameObject.FindGameObjectWithTag("Speaker");
        Tier1Points = 5;
        PointMulti = 10;

        OrbList = new List<GameObject>();
        OrbLocationList = new List<Transform>();
        ElementList = new List<Element>();
        TierList = new List<Tier>();
        
    }
	
	// Update is called once per frame
	void Update () {

	}


    public virtual void Combine(Element OrbElement, Tier OrbTier, GameObject ExactOrb)
    {

        if (OrbList.Count != 0)
        {
            foreach (GameObject ListOrb in OrbList)
            {
                if (ExactOrb == ListOrb)
                {
                    //Already in list so remove
                    print("In List");
                    OrbList.Remove(ListOrb);
                    OrbLocationList.Remove(ListOrb.transform);
                    ElementList.Remove(OrbElement);
                    TierList.Remove(OrbTier);
                    break;
                }
                else
                {
                    //Not in list so add
                    print("Not in List");
                    OrbList.Add(ExactOrb);
                    OrbLocationList.Add(ExactOrb.transform);
                    ElementList.Add(OrbElement);
                    TierList.Add(OrbTier);
                    break;
                }
            }
        }
        else
        {
            //Nothing in list so add
            OrbList.Add(ExactOrb);
            OrbLocationList.Add(ExactOrb.transform);
            ElementList.Add(OrbElement);
            TierList.Add(OrbTier);
        }

    }


}
