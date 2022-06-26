using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : MonoBehaviour, ICollectable
{   
    [SerializeField]
    private Transform crewPosition;
    public void Collect()
    {

    }

    public void CollectCrewMember(Vector3 targetPosition,Vector3 targetScale)
    {
        transform.parent = PlayerController.Instance.transform;
        transform.localScale = targetScale;
        transform.localPosition = targetPosition;
        GetComponent<BoxCollider>().enabled= false;
    }

    public void DropAtShip()
    {
        var player = PlayerController.Instance.transform.position;
        transform.parent = null;
        transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        transform.localPosition = new Vector3(player.x - 2, player.y, player.z);
    }

    public void RunCrew()
    {
        // var player = PlayerController.Instance.transform.position;
        // transform.parent = null;
        // for (int i = 0; i < CrewManager.Instance.crews.Count; i++)
        // {
        //     LeanTween.delayedCall(1f,()=>LeanTween.move(gameObject,new Vector3(crewPosition.position.x,crewPosition.position.y,crewPosition.position.z -i),.5f));
            
        // }
    }
    

}
