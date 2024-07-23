using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed;
    Vector2 movement;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");

        movement = new Vector2 (movX, movY);

        transform.Translate (movement * speed);

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);

        if (movement != Vector2.zero)
        {
            anim.SetFloat("horizontalIdle", movement.x);
            anim.SetFloat("verticalIdle", movement.y);
        }
    }
}
