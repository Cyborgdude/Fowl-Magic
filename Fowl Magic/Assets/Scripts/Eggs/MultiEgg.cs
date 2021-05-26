using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiEgg : EggBasic
{
    //Managers
    [Header("Child Managers")]
    [SerializeField]
    protected GameObject PointTracker;

    //Particles
    [Header("Child Particles")]
    [SerializeField]
    protected GameObject Upgrade;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        PointTracker = GameObject.FindGameObjectWithTag("PointTracker");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void SmashEgg()
    {
        PointTracker.GetComponent<IPointUpdate>().ISetPointMulti(2,10);
        SpawnThenDestroyParticle(Upgrade, transform);
        base.SmashEgg();
    }
}
