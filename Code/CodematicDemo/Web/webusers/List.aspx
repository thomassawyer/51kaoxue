<%@ Page Title="webusers" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Maticsoft.Web.webusers.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--Title -->

            <!--Title end -->

            <!--Add  -->

            <!--Add end -->

            <!--Search -->
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td style="width: 80px" align="right" class="tdbg">
                         <b>关键字：</b>
                    </td>
                    <td class="tdbg">                       
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询"  OnClick="btnSearch_Click" >
                    </asp:Button>                    
                        
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="id" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="username" HeaderText="username" SortExpression="username" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="password" HeaderText="password" SortExpression="password" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="email" HeaderText="email" SortExpression="email" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="school" HeaderText="school" SortExpression="school" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="name" HeaderText="name" SortExpression="name" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="mobile" HeaderText="mobile" SortExpression="mobile" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="province" HeaderText="province" SortExpression="province" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="city" HeaderText="city" SortExpression="city" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="position" HeaderText="position" SortExpression="position" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="subject" HeaderText="subject" SortExpression="subject" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="address" HeaderText="address" SortExpression="address" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="tel" HeaderText="tel" SortExpression="tel" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="level" HeaderText="level" SortExpression="level" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="regdate" HeaderText="regdate" SortExpression="regdate" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ip" HeaderText="ip" SortExpression="ip" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="daoqidate" HeaderText="daoqidate" SortExpression="daoqidate" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="openpwd" HeaderText="openpwd" SortExpression="openpwd" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="yewu" HeaderText="yewu" SortExpression="yewu" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="provinceid" HeaderText="provinceid" SortExpression="provinceid" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="cityid" HeaderText="cityid" SortExpression="cityid" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="grade" HeaderText="grade" SortExpression="grade" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="status" HeaderText="status" SortExpression="status" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="yewudiqv" HeaderText="yewudiqv" SortExpression="yewudiqv" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                                Text="编辑"  />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"   Visible="false"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                         Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                </asp:GridView>
               <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td align="left">
                        <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"/>                       
                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
