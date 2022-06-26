using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPlatformControler : MonoBehaviour
{
    [SerializeField]
    private Transform startPosition;

    [SerializeField]
    private Transform finishPosition;

    private void Start() 
    {
        GameManager.OnAfterStateChanged += OnAfterStateChanged;
    }


    private void OnTriggerEnter(Collider other) {
        var player = other.GetComponent<PlayerController>();
        if (player!=null)
        {
            LeanTween.move(player.gameObject,finishPosition.position,0.7f);
            LeanTween.rotateY(player.gameObject,90f,0.3f);
            //eanTween.delayedCall(0.5f, ()=> GameManager.Instance.ChangeGameState(GameState.Win)) ;
            GameManager.Instance.ChangeGameState(GameState.Win);
        }
    }
    private void OnAfterStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.Win:
            
                break;
        }
    }

}
