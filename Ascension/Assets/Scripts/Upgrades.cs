using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public bool multiShot = false;
    public bool expArrow = false;
    public bool poiArrow = false;
    [SerializeField] UpgradeInventoryUI InvUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMultiShot(Sprite icon)
    {
        multiShot = true;
        InvUI.UpdateIcons(icon);
    }

    public void setExpArrow(Sprite icon)
    {
        poiArrow = false;
        expArrow = true;
        InvUI.UpdateIcon1(icon);
    }

    public void setPoiArrow(Sprite icon)
    {
        expArrow = false;
        poiArrow = true;
        InvUI.UpdateIcon1(icon);
    }
}
