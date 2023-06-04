using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPositon : MonoBehaviour
{
    public bool isTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //GameManager.Instance.AddPlayer(1);
            other.gameObject.GetComponent<Player>().shallMove = false;

            if(isTarget) GameManager.Instance.AddPlayer(1);


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isTarget) GameManager.Instance.RemovePlayer(1);
            
        }
    }
}
