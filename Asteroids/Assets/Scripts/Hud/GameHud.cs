using System;
using Hud.Info;
using UnityEngine;
using UnityEngine.UI;

namespace Hud
{
    public class GameHud : MonoBehaviour
    {
        public GameObject Player;

        public Text CoordinatesTextField;
        public Text RotationTextField;
        public Text SpeedTextField;
        public Text WeaponCurrentChargesField;

        private PlayerPositionInfo _playerPositionInfo;
        private PlayerWeaponsInfo _playerWeaponsInfo;
        private PlayerScoreInfo _playerScoreInfo;

        private void Start()
        {
            _playerPositionInfo = new PlayerPositionInfo(Player);
            _playerWeaponsInfo = new PlayerWeaponsInfo(Player);
            _playerScoreInfo = new PlayerScoreInfo();
        }

        private void Update()
        {
            CoordinatesTextField.text = _playerPositionInfo.GetPlayerCoordinatesString();
            RotationTextField.text = _playerPositionInfo.GetPlayerRotationAngleString();
            SpeedTextField.text = _playerPositionInfo.GetPlayerSpeedMagnitudeString();
            WeaponCurrentChargesField.text = _playerWeaponsInfo.GetCurrentWeaponChargesString();
        }
    }
}