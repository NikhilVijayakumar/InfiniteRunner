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
            this.transform.position += PlayerController.player.transform.forward * speed;

            GameObject currentPlatform = PlayerController.currentPlatform;
            if(currentPlatform == null)
            {
                return;
            }

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
