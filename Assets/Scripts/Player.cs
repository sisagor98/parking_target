using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{

    public Rigidbody rigidBody;
    [SerializeField] private float movementSpeed = 0;
    private Vector3 movementDirection;

    public bool shallMove = false;
    public bool isSelectedPlayer = false;
    public bool shallPlay = false;

    public Transform arrowPosition;
   [HideInInspector] public float enemyDistance;


    public Transform[] waypoints;
    public float speed;
    private int currentWaypointIndex = 0;



    void Awake()
    {
      //  rigidBody = GetComponent<Rigidbody>();
        
    }
    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        if (shallMove)
        {
            PlayerMoveWay();
           // MoveArrow();
        }
    }

    private void MoveArrow()
    {
        if (movementDirection != null)
        {
            rigidBody.velocity = movementDirection * movementSpeed;
            //if(rigidBody.velocity.magnitude < 5f )
            //{
            //    rigidBody.velocity = movementDirection * movementSpeed;
            //   // print(rigidBody.velocity);
            //}
        }
    }

    public void SetMovementandDirection(bool moveArrow)
    {
        shallMove = moveArrow;
    }
    

    public void PlayerMoveWay()
    {
        
        Vector3 waypointPosition = waypoints[currentWaypointIndex].position;

       
        Vector3 direction = waypointPosition - transform.position;
        transform.position += direction * speed * Time.deltaTime;

     
        if (Vector3.Dot(direction, direction) < 0.01f)
        {
            
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    }
   



    //public void OnCollisionFeedback()
    //{
    //    if (isSelectedArrow)
    //    {
    //        rigidBody.isKinematic = true;
    //        shallMove = false;
    //        isSelectedArrow = false;
    //        GameInputManager.Instance.selectedArrow = null;
    //        Vector3 hitPosition = transform.position;
    //        rigidBody.velocity = Vector3.zero;
    //        rigidBody.angularVelocity = Vector3.zero;
    //        Vector3 newPos = hitPosition - (movementDirection * 0.6f);
     
        
    //        transform.DOMove(newPos,0.2f).OnComplete(() =>
    //            {
    //                //To Add more collision effeft;
    //            }
    //        );
    //    }
    //    else
    //    {
            
    //        // var rotation = transform.InverseTransformDirection(movementDirection);
    //        // (rotation.x, rotation.z) = (-rotation.z, rotation.x);
    //        // transform.DOPunchRotation(rotation * 7f, 0.3f, 8).SetId(transform);
    //        transform.DOShakePosition(0.25f,0.2f,2);
    //    }
    //}

    public void StopPhysicsBasedMovement()
    {
        rigidBody.isKinematic = true;
        shallMove = false;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        isSelectedPlayer = false;
    }




}
