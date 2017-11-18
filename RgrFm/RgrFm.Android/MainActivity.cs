using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Content;
using RgrFm.Droid.Common;
using RgrFm.Droid.Services;


namespace RgrFm.Droid
{
    [Activity(Label = "RgrFm.Android", MainLauncher = true, Icon = "@drawable/icon", ConfigurationChanges = ConfigChanges.KeyboardHidden | ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class MainActivity : Activity, IServiceConnection, View.IOnClickListener
    {
        private bool _isBound;
        private MusicPlayerService _musicPlayerService;

        private readonly MusicPlayerBroadCastReceiver _broadcastReceiver = new MusicPlayerBroadCastReceiver();

        private ImageButton _btnPlay;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _btnPlay = (ImageButton)FindViewById(Resource.Id.playButton);
            _btnPlay.SetOnClickListener(this);

            DoBindService();
            InitServiceListener();

            if (_musicPlayerService != null)
            {
                if (_musicPlayerService.MediaPlayer == null)
                {
                    _btnPlay.SetImageResource(Resource.Drawable.ic_play_circle_filled_white_48dp);
                }
                else if (_musicPlayerService.MediaPlayer != null)
                {
                    _btnPlay.SetImageResource(Resource.Drawable.ic_pause_circle_outline_white_48dp);
                }
            }
        }


        protected override void OnDestroy()
        {
            base.OnDestroy();

            _musicPlayerService?.Stop();

            DoUnbindService();
        }

        private void InitServiceListener()
        {
            var intentFilter = new IntentFilter();
            intentFilter.AddAction(MusicPlayerService.PlayerError);
            LocalBroadcastManager.GetInstance(this).RegisterReceiver(_broadcastReceiver, intentFilter);

        }

        private void DoBindService()
        {
            var intent = new Intent(ApplicationContext, typeof(MusicPlayerService));
            BindService(intent, this, Bind.AutoCreate);
            _isBound = true;
        }

        private void DoUnbindService()
        {
            if (_isBound)
            {
                UnbindService(this);
                _isBound = false;
            }
        }


        public void OnServiceConnected(ComponentName name, IBinder service)
        {
            _musicPlayerService = ((MusicPlayerService.MusicPlayerServiceBinder)service).GetService();
            Console.WriteLine(_musicPlayerService.ToString());
        }

        public void OnServiceDisconnected(ComponentName name)
        {
            _musicPlayerService = null;
        }

        public void OnClick(View v)
        {

            if (v.Equals(_btnPlay))
            {
                if (_musicPlayerService.MediaPlayer == null && Connectivity.IsConnected(ApplicationContext))
                {
                    _btnPlay.SetImageResource(Resource.Drawable.ic_pause_circle_outline_white_48dp);
                    _musicPlayerService.Play();
                }
                else if (_musicPlayerService.MediaPlayer != null)
                {
                    _btnPlay.SetImageResource(Resource.Drawable.ic_play_circle_outline_white_48dp);
                    _musicPlayerService.Stop();
                }
            }
        }
    }

}


