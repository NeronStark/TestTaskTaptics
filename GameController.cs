using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class GameController : MonoBehaviour
{
    private float damage;
    public float gameTime = 60; // Game time
    Timer timer;
    UiController uiController;
    EnemyController enemyContrl;
    
    private const string VideoId = "ca-app-pub-3940256099942544/5224354917"; //AD ID of reward video (test ID)
    private RewardBasedVideoAd rewardVideo; // reward video
    


    private void Awake()
    {
        timer = transform.GetComponent<Timer>();
        uiController = transform.GetComponent<UiController>();
        enemyContrl = GameObject.Find("Enemy").transform.GetComponent<EnemyController>();
        rewardVideo = RewardBasedVideoAd.Instance; //Set instance of RW
        rewardVideo.OnAdRewarded += HandleUserEarnedReward; // Event handler for reward
    }
    private void Start()
    { 
        GameStart();
    }
    private void Update()
    {
        if (uiController.EnemyLeft() == 0) Victory(); // if no enemy -> Victory
    }
    private void GameStart()  //Start of Game
    {
        rewardVideo.LoadAd(new AdRequest.Builder().Build(), VideoId); // Loading of AD
        uiController.ChangeEnemyLeft(10);
        timer.StartTimer(gameTime);
        enemyContrl.NewGame();
        uiController.PlayAgain();
    }
    public void GameResumes()
    {
        timer.StartTimer(30);
        uiController.PlayAgain();

    }
    private void Victory()
    {
        uiController.ShowVictory();
        timer.StopTimer();
        uiController.ShowMyTime(timer.ReturnTime());
    }
    public void Lose()
    {
        uiController.ShowLose();
    }
    public void Video() //Video Show method
    {
        if (rewardVideo.IsLoaded()) rewardVideo.Show();
    }
    public void PlayAgain()
    {
       GameStart();
    }
   
    
    public void HandleUserEarnedReward(object sender, Reward args) //Event handler for reward
    {
        string type = args.Type;
        double amount = args.Amount;
        print("HandleRewardedAdRewarded event received for " + amount.ToString() + " " + type);
        GameResumes();
    }


}
    