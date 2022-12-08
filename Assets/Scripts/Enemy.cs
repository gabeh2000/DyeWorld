using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int vida = 1;
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

    public void TakeDamage(int damage)
    {
        vida -= damage;
        if(vida<=0){
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }  
    
}
