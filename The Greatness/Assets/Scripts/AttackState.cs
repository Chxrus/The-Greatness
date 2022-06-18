using UnityEngine;

public class AttackState : State
{
    private Military _military;
    private GameObject _target;

    public AttackState(Military military, GameObject target)
    {
        _military = military;
        _target = target;
    }

    public override void Enter()
    {
        base.Enter();
        _military.isMoving = true;
    }

    public override void Exit()
    {
        base.Exit();
        _military.isMoving = false;
    }

    public override void Update()
    {
        base.Update();
        Attacking();
    }

    private void Attacking()
    {
        _military.AttackColor();

        if (_target == null)
        {
            _military.isMoving = false;
            _military.ResetState();
        }
        else
        {
            _military.transform.position = Vector3.MoveTowards(_military.transform.position, _target.transform.position, _military.Speed * Time.deltaTime);
            if (_military.transform.position == _target.transform.position)
            {
                if (_target.tag == "Base")
                {
                    _target.GetComponent<Base>().TakeDamage(1);
                    _military.Destroy();
                }
                else
                    _target.GetComponent<Military>().TakeDamage(Random.Range(_military.MinDamage, _military.MaxDamage));
            }
        }
    }
}
