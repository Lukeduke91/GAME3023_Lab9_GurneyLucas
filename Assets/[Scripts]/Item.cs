using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item/New Item")]
public class Item : ScriptableObject
{
    [SerializeField]
    public Sprite icon;

    public string description = "this is an item";

    public void Use()
    {
        Debug.Log("Used item: " + name);
    }
}
