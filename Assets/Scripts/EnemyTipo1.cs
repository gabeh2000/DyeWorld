using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTipo1 : Enemy
{
    public int colors = 0;
    
    private void Start()
    {
        targetPlayer =  GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update() 
    {
        transform.position = Vector2.MoveTowards(transform.position,targetPlayer.position,MovementSpeed*Time.deltaTime);
    }

    // public void TakeDamage(int damage, int damageType)
    // {
    //     if(damageType==tipo_inimigo){
    //         vida -= damage;
    //     }
    //     if(vida<=0){
    //         Die();
    //     }
    // }

  
}
