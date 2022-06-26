using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class CrewManager : Singleton<CrewManager>
{
    [SerializeField]
    private float horizontalOffset = 0.05f;

    [SerializeField]
    private float verticalOffset = 0.05f;

    public Stack<Crew> crews;
    private int columnCount = 0;
    private int lineCount = 0;


    private void Start()
    {
        crews = new Stack<Crew>();
        GameManager.OnAfterStateChanged += OnAfterStateChanged;
    }


    public void AddCrewMember(Crew crewMember)
    {
        if (crews.Count % 4 == 0)
        {
            columnCount++;
            lineCount = 0;
        }
        var tempScale = new Vector3(0.05f, 0.05f, 0.05f);
        var tempPosition = new Vector3((-horizontalOffset + (horizontalOffset * lineCount++)), 0.65f, columnCount * verticalOffset);
        crewMember.CollectCrewMember(tempPosition, tempScale);
        crews.Push(crewMember);

    }

    public void RemoveCrewMember()
    {
        crews.Pop().DropAtShip();
        if (crews.Count % 4 == 0)
        {
            columnCount--;
            lineCount = 3;
        }
        else
        {
            lineCount--;
        }
    }

    public void CrewRun()
    {
        for (int i = 0; i < crews.Count; i++)
        {
            crews.Pop().RunCrew();
        }
    }
    private void OnAfterStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.Win:
                CrewRun();
                break;
        }
    }
}
