<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IceGola.aspx.cs" Inherits="www.motionrider.com.IceGola" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WorkingArea" runat="server">

    <h4 id="PageHeading" runat="server">Ice Gola</h4>

    <asp:GridView ID="IceGolaGridView" runat="server" CssClass="table" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="slush_id" HeaderText="Ice Gola #"/>
            <asp:BoundField DataField="slush_name" HeaderText="Name" />
            <asp:BoundField DataField="slush_price" HeaderText="Price" />
        </Columns>

    </asp:GridView>

</asp:Content>
