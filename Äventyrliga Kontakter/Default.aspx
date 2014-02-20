<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Äventyrliga_Kontakter.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <header>
        <h1>Äventyrliga Kontakter</h1>
    </header>
    <form id="form1" runat="server">
    <div>
        
        <asp:Panel ID="Panel" runat="server" Visible="false">
            <asp:Label ID="TextLabel" runat="server" Text=""></asp:Label>
        </asp:Panel>

        <asp:ValidationSummary class="error" runat="server" />
        <asp:ValidationSummary class="error" runat="server" ValidationGroup="Edit"/>

        <asp:ListView ID="ContactListView" runat="server" ItemType="Äventyrliga_Kontakter.Model.Contact" 
            SelectMethod="ContactListView_GetData"
            InsertMethod="ContactListView_InsertItem"
            DeleteMethod="ContactListView_DeleteItem"
            UpdateMethod="ContactListView_UpdateItem"
            DataKeyNames="ContactID"
            InsertItemPosition="FirstItem">
            <LayoutTemplate>
                <table>
                    <tr>
                        <th>
                            Förnamn
                        </th>
                        <th>
                            Efternamn
                        </th>
                        <th>
                            E-post
                        </th>
                        <th>
                        </th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Item.FirstName  %>
                    </td>
                    <td>
                        <%# Item.LastName %>
                    </td>
                    <td>
                        <%# Item.EmailAddress %>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" OnClientClick="return confirm('Är du säker att du vill ta bort kontakten')"></asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td>
                            Kunduppgifter saknas
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr>
                    <td>
                        <asp:TextBox ID="FirstName" runat="server" Text='<%# BindItem.FirstName %>' MaxLength="50" />
                    </td>
                    <td>
                        <asp:TextBox ID="LastName" runat="server" Text='<%# BindItem.LastName %>' MaxLength="50" />
                    </td>
                    <td>
                        <asp:TextBox ID="EmailAddress" runat="server" Text='<%# BindItem.EmailAddress %>' MaxLength="50" TextMode="Email" />
                    </td>
                    <td>
                        <asp:LinkButton  runat="server" CommandName="Insert" Text="Lägg till" ></asp:LinkButton>
                        <asp:LinkButton  runat="server" CommandName="Cancel" Text="Rensa" ></asp:LinkButton>
                    </td>
                </tr>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Förnamn måste fyllas i" ControlToValidate="FirstName" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Efternamn måste fyllas i" ControlToValidate="LastName" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Email - address måste fyllas i" ControlToValidate="EmailAddress" Display="None"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ErrorMessage="Ange en giltig e-post adress" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" ControlToValidate="EmailAddress"></asp:RegularExpressionValidator>
            </InsertItemTemplate>
            <EditItemTemplate>
                <tr>
                    <td>
                        <asp:TextBox ID="FirstName" runat="server" Text='<%# BindItem.FirstName %>' ValidationGroup="Edit"/>
                    </td>
                    <td>
                        <asp:TextBox ID="LastName" runat="server" Text='<%# BindItem.LastName %>' ValidationGroup="Edit"/>
                    </td>
                    <td>
                        <asp:TextBox ID="EmailAddress" runat="server" Text='<%# BindItem.EmailAddress %>' TextMode="Email" ValidationGroup="Edit"/>
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton1"  runat="server" CommandName="Update" Text="Spara" ValidationGroup="Edit"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2"  runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation ="false"></asp:LinkButton>
                    </td>
                </tr>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Förnamn måste fyllas i" ControlToValidate="FirstName" Display="None" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Efternamn måste fyllas i" ControlToValidate="LastName" Display="None" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Email - address måste fyllas i" ControlToValidate="EmailAddress" Display="None" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ErrorMessage="Ange en giltig e-post adress" ValidationGroup="Edit" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" ControlToValidate="EmailAddress"></asp:RegularExpressionValidator>
            </EditItemTemplate>     
        </asp:ListView>
        <asp:DataPager ID="DataPager1" runat="server" PageSize="20" PagedControlID="ContactListView">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="False" ShowFirstPageButton="True" />
                <asp:NumericPagerField ButtonType="Link" ButtonCount="10" />
                <asp:NextPreviousPagerField ButtonType="Link" ShowPreviousPageButton="False" ShowLastPageButton="True" />
            </Fields>
        </asp:DataPager>
    </div>
    </form>
</body>
</html>
