using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private WayPointsSwitcher _wayPointsSwitcher;
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<FirstPersonAIO>() != null) 
        {
            _wayPointsSwitcher.ToggleWayPoints(this);
            _wayPointsSwitcher.ChangeStencilId(this);
        }
    }
}
