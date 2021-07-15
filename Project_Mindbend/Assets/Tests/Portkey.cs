using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Test
{
    public class Portkey
    {
        [Test]
        public void PortkeyWithPlayerTest()
        {
            Vector3 playerPos = new Vector3(0, 0, 0);
            Vector3 targetPos = new Vector3(0, 0, 1);

            float portalToPlayer = 5f;
            float dotProduct = -0.3f;

            if (dotProduct < 0f)
            {
                playerPos = targetPos;
            }

            Assert.That(playerPos, Is.EqualTo(targetPos));
        }
    }
}
