using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, ILoss
{



    [Header("Orbs")]
    [SerializeField]
    private GameObject OrbPrefab;
    [SerializeField]
    private int SecondsBetweenSpawns;
    [SerializeField]
    private int SecondsBeforeFirstSpawn;
    [SerializeField]
    private int RandomOrbsBetweenSequence = 1;
    private Element OrbTypeToSpawn;
    private List<Element> ElementList;
    private int IndexToSpawn;

    [Header("Eggs")]
    [SerializeField]
    private int SecondsBetweenEggSpawns;
    [SerializeField]
    private int SecondsBeforeFirstEggSpawn;
    [SerializeField]
    private GameObject[] PowerEggPrefabs = new GameObject[3];

    [Header("Grey Matter")]
    [SerializeField]
    private int SecondsBetweenGMSpawns;
    [SerializeField]
    private int SecondsBeforeFirstGMSpawn;



    // Use this for initialization
    void Start () {
        ElementList = new List<Element> { Element.Fire, Element.Water, Element.Air, Element.Plant};
        ShuffleElements();
        IndexToSpawn = ElementList.Count + RandomOrbsBetweenSequence;
        InvokeRepeating("SpawnOrb",SecondsBeforeFirstSpawn,SecondsBetweenSpawns);
        InvokeRepeating("SpawnEgg", SecondsBeforeFirstEggSpawn, SecondsBetweenEggSpawns);
        InvokeRepeating("SpawnGM", SecondsBeforeFirstGMSpawn, SecondsBetweenGMSpawns);

    }
	
	// Update is called once per frame
	void Update () {
    }

    private void SpawnOrb()
    {

        //Attempt 2
        if (IndexToSpawn < ElementList.Count)
        {
            OrbTypeToSpawn = ElementList[IndexToSpawn];
            IndexToSpawn++;
        }
        else
        {
            OrbTypeToSpawn = ElementList[Random.Range(0, ElementList.Count)];
            ShuffleElements();
            IndexToSpawn = 0;
        }


        GameObject SpawnedOrb = Instantiate
            (
            OrbPrefab,
            new Vector2(Random.Range(transform.position.x - 1, transform.position.x + 1), transform.position.y),
            Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)))
            );
        SpawnedOrb.GetComponent<Orb>().SetElement(OrbTypeToSpawn);
    }


    //Attempt 2
    private void ShuffleElements()
    {

        for (int i = 0; i < ElementList.Count; i++)
        {
            Element TemporaryStorage = ElementList[i];

            int RandomIndex = Random.Range(i, ElementList.Count);

            ElementList[i] = ElementList[RandomIndex];
            ElementList[RandomIndex] = TemporaryStorage;
        }     
    }

    private void SpawnEgg()
    {
        GameObject SpawnedEgg = Instantiate
            (
            PowerEggPrefabs[Random.Range(0, PowerEggPrefabs.Length)],
            new Vector2(Random.Range(transform.position.x - 1, transform.position.x + 1), transform.position.y),
            Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)))
            );
    }

    private void SpawnGM()
    {
        GameObject SpawnedGM = Instantiate
            (
            OrbPrefab,
            new Vector2(Random.Range(transform.position.x - 1, transform.position.x + 1), transform.position.y),
            Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)))
            );
        SpawnedGM.GetComponent<Orb>().SetElement(Element.GreyMatter);
    }

    public void ILoss()
    {
        CancelInvoke("SpawnOrb");
        CancelInvoke("SpawnEgg");
        CancelInvoke("SpawnGM");
    }

}
