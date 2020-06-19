using PathCreation;
using UnityEngine;
public class PathFollower : PathFollowerBase
{
    float distanceTravelled;

    public PathCreator pathCreator;

    public override void Init(GameObject pathContainer)
    {
        pathCreator = pathContainer.GetComponent<PathCreator>();

        this.enabled = true;
    }

    protected override void PerformMove()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
    }
}

