using System;

namespace UnityEngine
{
	// Token: 0x020001D3 RID: 467
	public sealed class AddComponentMenu : Attribute
	{
		// Token: 0x060014C5 RID: 5317 RVA: 0x00021B72 File Offset: 0x0001FD72
		public AddComponentMenu(string menuName)
		{
			this.m_AddComponentMenu = menuName;
			this.m_Ordering = 0;
		}

		// Token: 0x060014C6 RID: 5318 RVA: 0x00021B8A File Offset: 0x0001FD8A
		public AddComponentMenu(string menuName, int order)
		{
			this.m_AddComponentMenu = menuName;
			this.m_Ordering = order;
		}

		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x060014C7 RID: 5319 RVA: 0x00021BA4 File Offset: 0x0001FDA4
		public string componentMenu
		{
			get
			{
				return this.m_AddComponentMenu;
			}
		}

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x060014C8 RID: 5320 RVA: 0x00021BBC File Offset: 0x0001FDBC
		public int componentOrder
		{
			get
			{
				return this.m_Ordering;
			}
		}

		// Token: 0x04000745 RID: 1861
		private string m_AddComponentMenu;

		// Token: 0x04000746 RID: 1862
		private int m_Ordering;
	}
}
