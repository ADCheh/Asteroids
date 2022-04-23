using UnityEngine;

namespace Mechanics.WarpZone
{
    public class WarpZoneLogic
    {
        private bool _isDestination = false;
        private readonly Transform _targetZoneTransform;
        private readonly WarpType _warpZoneType;

        public WarpZoneLogic(WarpType warpType, Transform targetZone)
        {
            _warpZoneType = warpType;
            _targetZoneTransform = targetZone;
        }

        public void WarpTo(Collider2D col)
        {
            if (!col.CompareTag("Player")) 
                return;

            if (_isDestination)
                return;
            
            _targetZoneTransform.GetComponent<WarpZone>().SetDestination(true);
            
            Vector3 position = col.transform.position;
            
            if (_warpZoneType == WarpType.Vertical)
            {
                position = new Vector3(position.x, _targetZoneTransform.transform.position.y,
                    position.z);
            }
            else
            {
                position = new Vector3(_targetZoneTransform.transform.position.x, position.y,
                    position.z);
            }
            col.transform.position = position;
        }

        public void SetDestination(bool isDestination)
        {
            _isDestination = isDestination;
        }
    }
}