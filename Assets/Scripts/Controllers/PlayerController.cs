using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float sideSpeed;

    private Rigidbody rb;

    private float currentSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        InputSystem.Instance.TouchPositionChanged += OnTouchPositionChanged;
        GameManager.OnAfterStateChanged += OnAfterStateChanged;
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, currentSpeed * Time.deltaTime);
    }

    private void OnAfterStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.Starting:
                InputSystem.Instance.TouchPositionChanged += OnTouchPositionChanged;
                currentSpeed = 0;
                transform.position = Vector3.zero;
                break;
            case GameState.InGame:
                currentSpeed = speed;
                break;
            case GameState.Win:
                break;
            case GameState.Lose:
                InputSystem.Instance.TouchPositionChanged -= OnTouchPositionChanged;
                break;
        }
    }

    private void OnTouchPositionChanged(Touch touch)
    {
        if (GameManager.Instance.State != GameState.InGame) return;

        var target = new Vector3
        (
            Mathf.Clamp
            (
                transform.position.x + sideSpeed * Time.deltaTime * touch.deltaPosition.x,
                -4f,
                4f
            ),
            transform.position.y,
            transform.position.z
        );
        transform.position = Vector3.Lerp(transform.position,target,0.125f);


    }



}
