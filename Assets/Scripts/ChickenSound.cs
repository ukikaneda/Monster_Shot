using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSound : MonoBehaviour
{
 void OnCollisionEnter(Collision col) {
      if (col.gameObject.name == "Zombie(Clone)") {
            GetComponent<AudioSource>().Play();
        }
      }

}
