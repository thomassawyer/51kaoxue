<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Maticsoft.Web.page_dict.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		PAGEID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPAGEID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PAGENAME
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPAGENAME" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PAGEPARENTID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPAGEPARENTID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PAGEURL
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPAGEURL" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PAGETARGET
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPAGETARGET" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PAGEIMG
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPAGEIMG" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CHECKFLAG
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCHECKFLAG" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PAGEMOUDAL
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPAGEMOUDAL" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ISFLAG
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblISFLAG" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SEQSORT
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSEQSORT" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




