using UnityEngine;

public class tiroScript : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab_green;
    public GameObject bulletPrefab_blue;

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.U)){
            Shoot(bulletPrefab);
        }
        else if(Input.GetKeyDown(KeyCode.I)){
            Shoot(bulletPrefab_green);
        }
        else if(Input.GetKeyDown(KeyCode.O)){
            Shoot(bulletPrefab_blue);
        }
    }

    void Shoot(GameObject bullet){
        Instantiate(bullet,firepoint.position, firepoint.rotation);
    }

    /*void Change_bullet_type(){
        bulletPrefab.GetComponent<SpriteRenderer>().color = new Color(0,0,0,1);
        bulletPrefab.GetComponent<tiroFisica>().setTipo_tiro(1);
    }*/
}
