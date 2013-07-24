using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EpicMorg.Net;

namespace _2ch_vk_wiper {
	public partial class Form1 : Form {
		bool is_wiping = false;
		public Form1() {
			InitializeComponent();
		}

		private void label2_Click( object sender, EventArgs e ) {

		}

		private void button1_Click( object sender, EventArgs e ) {
			if (is_wiping)
			{
				btn_wipe.Text = "Завайпать";
				is_wiping = false;
			}
			else
			{
				is_wiping = true;
				btn_wipe.Text = "Горшочек, не вари!";
				bw_wiper.RunWorkerAsync();
			}
		}

		private void bw_wiper_DoWork( object sender, DoWorkEventArgs e )
		{
			int count = 0;
			int delay=0;
			bool noproxy=false;
			string __ProxyFile=null, __AccFile=null, page=null, text=null;
			this.Invoke((Action) (() =>
				{
					__ProxyFile = txt_proxies.Text;
					__AccFile = txt_accounts.Text;
					page = txt_url.Text;
					text = txt_wipe_text.Text;
					delay = Convert.ToInt32(numericUpDown1.Value);
					noproxy = checkBox1.Checked;
				}));
			WebProxy[] __Proxies = noproxy?new WebProxy[]{null}: File.ReadAllLines(__ProxyFile).Select(a => new WebProxy(a)).ToArray();
			string[][] __Accounts = File.ReadAllLines(__AccFile).Select(a => a.Split(":".ToCharArray(), 2)).ToArray();
			while (is_wiping) {
				var __Attackers = __Accounts.SelectMany( b => __Proxies.Select( a => new Attacker( b[ 0 ], b[ 1 ], a ) ) ).ToArray();
				foreach (var a in __Attackers)
				{
					if ( !is_wiping )
						return;
					a.Send(page, text, 1);
					Thread.Sleep(delay);
					this.Invoke((Action) (() =>
						{
							lbl_count.Text = (++count).ToString();
						}));
				}
			}
		}
	}

	internal class Attacker
	{
		private static Random r = new Random();
		private static int tom = 15000;
		internal WebProxy p;
		internal CookieContainer c;
		private static Regex Hash_regex = new Regex("\"post_hash\":\"(?<hash>[0-9a-f]+)\"", RegexOptions.Compiled);
		private static Regex PageRegex = new Regex( "http://vk.com/wall-(?<page>[0-9]+_[0-9]+)", RegexOptions.Compiled );
		private static string post = "Message={0}&act=post&al=1&from=wkview&hash={1}&reply_to=-{2}&reply_to_msg=&reply_to_user=0&start_id=";

		private static string post_url = "http://vk.com/al_wall.php",
		                      vkdomain = "http://vk.com";
		public Attacker(string login, string pass, WebProxy _p)
		{
			this.p = _p;
			c = new CookieContainer();
			c.Add( DoLoginVk( login, pass ));
			
		}
		public void Send(string page, string text, int count)
		{
			try
			{
				string _page_s = FetchPage(page);
				string hash = Hash_regex.Match(_page_s).Groups["hash"].Value;
				page = PageRegex.Match(page).Groups["page"].Value;
				for (int i = 0; i < count; i++)
				{
					PostShit(page, hash, text+r.Next().ToString());
				}
			}
			catch
			{
			}
		}

		private void PostShit( string page, string hash, string text )
		{
			try
			{
				var __Data = Encoding.ASCII.GetBytes(string.Format(post, text, hash, page));
				var __Request = ( HttpWebRequest ) WebRequest.Create( post_url );
				__Request.Method = "POST";
				__Request.ProtocolVersion = System.Net.HttpVersion.Version11;
				__Request.Headers.Add( "Accept-Charset: UTF-8,*;q=0.5" );
				__Request.Accept = "*/*";
				__Request.Headers.Add( "Accept-Language: en-US,en;q=0.8" );
				__Request.Timeout = tom;
				__Request.Proxy = p;
				__Request.UserAgent = "Opera/9.80 (Windows NT 6.1; U; ru) Presto/2.7.62 Version/11.00";
				__Request.Headers.Add( "Origin: http://vk.com" );
				__Request.Referer = "http://vk.com/wall-" + page;
				__Request.Headers.Add("X-Requested-With:XMLHttpRequest");
				__Request.ContentType = "application/x-www-form-urlencoded";
				__Request.CookieContainer = c;
				Stream stream = __Request.GetRequestStream();
				stream.Write(__Data, 0, __Data.Length);
				stream.Close();
				var z = (HttpWebResponse) __Request.GetResponse();
				var xx = new StreamReader(z.GetResponseStream()).ReadToEnd();
			}
			catch
			{
			}
		}
		CookieCollection DoLoginVk( string _Email, string _Password ) {
			var auth_url = "http://m.vk.com/login?fast=1&hash=&s=0&to=";
			try {
				#region Send password
				_Email = _Email.Replace( "@", "%40" );
				string __GetHash = AdvancedWebClient.DownloadString( auth_url );
				string __Posturl = new Regex( "https:\\/\\/login\\.vk.com\\/.*\"" ).Match( __GetHash ).ToString();
				__Posturl = __Posturl.Substring( 0, __Posturl.Length - 1 );
				byte[] __Data = new System.Text.ASCIIEncoding().GetBytes( "email=" + _Email + "&pass=" + _Password );
				ServicePointManager.ServerCertificateValidationCallback += ( a, b, c, d ) => true;
				var request = ( HttpWebRequest ) WebRequest.Create( __Posturl );
				#region Headers
				request.Proxy = p;
				request.UserAgent = "Opera/9.80 (Windows NT 6.1; U; ru) Presto/2.7.62 Version/11.00";
				request.Method = "POST";
				request.Referer = auth_url;
				request.ContentType = "application/x-www-form-urlencoded";
				request.ContentLength = __Data.Length;
				request.CookieContainer = new CookieContainer();
				request.CookieContainer.Add( new Cookie( "remixlang", "0", "/", "login.vk.com" ) );
				request.CookieContainer.Add( new Cookie( "remixchk", "5", "/", "login.vk.com" ) );

				request.MaximumAutomaticRedirections = 1;
				#endregion
				Stream stream = request.GetRequestStream();
				stream.Write( __Data, 0, __Data.Length );
				stream.Close();
				//stream.Dispose();
				var z = ( HttpWebResponse ) request.GetResponse();
				var xx = new StreamReader( z.GetResponseStream() ).ReadToEnd();
				#endregion
			}
			catch ( WebException Ex ) {
				#region Get cookies from valid response
				if ( Ex.Response != null ) {
					var cook = ( ( HttpWebResponse ) Ex.Response ).Cookies;
					var __Cookie = cook["remixsid"];
					if ( __Cookie != null && (cook.Count > 0 && __Cookie.Value != "deleted") )
						return cook;
					else throw;
				}
				#endregion
				else throw;
			}
			catch ( Exception ex ) {
				return null;
			}
			return null;
		}		
		string FetchPage(string url)
		{
			try
			{
				var __Request = (HttpWebRequest) WebRequest.Create(url);
				__Request.Timeout = tom;
				__Request.Proxy = p;
				__Request.UserAgent = "Opera/9.80 (Windows NT 6.1; U; ru) Presto/2.7.62 Version/11.00";
				__Request.Referer = vkdomain;
				__Request.CookieContainer = c;
				var z = ( HttpWebResponse ) __Request.GetResponse();
				return new StreamReader(z.GetResponseStream()).ReadToEnd();
			}
			catch
			{
				return "";
			}
		}
	}
}
