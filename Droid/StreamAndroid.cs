using System;
using Xamarin.Forms;
using NuanceTTS.Droid;
using Android.Media;
using System.Net;
using System.IO;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(StreamAndroid))]

namespace NuanceTTS.Droid
{
    public class StreamAndroid : Java.Lang.Object, IStream
    {
        public StreamAndroid()
        {

        }

        private System.IO.Stream ms = new MemoryStream();
        private AudioTrack audioTrack = null;

        public async void PlayStream(string text)
        {
            var bufferSize = AudioTrack.GetMinBufferSize(16000, ChannelOut.Stereo, Encoding.Pcm16bit);

            ////new System.Threading.Thread(delegate (object o)
            ////  {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Helpers.URL.NuanceURL);

            req.Method = "POST";
            req.KeepAlive = false;
            req.Accept = "audio/x-wav;codec=pcm;bit=16;rate=16000";
            // req.Accept = "audio/x-wav";
            req.ContentType = "text/plain";

            var streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            streamOut.Write(text);
            streamOut.Close();

            audioTrack = new AudioTrack(
                Android.Media.Stream.Music,
                8000,
                ChannelOut.Stereo,
                Android.Media.Encoding.Pcm16bit,
                bufferSize,
                AudioTrackMode.Stream);

            using (var stream = req.GetResponse().GetResponseStream())
            {
                byte[] buffer = new byte[65536];
                int read;
                audioTrack.Play();
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    var pos = ms.Position;
                    ms.Position = ms.Length;
                    ms.Write(buffer, 0, read);
                    ms.Position = pos;
                }

            }

            // }).Start();


            //while (ms.Length < bufferSize * 5)
            //{
            //    System.Threading.Thread.Sleep(1000);
            //}

            var br = new BinaryReader(ms);
            await PlayAudioTrack(br.ReadBytes((int)ms.Length));

            ////ms.Position = 0;
            ////var br = new BinaryReader(ms);

            ////PlayAudioTrack(br.ReadBytes((int)ms.Length));

            audioTrack.Release();

        }

        private async Task<int> PlayAudioTrack(byte[] audioBuffer)
        {
            audioTrack.Play();
            return await audioTrack.WriteAsync(audioBuffer, 0, audioBuffer.Length);
        }
    }
}

