using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{

    GameObject Player;
    // Start is called before the first frame update
    public void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    public void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D Collider)
    {
        if (GetComponent<Collider>().GetComponent<Collider>().tag == "Ground")
        {
            Player.GetComponent<Movement>().isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.collider.tag == "Ground")
        {
            Player.GetComponent<Movement>().isGrounded = false;
        }
    }
}
