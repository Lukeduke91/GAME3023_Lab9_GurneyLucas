using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.WSA;

public class Ability : MonoBehaviour
{
    public enum enemyAbilityPool
    {
        //Theif
        STEAL,
        STAB,
        REUSE,
        //Barbarian
        SMASH,
        TANK,
        //Swashbuckler
        SLASH,
        PARRY,
        COUNTER,
        TRIP
    }
    public enum playerAbilityPool
    {
        LIGHTA,
        HEAVYA,
        BLOCK,
        SBOOST,
        ABOOST
    }
    public List<Ability> abilities;
    public Player player;
    public Enemy enemy;
    public string Titles;
    public bool isProtected;
    public int damage;
    void AbilityPool(playerAbilityPool PA, enemyAbilityPool EA)
    {
        
        //Enemy Pool
        if(Titles == "Theif")
        {
            switch(EA)
            {
                case enemyAbilityPool.STEAL:
                    //PA = playerAbilityPool.LIGHTA;
                    //steal players turn
                    break;
                case enemyAbilityPool.STAB:
                    damage = 15;
                    break;
                case enemyAbilityPool.REUSE:
                    if (EA == enemyAbilityPool.STEAL)
                    {
                        // reuse the turn
                    }
                    break;
            }
        }

        if (Titles == "Barbarian")
        {
            switch (EA)
            {
                case enemyAbilityPool.SMASH:
                    damage = 30;
                    break;
                case enemyAbilityPool.TANK:
                    damage -= 25;
                    break;
            }
        }

        if (Titles == "Swashbuckler")
        {
            switch (EA)
            {
                case enemyAbilityPool.SLASH:
                    damage = 10;
                    break;
                case enemyAbilityPool.PARRY:
                    damage -= 10;
                    break;
                case enemyAbilityPool.COUNTER:
                    damage = damage;
                    break;
                case enemyAbilityPool.TRIP:
                    damage = 0;
                    break;
            }
        }
        //Player Pool
        if (Titles == "Player")
        {
            switch(PA)
            {
                case playerAbilityPool.LIGHTA:
                    damage = 25;
                    break;
                case playerAbilityPool.HEAVYA:
                    damage = 50;
                    break;
                case playerAbilityPool.BLOCK:
                    damage -= 25;
                    break;
                case playerAbilityPool.SBOOST:
                    damage = 12;
                    break;
                case playerAbilityPool.ABOOST:
                    damage += 10;
                    break;
            }
        }

    }

    //void damagePool()
    //{

    //}
}
