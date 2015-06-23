<%@ Page Title="" Language="C#" MasterPageFile="~/BeheerderPages/Beheerder.Master" AutoEventWireup="true" CodeBehind="BeheerderPage.aspx.cs" Inherits="OAS.BeheerderPages.BeheerderPage" %>

<%@ Register Src="~/UserControls/DocentForm.ascx" TagPrefix="uc1" TagName="DocentForm" %>
<%@ Register Src="~/UserControls/BeheerderForm.ascx" TagPrefix="uc1" TagName="BeheerderForm" %>
<%@ Register Src="~/UserControls/StudentenForm.ascx" TagPrefix="uc1" TagName="StudentenForm" %>



<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="formsPlaceholder" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="formsconainer">
            <div class="formdiv">
                <uc1:DocentForm runat="server" ID="DocentForm" />
            </div>
            <div class="formdiv">
                <uc1:BeheerderForm runat="server" id="BeheerderForm"/>
                    <br />
                <uc1:StudentenForm runat="server" id="StudentenForm"/>
            </div>
        </div>
</asp:Content>

