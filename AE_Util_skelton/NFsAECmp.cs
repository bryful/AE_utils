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
		public event EventHandler TargetAEIndexChanged;

		protected virtual void OnTargetAEIndexChanged(EventArgs e)
		{
			if (TargetAEIndexChanged != null)
			{
				TargetAEIndexChanged(this, e);
			}
		}
		#endregion


		#region installed
		public int InstallCount
		{
			get { return NFsAE.InstallCount; }
		}
		public string[] InstalledAFX
		{
			get
			{
				return NFsAE.InstalledAFX;
			}
		}
		#endregion


		public string TargetVersionStr
		{
			get
			{
				return NFsAE.TargetVersionStr;
			}
			set
			{
				NFsAE.TargetVersionStr = value;
			}
		}

		public int TargetVersionIndex
		{
			get { return NFsAE.TargetVersionIndex; }
			set
			{
				if (NFsAE.TargetVersionIndex != value)
				{
					NFsAE.TargetVersionIndex = value;
					if (m_CombTargetVertion != null)
					{
						if (m_CombTargetVertion.SelectedIndex != TargetVersionIndex)
						{
							m_CombTargetVertion.SelectedIndex = TargetVersionIndex;
						}

					}
					OnTargetAEIndexChanged(new EventArgs());
				}
			}
		}

		public string AfterFXPath
		{
			get
			{
				return NFsAE.AfterFXPath;
			}
		}
		public string AerenderPath
		{
			get
			{
				return NFsAE.AerenderPath;
			}
		}



		#region CombTargeVersion
		private ComboBox m_CombTargetVertion = null;
		public ComboBox CombTargetVersion
		{
			get { return m_CombTargetVertion; }
			set
			{
				m_CombTargetVertion = value;
				if (m_CombTargetVertion != null)
				{
					m_CombTargetVertion.DropDownStyle = ComboBoxStyle.DropDownList;
					m_CombTargetVertion.Items.Clear();
					if (NFsAE.InstallCount > 0)
					{
						m_CombTargetVertion.Items.Clear();
						m_CombTargetVertion.Items.AddRange(NFsAE.InstalledAFX);
						if ((NFsAE.TargetVersionIndex >= 0) && (NFsAE.TargetVersionIndex < m_CombTargetVertion.Items.Count))
						{
							m_CombTargetVertion.SelectedIndex = NFsAE.TargetVersionIndex;
						}
						m_CombTargetVertion.SelectedIndexChanged += M_CombTargetVersion_SelectedIndexChanged;
					}
				}
			}
		}

		private void M_CombTargetVersion_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cmb = (ComboBox)sender;
			int idx = cmb.SelectedIndex;
			if ((idx >= 0) && (idx < NFsAE.InstallCount))
			{
				if (TargetVersionIndex != idx)
				{
					TargetVersionIndex = idx;
				}
			}
		}
		#endregion
		public string AeWin
		{
			get { return NFsAE.AeWin; }
			set
			{
				NFsAE.AeWin = value;
			}
		}
		public NFsAECmp()
		{
			NFsAE.FindInstalledAE();
		}
		// ******************************************************************************
		public AEStutas Run()
		{
			return NFsAE.Run();
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


	}
}
