using UnityEngine;

public class AttackPointsList : MonoBehaviour
{
    private AttackPoint[] _allAttackPoints;

    private void Start()
    {
        _allAttackPoints = GetComponentsInChildren<AttackPoint>();
    }

    public Vector3 GetAttackPoint(Enemy enemy)
    {
        AttackPoint closestPoint = null;
        var minDistance = Mathf.Infinity;

        for (int i = 0; i < _allAttackPoints.Length; i++)
        {
            var distanceToPoint = (enemy.transform.position - _allAttackPoints[i].transform.position).magnitude;

            if(_allAttackPoints[i].IsAvailable)
                if(minDistance >= distanceToPoint)
                {
                    closestPoint = _allAttackPoints[i];
                    minDistance = distanceToPoint;
                }
        }

        if (closestPoint == null)
        {
            Debug.Log("Kak suka");
            return Vector3.zero;
        }
        else
        {
            closestPoint.SetEnemy(enemy);

            return closestPoint.transform.position;
        }
    }
}