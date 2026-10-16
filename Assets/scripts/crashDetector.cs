using UnityEngine;
using UnityEngine.SceneManagement;

public class crashDetector : MonoBehaviour
{
    [SerializeField] float delay = 5f;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] playerController controllPlayer;
    void Start()
    {
        controllPlayer = FindAnyObjectByType<playerController>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        int  layerIndex = LayerMask.NameToLayer("Floor");
        if(collision.gameObject.layer == layerIndex)
        {
            controllPlayer.disableControlls();
            Debug.Log("LOOOOOSer!");
            crashParticles.Play();
            Invoke("ReloadScene", delay);
        }
    }
    
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    
}
