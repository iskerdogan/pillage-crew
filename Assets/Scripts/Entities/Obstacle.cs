using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour,ICollectable
{
    public void Collect()
    {
        gameObject.SetActive(false);
    }

    
}
