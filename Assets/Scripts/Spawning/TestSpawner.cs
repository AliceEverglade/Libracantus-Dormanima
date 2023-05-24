using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    [SerializeField] private List<CreatureData> characters;
    [SerializeField] private float range;
    // Start is called before the first frame update
    void Start()
    {
        foreach(CreatureData character in characters)
        {
            Vector3 pos = new Vector3(transform.position.x + Random.Range(-range, range), transform.position.y + 2, transform.position.z + Random.Range(-range, range));
            character.Spawn(pos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
