﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager S;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    private PlayerController[] playerListAsArray;
    public List<PlayerController> playerList;

    public List<PlankManager> planksInScene;

    public GameObject winner;
    [HideInInspector]
    public bool someoneWon = false;

    public GameObject cameraRef;

    private void Awake()
    {
        
        if(S == null)
        {
            S = this;
        }
        else
        {
            Destroy(this);
        }

        //created planks add themseleves to this
        planksInScene = new List<PlankManager>();

        /*Debug.Log("There are four players: " + PlayerSelect.S.FourPlayersReady);
        if (!PlayerSelect.S.FourPlayersReady)
        {
            player4.SetActive(false);
        }

        Debug.Log("There are three players: " + PlayerSelect.S.ThreePlayersReady);
        if (!PlayerSelect.S.ThreePlayersReady)
        {
            player3.SetActive(false);
        }*/



        playerListAsArray = GameObject.FindObjectsOfType<PlayerController>();
        //Debug.Log("playerList.Length = " + playerList.Length);

        for (int index = 0; index < playerListAsArray.Length; index++)
        {
            playerList.Add(playerListAsArray[index]);
        }

        if (player1 == null || player2 == null || player3 == null || player4 == null)
        {
            //make sure 2 players
            
            if(playerList.Count < 2 || playerList.Count > 4)
            {
                print("either to few or too many players");
            }
            else
            {

                foreach(PlayerController player in playerList)
                {
                    switch (player.playerNumber)
                    {
                        case PlayerController.PlayerNumber.p1Clumsy:
                            player1 = player.gameObject;
                            break;
                        case PlayerController.PlayerNumber.p2Tough:
                            player2 = player.gameObject;
                            break;
                        case PlayerController.PlayerNumber.p3Joker:
                            player3 = player.gameObject;
                            break;
                        case PlayerController.PlayerNumber.p4Crazy:
                            player4 = player.gameObject;
                            break;
                        default:
                            break;
                    }
                }
                
            }
        }
        
        if(cameraRef == null)
        {
            cameraRef = GameObject.FindObjectOfType<CameraController>().gameObject;
        }

        someoneWon = false;

        if (PlayerSelect.S.startedPS)
        {
            Debug.Log("There are four players: " + PlayerSelect.S.FourPlayersReady);
            if (!PlayerSelect.S.FourPlayersReady)
            {
                player4.SetActive(false);
            }

            Debug.Log("There are three players: " + PlayerSelect.S.ThreePlayersReady);
            if (!PlayerSelect.S.ThreePlayersReady)
            {
                player3.SetActive(false);
            }
        }

        //clean list
        for (int index = 0; index < playerList.Count; index++)
        {
            if(!playerList[index].gameObject.activeSelf)
            {
                //print(playerList[index] + " not active.");
                playerList.RemoveAt(index);
            }
        }

    }
    /*public void RestartGame()
    {
        someoneWon = false;
        SceneManager.LoadScene("Main_Menu");
    }*/

    public void EndLevel()
    {
        someoneWon = false;
        planksInScene = new List<PlankManager>();
        SceneManager.LoadScene("EndScreen");
    }

}
