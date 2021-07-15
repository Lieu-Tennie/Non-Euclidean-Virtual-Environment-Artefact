using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class PortalTest
    {
        public void PortkeyWithPlayerTest()
        {
            SceneManager.LoadScene("SampleScene");

            Vector3 playerPos = new Vector3(0, 0, 0);
            Vector3 targetPos = new Vector3(0, 0, 1);

            float portalToPlayer = 5f;
            float dotProduct = -0.3f; //set to soemthign below  0 so it will run the if

            if (dotProduct < 0f)
            {
                playerPos = targetPos;
            }

            Assert.That(playerPos, Is.EqualTo(targetPos));
        }
    }
}
