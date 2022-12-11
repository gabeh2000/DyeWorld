using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int vida = 2;
    public int tipo_inimigo = 0;
    public float MovementSpeed = 1;
    public Transform targetPlayer;
    public int dano = 1;

    private void Start()
    {
        targetPlayer =  GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update() 
    {
        transform.position = Vector2.MoveTowards(transform.position,targetPlayer.position,MovementSpeed*Time.deltaTime);
    }

//    public virtual void TakeDamage(int damage, int damageType);
   public virtual void TakeDamage(int damage, int damageType)
    {
        if(damageType==tipo_inimigo){
            vida -= damage;
        }
        if(vida<=0){
            Die();
        }
    }

    protected void Die()
    {
        Destroy(gameObject);
    }  
    
}
