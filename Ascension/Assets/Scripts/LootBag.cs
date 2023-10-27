using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
   // public GameObject droppedItemPrefab;
    public List<Loot> lootList = new List<Loot>();
    public float dropForce = 300f;
   
    List<Loot> GetDroppedItems()
    {
        int randomNum = Random.Range(1, 101);
        List<Loot> possibleItems = new List<Loot>();
        foreach(Loot item in lootList)
        {
            if(randomNum <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        return possibleItems;
    }

    public void InstantiateLoot(Vector3 spawnPos)
    {
        List<Loot> droppedItems = GetDroppedItems();
        if(droppedItems != null)
        {
            foreach(Loot item in droppedItems)
            {
                GameObject lootGameObject = Instantiate(item.lootPrefab, spawnPos, Quaternion.identity);

                Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
            }
        }
    }

}
