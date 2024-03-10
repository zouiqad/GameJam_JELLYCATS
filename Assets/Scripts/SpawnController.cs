using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObject : BasicEntityCharacter
{
    private GameObject spawnGO;
    private void Update()
    {
        if (!isDead)
        {
            Instantiate(spawnGO, transform.position, Quaternion.identity);
        }
    }
}