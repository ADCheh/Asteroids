using System;
using UnityEngine;

namespace Mechanics.WarpZone
{
    public class WarpZone : MonoBehaviour
    {
        public Transform targetZone;
        public WarpType warpZoneType;
        
        private WarpZoneLogic _warpZoneLogic;

        private void Start()
        {
            _warpZoneLogic = new WarpZoneLogic(warpZoneType,targetZone);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            _warpZoneLogic.WarpTo(col);
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
