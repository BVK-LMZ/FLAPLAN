using UnityEngine;

public class PipeScoring___MK1 : MonoBehaviour
{
    //Component 
    public BoxCollider2D _theMiddlePipeHitBox;









    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision + "Entered Pipe Hitbox");
        // Directly call the static method from the Score___MK1 class to update the score
        Score___MK1.UpdateScore(1); // Increment the score by 1
    }



   
}
    