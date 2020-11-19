using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMoving : MonoBehaviour
{
    
    public float Speed = 5;
    
    
    private float _distancetotarget;
    private float _distanceMovedThisFrame;
    private bool HasReachedTarget;
    
    // Start is called before the first frame update
    void Start()
    {
        
        HasReachedTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (HasReachedTarget == false) //verifica se a peça foi chamada e se ela ainda n chegou
        {
            Vector3 direction = GetComponentInParent<Spot>().transform.position - transform.position;
            direction.y = 0;
            _distancetotarget = direction.magnitude;

            direction.Normalize();
            _distanceMovedThisFrame = Speed * Time.deltaTime;
            if (_distanceMovedThisFrame > _distancetotarget)
                _distanceMovedThisFrame = _distancetotarget;
            MoveCharacter(_distanceMovedThisFrame * direction);
            if (_distanceMovedThisFrame == _distancetotarget) //se ele tiver se movido o quanto faltava para chegar no alvo, ele seta o
                HasReachedTarget = true;                      //HasReachedTarget pra true e deixa de se mover


        }
    }


    public void MoveCharacter(Vector3 frameMovement)
    {
        transform.position += frameMovement;
    }
}
