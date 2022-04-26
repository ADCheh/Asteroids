using System;
using UnityEngine;

namespace Mechanics.WarpZone
{
    public class WarpZone : MonoBehaviour
    {
        public Transform targetZone;
        public WarpType warpZoneType;
        public float warpDelay;
        
        private WarpZoneLogic _warpZoneLogic;

        private void Start()
        {
            _warpZoneLogic = new WarpZoneLogic(warpZoneType,targetZone,warpDelay);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            StartCoroutine(_warpZoneLogic.WarpTo(other));
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            SetDestination(false);
        }

        public void SetDestination(bool isDestination)
        {
            _warpZoneLogic.SetDestination(isDestination);
        }

    }
    
}
