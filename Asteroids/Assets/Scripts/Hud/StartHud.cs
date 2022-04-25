using UnityEngine;

namespace Hud
{
    public class StartHud : MonoBehaviour
    {
        private void Awake()
        {
            Time.timeScale = 0;
        }

        public void StartGame()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
