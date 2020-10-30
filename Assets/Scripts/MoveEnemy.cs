using DG.Tweening;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    private Vector3[] path;
    
    private void Start()
    {
        path = new Vector3[points.Length];
        for (var i = 0; i < points.Length; i++)
        {
            path[i] = points[i].position;
        }
        Move();
    }

    private void Move()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(gameObject.transform.DOPath(path, 15f));
        sequence.AppendCallback(Move);
    }
}
