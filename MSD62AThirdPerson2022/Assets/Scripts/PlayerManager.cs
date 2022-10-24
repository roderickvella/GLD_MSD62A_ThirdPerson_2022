using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane1")
            GameManager.Instance.OnChangeGameState(GameManager.GameState.AreaA);
        else if (collision.gameObject.name == "Plane2")
            GameManager.Instance.OnChangeGameState(GameManager.GameState.AreaB);
    }
}
