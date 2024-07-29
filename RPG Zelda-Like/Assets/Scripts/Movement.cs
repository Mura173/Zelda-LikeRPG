using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Variáveis Inspector
    Animator anim;
    Rigidbody2D rb;

    public float speed;
    Vector2 movement;
    Vector2 lastMovement;

    public float attackDuration = 1f;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movimentacao();

        if (movement != Vector2.zero)
        {
            IdleAnim();
            lastMovement = movement; // Armazena última direção do movimento
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            AttackAnim();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void Movimentacao()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("horizontal", movement.x);
        anim.SetFloat("vertical", movement.y);
        anim.SetFloat("speed", movement.sqrMagnitude);
    }

    void IdleAnim()
    {
        anim.SetFloat("horizontalIdle", movement.x);
        anim.SetFloat("verticalIdle", movement.y);
    }

    void AttackAnim()
    {
        // Verifica se a animação de ataque não está em andamento
        if (!anim.GetBool("isAttacking"))
        {
            StartCoroutine(PerformAttack());
        }
    }

    IEnumerator PerformAttack()
    {
        anim.SetBool("isAttacking", true);

        if (movement == Vector2.zero) // Se o personagem estiver em idle
        {
            anim.SetFloat("horizontalAttack", lastMovement.x);
            anim.SetFloat("verticalAttack", lastMovement.y);
        }
        else
        {
            anim.SetFloat("horizontalAttack", movement.x);
            anim.SetFloat("verticalAttack", movement.y);
        }

        yield return new WaitForSeconds(attackDuration);
        anim.SetBool("isAttacking", false);
    }
}
