using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    public Animator animator;
    public GameObject[] fireEffects;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "fireboy")
        {
            animator.Play("TreeAnim");
            foreach (GameObject fireEffect in fireEffects)
            {
                fireEffect.SetActive(true);
            }
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(8);
        gameObject.SetActive(false);
    }
}
