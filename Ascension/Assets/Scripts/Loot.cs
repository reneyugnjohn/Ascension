using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public string lootName;
    public int dropChance;
    public GameObject lootPrefab;

    public Loot(string lootName, int dropChance, GameObject lootPrefab)
    {
        this.lootName = lootName;
        this.dropChance = dropChance;
        this.lootPrefab = lootPrefab;
    }

}
