using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTipo2 : Enemy
{   
    public int[] colors = new int[2]{0,1};

    // private void Start(){
    //     targetPlayer =  GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    // }

    // private void Update(){
    //     if(targetPlayer != null){
    //         transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, MovementSpeed * Time.deltaTime);
    //     }
    // }

    public override void TakeDamage(int damage, int damageType){   
        if(damageType == colors[0]){
            vida -= damage;
            colors[0] = -1;
        }else if(damageType == colors[1]){
            vida -= damage;
            colors[1] = -1;
        }

        if(vida<=0){
            Die();
        }
    }

}
