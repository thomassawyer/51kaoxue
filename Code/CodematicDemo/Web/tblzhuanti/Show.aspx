<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Maticsoft.Web.tblzhuanti.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		name
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblname" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		picsrc
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblpicsrc" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ftitle
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblftitle" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		stitle
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblstitle" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		daodu
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbldaodu" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		model
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmodel" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		viewstate
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblviewstate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		level
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbllevel" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		subject
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblsubject" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		category
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcategory" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		istop
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblistop" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		position
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblposition" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		bigpic
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblbigpic" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		updatetime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblupdatetime" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




