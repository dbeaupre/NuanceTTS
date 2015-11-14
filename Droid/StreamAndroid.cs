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

		public void PlayStream(string url, string text)
		{
			
				
			new System.Threading.Thread (delegate (object o) {
				
				HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
				req.Method = "POST";
				req.KeepAlive = false;
				req.Accept = "audio/x-wav;codec=pcm;bit=16;rate=16000";
				//req.Accept = "audio/x-wav";
				req.ContentType = "text/plain";


				var streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
				streamOut.Write (text);
				streamOut.Close ();


				using (var stream = req.GetResponse().GetResponseStream())
				{
					byte[] buffer = new byte[65536]; // 64KB chunks
					int read;
					while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
					{
						var pos = ms.Position;
						ms.Position = ms.Length;
						ms.Write(buffer, 0, read);
						ms.Position = pos;
					}
				}

			}).Start ();

			while (ms.Length < 65536) {
				System.Threading.Thread.Sleep (1000);
			}

			var br = new BinaryReader (ms);
			//ms.Position = 0;
			PlayAudioTrack(br.ReadBytes((int)ms.Length));

				
		}

		void PlayAudioTrack(byte[] audioBuffer)
		{
			AudioTrack audioTrack = null;

			audioTrack = new AudioTrack(
				Android.Media.Stream.Music,
				8000,
				ChannelOut.Stereo,
				Android.Media.Encoding.Pcm16bit,
				audioBuffer.Length,
				AudioTrackMode.Stream);
			
			audioTrack.Write(audioBuffer, 0, audioBuffer.Length);
			audioTrack.Play();


		}
	}
}

