﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_AnimationEvent : MonoBehaviour
{
    private Spider spider;

    private void Start()
    {
        spider = transform.parent.GetComponent<Spider>();
    }

    public void Fire()
    {
        spider.Attack();
    }
}
