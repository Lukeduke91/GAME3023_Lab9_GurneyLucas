using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string ID;
    public int Health;
    public StatusEffect SatusEffectList;

    public void TakeDamage(int damage)
    {
        if (SatusEffectList == StatusEffect.FIRE)
        {
            damage *= 2;
        }
        if (SatusEffectList == StatusEffect.WATER)
        {
            damage *= 2;
        }
        if (SatusEffectList == StatusEffect.EARTH)
        {
            damage *= 2;
        }
        if (SatusEffectList == StatusEffect.LIGHT)
        {
            damage *= 2;
        }
        if (SatusEffectList == StatusEffect.DARK)
        {
            damage *= 2;
        }
        Health -= damage;
    }
}
