using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatants : MonoBehaviour
{
    public Player Player;
    public Enemy Enemy;
    public Ability playerAction;
    public Ability EnemyAction;

    void Update()
    {
        if(playerAction.damage > 0)
        {
            if(playerAction.abilities.Count > 0)
            {
                //if specific player abilities were used, then specific actions would happen after the damage was applied
            }
            Enemy.Health -= playerAction.damage;
        }

        if (EnemyAction.damage > 0)
        {
            Player.Health -= EnemyAction.damage;
        }
    }
}
