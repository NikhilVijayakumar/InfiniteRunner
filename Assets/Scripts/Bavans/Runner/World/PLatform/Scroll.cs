using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bavans.Runner.Player;
namespace Bavans.Runner.World.Platform
{
    public class Scroll : MonoBehaviour
    {
        public float speed = -0.1f;
        private float height = 0.06f;

        private void FixedUpdate()
        {
            if (PlayerController.isDead)
            {
                return;
            }

            GameObject currentPlatform = PlayerController.currentPlatform;
            GameObject player = PlayerController.player;
            if (currentPlatform == null || player == null)
            {
                return;
            }            

            this.transform.position += player.transform.forward * speed;

            if (currentPlatform.tag == "StairUp")
            {
                this.transform.Translate(0, -height, 0);
            }
            else if (currentPlatform.tag == "StairDown")
            {
                this.transform.Translate(0, height, 0);
            }


        }


    }
}
