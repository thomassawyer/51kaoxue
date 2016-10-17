<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="Maticsoft.Web.page_dict.Add" Title="增加页" %>

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
		<asp:TextBox id="txtPAGEID" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PAGENAME
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPAGENAME" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PAGEPARENTID
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPAGEPARENTID" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PAGEURL
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPAGEURL" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PAGETARGET
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPAGETARGET" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PAGEIMG
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPAGEIMG" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CHECKFLAG
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCHECKFLAG" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PAGEMOUDAL
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPAGEMOUDAL" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ISFLAG
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtISFLAG" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SEQSORT
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtSEQSORT" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
</table>

            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="保存"
                    OnClick="btnSave_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                <asp:Button ID="btnCancle" runat="server" Text="取消"
                    OnClick="btnCancle_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
