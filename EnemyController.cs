using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{

    UiController uiController;
    private int enemyLvl;
    private float enemyMaxHp;
    private float enemyCurentHp;
    private Animator _animator;

    private void Awake()
    {
        _animator = transform.GetComponent<Animator>();
        uiController = Camera.main.transform.GetComponent<UiController>();

    }

    private void Start()
    {
        NewGame();
    }

    void Respawn(float maxHp)
    {
        enemyMaxHp = maxHp;
        enemyCurentHp = maxHp;
        uiController.ChangeHpBar(1);
    }

    void GetDamage(float damage)
    {
        if(enemyCurentHp > 0)
        {
            float hpProcent = damage / enemyCurentHp;
            enemyCurentHp -= damage;
            uiController.ChangeHpBar(Mathf.Abs(1-hpProcent));
            print(Mathf.Abs(1 - hpProcent));
            
            if(enemyCurentHp <= 0) // Enemy Dead
            {
                AnimManager(1);
                int enemyLeft = uiController.EnemyLeft();
                Respawn(enemyMaxHp * 1.4f); //Every new lvl gives 30% more HP to Enemy
                if(enemyLvl < 10) enemyLvl++;
                uiController.ChangeLvl(enemyLvl);
                uiController.ChangeEnemyLeft( enemyLeft -= 1);
                
            }
        }
    }

    private void OnMouseDown()
    {
        if(!uiController.canvasEnd.activeSelf)
        {
            if(_animator.GetBool("Death") == false)
            {
                AnimManager(3);
                GetDamage(10);
            }
        }
        
    }

    void AnimManager(int Anim)
    {
        switch(Anim)
        {
            case 0: _animator.SetBool("Death", false); break;    // Death off
            case 1: _animator.SetBool("Death", true); break;     // Death
            case 2: _animator.SetInteger("State", 1); break;     //ShowAniim
            case 3: _animator.SetTrigger("Attack"); break;       //Attacked

        }
    }
    public void NewGame()
    {
        enemyMaxHp = 20;
        enemyLvl = 1;
        uiController.ChangeLvl(enemyLvl);
        Respawn(enemyMaxHp);
    }

    
}
