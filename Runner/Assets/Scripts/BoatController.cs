using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{

    public Transform player;

    public float playerSpeed = 10f;
    public float speed = 5.0f;
    public Vector3 PlayerOffset;



    private bool touch = false;

    private Vector2 pointA;
    private Vector2 pointB;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = player.Find("untitled").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = player.Find("untitled").position + PlayerOffset;

        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.z, Camera.main.transform.position.z));
        }
        if (Input.GetMouseButton(0))
        {
            touch = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.z, Camera.main.transform.position.z));
        } else
        {
            touch = false;
        }
        
    }

    private void FixedUpdate()
    {
       

        player.Find("untitled").GetComponent<Rigidbody>().AddForce(0, 0, playerSpeed * Time.deltaTime);
        if (touch)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);

            moveBoat(direction);
        }
    }

    void moveBoat(Vector2 direction)
    {

        if (Input.GetMouseButton(0) && direction.x < 0)
        {
            animator.SetTrigger("turnLeft");
        } else if (Input.GetMouseButton(0) && direction.x < 0)
        {
            animator.SetTrigger("turnLeft");
        }
        player.Translate(direction * speed * Time.deltaTime);
    }
}
