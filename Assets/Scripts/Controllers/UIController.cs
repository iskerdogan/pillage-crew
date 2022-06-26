using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class UIController : Singleton<UIController>
{
    void Start()
    {
        InputSystem.Instance.TouchPositionChanged += OnTouchPositionChanged;
    }

    private void OnTouchPositionChanged(Touch touch)
    {
        if (touch.phase != TouchPhase.Began) return;
        InputSystem.Instance.TouchPositionChanged -= OnTouchPositionChanged;
        GameManager.Instance.ChangeGameState(GameState.InGame);
    }
}
