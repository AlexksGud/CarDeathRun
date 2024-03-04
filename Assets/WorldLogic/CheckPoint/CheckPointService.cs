using System;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointService : MonoBehaviour
{
    private int _current = -1;

    public int Current => _current;
    public Vector3 CheckPointPos => _checkPoints[_current].PositionForPlayer;
    public event Action OnFinalCheckPoint;
    [SerializeField] private List<CheckPoint> _checkPoints;

    void Start()
    {
        SetCheckPoint(0);
    }

    public void SetCheckPoint(int i)
    {
        DeleteLastCheckPoint();

        if (IsLastCheckPoint())
            return;

        _current = i;
        _checkPoints[_current].OnCheckPoint += CheckPointGained;

        bool IsLastCheckPoint()
        {
            var lastCheckIndx = _checkPoints.Count - 1;
            if (_current == lastCheckIndx)
                return true;

            return false;

        }
    }
    private void DeleteLastCheckPoint()
    {
        if (_current == -1)
            return;
        _checkPoints[_current].OnCheckPoint -= CheckPointGained;
    }

    private void CheckPointGained()
    {
        SetCheckPoint(_current + 1);
    }




}
