using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPositon : MonoBehaviour
{
    public bool isTarget;
    public int targetId;

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Player"))
        {
            other.gameObject.TryGetComponent<Player>(out Player player);
            if(player!= null && player.id == targetId)
            {
                player.shallMove = false;

                if (isTarget) GameManager.Instance.AddPlayer(1);
            }

            //GameManager.Instance.AddPlayer(1);
           


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.TryGetComponent<Player>(out Player player);
            if (player != null && player.id == targetId)
            {
                if (isTarget) GameManager.Instance.RemovePlayer(1);
            }
                
            
        }
    }
}
