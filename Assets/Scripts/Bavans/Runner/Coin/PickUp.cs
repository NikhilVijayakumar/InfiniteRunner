using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bavans.Runner.Player;
namespace Bavans.Runner.World
{
    public class PickUp : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                GameObject player = other.gameObject;
                PlayerController controller =  player.GetComponent<PlayerController>();
                if (controller != null)
                {
                    controller.updateScore(1);
                }
                
                gameObject.SetActive(false);
            }
        }

        private void OnEnable()
        {
            gameObject.SetActive(true);

        }

    }
}

