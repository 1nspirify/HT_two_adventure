using UnityEngine;

public class CollectabeItem : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private ParticleSystem _fxEffect;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        {
            _fxEffect.transform.parent = null;
            _fxEffect.Play();
            
            _gameManager.AddCoin();
            gameObject.SetActive(false);
        }
    }
}