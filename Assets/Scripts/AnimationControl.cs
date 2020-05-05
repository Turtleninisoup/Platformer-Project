using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationControl : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Transform characterTransform;
    public Rigidbody rb;
    public float speed = 3;
    public float jump = 5;
    public bool onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float translation = Input.GetAxis("Vertical") * moveSpeed;
        float straffe = Input.GetAxis("Horizontal") * moveSpeed;
        //translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, 0);

        onGround = Vector3.Dot(rb.velocity, Vector3.up) < .01;
        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * jump;
        }

        if (straffe != 0)
        {
            float y = (straffe < 0) ? 180 : 0;
            Vector3 input = new Vector3(0, y, 0);
            characterTransform.eulerAngles = input;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed * straffe);
        }

        else
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
        }


        //Animations
        //Walk
        if ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.D)))
        {
            gameObject.GetComponent<Animator>().SetTrigger("Walk");
        }
        //Run
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            gameObject.GetComponent<Animator>().SetTrigger("Jump");
        }
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Animator>().SetTrigger("Jump");
        }
    }

}
