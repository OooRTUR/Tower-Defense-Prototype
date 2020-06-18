using PathCreation;
using UnityEngine;
public class PathFollower : MonoBehaviour
{
    float distanceTravelled;
    float speed = 2.0f;
    public PathCreator pathCreator;

    private void Update()
    {
        if (pathCreator != null)
            PerformMove();
    }

    private void PerformMove()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
    }
}