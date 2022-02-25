using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public static Player current;
    public float MovementSpeed = 1;
    public bool isFacingRight = true;
   
    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            this.GetComponent<Animator>().SetBool("isWalking", true);
            if (Input.GetKeyDown(KeyCode.D) && !isFacingRight)
            {
                Flip();
            }
            else if(Input.GetKeyDown(KeyCode.A) && isFacingRight)
             {
                Flip();
            }
        }
        else
            this.GetComponent<Animator>().SetBool("isWalking", false);
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
