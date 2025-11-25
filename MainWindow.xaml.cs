using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Konyvtar
{
	public partial class MainWindow : Window
	{
		string fajlNev = "olvasok.txt";
		List<Olvaso> olvasok = new List<Olvaso>();

		public MainWindow()
		{
			InitializeComponent();
			BetoltOlvasok();
		}

		private void BetoltOlvasok()
		{
			if (File.Exists(fajlNev))
			{
				foreach (var sor in File.ReadAllLines(fajlNev))
				{
					var o = Olvaso.FromString(sor);
					olvasok.Add(o);
					lbOlvasok.Items.Add(o.Nev);
				}
			}
		}

		private void btnMent_Click(object sender, RoutedEventArgs e)
		{
			if (!int.TryParse(tbEletkor.Text, out int eletkor))
				return;

			string tagsag =
				rbNormal.IsChecked == true ? "Normál" :
				rbDiak.IsChecked == true ? "Diák" : "Nyugdíjas";

			var o = new Olvaso
			{
				Nev = tbNev.Text,
				Eletkor = eletkor,
				Mufaj = ((ComboBoxItem)cbMufaj.SelectedItem)?.Content.ToString() ?? "",
				Hirlevel = cbHirlevel.IsChecked == true,
				SmsErtesites = cbSms.IsChecked == true,
				Tagsag = tagsag
			};

			File.AppendAllText(fajlNev, o + Environment.NewLine);
			olvasok.Add(o);
			lbOlvasok.Items.Add(o.Nev);
			tbUzenet.Text = "Regisztráció sikeres.";

			tbNev.Clear();
			tbEletkor.Clear();
			cbMufaj.SelectedIndex = -1;
			cbHirlevel.IsChecked = false;
			cbSms.IsChecked = false;
			rbNormal.IsChecked = true;
		}
	}
}
