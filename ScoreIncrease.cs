using UnityEngine;

public class ScoreIncrease : MonoBehaviour
{
    //Score increasing and playing sound after successful passed mine
    public AudioSource passSound;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            passSound.Play();
            ScoreHanlder.scoreValue++;
        }
    }
}
