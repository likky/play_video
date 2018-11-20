using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;
using Android.OS;

namespace PlayVideo
{
    [Activity (Label = "PlayVideo", MainLauncher = true)]
    public class Activity1 : Activity, MediaPlayer.IOnCompletionListener
    {


        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
   
            var videoView = FindViewById<VideoView> (Resource.Id.SampleVideoView);
   
            var uri = Android.Net.Uri.Parse ("http://ia600507.us.archive.org/25/items/Cartoontheater1930sAnd1950s1/PigsInAPolka1943.mp4");
            
            videoView.SetVideoURI (uri);
            //本地播放
            //videoView.SetVideoPath(path);
            videoView.SetMediaController(new MediaController(this));
            videoView.SetOnCompletionListener(this);
			videoView.Visibility = ViewStates.Visible;
            //开始播放视频
            videoView.Start ();   
        }

        public void OnCompletion(MediaPlayer mp)
        {
            Toast.MakeText(this, "播放完成了", ToastLength.Short).Show();
            mp.Start();
            mp.Looping = true;
        }
    }
}


