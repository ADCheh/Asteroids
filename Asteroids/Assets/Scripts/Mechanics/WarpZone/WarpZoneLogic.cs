using System.Collections;
using Mono.Cecil;
using UnityEngine;

namespace Mechanics.WarpZone
{
    public class WarpZoneLogic
    {
        private bool _isDestination = false;
        private readonly Transform _targetZoneTransform;
        private readonly WarpType _warpZoneType;
        private float _warpDelay;

        public WarpZoneLogic(WarpType warpType, Transform targetZone, float warpDelay)
        {
            _warpZoneType = warpType;
            _targetZoneTransform = targetZone;
            _warpDelay = warpDelay;
        }

        public IEnumerator WarpTo(Collider2D col)
        {
            if (!col.CompareTag("Player")) 
                yield break;

            if (_isDestination)
                yield break;
            
            var targetZone = _targetZoneTransform.GetComponent<WarpZone>();
            
            
            _targetZoneTransform.GetComponent<WarpZone>().SetDestination(true);
            
            Vector3 position = col.gameObject.transform.position;
            
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
            col.gameObject.transform.position = position;

            yield return new WaitForSeconds(_warpDelay);
            
            _targetZoneTransform.GetComponent<WarpZone>().SetDestination(false);
        }
        
        public void SetDestination(bool isDestination)
        {
            _isDestination = isDestination;
        }
    }
}