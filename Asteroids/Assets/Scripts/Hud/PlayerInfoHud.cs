using Hud.Info;
using UnityEngine;
using UnityEngine.UI;

namespace Hud
{
    public class PlayerInfoHud : MonoBehaviour
    {
        public GameObject Player;

        public Text CoordinatesTextField;
        public Text RotationTextField;
        public Text SpeedTextField;
        public Text WeaponCurrentChargesField;

        public Image WeaponRechargeBar;

        private PlayerPositionInfo _playerPositionInfo;
        private PlayerWeaponsInfo _playerWeaponsInfo;

        private void Start()
        {
            _playerPositionInfo = new PlayerPositionInfo(Player);
            _playerWeaponsInfo = new PlayerWeaponsInfo(Player);
        }

        private void Update()
        {
            CoordinatesTextField.text = _playerPositionInfo.GetPlayerCoordinatesString();
            RotationTextField.text = _playerPositionInfo.GetPlayerRotationAngleString();
            SpeedTextField.text = _playerPositionInfo.GetPlayerSpeedMagnitudeString();
            WeaponCurrentChargesField.text = _playerWeaponsInfo.GetCurrentWeaponChargesString();
            WeaponRechargeBar.fillAmount = _playerWeaponsInfo.GetReloadStatus();
        }
    }
}