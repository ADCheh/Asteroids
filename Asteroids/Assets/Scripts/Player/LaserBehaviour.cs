using UnityEngine;

namespace Player
{
    public class LaserBehaviour : MonoBehaviour
    {
        public GameObject Player;
    
        void Update()
        {
            transform.position = Player.transform.position;
            transform.rotation = Player.transform.rotation;
        }
    }
}
