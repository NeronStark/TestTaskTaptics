using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UiController : MonoBehaviour
{
    #region UI variables
    Text enemyCount;
    Text Timer;
    Image hpBar;
    Text lvl;
    public GameObject canvasEnd;
    GameObject winText;
    GameObject loseText;
    GameObject extraGameBut;
    GameObject result;
    Text myTime;
    Text resultList;
    #endregion


    private void Awake()
    {
        enemyCount = GameObject.Find("enemyLeft").GetComponent<Text>();
        Timer = GameObject.Find("Time").GetComponent<Text>();
        hpBar = GameObject.Find("Hp").GetComponent<Image>();
        lvl = GameObject.Find("lvl").GetComponent<Text>();
        canvasEnd = GameObject.Find("CanvasEnd");
        winText = GameObject.Find("Win").gameObject;
        loseText = GameObject.Find("Lost").gameObject;
        extraGameBut = GameObject.Find("ExtraGame").gameObject;
        result = GameObject.Find("BestResultWindow").gameObject;
        myTime = GameObject.Find("myTime").GetComponent<Text>();
        resultList = GameObject.Find("result").GetComponent<Text>();
        canvasEnd.SetActive(false);
    }



    public void SetTimeLeft(float time) // TIme to UI
    {
        if (time > 0)
        {
            Timer.text = System.Convert.ToInt32(time).ToString();
        }
        else Timer.text = "0";
        
    }
    public void ChangeEnemyLeft(int enemyLeft) //Enemy left UI
    {
        enemyCount.text = enemyLeft.ToString();
    }
    public int EnemyLeft() //Enemy left data
    {
        return System.Convert.ToInt32(enemyCount.text);
    }
    public void ChangeHpBar(float hp) //HP changes in UI
    {
        hpBar.fillAmount = hp;
    }
    public void ChangeLvl(int level) //Lvl Changes in UI
    {
        lvl.text = level.ToString();
    }
    public void ShowVictory() //Victory window
    {
        canvasEnd.SetActive(true);
        winText.SetActive(true);
        loseText.SetActive(false);
        extraGameBut.SetActive(false);
        result.SetActive(true);
    }
    public void ShowLose() //Lose window
    {
        canvasEnd.SetActive(true);
        winText.SetActive(false);
        loseText.SetActive(true);
        extraGameBut.SetActive(true);
        result.SetActive(false);
    }
    public void PlayAgain() // Play again Hides Victory or Lose windows
    {
        canvasEnd.SetActive(false);
        
    }
    public void ShowMyTime(float time) // Record time
    {
        myTime.text = System.Convert.ToInt32(time).ToString();
        
    }

    

}
