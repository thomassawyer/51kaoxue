<%@ Page Title="tblJiaoan" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Maticsoft.Web.tblJiaoan.List" %>
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
                            
		<asp:BoundField DataField="level" HeaderText="level" SortExpression="level" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="subjectid" HeaderText="subjectid" SortExpression="subjectid" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="versionid" HeaderText="versionid" SortExpression="versionid" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="name" HeaderText="name" SortExpression="name" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="uploadtime" HeaderText="uploadtime" SortExpression="uploadtime" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="filesrc" HeaderText="filesrc" SortExpression="filesrc" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="downloadnum" HeaderText="downloadnum" SortExpression="downloadnum" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="neednum" HeaderText="neednum" SortExpression="neednum" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="extension" HeaderText="extension" SortExpression="extension" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="year" HeaderText="year" SortExpression="year" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="uploader" HeaderText="uploader" SortExpression="uploader" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="content" HeaderText="content" SortExpression="content" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="prepareid" HeaderText="prepareid" SortExpression="prepareid" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="isjing" HeaderText="isjing" SortExpression="isjing" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="isgaokao" HeaderText="isgaokao" SortExpression="isgaokao" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="isdujia" HeaderText="isdujia" SortExpression="isdujia" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="beikao" HeaderText="beikao" SortExpression="beikao" ItemStyle-HorizontalAlign="Center"  /> 
                            
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
