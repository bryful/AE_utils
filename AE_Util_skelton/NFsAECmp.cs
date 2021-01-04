using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace BRY
{
	

	public class NFsAECmp : Component
	{
		private NFsAE NFsAE = new NFsAE();  

		#region Event
		public event EventHandler InstalledAFXIndexChanged;

		protected virtual void OnInstalledAFXIndexChanged(EventArgs e)
		{
			if (InstalledAFXIndexChanged != null)
			{
				InstalledAFXIndexChanged(this, e);
			}
		}
		#endregion
		public event EventHandler RunningAFXIndexChanged;

		protected virtual void OnRunningAFXIndexChanged(EventArgs e)
		{
			if (RunningAFXIndexChanged != null)
			{
				RunningAFXIndexChanged(this, e);
			}
		}


		#region installed
		public int InstalledCount
		{
			get { return NFsAE.InstalledCount; }
		}
		public string[] InstalledAFX
		{
			get
			{
				return NFsAE.InstalledAFX;
			}
		}
		#endregion


		/// <summary>
		/// インストールされているバージョンで、選ばれている文字
		/// </summary>
		public string InstalledAFXStr
		{
			get
			{
				return NFsAE.InstalledAFXStr;
			}
			set
			{
				NFsAE.InstalledAFXStr = value;
			}
		}
		/// <summary>
		/// インストールされているバージョンで選ばれているインデックス番号
		/// </summary>
		public int InstalledAFXIndex
		{
			get { return NFsAE.InstalledAFXIndex; }
			set
			{
				if (NFsAE.InstalledAFXIndex != value)
				{
					NFsAE.InstalledAFXIndex = value;
					if (m_CombInstalled != null)
					{
						if (m_CombInstalled.SelectedIndex != InstalledAFXIndex)
						{
							m_CombInstalled.SelectedIndex = InstalledAFXIndex;
						}

					}
					if (m_ListBoxInstalled != null)
					{
						if (m_ListBoxInstalled.SelectedIndex != InstalledAFXIndex)
						{
							m_ListBoxInstalled.SelectedIndex = InstalledAFXIndex;
						}

					}
					OnInstalledAFXIndexChanged(new EventArgs());
				}
			}
		}

		/// <summary>
		/// インストールされているバージョンで選ばれているものの実行ファイルのパス
		/// </summary>
		public string AfterFXPath
		{
			get
			{
				return NFsAE.AfterFXPath;
			}
		}
		/// <summary>
		/// インストールされているバージョンで選ばれているもののaerender.exeのパス
		/// </summary>
		public string AerenderPath
		{
			get
			{
				return NFsAE.AerenderPath;
			}
		}



		#region CombInstalled
		private ComboBox m_CombInstalled = null;
		public ComboBox CombTargetVersion
		{
			get { return m_CombInstalled; }
			set
			{
				if( (value==null)&&(m_CombInstalled!=null))
				{
					m_CombInstalled.Items.Clear();
					m_CombInstalled.SelectedIndexChanged -= M_CombInstalled_SelectedIndexChanged;
				}
				m_CombInstalled = value;
				if (m_CombInstalled != null)
				{
					m_CombInstalled.DropDownStyle = ComboBoxStyle.DropDownList;
					m_CombInstalled.Items.Clear();
					if (NFsAE.InstalledCount > 0)
					{
						m_CombInstalled.Items.Clear();
						m_CombInstalled.Items.AddRange(NFsAE.InstalledAFX);
						if ((NFsAE.InstalledAFXIndex >= 0) && (NFsAE.InstalledAFXIndex < m_CombInstalled.Items.Count))
						{
							m_CombInstalled.SelectedIndex = NFsAE.InstalledAFXIndex;
						}
						m_CombInstalled.SelectedIndexChanged += M_CombInstalled_SelectedIndexChanged;
					}
				}
			}
		}

		private void M_CombInstalled_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cmb = (ComboBox)sender;
			int idx = cmb.SelectedIndex;
			bool ok = ((idx >= 0) && (idx < NFsAE.InstalledCount));
			if (ok)
			{
				if (InstalledAFXIndex != idx)
				{
					InstalledAFXIndex = idx;
				}
			}
			if (m_BtnRun != null)
			{
				m_BtnRun.Enabled = ok;
			}
		}
		#endregion
		#region ListBox
		private ListBox m_ListBoxInstalled = null;
		public ListBox ListBoxInstalled
		{
			get { return m_ListBoxInstalled; }
			set
			{
				if ((value == null) && (m_ListBoxInstalled != null))
				{
					m_ListBoxInstalled.Items.Clear();
					m_ListBoxInstalled.SelectedIndexChanged -= M_ListBoxInstalled_SelectedIndexChanged;
				}
				m_ListBoxInstalled = value;
				if(m_ListBoxInstalled !=null)
				{
					m_ListBoxInstalled.Items.Clear();
					m_ListBoxInstalled.Items.AddRange(NFsAE.InstalledAFX);
					if ((NFsAE.InstalledAFXIndex >= 0) && (NFsAE.InstalledAFXIndex < m_ListBoxInstalled.Items.Count))
					{
						m_ListBoxInstalled.SelectedIndex = NFsAE.InstalledAFXIndex;
					}
					m_ListBoxInstalled.SelectedIndexChanged += M_ListBoxInstalled_SelectedIndexChanged;

				}
			}
		}

		private void M_ListBoxInstalled_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListBox lst = (ListBox)sender;
			int idx = lst.SelectedIndex;
			bool ok = ((idx >= 0) && (idx < NFsAE.InstalledCount));
			if (ok)
			{
				if (InstalledAFXIndex != idx)
				{
					InstalledAFXIndex = idx;
				}
			}
			if (m_BtnRun != null) m_BtnRun.Enabled = ok;
		}
		#endregion
		#region btnRun
		private Button m_BtnRun = null;
		public Button BtnRun
		{
			get { return m_BtnRun; }
			set
			{
				if((value == null)&&(m_BtnRun != null))
				{
					m_BtnRun.Enabled = true;
					m_BtnRun.Click -= M_BtnRun_Click;
				}
				m_BtnRun = value;
				if(m_BtnRun != null)
				{
					m_BtnRun.Enabled = (NFsAE.InstalledAFXIndex >= 0);
					m_BtnRun.Click += M_BtnRun_Click;
				}
			}
		}

		private void M_BtnRun_Click(object sender, EventArgs e)
		{
		 	Run(true);
			NFsAE.FindRunningAFX();
		}
		#endregion

		private ComboBox m_CombRunning = null;
		public ComboBox CombRunning
		{
			get { return m_CombRunning; }
			set
			{
				if ((value == null) && (m_CombRunning != null))
				{
					m_CombRunning.Items.Clear();
					m_CombRunning.SelectedIndexChanged -= M_CombRunning_SelectedIndexChanged;
				}
				m_CombRunning = value;
				if (m_CombRunning != null)
				{
					m_CombRunning.DropDownStyle = ComboBoxStyle.DropDownList;
					m_CombRunning.Items.Clear();
					if (NFsAE.RunningCount > 0)
					{
						m_CombRunning.Items.Clear();
						m_CombRunning.Items.AddRange(NFsAE.RunningAFXStr);
						if ((NFsAE.RunningAFXIndex >= 0) && (NFsAE.RunningAFXIndex < m_CombRunning.Items.Count))
						{
							m_CombRunning.SelectedIndex = NFsAE.RunningAFXIndex;
						}
						m_CombRunning.SelectedIndexChanged += M_CombRunning_SelectedIndexChanged;
					}
				}
			}
		}

		private void M_CombRunning_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cmb = (ComboBox)sender;
			int idx = cmb.SelectedIndex;
			if(NFsAE.RunningAFXIndex !=idx)
			{
				NFsAE.RunningAFXIndex = idx;
			}
		}

		// ******************************************************************************
		public string AeWin
		{
			get { return NFsAE.AeWin; }
			set
			{
				NFsAE.AeWin = value;
			}
		}
		// ******************************************************************************
		public NFsAECmp()
		{
			NFsAE.FindInstalledAFX();

			NFsAE.InstalledAFXChanged += NFsAE_InstalledAFXChanged;
			NFsAE.InstalledAFXIndexChanged += NFsAE_TargetAEIndexChanged;

			NFsAE.RunningAFXChanged += NFsAE_RunningAFXChanged;
			NFsAE.RunningAFXIndexChanged += NFsAE_RunningAFXIndexChanged;

		}

		// ******************************************************************************
		private void NFsAE_RunningAFXIndexChanged(object sender, EventArgs e)
		{
			OnRunningAFXIndexChanged(new EventArgs());
		}

		// ******************************************************************************
		private void NFsAE_RunningAFXChanged(object sender, EventArgs e)
		{
			if(m_CombRunning!=null)
			{
				m_CombRunning.Items.Clear();
				m_CombRunning.Items.AddRange(NFsAE.RunningAFXStr);
			}
		}

		// ******************************************************************************
		private void NFsAE_InstalledAFXChanged(object sender, EventArgs e)
		{
			if (m_CombInstalled != null)
			{
				m_CombInstalled.Items.Clear();
				if (NFsAE.InstalledCount > 0)
				{
					m_CombInstalled.Items.Clear();
					m_CombInstalled.Items.AddRange(NFsAE.InstalledAFX);
				}
			}
			if (m_ListBoxInstalled != null)
			{
				m_ListBoxInstalled.Items.Clear();
				if (NFsAE.InstalledCount > 0)
				{
					m_ListBoxInstalled.Items.Clear();
					m_ListBoxInstalled.Items.AddRange(NFsAE.InstalledAFX);
				}
			}
		}

		// ******************************************************************************
		private void NFsAE_TargetAEIndexChanged(object sender, EventArgs e)
		{
			if(m_CombInstalled!=null)
			{
				if(m_CombInstalled.SelectedIndex != NFsAE.InstalledAFXIndex)
				{
					m_CombInstalled.SelectedIndex = NFsAE.InstalledAFXIndex;
				}
			}
			if (m_ListBoxInstalled != null)
			{
				if (m_ListBoxInstalled.SelectedIndex != NFsAE.InstalledAFXIndex)
				{
					m_ListBoxInstalled.SelectedIndex = NFsAE.InstalledAFXIndex;
				}
			}
		}

		// ******************************************************************************
		public AEStutas Run(bool IsShowMes = false)
		{
			AEStutas ret = AEStutas.None;
			 ret = NFsAE.Run();
			if (IsShowMes) {
				string mes = "";
				switch(ret)
				{
					case AEStutas.None:
						mes = "起動失敗失敗？";
						break;
					case AEStutas.IsRunning:
						mes = "既に起動しています。";
						break;
					case AEStutas.IsRunStart:
						mes = "起動します。";
						break;
				}
				MessageBox.Show(mes, "AfterFX起動");
			}
			return ret;
		}
		// ******************************************************************************
		public Process CallAerender(string aep, string op = "")
		{
			return NFsAE.CallAerender(aep, op);
		}
		// ******************************************************************************
		public bool ExecScriptFile(string p)
		{
			
			return NFsAE.ExecScriptFile(p);

		}
		// ******************************************************************************
		public bool ExecScriptCode(string p)
		{
			return NFsAE.ExecScriptCode(p);

		}
		// *************************************************************************************
		public void ForegroundWindow()
		{
			if (NFsAE.RunningAFXIndex>=0)
			{
				NFsAE.RunningAFX[NFsAE.RunningAFXIndex].SetForegroundWindow();
			}
		}
		public void WindowMax()
		{
			if (NFsAE.RunningAFXIndex >= 0)
			{
				NFsAE.RunningAFX[NFsAE.RunningAFXIndex].WindowMax();
				NFsAE.RunningAFX[NFsAE.RunningAFXIndex].SetForegroundWindow();
			}
		}
		public void WindowMin()
		{
			if (NFsAE.RunningAFXIndex >= 0)
			{
				NFsAE.RunningAFX[NFsAE.RunningAFXIndex].WindowMin();
			}
		}

		// *************************************************************************************


	}
}
