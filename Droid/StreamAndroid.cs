using System;
using Xamarin.Forms;
using NuanceTTS.Droid;
using Android.Media;
using System.Net;
using System.IO;


[assembly: Xamarin.Forms.Dependency (typeof (StreamAndroid))]

namespace NuanceTTS.Droid
{
	public class StreamAndroid:Java.Lang.Object, IStream 
	{
		public StreamAndroid ()
		{
			
		}
		private System.IO.Stream ms = new MemoryStream();

		public void PlayStream(string url)
		{
			
				


			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			req.Method = "POST";
			req.KeepAlive = false;
			req.Accept = "audio/x-wav;codec=pcm;bit=16;rate=16000";
			req.ContentType = "text/plain";

		
			var streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
			streamOut.Write ("Hello body!");
			streamOut.Close ();

			using (var stream = req.GetResponse().GetResponseStream())
			{
				byte[] buffer = new byte[32768]; // 32KB chunks
				int read;
				while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
				{
					var pos = ms.Position;
					ms.Position = ms.Length;
					ms.Write(buffer, 0, read);
					ms.Position = pos;
				}
			}
				
			var br = new BinaryReader (ms);

			PlayAudioTrack(br.ReadBytes((int)ms.Length));
				
		}

		void PlayAudioTrack(byte[] audioBuffer)
		{
			AudioTrack audioTrack = new AudioTrack(
				// Stream type
				Android.Media.Stream.Music,
				// Frequency
				16000,
				// Mono or stereo
				ChannelConfiguration.Stereo,
				// Audio encoding
				Android.Media.Encoding.Default,
				// Length of the audio clip.
				audioBuffer.Length,
				// Mode. Stream or static.
				AudioTrackMode.Stream);

		
			audioTrack.Play();
			audioTrack.Write(audioBuffer, 0, audioBuffer.Length);
		}
	}
}

