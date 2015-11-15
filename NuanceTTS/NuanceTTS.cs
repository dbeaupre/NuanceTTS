using System;
using System.Net;

using Xamarin.Forms;

//using NAudio.Wave;

using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace NuanceTTS
{
	public class App : Application
	{
		



		public App ()
		{
			// The root page of your application
			MainPage = new TTSPage();



		}

		public class TTSPage : ContentPage {
			
			private string _sampleText = "Sherbrooke Street (officially Rue Sherbrooke) is a major east-west artery and at 31.3 kilometres in length, is the second longest street on the Island of Montreal. The street begins in the town of Montreal West and ends on the extreme tip of the island in Pointe-aux-Trembles, intersecting Gouin Boulevard and joining up with Notre-Dame Street. East of Cavendish Boulevard this road is part of Quebec Route 138. The street is divided into two portions. Sherbrooke Street East is located east of Saint Laurent Boulevard and Sherbrooke Street West is located west. Sherbrooke Street West is home to many historic mansions that comprised its exclusive Golden Square Mile district, including the now-demolished Van Horne Mansion, the imposing Beaux-Arts style Montreal Masonic Memorial Temple as well as several historic properties incorporated into Maison Alcan, the world headquarters for Alcan.";

			private string _voice = "Samantha";
			private string _url = @"https://tts.nuancemobility.net/NMDPTTSCmdServlet/tts";
			  
			private string _appId = @"NMDPTRIAL_dominic_beaupre_gmail_com20150825190219";
			private string _appKey = @"4638455ad3220bf41de0fdc999d6d70b9fda4e912eb5e2baaec3fa72ad0369f33bae4e0ed05903ed3900b7d3d68ede75682c0696e1e8518fab4b01584e6a4c89";

			private string _completeURL
			{
				get {
					return string.Format("{0}?appId={1}&appKey={2}&id={3}&voice={4}",
						_url, _appId, _appKey, Guid.NewGuid().ToString(), _voice);
				}
			}

			public TTSPage() {
				

				var stack = new StackLayout { Spacing = 0 };
				var btnPlay = new Button ()
				{
					Text = "Play"
				};
			
				stack.Children.Add(btnPlay);

				Content = stack;


				btnPlay.Clicked += (sender, e) => {

					DependencyService.Get<IStream>().PlayStream(_completeURL, _sampleText);

				};
			}



		}
		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

