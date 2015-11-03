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
			
			/*private string SampleText = @"Microsoft Corporation /ˈmaɪkrɵsɒːft/[5] (commonly referred to as Microsoft) is an American multinational technology company headquartered in Redmond, Washington, that develops, manufactures, licenses, supports and sells computer software, consumer electronics and personal computers and services. Its best known software products are the Microsoft Windows line of operating systems, Microsoft Office office suite, and Internet Explorer and Edge web browsers. Its flagship hardware products are the Xbox game consoles and the Microsoft Surface tablet lineup. It is the world's largest software maker measured by revenues.[6] It is also one of the world's most valuable companies.[7]
 
										Microsoft was founded by Paul Allen and Bill Gates on April 4, 1975, to develop and sell BASIC interpreters for Altair 8800. It rose to dominate the personal computer operating system market with MS-DOS in the mid-1980s, followed by Microsoft Windows. The company's 1986 initial public offering, and subsequent rise in its share price, created three billionaires and an estimated 12,000 millionaires from Microsoft employees. Since the 1990s, it has increasingly diversified from the operating system market and has made a number of corporate acquisitions. In May 2011, Microsoft acquired Skype Technologies for $8.5 billion in its largest acquisition to date.[8]
										 
										As of 2015, Microsoft is market dominant in both the IBM PC-compatible operating system (while it lost the majority of the overall operating system market to Android) and office software suite markets (the latter with Microsoft Office). The company also produces a wide range of other software for desktops and servers, and is active in areas including Internet search (with Bing), the video game industry (with the Xbox, Xbox 360 and Xbox One consoles), the digital services market (through MSN), and mobile phones (via the operating systems of Nokia's former phones[9] and Windows Phone OS). In June 2012, Microsoft entered the personal computer production market for the first time, with the launch of the Microsoft Surface, a line of tablet computers.
										 
										With the acquisition of Nokia's devices and services division to form Microsoft Mobile Oy, the company re-entered the smartphone hardware market, after its previous attempt, Microsoft Kin, which resulted from their acquisition of Danger Inc.[10]
										 
										Microsoft is a portmanteau of the words microcomputer and software.[11]";
		
			private string Codec = @"audio/x-wav"; 
			*/

			private string Voice = "Samantha";
			private string URL = @"https://tts.nuancemobility.net/NMDPTTSCmdServlet/tts";
			  
			private string AppId = @"NMDPTRIAL_dominic_beaupre_gmail_com20150825190219";
			private string AppKey = @"4638455ad3220bf41de0fdc999d6d70b9fda4e912eb5e2baaec3fa72ad0369f33bae4e0ed05903ed3900b7d3d68ede75682c0696e1e8518fab4b01584e6a4c89";

			private string _completeURL
			{
				get {
					return string.Format("{0}?appId={1}&appKey={2}&id={3}&voice={4}",
						URL, AppId, AppKey, Guid.NewGuid().ToString(), Voice);
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

					DependencyService.Get<IStream>().PlayStream(_completeURL);

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

