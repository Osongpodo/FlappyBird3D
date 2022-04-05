using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float pipeSpeed = 3f;

    private void Update()
    {
        if (!Gmanager.playerDie)
        {
            transform.Translate(-pipeSpeed * Time.deltaTime, 0, 0);

            if (transform.position.x <= -8f)
            {
                Destroy(gameObject);
            }
        }

        else
        {
            Application.Quit();
        }
    }
}
