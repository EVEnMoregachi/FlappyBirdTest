using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Enemy : Unit
{
    public ENEMY_TYPE enemyType;
    public DAMAGE_POWER power = DAMAGE_POWER.Enemy_Hurt;
    public bool isDead = false;

    public override void OnStart()
    {
        Destroy(this.gameObject, 8f);
    }

    public override void OnUpdate()
    {
        this.transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
        if(this.enemyType == ENEMY_TYPE.Swing_Enemy)
        {
            this.transform.position = new Vector3(this.transform.position.x, Mathf.Sin(Time.time * 2f) * 2f, 0);
        }
        Fire();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Bullet hurt = collision.GetComponent<Bullet>();
            if (hurt != null)
            {
                this.HP -= (float)hurt.power;
                Destroy(hurt.gameObject);
            }
        }
        if (this.HP <= 0 && !isDead)
        {
            isDead = true;
            Dead();
        }
    }

    public virtual void Dead()
    {
        if (this.gameObject.name == "Enemy(Clone)")
        {
            Game.Instance.GetPoint(1);
        }
        else if (this.gameObject.name == "Enemy2(Clone)")
        {
            Game.Instance.GetPoint(2);
        }
        else if (this.gameObject.name == "Enemy3(Clone)")
        {
            Game.Instance.GetPoint(3);
        }
        this.animator.SetTrigger("Dead");
        Destroy(this.gameObject, 0.2f);
    }
}
