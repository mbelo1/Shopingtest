<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BeheerderForm.ascx.cs" Inherits="OAS.UserControls.BeheerderForm" %>

<table class="tablediv">
    <h2>Beheerders Beheren</h2>
    <asp:Label ID="lblBmode" runat="server" Text="Wat kan ik doen: Beheerder zoeken" CssClass="status" ></asp:Label>
                    <tr>
                        <td style="width:140px;"> <asp:Label ID="Label1" runat="server" Text="Email*"></asp:Label></td>
                        <td > 
                                <asp:TextBox ID="txtBeheerderEmail" CssClass="zoekVeld" runat="server" /> 
                                <asp:Button ID="zoekBeheerder" runat="server" Text="Zoeken" OnClick="zoekBeheerder_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td> <asp:Label ID="Label2" runat="server" Text="Voornaam*"></asp:Label></td>
                        <td > <asp:TextBox ID="txtBeheerderVoornaam" runat="server"></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td > <asp:Label ID="Label3" runat="server" Text="Tussenvoegsel"></asp:Label></td>
                        <td > <asp:TextBox ID="txtBeheerderTussenvoegsel" runat="server"></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td > <asp:Label ID="Label4" runat="server" Text="Achternaam*"></asp:Label></td>
                        <td > <asp:TextBox ID="txtBeheerderAchternaam" runat="server"></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td > <asp:Label ID="Label5" runat="server" Text="Wachtwoord"></asp:Label></td>
                        <td > <asp:TextBox ID="txtBeheerderWachtwoord" runat="server"></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td > <asp:Label ID="Label10" runat="server" Text=" "></asp:Label></td>
                        <td >  
                            <asp:Button ID="btnAddBeheerder" runat="server" Text="Toevoegen" Enabled="False" OnClick="btnAddBeheerder_Click" />
                            <asp:Button ID="btnUpdateBeheerder" runat="server" Text="Opslaan" Enabled="False" OnClick="btnUpdateBeheerder_Click" />
                            <asp:Button ID="btnDeleteBeheerder" runat="server" Text="Verwijderen" Enabled="False" OnClick="btnDeleteBeheerder_Click" />

                        </td>
                    </tr>
                </table>
