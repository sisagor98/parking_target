using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameInputManager : MonoBehaviour
{
    public static GameInputManager Instance; 
    
    public GameObject selectedPlayer = null;
    private Camera m_Camera;
    private Vector2 startTouchPosition;
    private Vector2 currentPosition;

    private Player selectedPlayerInstance;
    private Transform targetPoint;
    public int totallArrow=5;


    void Awake()
    {
        m_Camera = Camera.main;
       Instance = this;
      
    }
    void Update() { 
  
        Swipe();
      
    }


    void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPosition = Input.mousePosition;
            Ray ray = m_Camera.ScreenPointToRay(startTouchPosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    selectedPlayer = hit.transform.gameObject;
                    selectedPlayerInstance = selectedPlayer.GetComponent<Player>();
                    selectedPlayerInstance.isSelectedPlayer = true;
                    //selectedArrowInstance.rigidBody.isKinematic = false;
                    selectedPlayerInstance.SetMovementandDirection(true);
                }
            }
        }

        if (Input.GetMouseButton(0) && selectedPlayer != null)
        {
            currentPosition = Input.mousePosition;
            Vector2 Distance = currentPosition - startTouchPosition;


            if (Input.GetMouseButtonUp(0))
            {

                if (selectedPlayer != null)
                {
                    bool shouldPlay = selectedPlayerInstance.shallPlay;
                    selectedPlayerInstance.shallPlay = !shouldPlay;

                   // print("Tap detected");
                }



            }
            

        }

    }
   

}
