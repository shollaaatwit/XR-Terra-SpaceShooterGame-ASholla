using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Singleton<PlayerController>
{

    public Player player;
    public int maxLives = 3;
    private int _currentLife;

    public Image LifeOne;
    public Image LifeTwo;
    public Image LifeThree;

    private void Start()
    {
        ResetLives();
    }
    private void ResetLives()
    {
        _currentLife = maxLives;
    }

    public void PlayerKilled()
    {
        PlayerHit();
        if(_currentLife == 0)
        {
            GameController.Instance.GameOver();
        }
        else
        {
            player.gameObject.SetActive(false);
            Invoke("DoRespawn", 3f);
        }
    }

    private void DoRespawn()
    {
        player.gameObject.SetActive(true);
        player.RespawnPlayer();
    }

    public void PlayerHit()
    {
        _currentLife--;
        UpdateLives();
    }

    private void UpdateLives()
    {
        Debug.Log(_currentLife);
        switch(_currentLife)
        {
            case 0:
                LifeOne.gameObject.SetActive(false);
                break;
            case 1:
                LifeTwo.gameObject.SetActive(false);
                break;
            case 2:
                LifeThree.gameObject.SetActive(false);
                break;
            default:
                LifeOne.gameObject.SetActive(true);
                LifeTwo.gameObject.SetActive(true);
                LifeThree.gameObject.SetActive(true);
                break;
        }


    }
}
