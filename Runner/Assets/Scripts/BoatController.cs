using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{

    public Transform player;
    public float playerSpeed = 10f;
    public float speed = 5.0f;
    public Vector3 PlayerOffset;
    public HealthBar HealthBar;


    public int maxHealth = 3;
    
    
    private int currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        HealthBar.setMaxHealth(maxHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
        transform.position = player.Find("untitled").position + PlayerOffset;

        

        
    }

    private void FixedUpdate()
    {
       

        player.Find("untitled").GetComponent<Rigidbody>().AddForce(0, 0, playerSpeed * Time.deltaTime);

        if (Input.GetMouseButton(0) && Input.mousePosition.x <= Screen.width / 2){
            player.Find("untitled").GetComponent<Rigidbody>().AddForce(-1.1f, 0, 0);
            
        } else if (Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width / 2) {
            player.Find("untitled").GetComponent<Rigidbody>().AddForce(1.1f, 0, 0);
        }
     
    }

   

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthBar.setHealth(currentHealth);
    }
}
