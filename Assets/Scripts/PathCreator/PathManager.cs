using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathManager : MonoBehaviour
{
    public PathCreator pathCreator;
    public bool isPathClosed;
    public List<VisualRoadMesh> visualRoadMeshes;

    [HideInInspector] public List<Vector3> pathPosList;

    private void Awake()
    {
        ConstructLine();

    }

    public void ConstructLine()
    {

        pathCreator.transform.localPosition = transform.position;
        foreach (VisualRoadMesh roadmesh in visualRoadMeshes)
        {
            foreach (Transform pathPoint in roadmesh.pathPoints)
            {
                pathPosList.Add(pathPoint.position);
            }
        }

        if (pathPosList.Count > 0)
        {
            BezierPath bezierPath = new PathCreation.BezierPath(pathPosList.ToArray(), false, PathSpace.xyz);
            pathCreator.bezierPath = bezierPath;
            pathCreator.bezierPath.IsClosed = isPathClosed;
        }
    }
}
