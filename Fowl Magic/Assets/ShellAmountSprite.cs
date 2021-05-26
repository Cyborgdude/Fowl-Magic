using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShellAmountSprite : MonoBehaviour
{

    [SerializeField]
    private Sprite TinyShell;
    [SerializeField]
    private Sprite SmallShell;
    [SerializeField]
    private Sprite MediumShell;
    [SerializeField]
    private Sprite LargeShell;
    [SerializeField]
    private Sprite HugeShell;
    [SerializeField]
    private int SmallShellMin;
    [SerializeField]
    private int MediumShellMin;
    [SerializeField]
    private int LargeShellMin;
    [SerializeField]
    private int HugeShellMin;


    void Start()
    {
        Image ShellImage = GetComponent<Image>();
        int ShellAmount = Game.Current.GData.EggCount;

        if(ShellAmount >= HugeShellMin)
        {
            ShellImage.sprite = HugeShell;
        }
        else if(ShellAmount >= LargeShellMin)
        {
            ShellImage.sprite = LargeShell;
        }
        else if(ShellAmount >= MediumShellMin)
        {
            ShellImage.sprite = MediumShell;
        }
        else if(ShellAmount >= SmallShellMin)
        {
            ShellImage.sprite = SmallShell;
        }
        else
        { 
            ShellImage.sprite = TinyShell; 
        }







    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
