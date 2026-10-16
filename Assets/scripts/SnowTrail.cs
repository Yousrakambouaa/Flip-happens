using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowTrail ;
    
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        int IndexLayer = LayerMask.NameToLayer("Floor");
        if(collision.gameObject.layer == IndexLayer)
            snowTrail.Play();

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        int IndexLayer = LayerMask.NameToLayer("Floor");
        if(collision.gameObject.layer == IndexLayer)
            snowTrail.Stop();
    }
}
