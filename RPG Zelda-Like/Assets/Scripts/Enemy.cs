using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyObject enemySettings;

    public string names;
    public int life;
    public float speed;
    public float attack;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        anim.runtimeAnimatorController = enemySettings.animController;

        names = enemySettings.names;
        life = enemySettings.life;
        speed = enemySettings.speed;
        attack = enemySettings.attack;

        Debug.Log("Inimigo " + names + " inicializado com vida: " + life);
    }

    public void ReceberDano()
    {
        this.life--;
        Debug.Log("Inimigo " + names + " recebeu dano. Vida restante: " + life);

        Debug.Log("Vida restante: " + life);
        if(this.life == 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
