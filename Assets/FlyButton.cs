using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyButton : MonoBehaviour
{
    public float birdJump = 8f;

    private void Update()
    {
        if (!Gmanager.playerDie) {

            //player가 일정높이를 계속 날게 하고싶음
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, birdJump, 0);

                transform.rotation = Quaternion.Euler(0, 91.183f, 0);
            }
        }

   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.CompareTo("pipe_ground") == 0)
        {
            //Application.Quit();
            Gmanager.playerDie = true;
            //Time.timeScale = 0;
        }
    }

}