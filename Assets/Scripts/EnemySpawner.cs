using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{

    private const int MIN_HORIZONTAL_SPAWN_RANGE = -15;
    private const int MAX_HORIZONTAL_SPAWN_RANGE = 15;
    private const int VERTICAL_SPAWN_POSITION = 8;
    private const int DEPTH_SPAWN_POSITION = 0;
    private int enemiesInCurrentWave;
    private int dificultScale;
    public List<GameObject> enemies = new List<GameObject>();

    private const double INITIAL_TIME = 60.0;
    public TMP_Text currentTimeText;

    public GameObject enemyRedColor;
    public GameObject enemyGreenColor;
    public GameObject enemyBlueColor;
    public GameObject enemyRedGreenColor;
    public GameObject enemyRedBlueColor;
    public GameObject enemyGreenBlueColor;

    void Start(){
        enemiesInCurrentWave = 3;
        dificultScale = 2;
    }

    void Update(){
        if(!HaveEnemyAlive()){
            GenerateNewWave();
            ResetTimer();
        }
    }

    private void GenerateNewWave(){
        for(int i = 0; i < enemiesInCurrentWave; i++){
            System.Random randomEnemy = new System.Random();
            int choosenEnemy = randomEnemy.Next(1, 7);
            if(choosenEnemy == 1){
                SpawnEnemy(enemyRedColor);
            }else if(choosenEnemy == 2){
                SpawnEnemy(enemyGreenColor);
            }else if(choosenEnemy == 3){
                SpawnEnemy(enemyBlueColor);
            }else if(choosenEnemy == 4){
                SpawnEnemy(enemyRedGreenColor);
            }else if(choosenEnemy == 5){
                SpawnEnemy(enemyRedBlueColor);
            }else{
                SpawnEnemy(enemyGreenBlueColor);
            }
        }
        enemiesInCurrentWave = enemiesInCurrentWave * dificultScale;
    }

    private void SpawnEnemy(GameObject enemy){
        System.Random randomEnemy = new System.Random();
        int horizontalSpawnPosition = randomEnemy.Next(MIN_HORIZONTAL_SPAWN_RANGE, MAX_HORIZONTAL_SPAWN_RANGE);
        GameObject spawnedEnemy = Instantiate(enemy, new Vector3(horizontalSpawnPosition, VERTICAL_SPAWN_POSITION, DEPTH_SPAWN_POSITION), Quaternion.identity);
        enemies.Add(spawnedEnemy);
    }

    public void DestroyEnemy(GameObject enemy){
        enemies.Remove(enemy);
    }

    private bool HaveEnemyAlive(){
        if(enemies.Count > 0){
            return true;
        }
        return false;
    }

    private void ResetTimer(){
        Timer timerObject = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        timerObject.currentTime = INITIAL_TIME;
    }
}
