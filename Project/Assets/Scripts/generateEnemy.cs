using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class generateEnemy : MonoBehaviour
    {

        public GameObject zombiePrefab;

        public int zPos;
        private int xPos;
        private float yPos;

        public int enemyCounter;
        public int maxEnemies;
        public float spawningInterval = 3.0f;

     void Start()

        {
            maxEnemies = 10;
            StartCoroutine(generateEnemies());
        }

        IEnumerator generateEnemies()
        {
            while (enemyCounter != maxEnemies)

            {
                yield return new WaitForSeconds(spawningInterval);
                enemySpawn();

            if (enemyCounter == maxEnemies - 2)
            {
                maxEnemies = maxEnemies + 10;
                spawningInterval -= 0.1f;
            }
        }

    }

    public void decrementEnemyCount ()

        {

        enemyCounter -= 1;

        }


        void enemySpawn()

        {
            xPos = Random.Range(440, 480);
            zPos = 300;
            yPos = 39;

            Vector3 zombieLocation = new Vector3(xPos, yPos, zPos);
            GameObject enemyZombie = Instantiate(zombiePrefab, zombieLocation, Quaternion.Euler(0, 180, 0));

   
        enemyCounter++;


    }
}
