<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calling CORE API IN ASP APPLICATION.aspx.cs" Inherits="Calling_CORE_API_IN_ASP_APPLICATION.Calling_CORE_API_IN_ASP_APPLICATION" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>


        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <br />
        <br />
        <div>

            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
                PageSize="25" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:TextBox ID="name" runat="server"  />
                        </ItemTemplate>
                        <ItemStyle></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="City">
                        <ItemTemplate>
                            <asp:TextBox ID="city" runat="server"
                                />
                        </ItemTemplate>
                        <ItemStyle ></ItemStyle>
                    </asp:TemplateField>


                </Columns>

            </asp:GridView>
            <br />
              <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" Font-Bold="True" ForeColor="#003366" BackColor="#CC99FF" />
            <br />
            <br />
        
            <div>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </div>
        </div>

    </form>
</body>
</html>
