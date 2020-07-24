using UnityEngine;

public class PatrolPoints : MonoBehaviour
{
    public Transform[] Points;

    public Transform GetRandomPoint()
    {
        return Points[Random.Range(0, Points.Length)];
    }

    public Vector3[] GetPointsPositions()
    {
        Vector3[] positions = new Vector3[Points.Length];

        for (int i = 0; i < Points.Length; i++)
        {
            positions[i] = Points[i].position;
        }

        return positions;

    }
}
