using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{
    private bool _canPourCoffee = true;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _coffeePourSound;
    [SerializeField] private GameObject _coffeePrefab;
    [SerializeField] private GameObject _coffeeSpawnPos;
    [SerializeField] private Button _button;

    public void PourCoffee()
    {
        if(_canPourCoffee == true)
            StartCoroutine(PourCoffeeRoutine());
    }

    private IEnumerator PourCoffeeRoutine()
    {
        int coffeeSpawned = 0;
        _canPourCoffee = false;
        yield return new WaitForSeconds(1);
        _audioSource.PlayOneShot(_coffeePourSound);

        while(coffeeSpawned != 5)
        {
            coffeeSpawned++;
            Instantiate(_coffeePrefab, _coffeeSpawnPos.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }
        yield return new WaitForSeconds(1f);
        _canPourCoffee = true;
        _button.PlayFlashAnimation();
    }
}
