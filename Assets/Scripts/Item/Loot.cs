using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Loot :ScriptableObject
{
    public Sprite lootIamge;
    public string Name;
    public int dropChance;
    public Loot()
    {
        this.Name = Name;
        this.dropChance = dropChance;
    }
    // Start is called before the first frame update
    
}
