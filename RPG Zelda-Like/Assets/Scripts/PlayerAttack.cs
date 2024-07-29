using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Transform pointAttack;

    [SerializeField]
    private float rayAttack;

    [SerializeField]
    private LayerMask layersAttack;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Attack();
        }
    }

    private void OnDrawGizmos()
    {
        if(this.pointAttack != null)
        {
            Gizmos.DrawWireSphere(this.pointAttack.position, this.rayAttack);
        }
    }

    private void Attack()
    {
        // Verifica se existe algum colisor dentro da área
        Collider2D enemyCollider = Physics2D.OverlapCircle(this.pointAttack.position, this.rayAttack, this.layersAttack);

        if(enemyCollider != null)
        {
            // Enemy Damage
            Enemy enemy = enemyCollider.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.ReceberDano();
            }

        }
    }
}
