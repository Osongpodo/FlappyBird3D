FlappyBird3D
================
## 1. 작업 개요
__작업자__   
@Osongpodo   
__작업 도구__   
Unity 2020.3.28f1
## 2. Flappy Bird
![images](https://user-images.githubusercontent.com/73912947/167560058-0d961b7e-ddd2-408c-9c5e-0bcc4695cb31.jpg)   
Flappy Bird는 2013년에 출시된 모바일 게임이다.   
게임 방식은 화면을 Click(또는 Touch)하여 장애물을 피하여 점수를 쌓는다.
## 3. Flappy Bird 3D
Unity의 기본적인 함수들과 툴을 익히기 위해 제작하기로 하였다.   
   
            

__space를 누르면 player가 일정한 속도, 일정한 높이로 날기__
```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyButton : MonoBehaviour
{
    public float birdJump = 8f;

    private void Update()
    {
        if (!Gmanager.playerDie) {

           
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
```
__pipe prefab이 일정한 속도로 -x축으로 이동하기__
```c#
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

```
__pipe를 random한 위치로 생성하게 하고, pipe를 통과하면 스코어 업데이트하기__
```c#
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
```
__점수 나타내기__
```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getScore : MonoBehaviour
{
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag.CompareTo("Player") == 0)
        {
            Gmanager.score += 1;
        }
    }
}
```
## 4. 작업 결과
https://user-images.githubusercontent.com/73912947/167562350-903915bb-603a-498a-b6f5-b6feb44f7479.mp4

pipe는 직접 제작하였고 귀여운 player와 배경의 구름, 비행기는 asset store를 활용하였다.
## 5. 고찰
1. Hierachy, Asset을 보기 쉽게 정리하기   
2. Aseet Store에서 Asset을 가져올때 "필요한" Asset만 Import하기   
