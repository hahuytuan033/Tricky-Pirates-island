using UnityEngine;

public class InstantDeath : MonoBehaviour
{
   private void OnCollisionEnter2D (Collision2D other)
   {
       var player = other.collider.GetComponent<PlayerManager>();
       if (player != null)
       {
           player.Die();
       }
   }
    
}
