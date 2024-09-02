using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{

    [SerializeField] GameObject batBoss, ghostBoss;
    [SerializeField] GameObject batBossWarning, ghostBossWarning, WinScreen;
    EnemyAi batBossEnemyAi, ghostBossEnemyAi;
    private bool alreadyDidOneTime = false;

    private int count = 0 ;

    private void Awake()
    {
        ResumeGame();
    }

    private void Start()
    {

        batBossEnemyAi = batBoss.GetComponent<EnemyAi>();
        ghostBossEnemyAi = ghostBoss.GetComponent<EnemyAi>();

        StartCoroutine(WaitTimeForBatBoss(4));

    }

    void Update()
    {
        if (batBossEnemyAi.GetIsEnemyDead() && alreadyDidOneTime == false)
        {
            //batBoss is Dead;
            batBoss.SetActive(false);

            if(count==0)
            {
                ghostBossWarning.SetActive(true);
                count++;


            }
            StartCoroutine(WaitTimeForGhostBoss(4));

           

            if (ghostBossEnemyAi.GetIsEnemyDead() && alreadyDidOneTime == false)
            {
                //ghostBoss is Dead;
                //you win

                StartCoroutine(WaitForDead());



                alreadyDidOneTime = true;
            }
        }


    }

    IEnumerator WaitTimeForGhostBoss(int time)
    {
        yield return new WaitForSeconds(time);

        ghostBossWarning.SetActive(false);
        ghostBoss.SetActive(true);

    }
    IEnumerator WaitTimeForBatBoss(int time)
    {
        yield return new WaitForSeconds(time);

        batBossWarning.SetActive(false);
        

    }

    public void ReturnMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    IEnumerator WaitForDead()
    {
        yield return new WaitForSeconds(2f);
        WinScreen.SetActive(true);
        PauseGame();


    }
    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(3f);




    }
}
