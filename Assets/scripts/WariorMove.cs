using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WariorMove : MonoBehaviour
{
    // Start is called before the first frame update
    static Animator anim;
    public float Speed;
    public Transform ilkkatsol, ilkkatsag, ikikatsol, ikikatsag, uckatsol,uckatsag,dortsol,dortsag;
    bool crouch;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            crouch = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            crouch = false;
        }
        if (crouch)
        {
            Speed = 5;

            if (Input.GetKey(KeyCode.D))
            {
                anim.SetBool("Crouch", true);
                anim.SetBool("Crouchidle", false);
                anim.SetBool("Walk", false);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.Translate(Vector2.right * Speed * Time.deltaTime);

            }
            else if (Input.GetKey(KeyCode.A))
            {
                anim.SetBool("Crouch", true);
                anim.SetBool("Crouchidle", false);
                anim.SetBool("Walk", false);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                transform.Translate(Vector2.right * Speed * Time.deltaTime);
            }
            else
            {
                anim.SetBool("Walk", false);
                anim.SetBool("Crouch", false);
                anim.SetBool("Crouchidle", true);
            }
       
    
        }
            else
            {
            Speed = 7;
            if (Input.GetKey(KeyCode.D))
                {
                    anim.SetBool("Walk", true);
                    anim.SetBool("Crouch", false);
                    anim.SetBool("Crouchidle", false);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                    transform.Translate(Vector2.right * Speed * Time.deltaTime);

                }
                else if (Input.GetKey(KeyCode.A))
                {
                    anim.SetBool("Walk", true);
                    anim.SetBool("Crouch", false);
                    anim.SetBool("Crouchidle", false);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                    transform.Translate(Vector2.right * Speed * Time.deltaTime);

                }
                else
                {
                    anim.SetBool("Walk", false);
                    anim.SetBool("Crouch", false);
                    anim.SetBool("Crouchidle", false);
            }
            }       
    }
    void OnTriggerEnter2D(Collider2D other)
    {      
        if (other.tag == "firstleft")
        {
            gameObject.transform.position = ikikatsag.transform.position;
        }
        if (other.tag == "secondleft")
        {
            gameObject.transform.position = uckatsag.transform.position;
        }
        if (other.tag == "thirtleft")
        {
            gameObject.transform.position = dortsag.transform.position;
        }
        if (other.tag == "fourthleft")
        {
            gameObject.transform.position = ilkkatsag.transform.position;
        }
        if (other.tag == "firstright")
        {
            gameObject.transform.position = dortsol.transform.position;
        }
        if (other.tag == "secondright")
        {
            gameObject.transform.position = ilkkatsol.transform.position;
        }
        if (other.tag == "thirtright")
        {
            gameObject.transform.position = ikikatsol.transform.position;
        }
        if (other.tag == "fourthright")
        {
            gameObject.transform.position = uckatsol.transform.position;
        }
    }


}
