using UnityEngine;

namespace Player.Attack
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
