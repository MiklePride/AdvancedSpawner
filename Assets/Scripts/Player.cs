using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _path;

    private Mover _mover;
    private Transform[] _wayPoints;
    private Transform _targetPoint;
    private int _indexPoint;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Start()
    {
        _wayPoints = new Transform[_path.childCount];

        for (int i = 0; i < _wayPoints.Length; i++)
        {
            _wayPoints[i] = _path.GetChild(i);
        }

        ResetTargetPoint();
    }

    private void Update()
    {
        if (transform.position == _targetPoint.position)
        {
            PassNextTargetPoint();
        }
    }

    private void ResetTargetPoint()
    {
        if (_wayPoints != null)
        {
            _indexPoint = 0;
            _targetPoint = _wayPoints[_indexPoint];
            _mover.GetTargetPoint(_targetPoint);
        }
    }

    private void PassNextTargetPoint()
    {
        _indexPoint++;

        if (_indexPoint == _wayPoints.Length)
        {
            ResetTargetPoint();
        }
        else
        {
            _targetPoint = _wayPoints[_indexPoint];
            _mover.GetTargetPoint(_targetPoint);
        }
    }
}
