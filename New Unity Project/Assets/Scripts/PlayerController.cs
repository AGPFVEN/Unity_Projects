using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{ 
    //Base
    public LayerMask wallMask;
    Rigidbody2D rb;
    Transform cannon_Transform;

    //Fire
    float watch_FireReload;
    float watch_FireReloadL; //Esta variable hay que quitarla en cuanto tengas score

    //Jump
    float watch_Jump;
    float watch_Jump_Limit;
    float power_Jump;
    GameObject jumped_GameObject;
    Rigidbody2D jumped_rb;

    //Modificable Stats
    public float healt_this;
    float speed;
    float jumpHeight;

    //Cannon rotation
    Vector2 lookDirection;
    float lookAngle;

    //Cannon top
    Transform cannon_Transform_Top;

    //Fire
    public GameObject bullet_Gameobject;
    float watch_fire;
    float watch_fire_Limit; //Esta variable hay que quitarla en cuanto tengas score

    //Enemy
    SetHealth health_Enemy_script;
    float health_Enemy_float;

    void Awake()
    {
        //Fire
        watch_fire = 0;
        watch_fire_Limit = 1; //Esta variable hay que quitarla en cuanto tengas score

        //Basic Stuff
        rb = GetComponent<Rigidbody2D>();
        cannon_Transform = transform.GetChild(0);
        cannon_Transform_Top = transform.GetChild(0).GetChild(0);

        //Reload
        watch_FireReload = 0;
        watch_FireReloadL = 1; //Esta variable hay que quitarla en cuanto tengas score

        //Modificable Stats
        speed = 5f;
        jumpHeight = 2f;
        healt_this = 1f;
    }
    void FixedUpdate()
    {
        //Horizontal movement
        float hInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(hInput * speed * Time.deltaTime, 0, 0);

        //Cannon rotation
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        cannon_Transform.rotation = Quaternion.Euler(0f, 0f, lookAngle + 90f);

        //Jump ray
        RaycastHit2D fireRay = Physics2D.Raycast(cannon_Transform_Top.position, lookDirection.normalized);
        Debug.DrawRay(cannon_Transform_Top.position, lookDirection.normalized, Color.green);

        //Jump 
        float jInput = Input.GetAxis("Jump");
        if (watch_Jump <= 0 && jInput >= 1 && fireRay.transform.name != null)
        {
            jumped_GameObject = GameObject.Find(fireRay.transform.name);
            if (jumped_GameObject.GetComponent<SetHealth>() == true)
            {
                jumped_rb = jumped_GameObject.GetComponent<Rigidbody2D>();
                health_Enemy_script = jumped_GameObject.GetComponent<SetHealth>();
                jumped_rb.AddForce
                (new Vector2(
                    -jumped_GameObject.transform.position.x + transform.position.x,
                    -jumped_GameObject.transform.position.y + transform.position.y).normalized
                    * 10 * ((health_Enemy_script.healthset) - healt_this / fireRay.distance)
                );
            }
            else if (jInput >= 1 && fireRay.transform.tag == "Walls")
            {
                /*HoldJump(power_Jump, jInput);*/
                print("JUMp");

                //Default
                jumped_GameObject = null;
                jumped_rb = null;

                //Jump
                if(fireRay.distance <= 1)
                {
                    rb.AddForce(-lookDirection.normalized *  14/*meter variable*/, ForceMode2D.Impulse);
                    watch_Jump = 2;
                }
                else
                {
                    rb.AddForce(-lookDirection.normalized * 50 / fireRay.distance);
                    watch_Jump  = 2;
                }
            }
        }
        else if (watch_Jump > 0)
        {
            watch_FireReload -= 1 * Time.deltaTime;
        }

        //Fire
        if (Input.GetMouseButton(0))
        {
            if (watch_fire <= 0)
            {
                Fire(transform, lookDirection.normalized, Quaternion.Euler(0f, 0f, lookAngle - 90f), bullet_Gameobject);
                watch_fire = watch_fire_Limit;
            }
        }
        if (watch_fire > 0)
        {
            watch_fire -= 1 * Time.deltaTime;
        }

        print(watch_Jump);
        //print(fireRay.transform.name);
    }
    void Fire(Transform fire_position_intial, Vector2 vector_Direction, Quaternion fire_rotation, GameObject bullet_func)
    {
        GameObject firedBullet = Instantiate(bullet_func, fire_position_intial.position, fire_rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = vector_Direction * 20f;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        healt_this -= 0.5f;
    }
    void HoldJump(float powerJump, float jinput)
    {
        if (jinput >= 1)
        {
            powerJump += 1 * Time.deltaTime;
            HoldJump(powerJump, jinput);
        }
    }
}
