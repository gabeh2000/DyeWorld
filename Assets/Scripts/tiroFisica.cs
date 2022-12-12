using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiroFisica : MonoBehaviour
{   
    public float speedo = 20f;
    public Rigidbody2D rb;
    public int dano = 1;
    public int tipo_tiro = 0;
    // Start is called before the first frame update
    
    void Start()
    {
        rb.velocity = transform.up * speedo;
    }
    
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
    public void setTipo_tiro(int valor_tipo){
        tipo_tiro = valor_tipo;
    }
    void OnTriggerEnter2D(Collider2D hitInfo) {
        //Debug.Log(hitInfo.name);
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        Wall wall = hitInfo.GetComponent<Wall>();
        if(enemy !=null){
        
            enemy.TakeDamage(dano, tipo_tiro);
            Destroy(gameObject);
        
        }else if(wall!=null){
            Destroy(gameObject);
        }
        
        
    }
   
}