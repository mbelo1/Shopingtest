<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocentForm.ascx.cs" Inherits="OAS.UserControls.DocentForm" %>

<table class="tablediv">
    <h2>Docent Beheren</h2>
    <asp:Label ID="lblMode" runat="server" Text="Wat Kan ik doen: Docent zoeken" CssClass="status" ></asp:Label>
                    <tr>
                        <td style="width:140px;"> <asp:Label ID="Label1" runat="server" Text="Afkorting*"></asp:Label></td>
                        <td > 
                                <asp:TextBox ID="txtDocentAfkorting" CssClass="zoekVeld" runat="server" /> 
                                <asp:Button ID="zoekDocent" runat="server" Text="Zoeken" OnClick="zoekDocent_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td> <asp:Label ID="Label2" runat="server" Text="Voornaam*"></asp:Label></td>
                        <td > <asp:TextBox ID="txtDocentVoornaam" runat="server"  /> </td>
                    </tr>
                    <tr>
                        <td > <asp:Label ID="Label3" runat="server" Text="Tussenvoegsel"></asp:Label></td>
                        <td > <asp:TextBox ID="txtDocentTussenvoegsel" runat="server"></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td > <asp:Label ID="Label4" runat="server" Text="Achternaam*"></asp:Label></td>
                        <td > <asp:TextBox ID="txtDocentAchternaam" runat="server" /> </td>
                    </tr>
                    <tr>
                        <td > <asp:Label ID="Label5" runat="server" Text="Email*"></asp:Label></td>
                        <td > <asp:TextBox ID="txtDocentEmail" runat="server" /> </td>
                    </tr>
                    <tr>
                        <td > <asp:Label ID="Label6" runat="server" Text="Telefoon1*"></asp:Label></td>
                        <td > <asp:TextBox ID="txtDocentTelefoon1" runat="server" /> </td>
                    </tr>
                     <tr>
                        <td > <asp:Label ID="Label7" runat="server" Text="Telefoon2"></asp:Label></td>
                        <td > <asp:TextBox ID="txtDocentTelefoon2" runat="server"></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td > <asp:Label ID="Label11" runat="server" Text="Wachtwoord"></asp:Label></td>
                        <td > <asp:TextBox ID="txtDocentWachtwoord" runat="server" /></td>
                    </tr>
                     <tr>
                        <td > <asp:Label ID="Label8" runat="server" Text="Klas"></asp:Label></td>
                        <td > <asp:DropDownList ID="dllKlas" runat="server"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td > <asp:Label ID="Label9" runat="server" Text="Isactief"></asp:Label></td>
                        <td > <asp:CheckBox ID="cbDocentIsactief" runat="server" /> </td>
                    </tr>
                    <tr>
                        <td > <asp:Label ID="Label10" runat="server" Text=" "></asp:Label></td>
                        <td >  
                            <asp:Button ID="btnAddDocent" runat="server" Text="Toevoegen" Enabled="False" OnClick="btnAddDocent_Click" />
                            <asp:Button ID="btnUpdateDocent" runat="server" Text="Opslaan" Enabled="False" OnClick="btnUpdateDocent_Click" />
                            <asp:Button ID="btnDeleteDocent" runat="server" Text="Verwijderen" Enabled="False" OnClick="btnDeleteDocent_Click" />
                            

                        </td>
                    </tr>
                </table>