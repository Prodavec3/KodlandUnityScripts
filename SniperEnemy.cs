using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEnemy : Enemy
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject rifleStart;

    enum Firing { Wait, Prepare, Shoot};
    Firing fire = Firing.Wait;

    float timer = 0;
    float cooldown = 3;
    float moveTimer = 0;
    float moveCooldown = 5;
    float area = 25;
    public override void Move()
    {
        if (fire == Firing.Wait)
        {
            GetComponent<CharacterController>().Move(transform.forward * Time.deltaTime);
            moveTimer += Time.deltaTime;
            if (moveTimer > moveCooldown)
            {
                transform.Rotate(new Vector3(0, 90, 0));
                moveTimer = 0;
            }
        }
    }
    public override void Attack()
    {
        switch (fire)
        {
            case Firing.Wait:
                if (Vector3.Distance(transform.position, player.transform.position) < area)
                {
                    fire = Firing.Prepare;
                }
                break;
            case Firing.Prepare:
                timer += Time.deltaTime;
                transform.LookAt(player.transform);
                if (timer > cooldown)
                {
                    fire = Firing.Shoot;
                }
                break;
            case Firing.Shoot:
                timer = 0;
                GameObject buf = Instantiate(bullet);
                buf.transform.position = rifleStart.transform.position;
                buf.transform.rotation = transform.rotation;
                buf.transform.Rotate(new Vector3(90, 0, 0));
                buf.GetComponent<Bullet>().setDirection(transform.forward);
                buf.GetComponent<Bullet>().MakeSniper();
                fire = Firing.Wait;
                break;
        }
    }
}
