
using UnityEngine;
using UnityEngine.SceneManagement;

public class charScript : MonoBehaviour
{
    public float MovementSpeed = 5;
    public float JumpForce = 5;
    bool facingleft = true;
    public int vida  = 3;
    public const int INTERFACE_SCENE = 0;

    private Rigidbody2D _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement,0,0)*Time.deltaTime*MovementSpeed;
        if(Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f){
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        if(movement>0 && facingleft){
            Flip();
        }
         if(movement<0 && !facingleft){
            Flip();
        }
    }

    public void TakeDamage(int damage){
        vida -= damage;
        if(vida<=0){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
        SceneManager.LoadScene(INTERFACE_SCENE);
    }

    void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *=-1;
        gameObject.transform.localScale = currentScale;
        facingleft = !facingleft; 
    }

    void OnCollisionEnter2D(Collision2D hitInfo) {
        if(hitInfo.gameObject.tag == "Inimigo"){
            TakeDamage(1);
        }
    }
}
