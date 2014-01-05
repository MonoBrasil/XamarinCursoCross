using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Media;

namespace Dia1Ex10
{
	[Activity (Label = "Dia1-Ex10", MainLauncher = true)]
	public class MainActivity : Activity, MediaPlayer.IOnPreparedListener, MediaPlayer.IOnBufferingUpdateListener,
	MediaPlayer.IOnCompletionListener, MediaPlayer.IOnVideoSizeChangedListener, MediaPlayer.IOnSeekCompleteListener,
	View.IOnTouchListener, ISurfaceHolderCallback
	{
		VideoView vv;
		ProgressBar pb;
		MediaPlayer mp;
		ISurfaceHolder holder;
		bool ready = false;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Carega o layout "main" na view principal
			SetContentView (Resource.Layout.Main);

			// Pega o botão do recurso de layout e coloca um evento nele
			Button button = FindViewById<Button> (Resource.Id.button);

			vv = FindViewById<VideoView> (Resource.Id.video_view);
			pb = FindViewById<ProgressBar> (Resource.Id.progress_bar);
			MediaController mc = new MediaController(this);
			mp = new MediaPlayer ();

			pb.SetOnTouchListener (this);

			var uri = Android.Net.Uri.Parse ("http://3gpfind.com/vid/load/Movie%20Trailer/Predators(3gpfind.com).3gp");
			vv.SetOnPreparedListener (this);
			vv.SetVideoURI(uri);
			vv.SetMediaController(mc);
			mc.SetMediaPlayer(vv);
			mc.SetAnchorView(vv);

			button.Click += delegate {
				mc.Show();
				if (!ready)
				{
					holder = vv.Holder;
					holder.SetType (SurfaceType.PushBuffers);
					holder.AddCallback(this);
					mp.SetDataSource(this, uri);
					mp.SetOnPreparedListener(this);
					mp.Prepare();
					ready = true;
				}

				mp.Start();
//				vv.Start();

				Toast.MakeText (this, "Video Started", ToastLength.Short).Show ();
			};
		}

		public void SurfaceChanged (ISurfaceHolder holder, Android.Graphics.Format format, int width, int height)
		{
			Toast.MakeText (this, "Surface Changed", ToastLength.Short).Show ();
		}

		public void SurfaceCreated (ISurfaceHolder holder)
		{
			mp.SetDisplay (holder);
			Toast.MakeText (this, "Surface Created", ToastLength.Short).Show ();
		}

		public void SurfaceDestroyed (ISurfaceHolder holder)
		{
			Toast.MakeText (this, "Surface Destroyed", ToastLength.Short).Show ();
		}

		public void OnPrepared (MediaPlayer mp)
		{
			mp.Looping = true;
			int h = mp.VideoHeight;
			int w = mp.VideoWidth;

			mp.SetOnVideoSizeChangedListener (this);
			mp.SetOnBufferingUpdateListener (this);
			mp.SetOnSeekCompleteListener (this);
			mp.SetOnCompletionListener (this);

			int time = vv.Duration;
			int time_elapsed = vv.CurrentPosition;
			pb.Progress = time_elapsed;

			var timer = new CountDown (time, 500);
			timer.Tick += (long millisUntilFinished) => {
				float a = vv.CurrentPosition;
				float b = vv.Duration;

				pb.Progress = (int)(a/b*100);
			};
			timer.Finish += () => {
				Toast.MakeText (this, "Timer Finished", ToastLength.Short).Show ();
			};

			Toast.MakeText (this, "Video Prepared", ToastLength.Short).Show ();
		}

		public void OnVideoSizeChanged (MediaPlayer mp, int width, int height)
		{
			if (width != 0 && height != 0) {
			} else {
				Toast.MakeText (this, "Video Size Changed", ToastLength.Short).Show ();
			}
		}

		public void OnBufferingUpdate (MediaPlayer mp, int percent)
		{
			pb.SecondaryProgress = percent;
		}

		public void OnSeekComplete (MediaPlayer mp)
		{
			if (mp.IsPlaying) {
				Toast.MakeText (this, "Seek Complete - Playing", ToastLength.Short).Show ();
			} else {
				Toast.MakeText (this, "Seek Complete - Stopped", ToastLength.Short).Show ();
			}
		}

		public void OnCompletion (MediaPlayer mp)
		{
			Toast.MakeText (this, "Video Completed", ToastLength.Short).Show ();
		}

		public bool OnTouch (View v, MotionEvent e)
		{
			ProgressBar pb = (ProgressBar) v;

			int newPosition = (int) (100 * e.GetX() / pb.Width);
			if (newPosition > pb.SecondaryProgress) {
				newPosition = pb.SecondaryProgress;
			}

			var pos = (int)newPosition * vv.Duration / 100;

			switch (e.Action) {
			case MotionEventActions.Down:
			case MotionEventActions.Move:
			case MotionEventActions.Up:
				pb.Progress = newPosition;
				vv.SeekTo (pos);
				Toast.MakeText (this, "Seek to " + pos + "%", ToastLength.Short).Show ();
				break;
			}
			return true;
		}
	}
}


