using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject lootPrefabs;
    public List<Loot> lootList=new List<Loot>();
    Loot GetDroppedItem()
    {
        int random = Random.Range(0, 101);
        List<Loot> listitem = new List<Loot>();
       foreach (Loot item in lootList)
        {
            if (random <= item.dropChance)
            {
                listitem.Add(item);
                
            }
        }
       if(listitem.Count > 0)
        {
            Loot dropitem = listitem[Random.Range(0,listitem.Count)];
            return dropitem;
        }
       return null;
        
    }
    public void InstantiateLoot(Vector3 pos)
    {
        Loot droppedItem=GetDroppedItem();
        if( droppedItem != null )
        {
            GameObject LootItem= Instantiate( lootPrefabs,pos,Quaternion.identity );
            LootItem.GetComponent<SpriteRenderer>().sprite = droppedItem.lootIamge;
        }

    }
}   
