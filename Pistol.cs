using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    // Start is called before the first frame update
    void Start()
    {
        auto = false;
        cooldown = 0;
    }
    protected override void OnShoot()
    {
        GameObject buf = Instantiate(bullet);
        buf.transform.position = rifleStart.position;
        buf.transform.rotation = transform.rotation;
        buf.GetComponent<Bullet>().setDirection(transform.forward);
    }
}
