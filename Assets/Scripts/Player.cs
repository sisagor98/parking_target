using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PathCreation;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Rigidbody rigidBody;
    [SerializeField] private float movementSpeed = 0;
    private Vector3 movementDirection;

    public bool shallMove = false;
    public bool shallMoveRev = false;
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
    public Image progressBarImage;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        if (shallMove)
        {
            PlayerMove();
        }
       
    }



    public void SetMovementandDirection(bool moveArrow)
    {
        shallMove = moveArrow;
    }
    

    public void PlayerMove()
    {
         distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        Quaternion rot = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        PlayerBodyRot.eulerAngles = new Vector3(rot.eulerAngles.x, rot.eulerAngles.y, 0);
        transform.SetPositionAndRotation(transform.position, PlayerBodyRot);

        UpdateProgressBar();

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

    private void UpdateProgressBar()
    {
        //float progress = 1f- ( distanceTravelled / pathCreator.path.length);
        //progressBarImage.fillAmount = progress;
    }
}
