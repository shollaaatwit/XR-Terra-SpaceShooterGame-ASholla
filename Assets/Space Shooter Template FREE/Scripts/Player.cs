using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script defines which sprite the 'Player" uses and its health.
/// </summary>

public class Player : MonoBehaviour
{
    public GameObject destructionFX;

    public static Player instance; 

    private Vector3 _startPosition;

    private bool _isInvincible;

    private void Awake()
    {
        if (instance == null) 
            instance = this;
    }

    private void Start()
    {
        _startPosition = transform.position;
    }

    //method for damage proceccing by 'Player'
    public void GetDamage(int damage)   
    {
        Destruction();
    }    

    //'Player's' destruction procedure
    void Destruction()
    {
        if(_isInvincible)
        {
            return;
        }
        Instantiate(destructionFX, transform.position, Quaternion.identity); //generating destruction visual effect and destroying the 'Player' object
    //    Destroy(gameObject);
        PlayerController.Instance.PlayerKilled();
    }
    
    public void RespawnPlayer()
    {
        transform.position = _startPosition;
        _isInvincible = true;
        Invoke("ClearInvincible", 2f);
    }

    private void ClearInvincible()
    {
        _isInvincible = false;
    }
}
















