using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleVisOnLoss : MonoBehaviour, ILoss
{
    Renderer RN;
    Text DText;

    // Start is called before the first frame update
    void Start()
    {
       if(GetComponent<Renderer>() != null)
        {
            RN = GetComponent<Renderer>();
        }
       if(GetComponent<Text>() != null)
        {
            DText = GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ILoss()
    {
        if (GetComponent<Renderer>() != null)
        {
            RN.enabled = !RN.enabled;
        }
        if (GetComponent<Text>() != null)
        {
            DText.enabled = !DText.enabled;
        }
    }
}
