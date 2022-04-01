using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : CharacterCombat
{
    public event System.Action OnAttack;
    public Transform attackPoint;

    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    CharacterStats mystats;



    public override void Start()
    {
        mystats = GetComponent<CharacterStats>();
    }




    public override void Update()
    {
        base.Update();
        if (Input.GetMouseButtonDown(1))
        {
            AttackCheck();
        }
    }

    public void AttackCheck()
    {
        if (attackCooldown <= 0f)
        {
            if( OnAttack != null)
            {
                OnAttack();
                Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
                foreach(Collider enemy in hitEnemies)
                {
                    Debug.Log("We hit" + enemy.name);
                    enemy.GetComponent<EnemyStats>().TakeDamage(mystats.damage.GetValue());
                }
            }
            attackCooldown = 1f / attackSpeed;
            lastAttackTime = Time.time;
            InCombat = true;
            
        }
        
            
        

    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }



}
