using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Combat;
using RPG.Control;
using RPG.Core;

public class AIController : MonoBehaviour
{
    [SerializeField] float chaseDistance = 5f;

    Fighter fighter;
    Health health;
    GameObject player;

    private void Start(){
        fighter = GetComponent<Fighter>();
        health = GetComponent<Health>();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if(health.IsDead()) return;
        if(InAttackRangeOfPlayer() && fighter.CanAttack(player))
        {
            GetComponent<Fighter>().Attack(player);
        }
        else{
            fighter.Cancel();
        }

    }

    private bool InAttackRangeOfPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        return distanceToPlayer < chaseDistance;
    }
}

