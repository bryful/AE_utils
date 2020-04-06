using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AE_Util_skelton
{
	public class SelectFolderEventArgs : EventArgs
	{
		public string FullPath;
	}

	public class DriveBrowser : TreeView
	{
		public delegate void SelectFolderHandler(object sender, SelectFolderEventArgs e);
    	public event SelectFolderHandler SelectFolder;

		protected virtual void OnSelectFolder(SelectFolderEventArgs e)
		{
			if (SelectFolder != null)
			{
				SelectFolder(this, e);
			}
		}
		private string m_Current = "";
		public string Current
		{
			get
			{
				return m_Current;
			}
		}
		public DriveBrowser()
		{
			foreach (String drive in Environment.GetLogicalDrives())
				{
					// 新規ノード作成
					// プラスボタンを表示するため空のノードを追加しておく
					TreeNode node = new TreeNode(drive);
					node.Nodes.Add(new TreeNode());
					this.Nodes.Add(node);
				}
			this.BeforeExpand += DriveBrowser_BeforeExpand;
			this.BeforeSelect += DriveBrowser_BeforeSelect;
		}

		private void DriveBrowser_BeforeSelect(object sender, TreeViewCancelEventArgs e)
		{
			TreeNode node = e.Node;
			SelectFolderEventArgs ee = new SelectFolderEventArgs();
			m_Current = node.FullPath;
			ee.FullPath = node.FullPath;
			OnSelectFolder(ee);
		}

		private void DriveBrowser_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			TreeNode node = e.Node;
			String path = node.FullPath;
			node.Nodes.Clear();
    
			try
			{
				DirectoryInfo dirList = new DirectoryInfo(path);
				foreach (DirectoryInfo di in dirList.GetDirectories())
				{
					TreeNode child = new TreeNode(di.Name);
					child.Nodes.Add(new TreeNode());
					node.Nodes.Add(child);
				}
			}
			catch (IOException ie)
			{
				MessageBox.Show(ie.Message, "選択エラー");
			}
		}

		protected override void InitLayout()
		{
		}
		
	}
}
