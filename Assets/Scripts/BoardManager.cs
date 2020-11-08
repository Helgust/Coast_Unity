﻿using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;		//Allows us to use Lists.
using Newtonsoft.Json;
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.

[System.Serializable]
public class BoardManager : MonoBehaviour
{

    public Board gameBoard;
    public Board BGBoard;
    private DB DBScript;

    public GameObject[] ShipTiles;                                  //Array of floor prefabs.
    public GameObject[] SmallShipTiles;                                 //Array of floor prefabs.
    public GameObject[] OuterWaterTiles;                                    //Array of wall prefabs.
    public GameObject[] MiddleWaterTiles;                                   //Array of food prefabs.
    public GameObject[] InnerWaterTiles;                                    //Array of enemy prefabs.
    public GameObject[] ForestTiles;                                //Array of outer tile prefabs.
    public GameObject[] AgroCultureTiles;                               //Array of outer tile prefabs.
    public GameObject[] TourismTiles;                               //Array of outer tile prefabs.
    public GameObject[] BeachTourismTiles;                              //Array of outer tile prefabs.

    public GameObject[] FactoryTiles;                               //Array of outer tile prefabs.
    public GameObject[] PlaneTiles;                             //Array of outer tile prefabs.

    public GameObject[] DirtTiles;                              //Array of outer tile prefabs.


    private Transform boardHolder;                                  //A variable to store a reference to the transform of our Board object
    private Transform boardBGHolder;
    private List<Vector3> gridPositions = new List<Vector3>();  //A list of possible locations to place tiles.



    /* 	public void InitBoard(string jsonString)
    	{
			Debug.Log("InitBoard: File Exists: " + File.Exists(jsonString));
			string json = File.ReadAllText(jsonString);
			gameBoard = JsonConvert.DeserializeObject<Board>(json);
			//Debug.Log("InitBoard: First Line " + gameBoard.columns);


				
    	} */


    //Clears our list gridPositions and prepares it to generate a new board.
    void InitialiseList()
    {
        //Clear our list gridPositions.
        gridPositions.Clear();
        //Loop through x axis (columns).
        for (int x = 0; x < gameBoard.columns; x++)
        {
            //Within each column, loop through y axis (rows).
            for (int y = 0; y < gameBoard.rows; y++)
            {
                //At each index add a new Vector3 to our list with the x and y coordinates of that position.
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }


    void BoardSetup(Board gameBoard)
    {
        gameBoard.array2d.Reverse(); // make reverse for correct drawing on gamingBoard

        //Instantiate Board and set boardHolder to its transform.
        boardHolder = new GameObject("Board").transform;
        boardHolder.tag = "gameBoard";
        //Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
        for (int x = 0; x < gameBoard.columns; x++)
        {
            //Loop along y axis, starting from -1 to place floor or outerwall tiles.
            for (int y = 0; y < gameBoard.rows; y++)
            {
                //Debug.Log(gameBoard.array2d[y][x]);
                //Debug.Log(x+" "+y);
                GameObject toInstantiate;


                if (gameBoard.array2d[y][x] == 10) //ship
                {
                    toInstantiate = ShipTiles[Random.Range(0, ShipTiles.Length)];
                }
                else if (gameBoard.array2d[y][x] == 1) //outer waters
                {
                    toInstantiate = OuterWaterTiles[Random.Range(0, OuterWaterTiles.Length)];
                }
                else if (gameBoard.array2d[y][x] == 2)
                {
                    toInstantiate = MiddleWaterTiles[Random.Range(0, MiddleWaterTiles.Length)];
                }
                else if (gameBoard.array2d[y][x] == 3)
                {
                    toInstantiate = InnerWaterTiles[Random.Range(0, InnerWaterTiles.Length)];
                }
                else if (gameBoard.array2d[y][x] == 4)
                {
                    toInstantiate = ForestTiles[Random.Range(0, ForestTiles.Length)];
                }
                else if (gameBoard.array2d[y][x] == 5)
                {
                    toInstantiate = AgroCultureTiles[Random.Range(0, AgroCultureTiles.Length)];
                }
                else if (gameBoard.array2d[y][x] == 15)
                {
                    toInstantiate = FactoryTiles[Random.Range(0, FactoryTiles.Length)];
                }
                else if (gameBoard.array2d[y][x] == 14)
                {
                    toInstantiate = PlaneTiles[Random.Range(0, PlaneTiles.Length)];
                }
                else if (gameBoard.array2d[y][x] == 13)
                {
                    toInstantiate = TourismTiles[Random.Range(0, TourismTiles.Length)];
                }
                else if (gameBoard.array2d[y][x] == 12)
                {
                    toInstantiate = BeachTourismTiles[Random.Range(0, BeachTourismTiles.Length)];
                }
                else if (gameBoard.array2d[y][x] == 11)
                {
                    toInstantiate = SmallShipTiles[Random.Range(0, SmallShipTiles.Length)];
                }

                else
                {
                    toInstantiate = DirtTiles[Random.Range(0, DirtTiles.Length)];
                }


                //Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
                GameObject instance =
                    Instantiate(toInstantiate, new Vector3(x, y, -1.0f), Quaternion.identity) as GameObject;

                //Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
                instance.transform.SetParent(boardHolder);
            }
        }

        gameBoard.array2d.Reverse(); // make reverse for correct drawing on gamingBoard

    }

   void BoardBackGroundSetup(Board BGBoard)
    {
        BGBoard.array2d.Reverse(); // make reverse for correct drawing on gamingBoard

        //Instantiate Board and set boardHolder to its transform.
        boardBGHolder = new GameObject("BoardBG").transform;
        boardBGHolder.tag = "gameBoardBG";
        //Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
        for (int x = 0; x < BGBoard.columns; x++)
        {
            //Loop along y axis, starting from -1 to place floor or outerwall tiles.
            for (int y = 0; y < BGBoard.rows; y++)
            {
                //Debug.Log(gameBoard.array2d[y][x]);
                //Debug.Log(x+" "+y);
                GameObject toInstantiate;

                if (BGBoard.array2d[y][x] == 1) //outer waters
                {
                    toInstantiate = OuterWaterTiles[Random.Range(0, OuterWaterTiles.Length)];
                }
                else if (BGBoard.array2d[y][x] == 2)
                {
                    toInstantiate = MiddleWaterTiles[Random.Range(0, MiddleWaterTiles.Length)];
                }
                else if (BGBoard.array2d[y][x] == 3)
                {
                    toInstantiate = InnerWaterTiles[Random.Range(0, InnerWaterTiles.Length)];
                }
                else if (BGBoard.array2d[y][x] == 15)
                {
                    toInstantiate = FactoryTiles[Random.Range(0, FactoryTiles.Length)];
                }
                else if (BGBoard.array2d[y][x] == 14)
                {
                    toInstantiate = PlaneTiles[Random.Range(0, PlaneTiles.Length)];
                }
                else
                {
                    toInstantiate = DirtTiles[Random.Range(0, DirtTiles.Length)];
                }


                //Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
                GameObject instance = Instantiate(toInstantiate, new Vector3(x,y, 0f), Quaternion.identity) as GameObject;

                //Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
                instance.transform.SetParent(boardBGHolder);
            }
        }

    }



    public void SetupScene(Board gameBoard)
    {
        //Creates the outer walls and floor.
        BoardSetup(gameBoard);

        //Reset our list of gridpositions.
        InitialiseList();
    }
    public void SetupBGScene(Board BGBoard)
    {
        //Creates the outer walls and floor.
        BoardBackGroundSetup(BGBoard);

        //Reset our list of gridpositions.
        InitialiseList();
    }
}
