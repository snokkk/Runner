using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Terrain terrain;
    private int terrainWidth;
    private int terrainLength;
    private int terrainPosX;
    private int terrainPosZ;

    [SerializeField] private GameObject coinToSpawn;
    public int numberOfCoins;
    private int currentCoin;
    

    void Start()
    {
        terrainWidth = (int)terrain.terrainData.size.x;
        terrainLength = (int)terrain.terrainData.size.z;
        terrainPosX = (int)terrain.transform.position.x;
        terrainPosZ = (int)terrain.transform.position.z;
    }

    void Update()
    {
            if (currentCoin <= numberOfCoins)
            {

                int posx = Random.Range(terrainPosX, terrainPosX + terrainWidth);
                int posz = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
                float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz));

                if (posy < 0.5f)
                {
                    GameObject newObject = (GameObject)Instantiate(coinToSpawn, new Vector3(posx, posy, posz), Quaternion.identity);

                    currentCoin += 1;
                }

            }
    }
   
}
