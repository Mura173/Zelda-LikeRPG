using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public int life;

    public void ReceberDano()
    {
        this.life--;
        if (this.life == 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
