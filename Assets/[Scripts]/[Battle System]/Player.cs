using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string ID;
    public int Health = 50;

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
    
}
