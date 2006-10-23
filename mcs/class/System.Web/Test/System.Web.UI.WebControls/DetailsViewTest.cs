//
// Tests for System.Web.UI.WebControls.FormView.cs 
//
// Author:
//	Merav Sudri (meravs@mainsoft.com)
//
//
// Copyright (C) 2005 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

#if NET_2_0

using NUnit.Framework;
using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MonoTests.SystemWeb.Framework;
using MonoTests.stand_alone.WebHarness;
using System.Collections.Generic;


namespace MonoTests.System.Web.UI.WebControls
{
	[TestFixture]	
	public class DetailsViewTest {

		public class DataSourceObject
		{
			public static List<string> GetList (string sortExpression, int startRowIndex, int maximumRows) {
				return GetList ();
			}

			public static List<string> GetList (int startRowIndex, int maximumRows) {
				return GetList ();
			}

			public static List<string> GetList (string sortExpression) {
				return GetList ();
			}

			public static List<string> GetList () {
				List<string> list = new List<string> ();
				list.Add ("Norway");
				list.Add ("Sweden");
				list.Add ("France");
				list.Add ("Italy");
				list.Add ("Israel");
				list.Add ("Russia");
				return list;
			}

			public static int GetCount () {
				return GetList ().Count;
			}
		}
		
		public class PokerDetailsView : DetailsView 
		{
			public bool ensureDataBound=false;
			public bool isInitializePager = false;
			public bool controlHierarchy = false;
			public bool ensureCreateChildControls = false;
			public bool createChildControls1 = false;
			public bool createChildControls2 = false;
			public PokerDetailsView () 
			{
			 TrackViewState ();
			}

			public object SaveState ()
			{
			 return SaveViewState ();
			}

			 public void LoadState (object o)
			{
			 LoadViewState (o);
			}

			public StateBag StateBag 
			{
			  get { return base.ViewState; }
			}

			public HtmlTextWriterTag PokerTagKey
			{
				get { return base.TagKey; }
			}

			public string Render ()
			{
				StringWriter sw = new StringWriter ();
				HtmlTextWriter tw = new HtmlTextWriter (sw);
				Render (tw);
				return sw.ToString ();
			}

			public void DoOnInit (EventArgs e)
			{
				OnInit (e);
			}

			public void DoOnDataSourceViewChanged (Object sender, EventArgs e)
			{
				OnDataSourceViewChanged (sender, e);
			}

			public void DoOnItemCommand (DetailsViewCommandEventArgs e)
			{
				OnItemCommand (e);
			}

			public void DoOnItemCreated (EventArgs e)
			{
				OnItemCreated (e); 
			}

			public void DoOnItemDeleted (DetailsViewDeletedEventArgs e)
			{
				OnItemDeleted (e); 
			}

			public void DoOnItemDeleting  (DetailsViewDeleteEventArgs e)
			{
				OnItemDeleting (e);
			}

			public void DoOnItemInserted (DetailsViewInsertedEventArgs e)
			{
				OnItemInserted (e);
			}

			public void DoOnItemInserting (DetailsViewInsertEventArgs e)
			{
				OnItemInserting (e); 
			}

			public void DoOnItemUpdated (DetailsViewUpdatedEventArgs  e)
			{
				OnItemUpdated(e);
			}

			public void DoOnItemUpdating (DetailsViewUpdateEventArgs e)
			{
				OnItemUpdating (e);
			}


			public void DoOnModeChanged (EventArgs e)
			{
				OnModeChanged (e);
			}
			public void DoOnModeChanging (DetailsViewModeEventArgs e)
			{
				OnModeChanging (e);
			}
			public void DoOnPageIndexChanged (EventArgs e)
			{
				OnPageIndexChanged (e);
			}
			public void DoOnPageIndexChanging (DetailsViewPageEventArgs e)
			{
				OnPageIndexChanging (e);
			}

			public void DoOnPagePreLoad  (Object sender , EventArgs e)
			{
				OnPagePreLoad (sender, e);
			}
			public void DoOnPreRender (EventArgs e)
			{
				OnPreRender (e);
			}
			public void DoOnUnload (EventArgs e)
			{
				OnUnload (e);
			}
			public bool DoOnBubbleEvent (Object sender, EventArgs e)
			{
				return OnBubbleEvent (sender, e);
			}

			public Object DoSaveControlState ()
			{
				return SaveControlState ();
			}

			public void DoLoadControlState (Object saveState)
			{
				LoadControlState (saveState);
			}

			public AutoGeneratedField DoCreateAutoGeneratedRow (AutoGeneratedFieldProperties filedProperties)
			{
				return CreateAutoGeneratedRow (filedProperties);
			}

			public ICollection DoCreateAutoGeneratedRows (Object DataItem)
			{
				return CreateAutoGeneratedRows (DataItem);
			}

			public int DoCreateChildControls (IEnumerable dataSource,bool dataBinding)
			{
				return CreateChildControls (dataSource, dataBinding);
			}

			public Style DoCreateControlStyle ()
			{
				return CreateControlStyle ();
			}

			public DetailsViewRow  DoCreateRow (int rowIndex,DataControlRowType rowType, DataControlRowState rowState)
			{
				return CreateRow (rowIndex, rowType, rowState); 
			}

			public Table DoCreateTable ()
			{
				return CreateTable ();
			}

			protected override void EnsureDataBound ()
			{
				base.EnsureDataBound ();
				ensureDataBound = true;
			}

			protected override void EnsureChildControls ()
			{
				base.EnsureChildControls ();
				ensureCreateChildControls = true;
			}

			protected override void CreateChildControls ()
			{
				base.CreateChildControls ();
				createChildControls1 = true;
			}

			protected override int CreateChildControls (IEnumerable data, bool dataBinding)
			{
				createChildControls2 = true;
				return base.CreateChildControls (data, dataBinding);
			}

			public void DoConfirmInitState ()
			{
				base.ConfirmInitState ();
			}

			public void DoExtractRowValues (IOrderedDictionary fieldValues, bool includeReadOnlyFields, bool includeKeys)
			{
				ExtractRowValues (fieldValues, includeReadOnlyFields, includeKeys);
			}

			public ICollection  DoCreateFieldSet (Object dataItem, bool useDataSource)
			{
				return CreateFieldSet (dataItem, useDataSource);
			}

			public string DoGetCallbackResult ()
			{
				return GetCallbackResult (); 
			}

			public string DoGetCallbackScript (IButtonControl buttonControl, string argument)
			{
				return GetCallbackScript (buttonControl, argument);
			}

			protected override void InitializePager (DetailsViewRow row, PagedDataSource pagedDataSource)
			{
				base.InitializePager (row,pagedDataSource);
				isInitializePager = true;
			}

			public void DoPerformDataBinding (IEnumerable data)
			{
				PerformDataBinding (data);
			}

			protected override void PrepareControlHierarchy ()
			{
				base.PrepareControlHierarchy ();
				controlHierarchy = true;
			}

			public void DoRaiseCallbackEvent (string eventArgument)
			{
				base.RaiseCallbackEvent (eventArgument);
			}

			public void DoEnsureChildControls ()
			{
				base.EnsureChildControls ();
			}

			public DataSourceSelectArguments DoCreateDataSourceSelectArguments ()
			{
				return CreateDataSourceSelectArguments ();
			}

			public DataSourceView DoGetData ()
			{
				return GetData ();
			}
		}

		ArrayList myds = new ArrayList ();
		[TestFixtureSetUp]
		public void setup ()
		{
			myds.Add ("Item1");
			myds.Add ("Item2");
			myds.Add ("Item3");
			myds.Add ("Item4");
			myds.Add ("Item5");
			myds.Add ("Item6");
#if VISUAL_STUDIO
			WebTest.CopyResource (GetType (), "MonoTests.System.Web.UI.WebControls.Resources.FooterTemplateTest.aspx",
				"FooterTemplateTest.aspx");
			WebTest.CopyResource (GetType (), "MonoTests.System.Web.UI.WebControls.Resources.DetailsViewTemplates.aspx",
				"DetailsViewTemplates.aspx");
			WebTest.CopyResource (GetType (), "MonoTests.System.Web.UI.WebControls.Resources.DetailsViewDataActions.aspx",
				"DetailsViewDataActions.aspx");
			WebTest.CopyResource (GetType (), "MonoTests.System.Web.UI.WebControls.Resources.DetailsViewProperties1.aspx",
				"DetailsViewProperties1.aspx");
#else
			WebTest.CopyResource (GetType (), "FooterTemplateTest.aspx", "FooterTemplateTest.aspx");
			WebTest.CopyResource (GetType (), "DetailsViewTemplates.aspx", "DetailsViewTemplates.aspx");
			WebTest.CopyResource (GetType (), "DetailsViewDataActions.aspx", "DetailsViewDataActions.aspx");
			WebTest.CopyResource (GetType (), "DetailsViewProperties1.aspx", "DetailsViewProperties1.aspx");
#endif
			
		}



		[Test]
		public void DetailsView_DefaultProperties ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			Assert.IsNotNull (dv.Rows);			
			Assert.AreEqual (false, dv.AllowPaging, "AllowPagingDefault");
			Assert.AreEqual (typeof(TableItemStyle), dv.AlternatingRowStyle.GetType(),"AlternatingRowStyleDefault") ;
			Assert.AreEqual (false, dv.AutoGenerateDeleteButton, "AutoGenerateDeleteButtonDefault");
			Assert.AreEqual (false, dv.AutoGenerateEditButton, "AutoGenerateEditButtonDefault");
			Assert.AreEqual (false, dv.AutoGenerateInsertButton, "AutoGenerateInsertButtonDefault");
			Assert.AreEqual (true, dv.AutoGenerateRows, "AutoGenerateRowsDefault");
			Assert.AreEqual ("", dv.BackImageUrl, "BackImageUrlDefault");
			Assert.AreEqual (null, dv.BottomPagerRow, "BottomPagerRowDefault");
			Assert.AreEqual ("", dv.Caption, "CaptionDefault");
			Assert.AreEqual (TableCaptionAlign.NotSet, dv.CaptionAlign, "CaptionAlignDefault");
			Assert.AreEqual (-1, dv.CellPadding, "CellPaddingDefault");
			Assert.AreEqual (0, dv.CellSpacing, "CellSpacingDefault");
			Assert.AreEqual (typeof(TableItemStyle), dv.CommandRowStyle.GetType(),"CommandRowStyleDefault");
			Assert.AreEqual (DetailsViewMode.ReadOnly, dv.CurrentMode, "CurrentModeDefault");
			Assert.AreEqual (null, dv.DataItem, "DataItemDefault");
			Assert.AreEqual (0, dv.DataItemCount, " DataItemCountDefault");
			Assert.AreEqual (0, dv.DataItemIndex, "DataItemIndexDefault");
			Assert.AreEqual (typeof (DataKey), dv.DataKey.GetType (), "DataKeyDefault");			
			Assert.AreEqual (new string[0],dv.DataKeyNames,"DataKeyNamesDefault");
			Assert.AreEqual (DetailsViewMode.ReadOnly, dv.DefaultMode, "DefaultMode");
			Assert.AreEqual (typeof (TableItemStyle),dv.EditRowStyle.GetType(),"EditRowStyleDefault");
			Assert.AreEqual (typeof (TableItemStyle),dv.EmptyDataRowStyle.GetType(), " EmptyDataRowStyleDefault");
			Assert.AreEqual (null,dv.EmptyDataTemplate,"EmptyDataTemplate");
			Assert.AreEqual (false,dv.EnablePagingCallbacks, "EnablePagingCallbacksDefault");
			Assert.AreEqual (true,dv.FieldHeaderStyle.IsEmpty,"FieldHeaderStyleDefault");
			Assert.AreEqual (typeof (TableItemStyle),dv.FieldHeaderStyle.GetType() ,"FieldHeaderStyleDefault");
			Assert.AreEqual (0, dv.Fields.Count  ,"FiledsDefault");
			Assert.AreEqual (null, dv.FooterRow, "FooterRowDefault1");
			Assert.AreEqual (typeof (TableItemStyle), dv.FooterStyle.GetType (), "FooterStyleDefault");
			Assert.AreEqual (null, dv.FooterTemplate, "FooterTemplateDefault");
			Assert.AreEqual ("", dv.FooterText, "FooterTextDefault");
			Assert.AreEqual (GridLines.Both, dv.GridLines, "GridLinesDefault");
			Assert.AreEqual (null, dv.HeaderRow, "HeaderRowDefault");
			Assert.AreEqual (typeof (TableItemStyle), dv.HeaderStyle.GetType() , "HeaderStyleDefault");
			Assert.AreEqual (null, dv.HeaderTemplate, "HeaderTemplateDefault");
			Assert.AreEqual ("", dv.HeaderText, "HeaderTextDefault");
			Assert.AreEqual (HorizontalAlign.NotSet, dv.HorizontalAlign, "HorizontalAlignDefault");
			Assert.AreEqual (typeof (TableItemStyle), dv.InsertRowStyle.GetType (), "InsertRowStyleDefault");
			Assert.AreEqual (0, dv.PageCount, "PageCountDefault");
			Assert.AreEqual (0, dv.PageIndex, "PageIndexDefault");
			Assert.AreEqual (typeof (PagerSettings), dv.PagerSettings.GetType() , "PagerSettingsDefault");
			Assert.AreEqual (typeof (TableItemStyle), dv.PagerStyle.GetType() , "PagerStyleDefault");
			Assert.AreEqual (null, dv.PagerTemplate, "PagerTemplateDefault");
			Assert.AreEqual (0, dv.Rows.Count, "RowsDefault1");
			Assert.AreEqual (typeof (DetailsViewRowCollection), dv.Rows.GetType (), "RowDefault2");
			Assert.AreEqual (typeof (TableItemStyle), dv.RowStyle.GetType (), "RowStyleDefault");
			Assert.AreEqual (null, dv.SelectedValue, "SelectedValueDefault");
			Assert.AreEqual (null, dv.TopPagerRow, "TopPagerRow");
		}

