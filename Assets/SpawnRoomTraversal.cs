//
//Author: James Hopkins, Khalid, Manhim
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnRoomTraversal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject[] spawnPoints;
    int max = 5;
    int traverse = 0;
    public List<int> intList = new List<int>();
    private GameObject[] newSpawn = new GameObject[5];

    private GameObject player;

    void SpawnShuffle()
    {
        for (int i = 0; i < max; i++)
        {
            intList.Add(i);
        }
        intList = intList.OrderBy(tvz => System.Guid.NewGuid()).ToList();
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            newSpawn[i] = spawnPoints[intList[i]];
        }
    }

    private void Start()
    {
        player = this.gameObject;
        SpawnShuffle();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "OpenDoor")
        {
            /*player.transform.position = spawnPoints[3].transform.position;
            Room newRoom = spawnPoints[4].transform.parent.GetComponent<Room>();
            player.GetComponent<PlayerControls>().ChangeRoom(newRoom, newRoom.GetTiles(), newRoom.GetDoors());
            traverse++;*/

           if (newSpawn[traverse].transform.parent.GetComponent<Room>().GetIsDoorBad())
            {
                SceneManager.LoadScene("MainScene");
            }
            else
            {
                player.transform.position = newSpawn[traverse].transform.position;
                Room newRoom = newSpawn[traverse].transform.parent.GetComponent<Room>();
                player.GetComponent<PlayerControls>().ChangeRoom(newRoom, newRoom.GetTiles(), newRoom.GetDoors());
                traverse++;
            }
        }
    }
}
