using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownFloor : MonoBehaviour
{
    public Transform ilkkatsol, ilkkatsag, ikikatsol, ikikatsag, uckatsol, uckatsag, dortsol, dortsag;

    GameObject target;
  

    void OnTriggerEnter2D(Collider2D other)
    {
        target = other.gameObject;


        if (this.gameObject.tag == "firstleft")
        {
            target.transform.position = ikikatsag.transform.position;
        }
        if (gameObject.tag == "secondleft")
        {
            target.transform.position = uckatsag.transform.position;
        }
        if (gameObject.tag == "thirtleft")
        {
            target.transform.position = dortsag.transform.position;
        }
        if (gameObject.tag == "fourthleft")
        {
            target.transform.position = ilkkatsag.transform.position;
        }
        if (gameObject.tag == "firstright")
        {
            target.transform.position = dortsol.transform.position;
        }
        if (gameObject.tag == "secondright")
        {
            target.transform.position = ilkkatsol.transform.position;
        }
        if (gameObject.tag == "thirtright")
        {
            target.transform.position = ikikatsol.transform.position;
        }
        if (gameObject.tag == "fourthright")
        {
            target.transform.position = uckatsol.transform.position;
        }
    }
}
