using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public bool multiShot = false;
    public bool expArrow = false;
    [SerializeField] UpgradeInventoryUI InvUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMultiShot(bool inInv, Sprite icon)
    {
        
        multiShot = inInv;
        if(inInv)
        {
            InvUI.UpdateIcons(icon);
        }
    }

    public void setExpArrow(bool inInv, Sprite icon)
    {

        expArrow = inInv;
        if (inInv)
        {
            InvUI.UpdateIcon1(icon);
        }
    }
}
