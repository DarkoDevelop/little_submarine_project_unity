using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    //Defining variables 
    public float flyStrength = 300f;    //Setting y force of flyspeed
    public GameManager gameManager;     //Fetching GameManager script
    public AudioSource deathSound;      //AudioSource for death sound 
    public ConstantForce2D force2d;     //Component force2D
    public Canvas startGameCanvas;      
    public Canvas GameCanvas;
    public Canvas EndGameCanvas;
    public GameObject mineSpawner;
    public Text highScore;
    private Rigidbody2D rb;
    private float rotation = 0f;
    private Animator anim;

    private void Awake()
    {
        GameAwake();    //Calling GameAwake() funcion for turning off some player components and playgame canvas
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            force2d.enabled = !force2d.enabled; //Reenabling component after disabling it in GameAwake() function
            Fly();  //Calling Fly() function
        }
        else
        {
            force2d.enabled = false; //Disable force2D component if touch/button is not used
        }

        //Rotating submarine acorrding to y speed
        if (rb.velocity.y > 0)
        {
            rotation = Mathf.Lerp(0, 70, rb.velocity.y / 17); 
            transform.rotation = Quaternion.Euler(0, 0, rotation); 
        }
        else if (rb.velocity.y <= 0)
        {
            rotation = Mathf.Lerp(0, -70, -rb.velocity.y / 17);
            transform.rotation = Quaternion.Euler(0, 0, rotation);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) //Quit if button is pressed
            Application.Quit();
    }

    void Fly()  //Adding force if the button is pressed
    {
        force2d.force = new Vector3(0 , flyStrength , 0);
    }
    
    private void OnTriggerEnter2D(Collider2D collider) //Checking if submarine hit a mine
    { 
        if (collider.name == "Mines(Clone)" || collider.name == "OutsideColliders") //Checking if player colided with a mine or top or bottom collider
        {
            gameManager.GameOver();
            EndGameCanvas.enabled = true;
            deathSound.Play();
        }
    }

    private void GameAwake() //Setting come needed components off and on when game loads
    {
        anim = GetComponent<Animator>();
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        force2d = GetComponent<ConstantForce2D>();
        rb = GetComponent<Rigidbody2D>();
        GameCanvas.enabled = false;
        EndGameCanvas.enabled = false;
        rb.isKinematic = true;
        force2d.enabled = false;
        mineSpawner.SetActive(false);
    }

    public void StartGameButton() //Setting come needed components off and on when game starts
    {
        GameCanvas.enabled = true;
        rb.isKinematic = false;
        mineSpawner.SetActive(true);
        startGameCanvas.enabled = false;
        anim.enabled = false;
    }
}
