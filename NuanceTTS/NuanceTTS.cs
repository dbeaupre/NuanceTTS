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

            //private string _sampleText = "Sherbrooke Street (officially Rue Sherbrooke) is a major east-west artery and at 31.3 kilometres in length, is the second longest street on the Island of Montreal. The street begins in the town of Montreal West and ends on the extreme tip of the island in Pointe-aux-Trembles, intersecting Gouin Boulevard and joining up with Notre-Dame Street. East of Cavendish Boulevard this road is part of Quebec Route 138. The street is divided into two portions. Sherbrooke Street East is located east of Saint Laurent Boulevard and Sherbrooke Street West is located west. Sherbrooke Street West is home to many historic mansions that comprised its exclusive Golden Square Mile district, including the now-demolished Van Horne Mansion, the imposing Beaux-Arts style Montreal Masonic Memorial Temple as well as several historic properties incorporated into Maison Alcan, the world headquarters for Alcan.";
            private string _sampleText = @" Google Inc. est une entreprise fondée le 4 septembre 1998 dans le garage Google dans la Silicon Valley, en Californie,
                                            par Larry Page et Sergueï Brin, créateurs du moteur de recherche Google. L'entreprise s'est principalement fait connaître
                                            à travers la situation monopolistique de son moteur de recherche, concurrencé historiquement par AltaVista puis par Yahoo et Bing. 
                                            Elle a ensuite procédé à de nombreuses acquisitions et développements et détient aujourd'hui de nombreux logiciels et sites web notables
                                            parmi lesquels YouTube, le système d'exploitation pour téléphones mobiles Androïd, ainsi que d'autres services tels que Google Earth, Google Maps ou Google Play. 
                                            Google s'est donné comme mission « d'organiser l'information à l'échelle mondiale et de la rendre universellement accessible et utile. 
                                            Eric Schmidt en a été le C E O jusqu'au 4 avril 2011 et est désormais remplacé par Larry Page. 
                                            Google est devenu l'une des premières entreprises américaines et mondiales par sa valorisation boursière, quelques années après une entrée en bourse originale. 
                                            Début 2008, elle valait 176 milliards de dollars à Wall Street. 
                                            En 2014, le classement Best Global Brands d'Interbrand positionne Google comme la 2e entreprise mondiale en termes de valeur avec une valorisation de 107,43 milliards de dollars (+15 % par rapport à 2013), dépassant avec Apple pour la première fois depuis la création de ce classement en 1974 la barre des cent milliards de dollars.
                                            La société compte environ 50 000 employés.La plupart travaillent au siège mondial : le Googleplex, à Mountain View en Californie.Google est l'une des plus imposantes entreprises du marché d'Internet et fait partie, avec Apple, Facebook et Amazon.com, du « Big Four » (les « quatre gros ») des entreprises de technologie.
                                            En 2011, Google possédait un parc de plus de 900 000 serveurs, contre 400 000 en 2006, ce qui en fait le parc de serveurs le plus important au monde(2 % du nombre total de machines), avec des appareils répartis sur 32 sites.
                                            Parallèlement, le moteur de recherche Google a indexé plus de 1 000 milliards de pages web en 2008. 
                                            En octobre 2010, Google représente 6,4 % du trafic Internet mondial et affiche une croissance supérieure à celle du web.
                                            En Europe, Google aurait une part de marché de 93 % concernant les moteurs de recherche. 
                                            Observant des gains de parts de marché qui se traduisent par plus de consultations, Google mise sur des changements d'infrastructure pour améliorer sa capacité technique.
                                            Par exemple, l'infrastructure Caffeine a pour but d'augmenter la rapidité du traitement des pages web afin de les indexer plus rapidement (il aurait ainsi gagné 50 % en rapidité).
                                            Au-delà du moteur de recherche, Google offre gratuitement de nombreux logiciels et services(email, suite bureautique, vidéo, photo, blog…) et se finance par la publicité à partir de l'an 2000 avec un principe de lien sponsorisé dans les résultats de recherche et une facturation au « coût par clic » pour les annonceurs.
                                            Cependant, la situation croissante de monopole et les questions de vie privée inquiètent de plus en plus, de l'internaute occasionnel jusqu'à certaines grandes organisations.
                                            Google a également fait l'objet de plusieurs poursuites en justice, notamment pour plusieurs affaires de compatibilité de copyright et pour sa plateforme Google Books.";



			public TTSPage() {
				

				var stack = new StackLayout { Spacing = 0 };
				var btnPlay = new Button ()
				{
					Text = "Play"
				};
			
				stack.Children.Add(btnPlay);

				Content = stack;


				btnPlay.Clicked += (sender, e) => {

					DependencyService.Get<IStream>().PlayStream( _sampleText);

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

