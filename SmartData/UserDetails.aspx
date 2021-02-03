<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="SmartData.UserDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>


    <div style=" min-height:500px;">
        <asp:Panel ID="Panel1" runat="server">
        <div class="col-md-12">
        <h1 align="center" style="text-align: center; background-color: #D95459" 
            class="fa-inverse"><asp:Label ID="lblhead" runat="server" Text="INSERT" ForeColor="White"></asp:Label></h1>
<table width="100%">
<tr><td width="40%" class="detail">Name :</td><td><asp:TextBox ID="lblusr" runat="server" Text=""></asp:TextBox></td></tr>
<tr><td width="40%" class="detail">Date of Birth : </td><td><asp:TextBox ID="lbldob" runat="server" Text=""></asp:TextBox></td></tr>
<tr><td width="40%" class="detail">Contact : </td><td><asp:TextBox ID="lblcont" runat="server" Text=""></asp:TextBox></td></tr>
<tr><td width="40%" class="detail">Email : </td><td><asp:TextBox ID="lblmail" runat="server" Text=""></asp:TextBox></td></tr>
<tr>
        <td width="70px">
        </td>
        <td><br />
            <asp:Button ID="btnupdate" runat="server" Text="INSERT" 
                onclick="btninsert_Click" Width="109px" ValidationGroup="form" Font-Bold="True" BackColor="#D95459" Font-Size="18px" ForeColor="White" Height="38px" />
               <asp:Label ID="lblmsg" runat="server"></asp:Label>
        </td>
</tr>
</table>
       
<asp:HiddenField ID="HiddenField1" runat="server" Value="" />
    <div class="clearfix"></div>
</div>
        </asp:Panel>
        
        <asp:Panel ID="Panel2" runat="server">
        
    <table width="100%">
    <tr>
    <td class="style6">
    <h1 align="center" style="text-align: center; background-color: #D95459; color: #FFFFFF;" 
            class="fa-inverse">USERS DETAILS</h1>
    <br />
    </td>
    </tr>
   
    <tr>
    <td>
        <asp:GridView ID="gvfee" DataKeyNames="id" runat="server" 
               AutoGenerateColumns="False" onrowediting="gv_edit"
                                onrowcancelingedit="gv_canceledit" 
               onrowdatabound="gv_rowdatabound" Width="100%" AllowPaging="True" BackColor="#CCCCCC" 
                                BorderColor="#999999" BorderStyle="Solid" 
                BorderWidth="3px" CaptionAlign="Top" 
                                CellPadding="4" CellSpacing="2" 
                EnableModelValidation="True" Font-Bold="False" 
                                ForeColor="Black"
                ShowFooter="False" PageSize="15"  OnRowDeleting="gv_delete">

        <Columns>

        
        <asp:TemplateField HeaderText="Name">
        
<ItemTemplate>
<asp:Label ID="lblname" runat="server" Text='<%#Eval("usr") %>'/>
</ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Date of Birth">
        
<ItemTemplate>
<asp:Label ID="lbldob" runat="server" Text='<%#Eval("dob") %>'/>
</ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Email">
        
<ItemTemplate>
<asp:Label ID="lblmail" runat="server" Text='<%#Eval("email") %>'/>
</ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Mobile No.">
        
<ItemTemplate>
<asp:Label ID="lblmobile" runat="server" Text='<%#Eval("cont") %>'/>
</ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Edit">
        <ItemTemplate>
        <asp:LinkButton ID="linkbtnedit" CommandName="edit"
    runat="server">Edit</asp:LinkButton>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:LinkButton ID="linkbtncancel" CommandName="cancel"
    runat="server">Cancel</asp:LinkButton>
        </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
        
<ItemTemplate><asp:LinkButton ID="linkbtndel" CommandName="delete"
    runat="server" OnClientClick=''>Delete</asp:LinkButton>
</ItemTemplate>
        </asp:TemplateField>

</Columns>

                             <FooterStyle BackColor="#CCCCCC" />
                             <HeaderStyle BackColor="Black" Font-Bold="True" 
                ForeColor="White" />
                             <PagerSettings PageButtonCount="15" />
                             <PagerStyle BackColor="#CCCCCC" ForeColor="Black" 
                HorizontalAlign="Left" />
                             <RowStyle BackColor="White" />
                             <SelectedRowStyle BackColor="#000099" Font-Bold="True" 
                ForeColor="White" />

                         </asp:GridView>
    <hr />
    </td>
    </tr>
    </table>
</asp:Panel>
</div>    


        </div>
    </form>
</body>
</html>
