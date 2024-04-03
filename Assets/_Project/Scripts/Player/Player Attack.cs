using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;

    public float attackRange = 0.5f;

    public LayerMask enemyLayers;

    public float _attackPower = 5f;

    // Update is called once per frame
    void Update()
    {
        //ataque
        if (Input.GetMouseButtonDown(0))
        {
            Attack();

        }
    }

    void Attack()
    {
        //attack animation
        animator.SetTrigger("IsAttack");
        //detect enemies
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
    
        //apply damage
        foreach (Collider enemy in hitEnemies)
        {
            //Debug.Log("We hit " + enemy.name);

            enemy.transform.GetComponent<EnemyHealth>().TakeDamage(_attackPower);

        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
