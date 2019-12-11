using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class GameController : MonoBehaviour
{
    private float damage;
    Timer timer;
    UiController uiController;
    EnemyController enemyContrl;
    public float gameTime =60;
    
    
    private const string VideoId = "ca-app-pub-3940256099942544/5224354917";
    private RewardBasedVideoAd rewardVideo;
    


    private void Awake()
    {
        timer = transform.GetComponent<Timer>();
        uiController = transform.GetComponent<UiController>();
        enemyContrl = GameObject.Find("Enemy").transform.GetComponent<EnemyController>();
        rewardVideo = RewardBasedVideoAd.Instance;
        rewardVideo.OnAdRewarded += HandleUserEarnedReward;
    }
    private void Start()
    { 
        GameStart();
    }
    private void Update()
    {
        if (uiController.EnemyLeft() == 0) Victory();
    }
    private void GameStart()
    {
        rewardVideo.LoadAd(new AdRequest.Builder().Build(), VideoId);
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
    public void Video()
    {
        if (rewardVideo.IsLoaded()) rewardVideo.Show();
    }
    public void PlayAgain()
    {
       GameStart();
    }
   
    
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        print("HandleRewardedAdRewarded event received for " + amount.ToString() + " " + type);
        GameResumes();
    }


}
    