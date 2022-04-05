using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Gmanager : MonoBehaviour
{
    public float pipeTime = 2f;
    public float pipeMin = -2f;
    public float pipeMax = 2f;

    static public bool playerDie = false;
    static public int score = 0;
    public Text Score;

    public GameObject pipePrefab;

    private void Start()
    {

        StartCoroutine(PipeStart());
    }

    private void Update()
    {
        Score.text = score.ToString();
    }

    IEnumerator PipeStart()
    {
        do
        {
            Instantiate(pipePrefab, new Vector3(15.4f, Random.Range(pipeMin, pipeMax), 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            yield return new WaitForSeconds(pipeTime);
        } while (!playerDie);

    }
}