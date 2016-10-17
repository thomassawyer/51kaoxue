<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Maticsoft.Web.tblTongbu.Show" Title="显示页" %>
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
		level
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbllevel" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		subjectid
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblsubjectid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		versionid
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblversionid" runat="server"></asp:Label>
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
		uploadtime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluploadtime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		filesrc
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblfilesrc" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		downloadnum
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbldownloadnum" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		neednum
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblneednum" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		extension
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblextension" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		year
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblyear" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		uploader
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluploader" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		content
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcontent" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		prepareid
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblprepareid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		isjing
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblisjing" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		isgaokao
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblisgaokao" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		isdujia
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblisdujia" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		beikao
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblbeikao" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




