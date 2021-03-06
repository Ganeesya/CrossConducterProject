﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrossConducter
{
	public partial class PluginConfigs : Form
	{
		public PluginConfigs( string title ,bool checkflg)
		{
			InitializeComponent();
			this.Text = title;
			this.listView1.CheckBoxes = checkflg;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count == 0)
				return;

			if (listView1.SelectedItems[0] != null)
			{
				((CCPluginInterface)listView1.SelectedItems[0].Tag).openConfig();
			}
		}

		public void addLists(List<CCPluginInterface> list)
		{
			foreach(CCPluginInterface e in list)
			{
				ListViewItem add = new ListViewItem(e.getPluginName());
				add.Tag = e;
				add.Checked = true;
				listView1.Items.Add(add);
			}
		}

		private void listView1_DoubleClick(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count == 0)
				return;

			if (listView1.SelectedItems[0] != null)
			{
				((CCPluginInterface)listView1.SelectedItems[0].Tag).openConfig();
			}
		}

		private void TaskConfigs_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			Hide();
		}

		private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			((CCInputInterface)(e.Item.Tag)).Enable(e.Item.Checked);
		}
	}
}
