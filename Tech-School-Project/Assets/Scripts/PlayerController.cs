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
    public float watch_Jump;
    public float watch_Jump_bool;
    float watch_Jump_Limit;
    public float power_Jump;
    GameObject jumped_GameObject;
    Rigidbody2D jumped_rb;

    //Modificable Stats
    public float[] modstats;
    float jumpHeight;

    //Health
    float health;

    //Cannon rotation
    Vector2 lookDirection;
    float lookAngle;

    //Cannon top
    Transform cannon_Transform_Top;

    //Fire
    public GameObject bullet_Gameobject;
    float watch_fire;

    //Enemy
    SetHealth health_Enemy_script;
    float health_Enemy_float;

    //Mira
    GameObject mira_Gameobject;

    //EXP
    public GameObject levelUp_prefab;
    Transform exp_Transform;
    public float exp_Float;
    public int disposable_level;
    public int level;

    //Give Health
    public float givenhealth;

    void Start()
    {
        //Declare Arrays
        modstats = new float[2];

        //Fire
        watch_fire = 0;
        modstats[1] = 1; //timepo entre disparo

        //Basic Stuff
        rb = GetComponent<Rigidbody2D>();
        cannon_Transform = transform.GetChild(0);
        cannon_Transform_Top = transform.GetChild(0).GetChild(0);

        //Reload
        watch_FireReload = 0;
        watch_FireReloadL = 1; //Esta variable hay que quitarla en cuanto tengas score

        //Modificable Stats
        modstats[0] = 10f; //Speed
        jumpHeight = 2f;

        //Mira set up
        mira_Gameobject = transform.GetChild(1).gameObject;

        //Exp set up
        exp_Float = 0;
        level = 0;
        disposable_level = 0;
        exp_Transform = transform.GetChild(2).transform;

        //Give health
        givenhealth = 0;
    }
    void Update()
    {
        //Health
        health = GameObject.Find("Health_bar").GetComponent<Health_Controller>().health_this;

        //Disposable level
        if (disposable_level > 0)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                print("Level up");

                //disposable level
                disposable_level -= 1;
            }
        }

        //Horizontal movement
        float hInput = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(hInput * modstats[0], 0));

        //Cannon rotation
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        cannon_Transform.rotation = Quaternion.Euler(0f, 0f, lookAngle + 90f);

        //Fire
        if (Input.GetMouseButton(0))
        {
            if (watch_fire <= 0)
            {
                Fire(cannon_Transform_Top, lookDirection.normalized, Quaternion.Euler(0f, 0f, lookAngle - 90f), bullet_Gameobject);
                rb.AddForce(-lookDirection.normalized * 3, ForceMode2D.Impulse);
                watch_fire = modstats[1];
            }
        }
        if (watch_fire > 0)
        {
            watch_fire -= 1 * Time.deltaTime;
        }

        //Jump ray
        RaycastHit2D fireRay = Physics2D.Raycast(cannon_Transform_Top.position, lookDirection.normalized);
        Debug.DrawRay(cannon_Transform_Top.position, lookDirection.normalized, Color.green);

        //Mira
        if (fireRay.point == null)
        {
            mira_Gameobject.transform.position = new Vector2(-22, 22);
            mira_Gameobject.SetActive(false);
        }
        else if (fireRay.point != null)
        {
            mira_Gameobject.SetActive(true);
            mira_Gameobject.transform.position = fireRay.point;
        }

        //Jump
        if (Input.GetKey(KeyCode.Space) && watch_Jump <= 0)
        {
            //Increse Force & Set up a limit
            if (power_Jump < 3)
            {
                power_Jump += 3 * Time.deltaTime;

            }
        }
        else if (!Input.GetKey(KeyCode.Space) && watch_Jump <= 0 && fireRay.transform != null)
        {
            jumped_GameObject = GameObject.Find(fireRay.transform.name);
            if (jumped_GameObject.GetComponent<SetHealth>() != null && power_Jump > 0)
            {
                //Jump Enemy
                jumped_rb = jumped_GameObject.GetComponent<Rigidbody2D>();
                health_Enemy_script = jumped_GameObject.GetComponent<SetHealth>();
                if (power_Jump > 0)
                {
                    jumped_rb.AddForce
                    (new Vector2(
                        -jumped_GameObject.transform.position.x + transform.position.x,
                        -jumped_GameObject.transform.position.y + transform.position.y).normalized
                        * power_Jump * 2 * ((health_Enemy_script.healthset) - health / fireRay.distance)
                    );
                }
            }
            if (power_Jump > 0 && (jumped_GameObject.tag == "Walls" || jumped_GameObject.GetComponent<SetHealth>() == null))
            {
                //Normal Jump
                jumped_GameObject = null;
                jumped_rb = null;

                if (fireRay.distance <= 1)
                {
                    rb.AddForce(-lookDirection.normalized * 5 * power_Jump, ForceMode2D.Impulse);
                    watch_Jump = 2;
                    power_Jump = 0;
                }
            }
        }
        //EXP////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////Gestiona variables
        if (exp_Float >= 1)
        {
            exp_Float = 0;
            level += 1;
            disposable_level += 1;
            Instantiate(levelUp_prefab, new Vector3(this.transform.position.x  + .5f, this.transform.position.y + 1f, 0), Quaternion.Euler(0, 0, 0));
        }
        if (exp_Float > 1)
        {

        }
        exp_Transform.localScale = new Vector3(exp_Float, exp_Float, 0);

        //Sand watch
        if (watch_Jump > 0)
        {
            watch_Jump -= 1 * Time.deltaTime;
        }
    }
    void Fire(Transform fire_position_intial, Vector2 vector_Direction, Quaternion fire_rotation, GameObject bullet_func)
    {
        GameObject firedBullet = Instantiate(bullet_func, fire_position_intial.position, fire_rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = vector_Direction * 20f;
    }
    float HoldJump(float powerJump)
    {

        if (Input.GetKey(KeyCode.Space) == true)
        {
            powerJump += 1 * Time.deltaTime;
            HoldJump(powerJump);
            return 0;
        }
        else
        {
            return powerJump;
        }
    }
}
