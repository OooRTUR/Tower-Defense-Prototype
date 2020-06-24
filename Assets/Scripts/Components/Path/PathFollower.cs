using PathCreation;
using UnityEngine;
public class PathFollower : PathFollowerBase
{
    //init
    [SerializeField]
    private PathCreator pathCreator;

    private GameManager gameManager;

    //runtime
    float distanceTravelled;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public override void Init(GameObject pathContainer)
    {
        pathCreator = pathContainer.GetComponent<PathCreator>();

        this.enabled = true;
    }

    protected override void PerformMove()
    {
        if (gameManager._GameStatus == GameStatus.Play)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
        }
    }
}

