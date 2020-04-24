namespace DeadmanRace
{
    public sealed class WeaponController : BaseController
    {
        private Weapon _weapon;
        
        public override void On(params IModel[] weapon)
        {
            
            //if (IsActive) return;
            base.On(weapon[0]);
            _weapon = weapon[0] as Weapon;
            
            if (_weapon == null) return;
            _weapon.IsVisible = true;


            //UiInterface.WeaponUiText.SetActive(true);
            //UiInterface.WeaponUiText.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);
        }

        public override void Off()
        {
            if (!IsActive) return;
            base.Off();
            _weapon.IsVisible = false;
            _weapon = null;
            //UiInterface.WeaponUiText.SetActive(false);
        }

        public void ReloadClip()
        {
            if (_weapon == null) return;
            _weapon.ReloadClip();
            //UiInterface.WeaponUiText.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);
        }

        public void Fire()
        {
            if (_weapon == null) return;
            _weapon.Fire();
            //UiInterface.WeaponUiText.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);
        }
        

    }
}
