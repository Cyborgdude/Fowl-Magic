using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OrbSpawnEgg : EggBasic
{
    //OrbPrefab
    [SerializeField]
    protected GameObject OrbPrefab;


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
        
        //Spawn a random element orb
        GameObject SpawnedOrb = Instantiate
            (
            OrbPrefab,
            new Vector2(transform.position.x, transform.position.y),
            transform.rotation
            );

        //The min range is 1 to avoid grey matter spawning
        SpawnedOrb.GetComponent<Orb>().SetElement((Element)Random.Range(1, System.Enum.GetValues(typeof(Element)).Length));

        AddRandomVelocity(SpawnedOrb);

        base.SmashEgg();
    }


}
