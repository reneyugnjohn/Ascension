using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public bool multiShot = false;
    public bool pierceShot = false;
    public bool expArrow = false;
    public bool poiArrow = false;
    public bool froArrow = false;
    [SerializeField] UpgradeInventoryUI InvUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPierceShot(Sprite icon)
    {
        pierceShot = true;
        multiShot = false;
        InvUI.UpdateIcons(icon);
    }

    public void setMultiShot(Sprite icon)
    {
        multiShot = true;
        pierceShot = false;
        InvUI.UpdateIcons(icon);
    }

    public void setExpArrow(Sprite icon)
    {
        poiArrow = false;
        froArrow = false;
        expArrow = true;
        InvUI.UpdateIcon1(icon);
    }

    public void setPoiArrow(Sprite icon)
    {
        expArrow = false;
        froArrow = false;
        poiArrow = true;
        InvUI.UpdateIcon1(icon);
    }

    public void setFroArrow(Sprite icon)
    {
        poiArrow = false;
        expArrow = false;
        froArrow = true;
        InvUI.UpdateIcon1(icon);
    }
}
