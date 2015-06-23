<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentenForm.ascx.cs" Inherits="OAS.UserControls.StudentenForm" %>
<div class="tablediv">
    <h2>Studenten Importeren</h2>
    &nbsp;&nbsp;&nbsp;    <asp:FileUpload ID="StudentenUpload" runat="server" /><asp:Button ID="btnImport" runat="server" Text="Importeer" OnClick="btnImport_Click" />
</div>
