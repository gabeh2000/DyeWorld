using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    
    EnemySpawner enemySpawner;
    
    public int vida = 2;
    public int tipo_inimigo = 0;
    public int dano = 1;
    public float speed;
    public float jumpForce;
    public Transform targetPlayer;
    public float nextWaypointDistance= 3f;

    public float repathRate = 0.5f;
    private float lastRepath = float.NegativeInfinity;
    public Path path;
    private int currentWaypoint=0;
    public bool reachedEndOfPath = false;
    private Seeker seeker;
    private Rigidbody2D _rigidbody;
    public void Start()
    {
        speed= 3;
        jumpForce= 10;
        targetPlayer =  GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        seeker = GetComponent<Seeker>();
        _rigidbody= GetComponent<Rigidbody2D>();
        
        seeker.StartPath(transform.position, targetPlayer.position, OnPathComplete);

        // InvokeRepeating("UpdatePath",0f, 0.5f); 
    }

   

    public void OnPathComplete(Path p){
        
        Debug.Log("YAYA"+p.error);
        p.Claim(this);
        if(!p.error){
            if (path != null) path.Release(this);
            path=p;
            currentWaypoint=0;
        }else{
            p.Release(this);
        }
    }
    // void RotateSprite(){
    //     if(rb.velocity.x>= 0.01f){
    //         enemyGFX.localScale= new Vector3(-1f,1f,1f);
    //     }else if(rb.velocity.x<= 0.01f){
    //         enemyGFX.localScale= new Vector3(1f,1f,1f);
    //     }
    // }

    public void Update() 
    {

        // if(targetPlayer != null){
        //     transform.position = Vector2.MoveTowards(transform.position,targetPlayer.position,speed*Time.deltaTime);
        // }
        
        if (Time.time > lastRepath + repathRate && seeker.IsDone()) {
            lastRepath = Time.time;

            // Start a new path to the targetPosition, call the the OnPathComplete function
            // when the path has been calculated (which may take a few frames depending on the complexity)
            seeker.StartPath(transform.position, targetPlayer.position, OnPathComplete);
        }
        if(path==null){
            return;
        }
        reachedEndOfPath=false;
        float distanceToWaypoint;

        
        while (true){
        
            distanceToWaypoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        
            if(distanceToWaypoint<nextWaypointDistance){
                if (currentWaypoint + 1 < path.vectorPath.Count) {
                    currentWaypoint++;
                } else {
        
                    reachedEndOfPath = true;
                    break;
                }
            } else {
                break;
            }
            }
        var speedFactor = reachedEndOfPath ? (Mathf.Sqrt(distanceToWaypoint/nextWaypointDistance)) : 1.5f;

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        Vector3 velocity = new Vector3(dir.x,0,0)  * speed * speedFactor;
        // Vector3 vel= new Vector3()
        // transform.position+= vel*Time.deltaTime*speed;
        transform.position += velocity * Time.deltaTime;
        if(dir.y>0 && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        

        // RotateSprite();
    }

   public virtual void TakeDamage(int damage, int damageType)
    {
        if(damageType == tipo_inimigo){
            vida -= damage;
            if(vida<=0){
                Die();
            }
        }
    }

    protected void Die()
    {
        enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawn").GetComponent<EnemySpawner>();
        enemySpawner.DestroyEnemy(gameObject);
        Destroy(gameObject);
    }  
    
}
