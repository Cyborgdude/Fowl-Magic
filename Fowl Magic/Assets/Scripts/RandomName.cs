using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] Names =
            new string[]
            {
                "Kim",
                "Clare",
                "Beth",
                "Denise",
                "Kerry",
                "Sian",
                "Rachel",
                "Debrah",
                "Grace",
                "Megan",
                "Emma",
                "Cassiopeia",
                "Eir",
                "Bell",
                "Jasmine",
                "Nicole",
                "Leona",
                "Sareena",
                "Sabrina",
                "Kelly"
            }
            
            ;


        GetComponent<Text>().text = "Ms." + Names[Random.Range(0, Names.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
