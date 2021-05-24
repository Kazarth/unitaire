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



     void Start()

        {
            StartCoroutine(generateEnemies());
        }

        IEnumerator generateEnemies()
        {
            while (enemyCounter < 10)

            {
                yield return new WaitForSeconds(3);
                enemySpawn();
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
