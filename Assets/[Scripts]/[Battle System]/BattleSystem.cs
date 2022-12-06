using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BattleSystem : MonoBehaviour
{
    public int TurnNum;
    public float TurnSpeed;
    List<Combatants> combatants;
    Queue<Combatants> TurnOrder;

    public Queue<Combatants> CalculateActionOrder;
}
