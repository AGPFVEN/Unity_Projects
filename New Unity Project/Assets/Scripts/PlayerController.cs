using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public LayerMask wallMask;
    Rigidbody2D rb;
    Transform cannon_Transform;

    //Jump
    float watch_JumpReload;
    float watch_JumpReloadL; //Esta variable hay que quitarla en cuanto tengas score
    float power_Jump;
    GameObject jumped_GameObject;
    Rigidbody2D jumped_rb;

    //Modificable Stats
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
        watch_JumpReload =0;
        watch_JumpReloadL = 1; //Esta variable hay que quitarla en cuanto tengas score

        //Modificable Stats
        speed = 5f;
        jumpHeight = 2f;
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
        RaycastHit2D fireRay =Physics2D.Raycast(cannon_Transform_Top.position, lookDirection.normalized);
        Debug.DrawRay(cannon_Transform_Top.position, lookDirection.normalized, Color.green);

        //Jump 
        float jInput = Input.GetAxis("Jump");
        if (/*watch_JumpReload == watch_JumpReloadL && */jInput >= 1 && fireRay.transform.name != null)
        {
            jumped_GameObject = GameObject.Find(fireRay.transform.name);
            print(fireRay.transform.transform.name);
            if(jumped_GameObject.GetComponent<Rigidbody2D>() == true)
            {
                jumped_rb = jumped_GameObject.GetComponent<Rigidbody2D>();
                //power_Jump  
                jumped_rb.AddForce
                (new Vector2(
                    jumped_GameObject.transform.position.x-transform.position.x, jumped_GameObject.transform.position.y-transform.position.y).normalized * power_Jump);
            }
            else
            {
                jumped_GameObject = null;
                jumped_rb = null;
                return;
            }
        }
        else if (watch_JumpReload == watch_JumpReloadL && jInput >= 1)
        {
            return;
        }
        else if (watch_JumpReload > 0)
        {
            watch_JumpReload += 1 * Time.deltaTime;
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
        //print(fireRay.transform.name);
    }
    void Fire(Transform fire_position_intial, Vector2 vector_Direction, Quaternion fire_rotation, GameObject bullet_func)
    {
        GameObject firedBullet = Instantiate(bullet_func, fire_position_intial.position, fire_rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = vector_Direction * 20f;
    }
}
