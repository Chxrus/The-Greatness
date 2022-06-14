﻿using UnityEngine;

public class AttackState : State
{
    private Military _military;

    public AttackState(Military military)
    {
        _military = military;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        Attacking();
    }

    private void Attacking()
    {
        _military.AttackColor();

        if (_military.Enemy != null)
        {
            Vector3 target = _military.Enemy.transform.position;
            _military.transform.up = target - _military.transform.position;

            _military.transform.position = Vector3.MoveTowards(_military.transform.position, target, _military.Speed * Time.deltaTime);

            if (_military.transform.position == _military.Enemy.transform.position)
            {
                if (_military.Enemy.tag == "Base")
                    _military.Enemy.GetComponent<Base>().TakeDamage(1);
                else
                    _military.Enemy.GetComponent<Military>().TakeDamage(Random.Range(_military.MinDamage, _military.MaxDamage));
            }
        }
    }

}
