using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    

    GameObject player, hackableObject;

    [SerializeField]
    float moveSpeed, jumpPower, Max_Speed;

    bool hacking, grounded, busy;
    float mouseX, mouseY;
    Vector2 mousePos, playerVec2;
    Vector3 hackingTarget;
    Vector3 cameraSpeed;
    float cameraTimeRemaining;
    public float cameraTimer;

    Vector3 s; //Speed
    Vector3 j; //Jump
    Rigidbody2D rb;
    Collider2D cl;


    // Use this for initialization
    void Start ()
    {
        player = this.gameObject;
        rb = player.GetComponent<Rigidbody2D>();

        j.x = 0;
        j.z = 0;
        j.y = jumpPower;

        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 v;

        
        //Movement
        if (Input.GetAxis("Horizontal") !=0 )
        {
            hacking = false;
            busy = false;
            s.x = moveSpeed * (Input.GetAxis("Horizontal"));
            if (s.x > Max_Speed)
            {
                s.x = Max_Speed;
            }
            transform.position += s;
        }
        if(Input.GetAxis("Vertical") > 0)
        {

            hacking = false;
            
            if (grounded)
            {
                
                rb.AddForce(j);
                grounded = false;
            }
        }


        if (hacking)
            v = Vector3.Lerp(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position, .5f);
        else
            v = transform.position;
        v.z = -10;
        if (Mathf.Abs(v.sqrMagnitude - hackingTarget.sqrMagnitude) > .04f)
        {
            cameraTimeRemaining = cameraTimer;
            hackingTarget = v;
        }
        if (cameraTimeRemaining > 0)
        {
            
            Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, hackingTarget, ref cameraSpeed, cameraTimeRemaining);
            cameraTimeRemaining -= Time.deltaTime;
        }
	if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0 || Input.GetMouseButton(0))
        {
            hacking = true;
            BeginHacking();

        }	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Platform")
        {
            grounded = true;
        }

    }

    void BeginHacking ()
    {
        //Character crouches while hacking
        if (!busy)
        {

            cl = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.1f);
            if (cl != null)
            {
                Hackable target = cl.GetComponent<Hackable>();
                if (target)
                {
                    hackableObject = cl.gameObject;

                    if (Input.GetButton("Left Click"))
                    {
                        target.Hack();
                        busy = true;
                    }

                }
            }
            else
            {
                hackableObject = null;
            }

        }
        
      
        
        //Activate little console light?
        
    }
}
