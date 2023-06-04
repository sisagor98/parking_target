using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;
using PathCreation;

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
   // public float speed;
    private int currentWaypointIndex = 0;


    [Header("PathCreator") ]
    [SerializeField] private PathCreator pathCreator;
    [SerializeField] private EndOfPathInstruction endOfPathInstruction;
    [SerializeField] private float speed;
    float distanceTravelled;
    Quaternion PlayerBodyRot;





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
            PlayerMove();
           // PlayerMoveWay();
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

    public void PlayerMove()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        Quaternion rot = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        PlayerBodyRot.eulerAngles = new Vector3(rot.eulerAngles.x, rot.eulerAngles.y, 0);
        transform.SetPositionAndRotation(transform.position, PlayerBodyRot);

    }

    public void StopPhysicsBasedMovement()
    {
        rigidBody.isKinematic = true;
        shallMove = false;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        isSelectedPlayer = false;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shallMove = false;
            GameOverPanelControl.Instance.EnablePanel(GameState.LevelFailed, 1f);
            print("GameOver");
        }
    }


}
