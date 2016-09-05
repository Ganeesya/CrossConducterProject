﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace VoiceroidConfigForm
{
	public partial class VoiceroidConfigForm : Form
	{
		public VoiroConfig config;

		private string configfname = "Out_Aoi.config";

		public VoiceroidConfigForm()
		{
			InitializeComponent();
			config = VoiroConfig.Load(configfname);
			textBox_main.Text = config.mainclassname;
			textBox_rich.Text = config.richtextclassname;
			textBox_butten.Text = config.buttenclassname;
			textBox_title.Text = config.titlename;
		}

		private void button_ok_Click(object sender, EventArgs e)
		{
			config.mainclassname = textBox_main.Text;
			config.richtextclassname = textBox_rich.Text;
			config.buttenclassname = textBox_butten.Text;
			config.titlename = textBox_title.Text;
			Hide();
		}

		private void button_cansel_Click(object sender, EventArgs e)
		{
			Hide();
		}

		private void VoiceroidConfigForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
		}
	}

	[Serializable]
	public class VoiroConfig
	{
		public string mainclassname = "WindowsForms10.Window.8.app.0.378734a";

		public string richtextclassname = "WindowsForms10.RichEdit20W.app.0.378734a";

		public string buttenclassname = "WindowsForms10.BUTTON.app.0.378734a";

		public string titlename = "VOICEROID＋ 琴葉葵";

		public static VoiroConfig Load(string path)
		{
			if (!File.Exists(path))
			{
				return new VoiroConfig();
			}

			using (FileStream fs = new FileStream(path, FileMode.Open))
			{
				return Load(fs);
			}
		}

		public static VoiroConfig Load(Stream stream)
		{
			VoiroConfig configData = null;
			try
			{
				System.Xml.Serialization.XmlSerializer xs = new XmlSerializer(typeof(VoiroConfig));
				configData = xs.Deserialize(stream) as VoiroConfig;
			}
			catch { }

			return configData != null ? configData : new VoiroConfig();
		}

		public void Save(Stream stream)
		{
			try
			{
				XmlSerializer xs = new XmlSerializer(this.GetType());
				xs.Serialize(stream, this);
			}
			catch
			{ }
		}

		public void Save(string path)
		{
			try
			{
				using (FileStream fs = new FileStream(path, FileMode.Create))
				{
					Save(fs);
				}
			}
			catch { }
		}
	}
}
