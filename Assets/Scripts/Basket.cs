using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private BoxCollider _upperCollider;
    [SerializeField] private GameObject _collectText;
    [SerializeField] private Transform _collectTextPoint;

    public IEnumerator DisableUpperBasketCollider(PickUp currentFruit)
    {
        _upperCollider.enabled = false;
        yield return new WaitForSeconds(1f);
        _upperCollider.enabled = true;
        Rigidbody currentFruitRb = currentFruit.GetFruitRigidbody();
        Collider currentFruitCollider = currentFruit.GetFruitCollider();
        currentFruit.transform.SetParent(transform, true);
        Destroy(currentFruitRb);
        GameManager.Instance.CollectFruit(currentFruit);
        if(GameManager.Instance.CurrentState == GameManager.GameState.Play)
            Instantiate(_collectText, _collectTextPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(currentFruitCollider);
    }
}
