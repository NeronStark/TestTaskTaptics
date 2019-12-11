using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UiController : MonoBehaviour
{
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



    public void SetTimeLeft(float time)
    {
        if (time > 0)
        {
            Timer.text = System.Convert.ToInt32(time).ToString();
        }
        else Timer.text = "0";
        
    }
    public void ChangeEnemyLeft(int enemyLeft)
    {
        enemyCount.text = enemyLeft.ToString();
    }
    public int EnemyLeft()
    {
        return System.Convert.ToInt32(enemyCount.text);
    }
    public void ChangeHpBar(float hp)
    {
        hpBar.fillAmount = hp;
    }
    public void ChangeLvl(int level)
    {
        lvl.text = level.ToString();
    }
    public void ShowVictory()
    {
        canvasEnd.SetActive(true);
        winText.SetActive(true);
        loseText.SetActive(false);
        extraGameBut.SetActive(false);
        result.SetActive(true);
    }
    public void ShowLose()
    {
        canvasEnd.SetActive(true);
        winText.SetActive(false);
        loseText.SetActive(true);
        extraGameBut.SetActive(true);
        result.SetActive(false);
    }
    public void PlayAgain()
    {
        canvasEnd.SetActive(false);
        
    }
    public void ShowMyTime(float time)
    {
        myTime.text = System.Convert.ToInt32(time).ToString();
        
    }

    

}
