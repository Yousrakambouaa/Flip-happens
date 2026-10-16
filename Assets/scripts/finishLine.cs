using UnityEngine;
using UnityEngine.SceneManagement;

public class finishLine : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem finishParticles;
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");
        if(collision.gameObject.layer == layerIndex)
        {
            Debug.Log("You won!");
            finishParticles.Play();
            Invoke("ReloadScene", delay);
            
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
