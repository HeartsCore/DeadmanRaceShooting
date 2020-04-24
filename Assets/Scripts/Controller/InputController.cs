using UnityEngine;
using DeadmanRace.Components;


namespace DeadmanRace
{
    public sealed class InputController :  IExecuteController
    {
        #region PrivateData
        
        private readonly GameContext _context;
        private KeyCode _cancel = KeyCode.Escape;
        private KeyCode _reloadClip = KeyCode.R;
        private int _mouseButton = (int)MouseButton.LeftButton;
                
        #endregion

        #region ClassLifeCycles

        public InputController(GameContext context, Services services)
        {
            _context = context;
        }

        #endregion

        #region IExecuteController

        Equipment equipment;
        bool InCar = false;

        public void Execute()
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");
            var j = Input.GetAxis("Jump");
            
            if (!InCar) _context.MyCharacter.Walk(h, v);
            else
            {
                _context.PlayerCar.Drive(h, v, v, j);
                _context.MyCharacter.Transform.position = _context.PlayerCar.CarTransform.position;
            }

            if (InCar)
            {
                _context.MyCharacter.Transform.gameObject.SetActive(!InCar);
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                if (equipment == null) equipment = UnityEngine.Object.FindObjectOfType<Equipment>();

                equipment.gameObject.SetActive(!equipment.gameObject.activeSelf);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if(Physics.Raycast(_context.MyCharacter.Transform.position, _context.MyCharacter.Transform.forward, 3f))
                {
                    InCar = !InCar;
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectWithKeyWeapon(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectWithKeyWeapon(1);
            }

            if (Input.GetKeyDown(_cancel))
            {
                _context.WeaponController.Off();
            }

            if (Input.GetKeyDown(_reloadClip))
            {
                _context.WeaponController.ReloadClip();
            }

            if (Input.GetMouseButton(_mouseButton))
            {
                _context.WeaponController.Fire();
            }
                       
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                MouseScroll(MouseScrollWheel.Up);


            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                MouseScroll(MouseScrollWheel.Down);

            }
            
        }
        private void SelectWithKeyWeapon(int i)
        {
            _context.WeaponController.Off();
            var tempWeapon = _context.Weapons[i];
            if (tempWeapon != null)
            {
                _context.WeaponController.On(tempWeapon);
            }
        }
        private void MouseScroll(MouseScrollWheel value)
        {
            var tempWeapon = _context.SelectWeapon(value);
            SelectWeapon(tempWeapon);
        }
        private void SelectWeapon(Weapon weapon)
        {
            _context.WeaponController.Off();
            if (weapon != null)
            {
                _context.WeaponController.On(weapon);
            }
        }
        
        
        #endregion
    }
}
