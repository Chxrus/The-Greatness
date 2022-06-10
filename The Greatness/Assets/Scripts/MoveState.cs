using UnityEngine;

public class MoveState : State
{
    private Military _military;
    private bool _isMoving;
    private Vector3 _startPosition;
    private Vector3 _target;

    public MoveState(Military military)
    {
        _military = military;
        _startPosition = _military.transform.position;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered the moving state");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Leave the moving state");
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("In the moving state");
        Moving();
    }

    private void Moving()
    {

        _military.WalkColor();

        if (!_isMoving)
        {
            int randomHorizontal = Random.Range(-5, 5);
            int randomVertical = Random.Range(-5, 5);
            _target = new Vector3(_startPosition.x + randomHorizontal, _startPosition.y + randomVertical, 6);

            if ((_target.y > -7 && _target.y < 7) && (_target.x > -10 && _target.x < 10))
                _isMoving = true;
        }
        else
        {
            if (_military.transform.position != _target)
            {
                _military.transform.position = Vector3.MoveTowards(_military.transform.position, _target, _military.Speed * Time.deltaTime);
            }
            else
            {
                _startPosition = _military.transform.position;
                _isMoving = false;
            }
        }
    }

}