		[Test]
		public void DetailsView_AssignToDefaultProperties ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			dv.AllowPaging = true;
			dv.DataSource = myds;
			dv.DataBind ();			
			Assert.AreEqual (true, dv.AllowPaging, "AllowPaging");
			dv.AlternatingRowStyle.CssClass = "style.css";
			Assert.AreEqual ("style.css", dv.AlternatingRowStyle.CssClass, "AlternatingRowStyle");
			dv.AutoGenerateDeleteButton = true;
			Assert.AreEqual (true, dv.AutoGenerateDeleteButton, "AutoGenerateDeleteButton");
			dv.AutoGenerateEditButton = true;
			Assert.AreEqual (true, dv.AutoGenerateEditButton, "AutoGenerateEditButton");
			dv.AutoGenerateInsertButton = true;
			Assert.AreEqual (true, dv.AutoGenerateInsertButton, "AutoGenerateInsertButton");
			dv.AutoGenerateRows = false;
			Assert.AreEqual (false, dv.AutoGenerateRows, "AutoGenerateRows");
			dv.BackImageUrl = "image.jpg";
			Assert.AreEqual ("image.jpg", dv.BackImageUrl, "BackImageUrl");
			dv.Caption = "Caption Test";
			Assert.AreEqual ("Caption Test", dv.Caption, "Caption");
			dv.CaptionAlign = TableCaptionAlign.Right;
			Assert.AreEqual (TableCaptionAlign.Right, dv.CaptionAlign, "CaptionAlign");
			dv.CellPadding = 2;
			Assert.AreEqual (2, dv.CellPadding, "CellPadding");
			dv.CellSpacing = 5;
			Assert.AreEqual (5, dv.CellSpacing, "CellSpacing");
			dv.CommandRowStyle.BackColor = Color.Purple;
			Assert.AreEqual (Color.Purple, dv.CommandRowStyle.BackColor, "CommandRowStyle.BackColor");
			dv.ChangeMode (DetailsViewMode.Insert);
			Assert.AreEqual (DetailsViewMode.Insert, dv.CurrentMode, "CurrentModeInsert");
			dv.ChangeMode (DetailsViewMode.Edit );
			Assert.AreEqual (DetailsViewMode.Edit, dv.CurrentMode, "CurrentModeEdit");
			Assert.AreEqual ("Item1", dv.DataItem, "DataItem");
			Assert.AreEqual (6, dv.DataItemCount, "DataItemCount");
			Assert.AreEqual (0, dv.DataItemIndex, "DataItemIndex");
			string[] names ={ "test1", "test2", "test3" };
			dv.DataKeyNames = names;
			Assert.AreEqual (names, dv.DataKeyNames, "DataKeyNames");
			dv.DefaultMode = DetailsViewMode.Edit;
			Assert.AreEqual (DetailsViewMode.Edit, dv.DefaultMode, "DefaultModeEdit");
			dv.DefaultMode = DetailsViewMode.Insert;
			Assert.AreEqual (DetailsViewMode.Insert, dv.DefaultMode, "DefaultModeInsert");
			dv.DefaultMode = DetailsViewMode.ReadOnly;
			Assert.AreEqual (DetailsViewMode.ReadOnly, dv.DefaultMode, "DefaultModeReadOnly");
			dv.EditRowStyle.ForeColor = Color.Pink;
			Assert.AreEqual (Color.Pink, dv.EditRowStyle.ForeColor, "EditRowStyle");
			dv.EmptyDataRowStyle.HorizontalAlign = HorizontalAlign.Center;
			Assert.AreEqual (HorizontalAlign.Center, dv.EmptyDataRowStyle.HorizontalAlign, "HorizontalAlignCenter");
			dv.EmptyDataTemplate = new DTemplate ();
			Assert.AreEqual (typeof (DTemplate), dv.EmptyDataTemplate.GetType() , "EmptyDataTemplate");
			dv.EmptyDataText = "No Data";
			Assert.AreEqual ("No Data", dv.EmptyDataText, "EmptyDataText");
			dv.EnablePagingCallbacks = true;
			Assert.AreEqual (true, dv.EnablePagingCallbacks, "EnablePagingCallbacks");
			dv.FieldHeaderStyle.CssClass = "style.css";
			Assert.AreEqual ("style.css", dv.FieldHeaderStyle.CssClass, "FieldHeaderStyle");
			DataControlFieldCollection coll=new DataControlFieldCollection ();
			dv.FooterStyle.HorizontalAlign = HorizontalAlign.Right ;
			Assert.AreEqual (HorizontalAlign.Right, dv.FooterStyle.HorizontalAlign , "FooterStyle");
			dv.FooterTemplate = new DTemplate ();
			Assert.AreEqual (typeof(DTemplate ),dv.FooterTemplate.GetType() ,"FooterTemplate");
			dv.FooterText = "Footer Text";
			Assert.AreEqual ("Footer Text", dv.FooterText, "FooterText");
			dv.GridLines = GridLines.Horizontal;
			Assert.AreEqual (GridLines.Horizontal, dv.GridLines, "GridLinesHorizontal ");
			dv.GridLines = GridLines.None;
			Assert.AreEqual (GridLines.None , dv.GridLines, "GridLinesNone ");
			dv.GridLines = GridLines.Vertical;
			Assert.AreEqual (GridLines.Vertical, dv.GridLines, "GridLinesVertical ");
			dv.GridLines = GridLines.Both;
			Assert.AreEqual (GridLines.Both, dv.GridLines, "GridLinesBoth ");
			dv.HeaderStyle.BorderColor = Color.PapayaWhip;
			Assert.AreEqual (Color.PapayaWhip, dv.HeaderStyle.BorderColor, "HeaderStyle");
			dv.HeaderTemplate = new DTemplate ();
			Assert.AreEqual (typeof (DTemplate), dv.HeaderTemplate.GetType (), "HeaderTemplate"); 
			dv.HeaderText = "Header Text";
			Assert.AreEqual ("Header Text", dv.HeaderText, "HeaderText");
			dv.HorizontalAlign = HorizontalAlign.Center;
			Assert.AreEqual (HorizontalAlign.Center, dv.HorizontalAlign, "HorizontalAlignCenter");
			dv.HorizontalAlign = HorizontalAlign.Justify;
			Assert.AreEqual (HorizontalAlign.Justify , dv.HorizontalAlign, "HorizontalAlignJustify");
			dv.HorizontalAlign = HorizontalAlign.Left ;
			Assert.AreEqual (HorizontalAlign.Left , dv.HorizontalAlign, "HorizontalAlignLeft");
			dv.HorizontalAlign = HorizontalAlign.NotSet ;
			Assert.AreEqual (HorizontalAlign.NotSet , dv.HorizontalAlign, "HorizontalAlignNotSet");
			dv.HorizontalAlign = HorizontalAlign.Right ;
			Assert.AreEqual (HorizontalAlign.Right , dv.HorizontalAlign, "HorizontalAlignRight");
			dv.InsertRowStyle.BackColor = Color.PeachPuff;
			Assert.AreEqual (Color.PeachPuff, dv.InsertRowStyle.BackColor, "InsertRowStyle");
			Assert.AreEqual (6, dv.PageCount, "PageCount");
			Assert.AreEqual (0, dv.PageIndex, "PageIndex");
			dv.PagerSettings.LastPageImageUrl = "image.jpg";
			Assert.AreEqual ("image.jpg", dv.PagerSettings.LastPageImageUrl, "PagerSettings");
			dv.PagerStyle.CssClass = "style.css";
			Assert.AreEqual ("style.css", dv.PagerStyle.CssClass, "PagerStyle");
			dv.PagerTemplate = new DTemplate ();
			Assert.AreEqual (typeof (DTemplate), dv.PagerTemplate.GetType (), "PagerTemplate");
			Assert.AreEqual (1, dv.Rows.Count, "Rows");
			dv.RowStyle.BackColor  = Color.Plum  ;
			Assert.AreEqual (Color.Plum, dv.RowStyle.BackColor, "RowStyle");
			dv.FooterRow.CssClass="style.css";
			Assert.AreEqual ("style.css", dv.FooterRow.CssClass , "FooterRow");
			dv.HeaderRow.BackColor =Color.Pink ;
			Assert.AreEqual (Color.Pink, dv.HeaderRow.BackColor, "HeaderRow");  

		}

		[Test]		
		public void DetailsView_DefaultProtectedProperties ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			Assert.AreEqual (HtmlTextWriterTag.Table, dv.PokerTagKey, "TagKey");
		}

		[Test]
		[Category ("NotWorking")] 
		public void DetailsView_AssignedPropertiesRender ()
		{
						string RenderedPageHtml = new WebTest ("DetailsViewProperties1.aspx").Run ();
			string newHtmlValue = RenderedPageHtml.Substring (RenderedPageHtml.IndexOf ("starttest") + 9, RenderedPageHtml.IndexOf ("endtest") - RenderedPageHtml.IndexOf ("starttest") - 9);
			string origHtmlValue = @" <div>
			<div>
			<table cellspacing=""20"" cellpadding=""30"" rules=""all"" border=""1"" id=""DetailsView1"" style=""height:50px;width:125px;background-image:url(Blue%20hills.jpg);"">
			<caption align=""Bottom"">
			Caption Test
			</caption><tr>
			<td>ID</td><td>1001</td>
			</tr><tr>
			<td>FName</td><td>Mahesh</td>
			</tr><tr>
			<td>LName</td><td>Chand</td>
			</tr>
			</table>
			</div>   
			 </div>";
			HtmlDiff.AssertAreEqual (origHtmlValue, newHtmlValue, "RenderDetailsViewProperties1");
			Assert.AreEqual (true,origHtmlValue.Contains (@"cellpadding=""30"""),"CellpaddingRender");
			Assert.AreEqual (true, origHtmlValue.Contains (@"cellspacing=""20"""), "CellspacingRender");
			Assert.AreEqual (true, origHtmlValue.Contains ("Caption Test"), "CaptionRender");
			Assert.AreEqual (true, origHtmlValue.Contains (@"caption align=""Bottom"""), "CaptionalignRender");
			Assert.AreEqual (true, origHtmlValue.Contains ("Blue%20hills.jpg"), "BackImageRender");
			Assert.AreEqual (true, origHtmlValue.Contains ("Blue%20hills.jpg"), "BackImageRender");
			//GridLines and HorizontalAlign were set but can not be shown in this rendering.
		}

		
		[Test]
		[Category ("NunitWeb")]
		public void DetailsView_EmptyDataTextPropertyRender ()
		{	
			PageDelegate pd = new PageDelegate (DetailsView_EmptyDataTextProperty);
			WebTest t = new WebTest (PageInvoker.CreateOnLoad (pd));
			string result = t.Run ();						
			FormRequest fr = new FormRequest (t.Response, "form1");
			fr.Controls.Add ("__EVENTTARGET");
			fr.Controls.Add ("__EVENTARGUMENT");
			fr.Controls["__EVENTTARGET"].Value = "LinkButton1";
			fr.Controls["__EVENTARGUMENT"].Value = "";
			t.Request = fr;
			//t.Invoker = PageInvoker.CreateOnLoad (pd);
			result = t.Run ();
			string newHtml = HtmlDiff.GetControlFromPageHtml (result); 
			string origHtml=@"<div>
					<table cellspacing=""0"" rules=""all"" border=""1"" style=""border-collapse:collapse;"">
					<tr>
					<td>Empty Data</td>
					</tr>
					</table>
					</div><a id=""LinkButton1"" href=""javascript:__doPostBack('LinkButton1','')"">Test</a>";
			HtmlDiff.AssertAreEqual(origHtml, newHtml, "EmptyDataTextTest");


		}

		public static void DetailsView_EmptyDataTextProperty (Page p)
		{
			LiteralControl lcb = new LiteralControl (HtmlDiff.BEGIN_TAG);
			LiteralControl lce = new LiteralControl (HtmlDiff.END_TAG);

			PokerDetailsView dv = new PokerDetailsView ();
			dv.DataSource = new ArrayList ();
			dv.EmptyDataText = "Empty Data";
			LinkButton lb = new LinkButton ();
			lb.ID = "LinkButton1";
			lb.Text = "Test";
			
			p.Form.Controls.Add (lcb);
			p.Form.Controls.Add (dv);
			dv.DataBind ();
			p.Form.Controls.Add (lb);
			p.Form.Controls.Add (lce);
		}
		//ToDo: Add more properties rendering tests (PageSettings,AutoGeneratedRows etc...)

		
		//Public Methods

		[Test]
		public void DetailsView_ChangeMode ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			Assert.AreEqual (DetailsViewMode.ReadOnly, dv.CurrentMode, "ChangeModeDefault");
			dv.ChangeMode (DetailsViewMode.Insert);
			Assert.AreEqual (DetailsViewMode.Insert, dv.CurrentMode, "ChangeModeInsert");
			dv.ChangeMode (DetailsViewMode.Edit);
			Assert.AreEqual (DetailsViewMode.Edit, dv.CurrentMode, "ChangeModeEdit");
			dv.ChangeMode (DetailsViewMode.ReadOnly);
			Assert.AreEqual (DetailsViewMode.ReadOnly, dv.CurrentMode, "ChangeModeReadOnly");
		}

		[Test]
		public void FormView_DataBind ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			dv.AllowPaging = true;
			dv.DataSource = myds;
			Assert.AreEqual (0, dv.PageCount, "BeforeDataBind1");
			Assert.AreEqual (null, dv.DataItem, "BeforeDataBind2");
			dv.DataBind ();
			Assert.AreEqual (6, dv.PageCount, "AfterDataBind1");
			Assert.AreEqual (6, dv.DataItemCount, "AfterDataBind2");
			Assert.AreEqual ("Item1", dv.DataItem, "AfterDataBind3");
		}

		[Test]
		public void FormView_IsBindableType ()
		{
			bool isBindable = false;
			PokerDetailsView dv = new PokerDetailsView ();
			isBindable = dv.IsBindableType (typeof (Decimal));
			Assert.AreEqual (true, isBindable, "IsBindableTypeDecimal");
			isBindable = dv.IsBindableType (typeof (Int32));
			Assert.AreEqual (true, isBindable, "IsBindableTypeInt32");
			isBindable = dv.IsBindableType (typeof (String));
			Assert.AreEqual (true, isBindable, "IsBindableTypeString");
			isBindable = dv.IsBindableType (typeof (Boolean));
			Assert.AreEqual (true, isBindable, "IsBindableTypeBoolean");
			isBindable = dv.IsBindableType (typeof (DateTime));
			Assert.AreEqual (true, isBindable, "IsBindableTypeDateTime");
			isBindable = dv.IsBindableType (typeof (Byte));
			Assert.AreEqual (true, isBindable, "IsBindableTypeByte");
			isBindable = dv.IsBindableType (typeof (Guid));
			Assert.AreEqual (true, isBindable, "IsBindableTypeGuid");
			isBindable = dv.IsBindableType (typeof (DTemplate));
			Assert.AreEqual (false, isBindable, "IsBindableTypeMyTemplate");
		}


		private bool isDeleted = false;

		[Test]
		public void DetailsView_DeleteItemHandler ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			dv.DataSource = myds;
			dv.DataBind ();
			Assert.AreEqual (false, isDeleted, "BeforeDeleteItem");
			dv.ItemDeleting += new DetailsViewDeleteEventHandler (dv_DeleteingHandler);
			dv.DeleteItem ();
			Assert.AreEqual (true, isDeleted, "BeforeDeleteItem");

		}

		public void dv_DeleteingHandler (Object sender, DetailsViewDeleteEventArgs e)
		{
			isDeleted = true;
		}

		[Test]
		[Category ("NunitWeb")]
		public void DetailsView_DeleteItemTest ()
		{
			string html = new WebTest (PageInvoker.CreateOnLoad (
				new PageDelegate (DetailsView_DeleteItem))).Run ();
			string newHtml = HtmlDiff.GetControlFromPageHtml (html);
			string origHtml = @"<div>
					<table cellspacing=""0"" rules=""all"" border=""1"" style=""border-collapse:collapse;"">
					<tr>
					<td>ID</td><td>1002</td>
					</tr><tr>
					<td>FName</td><td>Melanie</td>
					</tr><tr>
					<td>LName</td><td>Talmadge</td>
					</tr><tr>
					<td colspan=""2""><table border=""0"">
					<tr>
					<td><span>1</span></td><td><a href=""javascript:__doPostBack('ctl01','Page$2')"">2</a></td>
					</tr>
					</table></td>
					</tr>
					</table>
					</div>";
			HtmlDiff.AssertAreEqual (origHtml, newHtml, "DeleteItemMethod");
		}

		public static void DetailsView_DeleteItem (Page p)
		{
			LiteralControl lcb = new LiteralControl (HtmlDiff.BEGIN_TAG);
			LiteralControl lce = new LiteralControl (HtmlDiff.END_TAG);
			PokerDetailsView dv = new PokerDetailsView ();
			ObjectDataSource ds = new ObjectDataSource ();
			ds.ID = "ObjectDataSource1";
			ds.TypeName = "MonoTests.System.Web.UI.WebControls.TableObject";
			ds.SelectMethod = "GetMyData";
			ds.DeleteMethod = "Delete";
			ds.InsertMethod = "Insert";
			ds.UpdateMethod = "Update";
			Parameter p1 = new Parameter ("ID", TypeCode.String);
			Parameter p2 = new Parameter ("FName", TypeCode.String);
			Parameter p3 = new Parameter ("LName", TypeCode.String);
			ds.DeleteParameters.Add (p1);
			ds.DeleteParameters.Add (p2);
			ds.DeleteParameters.Add (p3);
			dv.Page = p;
			ds.Page = p;
			p.Form.Controls.Add (lcb);
			p.Form.Controls.Add (dv);
			p.Form.Controls.Add (ds);
			p.Form.Controls.Add (lce);
			dv.AllowPaging = true;
			dv.DataKeyNames = new string[] { "ID", "FName", "LName" };
			dv.DataSourceID = "ObjectDataSource1";
			dv.DataBind ();
			dv.DeleteItem ();
		}

		//ToDo: InsertItem method should be checked using postback
		private bool insertItem = false;
		[Test]
		public void DetailsView_InsertItem ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			dv.Page = new Page ();
			dv.ChangeMode (DetailsViewMode.Insert);
			dv.ItemInserting += new DetailsViewInsertEventHandler (insert_item);
			Assert.AreEqual (false, insertItem, "BeforeInsertItem");
			dv.InsertItem (true);
			Assert.AreEqual (true, insertItem, "AfterInsertItem");

		}

		public void insert_item (object sender, DetailsViewInsertEventArgs e)
		{
			insertItem = true;
		}

		//ToDo: UpdateItem method should be checked using postback
		private bool updateItem = false;
		[Test]
		[Category ("NotWorking")] 
		public void DetailsView_UpdateItem ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			dv.ChangeMode (DetailsViewMode.Edit);
			dv.Page = new Page ();
			dv.ItemUpdating += new DetailsViewUpdateEventHandler (update_item);
			Assert.AreEqual (false, updateItem, "BeforeUpdateItem");
			dv.UpdateItem (true);
			Assert.AreEqual (true, updateItem, "AfterUpdateItem");

		}

		public void update_item (object sender, DetailsViewUpdateEventArgs e)
		{
			updateItem = true;
		}

		//protected methods

		[Test]
		public void DetailsView_CreateAutoGeneratedRows ()
		{
			PokerDetailsView dv = new PokerDetailsView ();			
			DataTable ds = TableObject.CreateDataTable ();
			dv.DataSource = ds;
			dv.DataBind ();			
			ICollection col = dv.DoCreateAutoGeneratedRows (dv.DataItem);
			Assert.AreEqual (typeof(ArrayList),col.GetType (),"CreateAutoGeneratedRowsType");
			Assert.AreEqual (3, col.Count , "CreateAutoGeneratedRowsCount");
			Assert.AreEqual (typeof (AutoGeneratedField), ((ArrayList) col)[0].GetType (), "AutoGeneratedRowType");
			Assert.AreEqual ("ID", ((ArrayList) col)[0].ToString (), "AutoGeneratedRowName1");
			Assert.AreEqual ("FName", ((AutoGeneratedField)((ArrayList) col)[1]).HeaderText, "AutoGeneratedRowName2");
			Assert.AreEqual ("LName", ((AutoGeneratedField) ((ArrayList) col)[2]).SortExpression , "AutoGeneratedRowName3");
			
		}

		[Test]
		public void DetailsView_CreateAutoGenerateRow ()
		{
			PokerDetailsView dv = new PokerDetailsView ();			
			AutoGeneratedFieldProperties prop = new AutoGeneratedFieldProperties ();			
			prop.Name = "FieldItem";			
			prop.Type = typeof(String);
			AutoGeneratedField field = dv.DoCreateAutoGeneratedRow (prop);
			Assert.AreEqual (typeof (string), field.DataType, "FieldDataType");
			Assert.AreEqual ("FieldItem", field.HeaderText, "FieldHeaderText");
			Assert.AreEqual ("FieldItem",field.SortExpression ,"FieldSortExpretion");
			Assert.AreEqual (typeof(AutoGeneratedField), field.GetType (), "AutoGeneratedFieldType"); 

		}

		[Test]
		public void DetailsView_CreateChildControls ()
		{
			PokerDetailsView dv = new PokerDetailsView ();			
			Assert.AreEqual (6,dv.DoCreateChildControls (myds, true),"CreateChildControls1");
			Assert.AreEqual (6, dv.DoCreateChildControls (myds, false), "CreateChildControls2");
		}

		[Test]
		public void DetailsView_CreateControlStyle ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			Style style = dv.DoCreateControlStyle ();
			Assert.AreEqual (0, ((TableStyle) style).CellSpacing, "CreateControlStyle1");
			Assert.AreEqual (GridLines.Both, ((TableStyle) style).GridLines, "CreateControlStyle2");
			 
		}

		[Test]
		public void DetailsView_CreateRow ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			DetailsViewRow row = dv.DoCreateRow (1, DataControlRowType.DataRow, DataControlRowState.Alternate);
			Assert.AreEqual (1, row.RowIndex, "rowIndex1");
			Assert.AreEqual (DataControlRowType.DataRow, row.RowType, "RowType1");
			Assert.AreEqual (DataControlRowState.Alternate, row.RowState, "RowState1");
			row = dv.DoCreateRow (2, DataControlRowType.Header, DataControlRowState.Insert);
			Assert.AreEqual (2, row.RowIndex, "rowIndex2");
			Assert.AreEqual (DataControlRowType.Header , row.RowType, "RowType2");
			Assert.AreEqual (DataControlRowState.Insert , row.RowState, "RowState2");
			row = dv.DoCreateRow (3, DataControlRowType.EmptyDataRow , DataControlRowState.Selected );
			Assert.AreEqual (3, row.RowIndex, "rowIndex3");
			Assert.AreEqual (DataControlRowType.EmptyDataRow , row.RowType, "RowType3");
			Assert.AreEqual (DataControlRowState.Selected , row.RowState, "RowState3");			
			DetailsViewPagerRow pagerRow = (DetailsViewPagerRow )dv.DoCreateRow (5, DataControlRowType.Pager , DataControlRowState.Edit );
			Assert.AreEqual (5, pagerRow.RowIndex, "rowIndex4");
			Assert.AreEqual (DataControlRowType.Pager, pagerRow.RowType, "RowType4");
			Assert.AreEqual (DataControlRowState.Edit, pagerRow.RowState, "RowState4");
  
  
		}

		[Test]
		public void DetailsView_CreateTable ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			Table tb = dv.DoCreateTable();
			Assert.AreEqual (null, tb.Parent, "CreateTable1");
			Assert.AreEqual ("", tb.BackImageUrl, "CreateTable2");
			Assert.AreEqual (0, tb.Rows.Count, "CreateTable3");
			Assert.AreEqual (null, tb.ClientID , "CreateTable3");
			dv.ID = "testId"; //private filed _parentID should be set to "testId"			
			tb = dv.DoCreateTable ();
			Assert.AreEqual (-1, tb.CellSpacing, "CreateTable4");
			Assert.AreEqual (HorizontalAlign.NotSet , tb.HorizontalAlign , "CreateTable5");
		}

		[Test]
		public void DetailsView_EnsureDataBound ()
		{
			ObjectDataSource ds = new ObjectDataSource ();
			ds.ID = "ObjectDataSource1";
			ds.TypeName = "System.Guid";
			ds.SelectMethod = "ToByteArray";
			Page p = new Page ();
			PokerDetailsView dv = new PokerDetailsView ();
			dv.Page = p;
			ds.Page = p;
			p.Controls.Add (dv);
			p.Controls.Add (ds);
			dv.DataSourceID = "ObjectDataSource1";
			Assert.AreEqual (false, dv.ensureDataBound, "BeforeEnsureDataBound");
			dv.DoConfirmInitState ();
			dv.DoOnPreRender (EventArgs.Empty);
			Assert.AreEqual (true, dv.ensureDataBound, "AfterEnsureDataBound");
		}

		[Test]
		[Category ("NotWorking")]
		public void DetailsView_EnsureChildControls ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			int i = dv.Rows.Count;
			Assert.IsTrue (dv.ensureCreateChildControls);
			Assert.IsFalse (dv.ensureDataBound);
			Assert.IsFalse (dv.createChildControls1);
			Assert.IsFalse (dv.createChildControls2);
		}

		[Test]
		public void DetailsView_ExtractRowValues ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			DataTable ds = TableObject.CreateDataTable ();
			dv.DataSource = ds;
			dv.DataBind ();
			OrderedDictionary fieldsValues = new OrderedDictionary ();
			dv.DoExtractRowValues (fieldsValues, true, true);
			Assert.AreEqual (3, fieldsValues.Count, "ExtractRowValues1");
			Assert.AreEqual (3, fieldsValues.Keys.Count, "ExtractRowValues2");
			Assert.AreEqual (3, fieldsValues.Values.Count, "ExtractRowValues3");
			Assert.AreEqual (true, fieldsValues.Contains ("ID"), "ExtractRowValues4");
			IDictionaryEnumerator enumerator=fieldsValues.GetEnumerator ();
			enumerator.MoveNext ();
			Assert.AreEqual ("ID",enumerator.Key,"FieldValue1");
			Assert.AreEqual ("1001", enumerator.Value , "FieldValue2");
			enumerator.MoveNext ();
			Assert.AreEqual ("FName", enumerator.Key, "FieldValue3");
			Assert.AreEqual ("Mahesh", enumerator.Value, "FieldValue4");
			enumerator.MoveNext ();
			Assert.AreEqual ("LName", enumerator.Key, "FieldValue5");
			Assert.AreEqual ("Chand", enumerator.Value, "FieldValue6");
			fieldsValues = new OrderedDictionary ();
			dv.DoExtractRowValues (fieldsValues, false, false);
			Assert.AreEqual (0, fieldsValues.Count, "ExtractRowValues-NotReadOnly1");
			fieldsValues = new OrderedDictionary ();
			dv.DoExtractRowValues (fieldsValues, true, false);
			Assert.AreEqual (3, fieldsValues.Count, "ExtractRowValues-NoPrimaryKeys1");
			Assert.AreEqual (3, fieldsValues.Keys.Count, "ExtractRowValues-NoPrimaryKeys2");
			fieldsValues = new OrderedDictionary ();
			dv.DoExtractRowValues (fieldsValues, false, true);
			Assert.AreEqual (0, fieldsValues.Count, "ExtractRowValues-NotReadOnly2");
			Assert.AreEqual (0, fieldsValues.Keys.Count, "ExtractRowValues-NotReadOnly3");
		}

		[Test]
		[Category ("NotWorking")]
		public void DetailsView_CreateFieldSet_dont_useDataSource ()
		{
			DataTable ds = TableObject.CreateDataTable ();
			PokerDetailsView dv1 = new PokerDetailsView ();
			dv1.DataSource = ds;
			dv1.DataBind ();
			ICollection fieldSet1 = dv1.DoCreateFieldSet ("FieldTest", true);
			Assert.AreEqual (1, fieldSet1.Count, "FiledSetCount");
			AutoGeneratedField agf = (AutoGeneratedField) ((ArrayList) fieldSet1)[0];
			Assert.AreEqual ("Item", agf.HeaderText, "FieldSetCount");
		}

		[Test]
		public  void DetailsView_CreateFieldSet_useDataSource ()
		{
			DataTable ds = TableObject.CreateDataTable ();			
			PokerDetailsView dv2 = new PokerDetailsView ();
			dv2.DataSource = ds;
			dv2.DataBind ();
			ICollection fieldSet2 = dv2.DoCreateFieldSet ("FieldTest", false);
			Assert.AreEqual (3, fieldSet2.Count, "FiledSetCount");
			Assert.AreEqual ("ID", ((ArrayList) fieldSet2)[0].ToString (), "FieldValue1");
			Assert.AreEqual (typeof (Int32), ((AutoGeneratedField) ((ArrayList) fieldSet2)[0]).DataType, "FieldType1");
			Assert.AreEqual ("FName", ((ArrayList) fieldSet2)[1].ToString (), "FieldValue2");
			Assert.AreEqual (typeof (String), ((AutoGeneratedField) ((ArrayList) fieldSet2)[1]).DataType, "FieldType2");
			Assert.AreEqual ("LName", ((ArrayList) fieldSet2)[2].ToString (), "FieldValue3");
			Assert.AreEqual (typeof (String), ((AutoGeneratedField) ((ArrayList) fieldSet2)[2]).DataType, "FieldType3");
  

		}

		[Test]
		[Category ("NotWorking")] 
		public void DetailsView_GetCallBackResult ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			Page p = new Page ();
			p.Controls.Add (dv);
			DataTable ds = TableObject.CreateDataTable ();			
			dv.DataSource = ds;
			dv.DataBind ();
			dv.DoRaiseCallbackEvent ("a|b$c");
			string callbackResult=@"<table cellspacing=""0"" rules=""all"" border=""1"" style=""border-collapse:collapse;"">
						<tr>
						<td>ID</td><td>1001</td>
						</tr><tr>
						<td>FName</td><td>Mahesh</td>
						</tr><tr>
						<td>LName</td><td>Chand</td>
						</tr>
						</table>";
			string cbres = dv.DoGetCallbackResult ();
			Assert.IsNotNull (cbres);
			HtmlDiff.AssertAreEqual (callbackResult, cbres.Substring(dv.DoGetCallbackResult().IndexOf ("<table")), "GetCallbackResult");
				
		}

		[Test]
		public void DetailsView_GetCallbackScript ()
		{
			//Not implemented
		}

		[Test]
		public void DetailsView_InitializePager ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			Page page = new Page ();
			dv.AllowPaging = true;
			dv.DataSource = myds;
			page.Controls.Add (dv);						
			Assert.AreEqual (0, dv.PageCount, "BeforeInitializePagerPageCount");
			Assert.AreEqual (false, dv.isInitializePager, "BeforeInitializePager");
			dv.DataBind ();
			Assert.AreEqual (true, dv.isInitializePager, "AfterInitializePager");
			Assert.AreEqual (6, dv.PageCount, "AfterInitializePagerPageCount");
		}

		[Test]
		public void DetailsView_InitializeRow ()
		{
			//Not implemented
		}

		[Test]
		public void DetailsView_PerformDataBinding ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			Assert.AreEqual (0, dv.DataItemCount, "BeforePerformDataBinding");
			dv.DoPerformDataBinding (myds);
			Assert.AreEqual (6, dv.DataItemCount, "AfterPerformDataBinding");					
		}

		[Test]
		[Category ("NotWorking")] 
		public void DetailsView_PrepareControlHierarchy ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			//dv.Render ();
			//Assert.AreEqual (0, dv.Controls.Count, "ControlHierarchy1");
			//Assert.AreEqual (true, dv.controlHierarchy, "ControlHierarchy2");
			dv.controlHierarchy = false;
			dv.AllowPaging = true;
			dv.DataSource = myds;
			dv.DataBind ();
			dv.Page = new Page ();
			dv.Render ();
			Assert.AreEqual (1, dv.Controls.Count, "ControlHierarchy3");
			Assert.AreEqual (true, dv.controlHierarchy, "ControlHierarchy4");
			Button bt = new Button ();
			dv.Controls.Add (bt);
			dv.controlHierarchy = false;
			dv.Render ();
			Assert.AreEqual (2, dv.Controls.Count, "ControlHierarchy3");
			Assert.AreEqual (true, dv.controlHierarchy, "ControlHierarchy4");
		}
		
		//Render Methods
		[Test]
		public void DetailsView_FooterTemplateRender ()
		{
			//Footer Template property is checked.
			string RenderedPageHtml = new WebTest ("FooterTemplateTest.aspx").Run ();
			string newHtmlValue = RenderedPageHtml.Substring (RenderedPageHtml.IndexOf ("starttest")+9, RenderedPageHtml.IndexOf ("endtest") - RenderedPageHtml.IndexOf ("starttest")-9); 
			string origHtmlValue = @" <div>
						  <div>
						<table cellspacing=""0"" rules=""all"" border=""1"" id=""DetailsView1"" style=""height:50px;width:125px;border-collapse:collapse;"">
						<tr>
						<td>ID</td><td>1001</td>
						</tr><tr>
						<td>FName</td><td>Mahesh</td>
						</tr><tr>
						<td>LName</td><td>Chand</td>
						</tr><tr>
						<td colspan=""2"">
						 Footer Template Test<a id=""DetailsView1_HyperLink1"">Footer</a>
						 </td>
						</tr><tr>
						<td colspan=""2""><table border=""0"">
						<tr>
						<td><span>1</span></td><td><a href=""javascript:__doPostBack('DetailsView1','Page$2')"">2</a></td><td><a href=""javascript:__doPostBack('DetailsView1','Page$3')"">3</a></td>
						</tr>
						</table></td>
						</tr>
						</table>
						</div>   
						 </div>";
  				

                       HtmlDiff.AssertAreEqual (origHtmlValue, newHtmlValue, "RenderFooterTemplate");
		}

		[Test]
		[Category ("NotWorking")] 
		public void DetailsView_RenderHeaderTemplate ()
		{
			//Header Template property is checked
			string RenderedPageHtml = new WebTest ("DetailsViewTemplates.aspx").Run ();
			string newHtmlValue = RenderedPageHtml.Substring (RenderedPageHtml.IndexOf ("test1") + 5, RenderedPageHtml.IndexOf ("test2") - RenderedPageHtml.IndexOf ("test1") - 5);
                        string origHtmlValue = @" <div>
						 <div>
						<table cellspacing=""0"" rules=""all"" border=""1"" id=""DetailsView1"" style=""height:50px;width:125px;border-collapse:collapse;"">
						<tr>
						<td colspan=""2"">
						Header Template<input type=""submit"" name=""DetailsView1$Button1"" value=""Header button"" id=""DetailsView1_Button1"" />
						 </td>
						</tr><tr>
						<td>ID</td><td>1001</td>
						</tr><tr>
						<td>FName</td><td>Mahesh</td>
						</tr><tr>
						<td>LName</td><td>Chand</td>
						</tr><tr>
						<td colspan=""2""><a href=""javascript:__doPostBack('DetailsView1','Delete$0')"">Delete</a></td>
							</tr><tr>
						<td colspan=""2""><table border=""0"">
						<tr>
						<td><span>1</span></td><td><a href=""javascript:__doPostBack('DetailsView1','Page$2')"">2</a></td><td><a href=""javascript:__doPostBack('DetailsView1','Page$3')"">3</a></td>
						</tr>
						</table></td>
						</tr>
						</table>
						</div>";      
                
        
		HtmlDiff.AssertAreEqual (origHtmlValue, newHtmlValue, "RenderHeaderTemplate");
		}

		[Test]
		[Category ("NotWorking")] 
		public void DetailsView_PagerTemplateRender ()
		{
			//Pager Template property is checked
			string RenderedPageHtml = new WebTest ("DetailsViewTemplates.aspx").Run ();
			string newHtmlValue = RenderedPageHtml.Substring (RenderedPageHtml.IndexOf ("test2") + 5, RenderedPageHtml.IndexOf ("test3") - RenderedPageHtml.IndexOf ("test2") - 5);
			string origHtmlValue = @" <div>
						<table cellspacing=""0"" rules=""all"" border=""1"" id=""DetailsView2"" style=""height:50px;width:125px;border-collapse:collapse;"">
						<tr>
						<td>ID</td><td>1001</td>
						</tr><tr>
						<td>FName</td><td>Mahesh</td>
						</tr><tr>
						<td>LName</td><td>Chand</td>
						</tr><tr>
						<td colspan=""2"">
						 <input type=""submit"" name=""DetailsView2$ctl01$Button2"" value=""Prev"" id=""DetailsView2_ctl01_Button2"" />
						  <input type=""submit"" name=""DetailsView2$ctl01$Button3"" value=""Next"" id=""DetailsView2_ctl01_Button3"" />
						</td>
						</tr>
						</table>
						</div>";
    
			HtmlDiff.AssertAreEqual (origHtmlValue, newHtmlValue, "RenderPagerTemplate");
		}

		[Test]
		[Category ("NotWorking")] 
		public void DetailsView_EditFieldsRender ()
		{
			string RenderedPageHtml = new WebTest ("DetailsViewTemplates.aspx").Run ();
			string newHtmlValue = RenderedPageHtml.Substring (RenderedPageHtml.IndexOf ("test3") + 5, RenderedPageHtml.IndexOf ("endtest") - RenderedPageHtml.IndexOf ("test3") - 5);
			string origHtmlValue = @" </div>
							<div>
						<table cellspacing=""0"" rules=""all"" border=""1"" id=""DetailsView3"" style=""height:50px;width:125px;border-collapse:collapse;"">
						<tr>
						<td>ID</td><td>1001</td>
						</tr><tr>
						<td>FName</td><td>Mahesh</td>
						</tr><tr>
						<td>LName</td><td>Chand</td>
						</tr><tr>
						<td colspan=""2""><a href=""javascript:__doPostBack('DetailsView3','$0')"">TestButtonField</a></td>
						</tr><tr>
						<td>&nbsp;</td><td><a></a></td>
						</tr><tr>
						<td>Image field</td><td></td>
						</tr><tr>
						<td>&nbsp;</td><td></td>
						</tr><tr>
						<td>Template Field</td><td style=""background-color:#FFE0C0;"">&nbsp;</td>
						</tr><tr>
						<td colspan=""2""><table border=""0"">
						<tr>
						<td><span>1</span></td><td><a href=""javascript:__doPostBack('DetailsView3','Page$2')"">2</a></td><td><a href=""javascript:__doPostBack('DetailsView3','Page$3')"">3</a></td>
						</tr>
						</table></td>
						</tr>
						</table>
						</div>";
   
							
			HtmlDiff.AssertAreEqual (origHtmlValue, newHtmlValue, "RenderDataFields");
		}

		[Test]
		[Category ("NunitWeb")]
		public void DetailsView_PagingPostback ()
		{
			WebTest t = new WebTest ("DetailsViewDataActions.aspx");
			string pageHTML = t.Run ();
			pageHTML = pageHTML.Substring (pageHTML.IndexOf ("starttest") + 9, pageHTML.IndexOf ("endtest") - pageHTML.IndexOf ("starttest") - 9);
			string origHtmlValue = @" <div>
						 &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
						 <div>
						<table cellspacing=""0"" rules=""all"" border=""1"" id=""DetailsView1"" style=""height:50px;width:125px;border-collapse:collapse;"">
						<tr>
						<td>ID</td><td>1001</td>
						</tr><tr>
						<td>FName</td><td>Mahesh</td>
						</tr><tr>
						<td>LName</td><td>Chand</td>
						</tr><tr>
						<td colspan=""2""><a href=""javascript:__doPostBack('DetailsView1','Edit$0')"">Edit</a>&nbsp;<a href=""javascript:__doPostBack('DetailsView1','Delete$0')"">Delete</a>&nbsp;<a href=""javascript:__doPostBack('DetailsView1','New$0')"">New</a></td>
						</tr><tr>
						<td colspan=""2""><table border=""0"">
						<tr>
						<td><span>1</span></td><td><a href=""javascript:__doPostBack('DetailsView1','Page$2')"">2</a></td><td><a href=""javascript:__doPostBack('DetailsView1','Page$3')"">3</a></td>
						</tr>
						</table></td>
						</tr>
						</table>
						</div>     
						  </div>";
			HtmlDiff.AssertAreEqual (origHtmlValue, pageHTML, "BeforePagingDataPostback");
			FormRequest fr = new FormRequest (t.Response, "form1");
			fr.Controls.Add ("__EVENTTARGET");
			fr.Controls.Add ("__EVENTARGUMENT");		
			fr.Controls["__EVENTTARGET"].Value = "DetailsView1";
			fr.Controls["__EVENTARGUMENT"].Value = "Page$2";
			t.Request = fr;
			pageHTML = t.Run ();
			pageHTML = pageHTML.Substring (pageHTML.IndexOf ("starttest") + 9, pageHTML.IndexOf ("endtest") - pageHTML.IndexOf ("starttest") - 9);
			origHtmlValue = @" <div>
					&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
					<div>
					<table cellspacing=""0"" rules=""all"" border=""1"" id=""DetailsView1"" style=""height:50px;width:125px;border-collapse:collapse;"">
					<tr>
					<td>ID</td><td>1002</td>
					</tr><tr>
					<td>FName</td><td>Melanie</td>
					</tr><tr>
					<td>LName</td><td>Talmadge</td>
					</tr><tr>
					<td colspan=""2""><a href=""javascript:__doPostBack('DetailsView1','Edit$1')"">Edit</a>&nbsp;<a href=""javascript:__doPostBack('DetailsView1','Delete$1')"">Delete</a>&nbsp;<a href=""javascript:__doPostBack('DetailsView1','New$1')"">New</a></td>
					</tr><tr>
					<td colspan=""2""><table border=""0"">
					<tr>
					<td><a href=""javascript:__doPostBack('DetailsView1','Page$1')"">1</a></td><td><span>2</span></td><td><a href=""javascript:__doPostBack('DetailsView1','Page$3')"">3</a></td>
					</tr>
					</table></td>
					</tr>
					</table>
					</div>    
					</div>";
			HtmlDiff.AssertAreEqual (origHtmlValue, pageHTML, "AfterPagingDataPostback");

		}

		[Test]
		[Category ("NunitWeb")]
		public void DetailsView_EditPostback ()
		{			
			WebTest t = new WebTest ("DetailsViewDataActions.aspx");
			string pageHTML = t.Run ();
			Assert.AreEqual (true, pageHTML.Contains ("Edit"), "BeforeEditPostback");
			FormRequest fr = new FormRequest (t.Response, "form1");
			fr.Controls.Add ("__EVENTTARGET");
			fr.Controls.Add ("__EVENTARGUMENT");
			fr.Controls["__EVENTTARGET"].Value = "DetailsView1";
			fr.Controls["__EVENTARGUMENT"].Value = "Edit$0";
			t.Request = fr;			
			pageHTML = t.Run ();
			pageHTML = pageHTML.Substring (pageHTML.IndexOf ("starttest") + 9, pageHTML.IndexOf ("endtest") - pageHTML.IndexOf ("starttest") - 9);
			string origHtmlValue = @" <div>
						&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
						<div>
						<table cellspacing=""0"" rules=""all"" border=""1"" id=""DetailsView1"" style=""height:50px;width:125px;border-collapse:collapse;"">
						<tr>
						<td>ID</td><td>1001</td>
						</tr><tr>
						<td>FName</td><td>Mahesh</td>
						</tr><tr>
						<td>LName</td><td>Chand</td>
						</tr><tr>
						<td colspan=""2""><a href=""javascript:__doPostBack('DetailsView1$ctl01','')"">Update</a>&nbsp;<a href=""javascript:__doPostBack('DetailsView1','Cancel$0')"">Cancel</a></td>
						</tr><tr>
						<td colspan=""2""><table border=""0"">
						<tr>
						<td><span>1</span></td><td><a href=""javascript:__doPostBack('DetailsView1','Page$2')"">2</a></td><td><a href=""javascript:__doPostBack('DetailsView1','Page$3')"">3</a></td>
						</tr>
						</table></td>
						</tr>
						</table>
						</div>     
						</div>";
					HtmlDiff.AssertAreEqual (origHtmlValue, pageHTML, "AfterEditPostback");
			  

		}

		[Test]
		[Category ("NunitWeb")]
		public void DetailsView_DeletePostback ()
		{			
			WebTest t = new WebTest ("DetailsViewDataActions.aspx");			
			string pageHTML = t.Run ();
			Assert.AreEqual (true, pageHTML.Contains ("1001"), "BeforeDeletePostback");
			FormRequest fr = new FormRequest (t.Response, "form1");
			fr.Controls.Add ("__EVENTTARGET");
			fr.Controls.Add ("__EVENTARGUMENT");
			fr.Controls["__EVENTTARGET"].Value = "DetailsView1";
			fr.Controls["__EVENTARGUMENT"].Value = "Delete$0";
			t.Request = fr;
			pageHTML = t.Run ();
			pageHTML = pageHTML.Substring (pageHTML.IndexOf ("starttest") + 9, pageHTML.IndexOf ("endtest") - pageHTML.IndexOf ("starttest") - 9);
			string origHtmlValue = @"   <div>
						   &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
						 <div>
						<table cellspacing=""0"" rules=""all"" border=""1"" id=""DetailsView1"" style=""height:50px;width:125px;border-collapse:collapse;"">
						<tr>
						<td>ID</td><td>1002</td>
						</tr><tr>
						<td>FName</td><td>Melanie</td>
						</tr><tr>
						<td>LName</td><td>Talmadge</td>
						</tr><tr>
						<td colspan=""2""><a href=""javascript:__doPostBack('DetailsView1','Edit$0')"">Edit</a>&nbsp;<a href=""javascript:__doPostBack('DetailsView1','Delete$0')"">Delete</a>&nbsp;<a href=""javascript:__doPostBack('DetailsView1','New$0')"">New</a></td>
						</tr><tr>
						<td colspan=""2""><table border=""0"">
						<tr>
						<td><span>1</span></td><td><a href=""javascript:__doPostBack('DetailsView1','Page$2')"">2</a></td>
						</tr>
						</table></td>
						</tr>
						</table>
						</div>    
						</div>";

			HtmlDiff.AssertAreEqual (origHtmlValue, pageHTML, "DeleteDataPostback");
			Assert.AreEqual (false, pageHTML.Contains ("1001"), "AfterDeletePostback");
			
			

		}

		[Test]
		[Category ("NunitWeb")]
		public void DetailsView_InsertPostback ()
		{

			WebTest t = new WebTest ("DetailsViewDataActions.aspx");
			string pageHTML = t.Run ();
			Assert.AreEqual (true, pageHTML.Contains ("1001"), "BeforeDeletePostback");
			FormRequest fr = new FormRequest (t.Response, "form1");
			fr.Controls.Add ("__EVENTTARGET");
			fr.Controls.Add ("__EVENTARGUMENT");
			fr.Controls["__EVENTTARGET"].Value = "DetailsView1";
			fr.Controls["__EVENTARGUMENT"].Value = "New$0";
			t.Request = fr;			
			pageHTML = t.Run ();
			pageHTML = pageHTML.Substring (pageHTML.IndexOf ("starttest") + 9, pageHTML.IndexOf ("endtest") - pageHTML.IndexOf ("starttest") - 9);
			string origHtmlValue = @" <div>
			&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
			 <div>
			<table cellspacing=""0"" rules=""all"" border=""1"" id=""DetailsView1"" style=""height:50px;width:125px;border-collapse:collapse;"">
			<tr>
			<td>ID</td><td><input name=""DetailsView1$ctl01"" type=""text"" title=""ID"" /></td>
			</tr><tr>
			<td>FName</td><td><input name=""DetailsView1$ctl02"" type=""text"" title=""FName"" /></td>
			</tr><tr>
			<td>LName</td><td><input name=""DetailsView1$ctl03"" type=""text"" title=""LName"" /></td>
			</tr><tr>
			<td colspan=""2""><a href=""javascript:__doPostBack('DetailsView1$ctl04','')"">Insert</a>&nbsp;<a href=""javascript:__doPostBack('DetailsView1','Cancel$-1')"">Cancel</a></td>
			</tr>
			</table>
			</div>    
			</div>";    

			HtmlDiff.AssertAreEqual (origHtmlValue, pageHTML, "InsertDataPostback");
		}


		[Test]
		public void DetailsView_ViewState ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			PokerDetailsView copy = new PokerDetailsView ();
			dv.HeaderText = "Header";
			dv.GridLines = GridLines.Vertical;
			dv.CssClass = "style.css";
			object state = dv.SaveState ();
			copy.LoadState (state);
			Assert.AreEqual ("Header", copy.HeaderText, "ViewStateHeaderText");
			Assert.AreEqual (GridLines.Vertical, copy.GridLines, "ViewStateGridLines");
			Assert.AreEqual ("style.css", copy.CssClass, "ViewStateCssClass");
		}

		[Test]
		public void DetailsView_ControlState ()
		{

			PokerDetailsView dv = new PokerDetailsView ();
			PokerDetailsView copy = new PokerDetailsView ();
			string[] keys = new String[2];
			keys[0] = "key1";
			keys[1] = "key2";
			dv.DataKeyNames = keys;
			dv.BackImageUrl = "photo.jpg";
			dv.DefaultMode = DetailsViewMode.Insert;
			object state = dv.DoSaveControlState ();
			copy.DoLoadControlState (state);
			Assert.AreEqual ("key1", copy.DataKeyNames[0], "ControlStateDataKeyValue");
			Assert.AreEqual ("key2", copy.DataKeyNames[1], "ControlStateDataKeyValue2");
			Assert.AreEqual (DetailsViewMode.Insert, copy.DefaultMode, "ControlStateDefaultMode");

		}

		//events
		private bool init;
		private bool itemCommand;
		private bool itemCreated;
		private bool itemDeleted;
		private bool itemDeleting;
		private bool itemInserted;
		private bool itemInserting;
		private bool itemUpdated;
		private bool itemUpdating;
		private bool modeChanged;
		private bool modeChanging;
		private bool pageIndexChanged;
		private bool pageIndexChanging;
		private bool pagePreLoad;
		private bool dataSourceViewChanged;
		private bool preRender;
		private bool unload;
		private int newPageIndex;

		public void ResetEvents ()
		{
			init = false;
			itemCommand = false;
			itemCreated = false;
			itemDeleted = false;
			itemDeleting = false;
			itemInserted = false;
			itemInserting = false;
			itemUpdated = false;
			itemUpdating = false;
			modeChanged = false;
			modeChanging = false;
			pageIndexChanged = false;
			pageIndexChanging = false;
			pagePreLoad = false;
			dataSourceViewChanged = false;
			preRender = false;
			unload = false;		
		}

		[Test]
		public void DetailsView_BubbleEvents ()
		{
			ResetEvents ();
			DetailsViewCommandEventArgs com;
			PokerDetailsView dv = new PokerDetailsView ();
			dv.DataSource = TableObject.CreateDataTable ();
			Page page = new Page ();
			Button bt = new Button ();
			dv.AllowPaging = true;
			dv.DataSource = myds;
			page.Controls.Add (dv);
			dv.DataBind ();
			dv.ItemCommand += new DetailsViewCommandEventHandler (dv_ItemCommand );
			dv.ItemDeleted += new DetailsViewDeletedEventHandler (dv_ItemDeleted );
			//Delete
			dv.ItemDeleting += new DetailsViewDeleteEventHandler (dv_ItemDeleting );
			com = new DetailsViewCommandEventArgs (bt, new CommandEventArgs ("Delete", null));
			Assert.AreEqual (false, itemCommand, "BeforeDeleteCommandBubbleEvent");
			Assert.AreEqual (false, itemDeleting, "BeforeDeleteBubbleEvent");			
			Assert.IsTrue (dv.DoOnBubbleEvent (bt, com), "OnBubbleEvent - Delete");
			Assert.AreEqual (true, itemDeleting, "AfterDeleteBubbleEvent");			
			Assert.AreEqual (true, itemCommand, "AfterDeleteCommandBubbleEvent");

			//Insert
			itemCommand = false;
			dv.ItemInserting += new DetailsViewInsertEventHandler (dv_ItemInserting);
			dv.ChangeMode (DetailsViewMode.Insert);
			com = new DetailsViewCommandEventArgs (bt, new CommandEventArgs ("Insert", null));
			Assert.AreEqual (false, itemCommand, "BeforeInsertCommandBubbleEvent");
			Assert.AreEqual (false, itemInserting, "BeforeInsertBubbleEvent");
			Assert.IsTrue (dv.DoOnBubbleEvent (bt, com), "OnBubbleEvent - Insert");
			Assert.AreEqual (true, itemCommand, "AfterInsertCommandBubbleEvent");
			Assert.AreEqual (true, itemInserting, "AfterInsertBubbleEvent");

			//Update
			itemCommand = false;
			dv.ItemUpdating += new DetailsViewUpdateEventHandler (dv_ItemUpdating);
			dv.ChangeMode (DetailsViewMode.Edit);
			com = new DetailsViewCommandEventArgs (bt, new CommandEventArgs ("Update", null));
			Assert.AreEqual (false, itemUpdating, "BeforeUpdateEvent");
			Assert.AreEqual (false, itemCommand, "BeforeUpdateCommandEvent");
			Assert.IsTrue (dv.DoOnBubbleEvent (bt, com), "OnBubbleEvent - Update");
			Assert.AreEqual (true, itemCommand, "AfterUpdateCommandBubbleEvent");
			Assert.AreEqual (true, itemUpdating, "AfterUpdateBubbleEvent");

			//Cancel 
			itemCommand = false;
			dv.ModeChanging += new DetailsViewModeEventHandler (dv_ModeChanging);
			com = new DetailsViewCommandEventArgs (bt, new CommandEventArgs ("Cancel", null));
			Assert.AreEqual (false, itemCommand, "BeforeCancelCommandBubbleEvent");
			Assert.AreEqual (false, modeChanging, "BeforeCancelBubbleEvent");
			Assert.IsTrue (dv.DoOnBubbleEvent (bt, com), "OnBubbleEvent - Cancel");
			Assert.AreEqual (true, itemCommand, "AfterCancelCommandBubbleEvent");
			Assert.AreEqual (true, modeChanging, "AfterCancelBubbleEvent");

			//Edit
			itemCommand = false;
			modeChanging = false;
			com = new DetailsViewCommandEventArgs (bt, new CommandEventArgs ("Edit", null));
			Assert.AreEqual (false, itemCommand, "BeforeEditCommandBubbleEvent");
			Assert.AreEqual (false, modeChanging, "BeforeEditBubbleEvent");
			Assert.IsTrue (dv.DoOnBubbleEvent (bt, com), "OnBubbleEvent - Edit");
			Assert.AreEqual (true, itemCommand, "AfterEditCommandBubbleEvent");
			Assert.AreEqual (true, modeChanging, "AfterEditBubbleEvent");

			//New
			itemCommand = false;
			modeChanging = false;
			com = new DetailsViewCommandEventArgs (bt, new CommandEventArgs ("New", null));
			Assert.AreEqual (false, itemCommand, "BeforeNewCommandBubbleEvent");
			Assert.AreEqual (false, modeChanging, "BeforeNewBubbleEvent");
			Assert.IsTrue (dv.DoOnBubbleEvent (bt, com), "OnBubbleEvent - New");
			Assert.AreEqual (true, itemCommand, "AfterNewCommandBubbleEvent");
			Assert.AreEqual (true, modeChanging, "AfterNewBubbleEvent");

			//Page Index default
			itemCommand = false;
			dv.PageIndexChanging += new DetailsViewPageEventHandler (dv_PageIndexChanging );
			com = new DetailsViewCommandEventArgs (bt, new CommandEventArgs ("Page", null));
			Assert.AreEqual (false, itemCommand, "BeforePageCommandBubbleEvent");
			Assert.AreEqual (false, pageIndexChanging, "BeforePageBubbleEvent");
			Assert.IsTrue (dv.DoOnBubbleEvent (bt, com), "OnBubbleEvent - Page Index default");
			Assert.AreEqual (true, itemCommand, "AfterPageCommandBubbleEvent");
			Assert.AreEqual (true, pageIndexChanging, "AfterPageBubbleEvent");
			Assert.AreEqual (-1, newPageIndex, "PageIndex");

			//Next Page
			itemCommand = false;
			pageIndexChanging = false;
			com = new DetailsViewCommandEventArgs (bt, new CommandEventArgs ("Page", "Next"));
			Assert.AreEqual (false, itemCommand, "BeforeNextPageCommandBubbleEvent");
			Assert.AreEqual (false, pageIndexChanging, "BeforeNextPageBubbleEvent");
			Assert.IsTrue (dv.DoOnBubbleEvent (bt, com), "OnBubbleEvent - Next Page");
			Assert.AreEqual (true, itemCommand, "AfterNextPageCommandBubbleEvent");
			Assert.AreEqual (true, pageIndexChanging, "AfterNextPageBubbleEvent");
			Assert.AreEqual (1, newPageIndex, "NextPageIndex");

			//Prev Page
			itemCommand = false;
			pageIndexChanging = false;
			com = new DetailsViewCommandEventArgs (bt, new CommandEventArgs ("Page", "Prev"));
			Assert.AreEqual (false, itemCommand, "BeforePrevPageCommandBubbleEvent");
			Assert.AreEqual (false, pageIndexChanging, "BeforePrevPageBubbleEvent");
			Assert.IsTrue (dv.DoOnBubbleEvent (bt, com), "OnBubbleEvent - Prev Page");
			Assert.AreEqual (true, itemCommand, "AfterPrevPageCommandBubbleEvent");
			Assert.AreEqual (true, pageIndexChanging, "AfterPrevPageBubbleEvent");
			Assert.AreEqual (-1, newPageIndex, "PrevPageIndex");

			//First Page
			itemCommand = false;
			pageIndexChanging = false;
			com = new DetailsViewCommandEventArgs (bt, new CommandEventArgs ("Page", "First"));
			Assert.AreEqual (false, itemCommand, "BeforeFirstPageCommandBubbleEvent");
			Assert.AreEqual (false, pageIndexChanging, "BeforeFirstPageBubbleEvent");
			Assert.IsTrue (dv.DoOnBubbleEvent (bt, com), "OnBubbleEvent - First Page");
			Assert.AreEqual (true, itemCommand, "AfterFirstPageCommandBubbleEvent");
			Assert.AreEqual (true, pageIndexChanging, "AfterFirstPageBubbleEvent");
			Assert.AreEqual (0, newPageIndex, "FirstPageIndex");

			//Last Page
			itemCommand = false;
			pageIndexChanging = false;
			com = new DetailsViewCommandEventArgs (bt, new CommandEventArgs ("Page", "Last"));
			Assert.AreEqual (false, itemCommand, "BeforeLastPageCommandBubbleEvent");
			Assert.AreEqual (false, pageIndexChanging, "BeforeLastPageBubbleEvent");
			Assert.IsTrue (dv.DoOnBubbleEvent (bt, com), "OnBubbleEvent - Last Page");
			Assert.AreEqual (true, itemCommand, "AfterLastPageCommandBubbleEvent");
			Assert.AreEqual (true, pageIndexChanging, "AfterLastPageBubbleEvent");
			Assert.AreEqual (5, newPageIndex, "FirstPageIndex");

		}

		[Test]
		public void DetailsView_Events ()
		{
			ResetEvents ();
			PokerDetailsView dv = new PokerDetailsView ();
			Button bt = new Button ();
			Page pg = new Page ();
			dv.Page = pg;
			dv.Init += new EventHandler (dv_Init);
			dv.ItemCommand += new DetailsViewCommandEventHandler (dv_ItemCommand);
			dv.ItemCreated += new EventHandler (dv_ItemCreated);
			dv.ItemDeleted += new DetailsViewDeletedEventHandler (dv_ItemDeleted);
			dv.ItemDeleting += new DetailsViewDeleteEventHandler (dv_ItemDeleting);
			dv.ItemInserted += new DetailsViewInsertedEventHandler (dv_ItemInserted);
			dv.ItemInserting += new DetailsViewInsertEventHandler (dv_ItemInserting);
			dv.ItemUpdated += new DetailsViewUpdatedEventHandler (dv_ItemUpdated);
			dv.ItemUpdating += new DetailsViewUpdateEventHandler (dv_ItemUpdating);
			dv.ModeChanged += new EventHandler (dv_ModeChanged);
			dv.ModeChanging += new DetailsViewModeEventHandler (dv_ModeChanging);
			dv.PageIndexChanged += new EventHandler (dv_PageIndexChanged);
			dv.PageIndexChanging += new DetailsViewPageEventHandler (dv_PageIndexChanging);
			dv.DataBound += new EventHandler (dv_DataBound);
			dv.PreRender += new EventHandler (dv_PreRender);
			dv.Unload += new EventHandler (dv_Unload);			
			Assert.AreEqual (false, init, "BeforeInit");
			dv.DoOnInit (new EventArgs ());
			Assert.AreEqual (true, init, "AfterInit");
			Assert.AreEqual (false, itemCommand, "BeforeItemCommand");
			dv.DoOnItemCommand (new DetailsViewCommandEventArgs (bt,new CommandEventArgs ("",null)));
			Assert.AreEqual (true, itemCommand , "AfterItemCommand");
			Assert.AreEqual (false, itemCreated, "BeforeItemCreated");
			dv.DoOnItemCreated (new EventArgs ());
			Assert.AreEqual (true, itemCreated, "AfterItemCreated");
			Assert.AreEqual (false, itemDeleted, "BeforeItemDeleted");
			dv.DoOnItemDeleted (new DetailsViewDeletedEventArgs (3, new Exception ()));
			Assert.AreEqual (true, itemDeleted, "AfterItemDeleted");
			Assert.AreEqual (false, itemDeleting, "BeforeItemDeleting");
			dv.DoOnItemDeleting(new DetailsViewDeleteEventArgs (2)); 
			Assert.AreEqual (true, itemDeleting, "AfterItemDeleting");
			Assert.AreEqual (false, itemInserted, "BeforeItemInserted");
			dv.DoOnItemInserted (new DetailsViewInsertedEventArgs (3,new Exception()));
			Assert.AreEqual (true, itemInserted, "AfterItemInserted");
			Assert.AreEqual (false, itemInserting, "BeforeItemInserting");
			dv.DoOnItemInserting (new DetailsViewInsertEventArgs (bt));
			Assert.AreEqual (true, itemInserting, "AfterItemInserting");
			Assert.AreEqual (false, itemUpdated, "BeforeItemUpdated");
			dv.DoOnItemUpdated (new DetailsViewUpdatedEventArgs (2,new Exception()));
			Assert.AreEqual (true, itemUpdated, "AfterItemUpdated");
			Assert.AreEqual (false, itemUpdating, "BeforeItemUpdating");
			dv.DoOnItemUpdating (new DetailsViewUpdateEventArgs (bt));
			Assert.AreEqual (true, itemUpdating, "AfterItemUpdating");
			Assert.AreEqual (false, modeChanged, "BeforeModeChanged");
			dv.DoOnModeChanged (new EventArgs ());
			Assert.AreEqual (true, modeChanged, "AfterModeChanged");
			Assert.AreEqual (false, modeChanging, "BeforeModeChanging");
			dv.DoOnModeChanging (new DetailsViewModeEventArgs (DetailsViewMode.Insert ,false));
			Assert.AreEqual (true, modeChanging, "AfterModeChanging");
			Assert.AreEqual (false, pageIndexChanged, "BeforePageIndexChanged");
			dv.DoOnPageIndexChanged (new EventArgs ());
			Assert.AreEqual (true, pageIndexChanged, "AfterPageIndexChanged");
			Assert.AreEqual (false, pageIndexChanging, "BeforePageIndexChanging");
			dv.DoOnPageIndexChanging (new DetailsViewPageEventArgs (2));
			Assert.AreEqual (true, pageIndexChanging, "AfterPageIndexChanging");
			//Assert.AreEqual (false, pagePreLoad, "BeforePagePreLoad");
			//dv.DoOnPagePreLoad (pg, new EventArgs ());
			//Assert.AreEqual (true, pagePreLoad, "AfterPagePreLoad");
			Assert.AreEqual (false, preRender, "BeforePreRender");			
			dv.DoOnPreRender(new EventArgs ());
			Assert.AreEqual (true, preRender, "AfterPreRender");
			Assert.AreEqual (false, unload, "BeforeUnload");
			dv.DoOnUnload (new EventArgs ());
			Assert.AreEqual (true, unload, "AfterUnload");
			//Assert.AreEqual (false, dataSourceViewChanged, "BeforeDataSourceViewChanged");
			//dv.DoOnDataSourceViewChanged (bt, new EventArgs ());
			//Assert.AreEqual (true, dataSourceViewChanged, "AfterDataSourceViewChanged");



			
		}

		void dv_DataBound(object sender, EventArgs e)
		{
			dataSourceViewChanged = true;
		}

		
		void dv_Unload (object sender, EventArgs e)
		{
			unload = true;
		}

		void dv_PreRender (object sender, EventArgs e)
		{
			preRender = true;			
		}

		void dv_PageIndexChanging (object sender, DetailsViewPageEventArgs e)
		{
			pageIndexChanging = true;
			newPageIndex = e.NewPageIndex;
			e.NewPageIndex = -1;
		}

		void dv_PageIndexChanged (object sender, EventArgs e)
		{
			pageIndexChanged = true;
		}

		void dv_ModeChanging (object sender, DetailsViewModeEventArgs e)
		{
			modeChanging = true;
		}

		void dv_ModeChanged (object sender, EventArgs e)
		{
			modeChanged = true;

		}

		

		void dv_ItemUpdating (object sender, DetailsViewUpdateEventArgs e)
		{
			itemUpdating = true;
		}

		void dv_ItemUpdated (object sender, DetailsViewUpdatedEventArgs e)
		{
			itemUpdated = true;
		}

		void dv_ItemInserting (object sender, DetailsViewInsertEventArgs e)
		{
			itemInserting = true;
		}

		void dv_ItemInserted (object sender, DetailsViewInsertedEventArgs e)
		{
			itemInserted = true;
		}

		void dv_ItemDeleting (object sender, DetailsViewDeleteEventArgs e)
		{
			itemDeleting = true;
		}

		void dv_ItemDeleted (object sender, DetailsViewDeletedEventArgs e)
		{
			itemDeleted = true;
		}

		void dv_ItemCreated (object sender, EventArgs e)
		{
			itemCreated = true;
		}

		void dv_ItemCommand (object sender, DetailsViewCommandEventArgs e)
		{
			itemCommand = true;
		}

		void dv_Init (object sender, EventArgs e)
		{
			init = true;
		}

		//Exceptions

		[Test]
		[ExpectedException (typeof (ArgumentOutOfRangeException))]
		public void CellPaddingException ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			dv.CellPadding = -2;
		}

		[Test]
		[ExpectedException (typeof (ArgumentOutOfRangeException))]
		public void CellSpacingException ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			dv.CellSpacing = -5;
		}

		[Test]
		[Category ("NotWorking")] 
		[ExpectedException (typeof (ArgumentOutOfRangeException))]
		public void PageIndexException ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			dv.PageIndex = -5;
		}

		[Test]
		[Category ("NotWorking")] 
		[ExpectedException (typeof (HttpException))]
		public void InsertItemException ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			dv.InsertItem (true);
		}

		[Test]
		[Category ("NotWorking")] 
		[ExpectedException (typeof (HttpException))]
		public void UpdateItemException ()
		{
			PokerDetailsView dv = new PokerDetailsView ();
			dv.UpdateItem (true);
		}

		[Test]
		public void DetailsView_CreateDataSourceSelectArguments () {
			DataSourceView view;
			Page p = new Page ();

			PokerDetailsView dv = new PokerDetailsView ();
			p.Controls.Add (dv);

			ObjectDataSource data = new ObjectDataSource ();
			data.TypeName = typeof (DataSourceObject).AssemblyQualifiedName;
			data.SelectMethod = "GetList";
			data.SortParameterName = "sortExpression";
			DataSourceSelectArguments arg;
			p.Controls.Add (data);

			dv.DataSource = data;
			dv.DataBind ();

			arg = dv.DoCreateDataSourceSelectArguments ();
			Assert.IsTrue (arg.Equals (DataSourceSelectArguments.Empty), "Default");

			dv.AllowPaging = true;
			dv.PageIndex = 2;
			arg = dv.DoCreateDataSourceSelectArguments ();
			view = dv.DoGetData ();
			Assert.IsFalse (view.CanPage);
			Assert.IsTrue (view.CanRetrieveTotalRowCount);
			Assert.IsTrue (arg.Equals (DataSourceSelectArguments.Empty), "AllowPaging = true, CanPage = false, CanRetrieveTotalRowCount = true");

			// make DataSourceView.CanPage = true
			data.EnablePaging = true;

			arg = dv.DoCreateDataSourceSelectArguments ();
			view = dv.DoGetData ();
			Assert.IsTrue (view.CanPage);
			Assert.IsFalse (view.CanRetrieveTotalRowCount);
			Assert.IsTrue (arg.Equals (new DataSourceSelectArguments (2, -1)), "AllowPaging = true, CanPage = true, CanRetrieveTotalRowCount = false");

			dv.AllowPaging = false;
			arg = dv.DoCreateDataSourceSelectArguments ();
			Assert.IsTrue (arg.Equals (DataSourceSelectArguments.Empty), "AllowPaging = false, CanPage = true, CanRetrieveTotalRowCount = false");

			// make DataSourceView.CanRetrieveTotalRowCount = true
			data.SelectCountMethod = "GetCount";

			arg = dv.DoCreateDataSourceSelectArguments ();
			Assert.IsTrue (arg.Equals (DataSourceSelectArguments.Empty), "AllowPaging = false, CanPage = true, CanRetrieveTotalRowCount = true");

			dv.AllowPaging = true;
			arg = dv.DoCreateDataSourceSelectArguments ();
			DataSourceSelectArguments arg1 = new DataSourceSelectArguments (2, 1);
			arg1.RetrieveTotalRowCount = true;
			view = dv.DoGetData ();
			Assert.IsTrue (view.CanPage);
			Assert.IsTrue (view.CanRetrieveTotalRowCount);
			Assert.IsTrue (arg.Equals (arg1), "AllowPaging = true, CanPage = true, CanRetrieveTotalRowCount = true");
		}

		[Test]
		public void DetailsView_CurrentMode () {
			DetailsView view = new DetailsView ();
			view.DefaultMode = DetailsViewMode.Insert;
			Assert.AreEqual (DetailsViewMode.Insert, view.CurrentMode, "DetailsView_CurrentMode#1");
			view.ChangeMode (DetailsViewMode.Edit);
			Assert.AreEqual (DetailsViewMode.Edit, view.CurrentMode, "DetailsView_CurrentMode#2");
		}

		[Test]
		public void DetailsView_GetPostBackOptions () {
			DetailsView dv = new DetailsView ();
			dv.Page = new Page ();
			IButtonControl btn = new Button ();
			btn.CausesValidation = false;
			Assert.IsFalse (btn.CausesValidation);
			Assert.AreEqual (String.Empty, btn.CommandName);
			Assert.AreEqual (String.Empty, btn.CommandArgument);
			Assert.AreEqual (String.Empty, btn.PostBackUrl);
			Assert.AreEqual (String.Empty, btn.ValidationGroup);
			PostBackOptions options = ((IPostBackContainer) dv).GetPostBackOptions (btn);
			Assert.IsFalse (options.PerformValidation);
			Assert.IsFalse (options.AutoPostBack);
			Assert.IsFalse (options.TrackFocus);
			Assert.IsTrue (options.ClientSubmit);
			Assert.IsTrue (options.RequiresJavaScriptProtocol);
			Assert.AreEqual ("$", options.Argument);
			Assert.AreEqual (null, options.ActionUrl);
			Assert.AreEqual (null, options.ValidationGroup);

			btn.ValidationGroup = "VG";
			btn.CommandName = "CMD";
			btn.CommandArgument = "ARG";
			btn.PostBackUrl = "Page.aspx";
			Assert.IsFalse (btn.CausesValidation);
			Assert.AreEqual ("CMD", btn.CommandName);
			Assert.AreEqual ("ARG", btn.CommandArgument);
			Assert.AreEqual ("Page.aspx", btn.PostBackUrl);
			Assert.AreEqual ("VG", btn.ValidationGroup);
			options = ((IPostBackContainer) dv).GetPostBackOptions (btn);
			Assert.IsFalse (options.PerformValidation);
			Assert.IsFalse (options.AutoPostBack);
			Assert.IsFalse (options.TrackFocus);
			Assert.IsTrue (options.ClientSubmit);
			Assert.IsTrue (options.RequiresJavaScriptProtocol);
			Assert.AreEqual ("CMD$ARG", options.Argument);
			Assert.AreEqual (null, options.ActionUrl);
			Assert.AreEqual (null, options.ValidationGroup);
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void DetailsView_GetPostBackOptions_CausesValidation () {
			DetailsView dv = new DetailsView ();
			dv.Page = new Page ();
			IButtonControl btn = new Button ();
			Assert.IsTrue (btn.CausesValidation);
			Assert.AreEqual (String.Empty, btn.CommandName);
			Assert.AreEqual (String.Empty, btn.CommandArgument);
			Assert.AreEqual (String.Empty, btn.PostBackUrl);
			Assert.AreEqual (String.Empty, btn.ValidationGroup);
			PostBackOptions options = ((IPostBackContainer) dv).GetPostBackOptions (btn);
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void DetailsView_GetPostBackOptions_Null_Argument () {
			DetailsView dv = new DetailsView ();
			dv.Page = new Page ();
			PostBackOptions options = ((IPostBackContainer) dv).GetPostBackOptions (null);
		}
	}

	public class DTemplate : ITemplate
	{

		Label l = new Label ();
#region ITemplate Members

		public void InstantiateIn (Control container)
		{
			container.Controls.Add (l);

		}

		public void SetDataItem (object value)
		{
			l.Text = value.ToString ();
		}

		#endregion
	}

	public class TableObject
	{
		public static DataTable ds = CreateDataTable ();
		public static DataTable GetMyData ()
		{
			return ds;
		}

		public static DataTable Delete (string ID, string FName, string LName)
		{
			DataRow dr = ds.Rows.Find (ID);
			Assert.IsNotNull (dr);
			int oldCount = ds.Rows.Count;
			ds.Rows.Remove (dr);
			Assert.AreEqual (oldCount - 1, ds.Rows.Count);
			return ds;

		}

		public static DataTable Update (string ID, string FName, string LName)
		{
			DataRow dr = ds.Rows.Find (ID);
			if (dr == null) {
				Label lbl = new Label ();
				lbl.Text = "ID doesn't exist. update only FName and LName";
				return ds;
			}
			dr["FName"] = FName;
			dr["LName"] = LName;
			return ds;

		}

		public static DataTable Insert (string ID, string FName, string LName)
		{
			DataRow dr = ds.NewRow ();
			dr["ID"] = ID;
			dr["FName"] = FName;
			dr["LName"] = LName;
			int oldCount = ds.Rows.Count;
			ds.Rows.Add (dr);
			Assert.AreEqual (oldCount + 1, ds.Rows.Count);
			return ds;
		}


		public static DataTable CreateDataTable ()
		{

			DataTable aTable = new DataTable ("A");
			DataColumn dtCol;
			DataRow dtRow;

			// Create ID column and add to the DataTable.

			dtCol = new DataColumn ();
			dtCol.DataType = Type.GetType ("System.Int32");
			dtCol.ColumnName = "ID";
			dtCol.AutoIncrement = true;
			dtCol.Caption = "ID";
			dtCol.ReadOnly = true;
			dtCol.Unique = true;

			// Add the column to the DataColumnCollection.

			aTable.Columns.Add (dtCol);

			// Create Name column and add to the table

			dtCol = new DataColumn ();
			dtCol.DataType = Type.GetType ("System.String");
			dtCol.ColumnName = "FName";
			dtCol.AutoIncrement = false;
			dtCol.Caption = "First Name";
			dtCol.ReadOnly = false;
			dtCol.Unique = false;
			aTable.Columns.Add (dtCol);


			// Create Last Name column and add to the table.

			dtCol = new DataColumn ();
			dtCol.DataType = Type.GetType ("System.String");
			dtCol.ColumnName = "LName";
			dtCol.AutoIncrement = false;
			dtCol.Caption = "Last Name";
			dtCol.ReadOnly = false;
			dtCol.Unique = false;
			aTable.Columns.Add (dtCol);


			// Create three rows to the table
			dtRow = aTable.NewRow ();
			dtRow["ID"] = 1001;
			dtRow["FName"] = "Mahesh";
			dtRow["LName"] = "Chand";
			aTable.Rows.Add (dtRow);


			dtRow = aTable.NewRow ();
			dtRow["ID"] = 1002;
			dtRow["FName"] = "Melanie";
			dtRow["LName"] = "Talmadge";
			aTable.Rows.Add (dtRow);

			dtRow = aTable.NewRow ();
			dtRow["ID"] = 1003;
			dtRow["FName"] = "Vinay";
			dtRow["LName"] = "Bansal";
			aTable.Rows.Add (dtRow);

			aTable.PrimaryKey = new DataColumn[] { aTable.Columns["ID"] };			
			return aTable;

		}
	}
}
#endif




