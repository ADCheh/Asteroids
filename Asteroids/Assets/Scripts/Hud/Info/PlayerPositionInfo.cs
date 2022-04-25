using UnityEngine;

namespace Hud.Info
{
    public class PlayerPositionInfo
    {
        private Transform _playerTransform;
        private Rigidbody2D _playerRigidbody;
        public PlayerPositionInfo(GameObject player)
        {
            _playerTransform = player.transform;
            _playerRigidbody = player.GetComponent<Rigidbody2D>();

        }

        public string GetPlayerCoordinatesString()
        {
            return $"Current X: {_playerTransform.position.x:0.00} Current Y: {_playerTransform.position.y:0.00}";
        }
        
        public string GetPlayerRotationAngleString()
        {
            return $"Current rotation angle: {_playerTransform.rotation.eulerAngles.z:0.00}";
        }
        
        public string GetPlayerSpeedMagnitudeString()
        {
            return $"Current speed: {_playerRigidbody.velocity.magnitude:0.00}";
        }
    }
}