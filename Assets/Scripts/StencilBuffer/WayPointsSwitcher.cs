using System.Collections.Generic;
using UnityEngine;

public class WayPointsSwitcher : MonoBehaviour
{
    [SerializeField] private List<WayPoint> _wayPoints;
    [SerializeField] private StencilSwitcher _stencilSwitcher;

    public void ToggleWayPoints(WayPoint wayPointToBeDeactivated)
    {
        foreach (var wayPoint in _wayPoints)
        {
            wayPoint.gameObject.SetActive(true);
        }
        
        wayPointToBeDeactivated.gameObject.SetActive(false);
    }

    public void ChangeStencilId(WayPoint wayPoint)
    {
        int wayPointIndex = _wayPoints.IndexOf(wayPoint);

        int leftWayPointIndex = ClampIndex(wayPointIndex + 1);
        int rightWayPointIndex = ClampIndex(wayPointIndex - 1);
        
        _stencilSwitcher.IncreaseStencilIdLevel(leftWayPointIndex, wayPointIndex);
        _stencilSwitcher.DecreaseStencilIdLevel(rightWayPointIndex, wayPointIndex);
    }

    private int ClampIndex(int index)
    {
        int clampedIndex = index;
        
        if (clampedIndex == -1)
            clampedIndex = _wayPoints.Count - 1;

        if (clampedIndex == _wayPoints.Count)
            clampedIndex = 0;

        return clampedIndex;
    }
}