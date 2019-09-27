using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    public float waitingTime = 3.2f; //Time required to wait after mines have been spawned
    public GameObject mineSpawner; //Transform of this game object is where mines are spawned
    public float upSpawnLimit = 0.06f; //Upper limit of spawning mines
    public float downSpawnLimit = 3.8f; //Down limit of spawning mines
    private float timer = 1.1f; // Timer for counting 
    private float speedDecreaser = 0.004f; //Speed decreaser for increasing spawning mines 

    void Update()
    {
        
        if (timer > waitingTime) //Spawning of mines, instantiating new mine with randomized upper and lower limit, and finally destroying them
        {
            GameObject newMine = Instantiate(mineSpawner); //Instantiating mines
            newMine.transform.position = new Vector3(transform.position.x, Random.Range(transform.position.y + upSpawnLimit,transform.position.y - downSpawnLimit),transform.position.z); // Placing coordinates for mines
            Destroy(newMine, 10f); //Destroying spawned mines after 10 seconds
            timer = 0; //Reseting timer
            waitingTime -= speedDecreaser; //Decreasing time needed to spawn mine
        }
        timer += Time.deltaTime; //Increasing timer varibable every iteration of Update function
        
    }
}
