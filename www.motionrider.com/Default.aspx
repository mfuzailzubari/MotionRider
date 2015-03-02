<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="www.motionrider.com.Default" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="LeftColumn" runat="server">

    <h4>Quick Links</h4>
    <ul class="left-nav">
        <li>
            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/IceGola.aspx" runat="server">View Ice Gola</asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink2" NavigateUrl="~/MotionRides.aspx" runat="server">View Motion Rider</asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink3" NavigateUrl="~/Closings.aspx" runat="server">View Closings</asp:HyperLink></li>
    </ul>

    <h4>User Settings</h4>
    <ul class="left-nav">
        <li>
            <asp:HyperLink ID="HyperLink2" NavigateUrl="~/FullAdmin/UserSettings/UpdateProfile.aspx" runat="server">Update Profile</asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink3" NavigateUrl="~/FullAdmin/UserSettings/UpdateEmail.aspx" runat="server">Change Email</asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink4" NavigateUrl="~/FullAdmin/UserSettings/UpdatePassword.aspx" runat="server">Change Password</asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink5" NavigateUrl="~/Logout.aspx" runat="server">Log Out</asp:HyperLink></li>
    </ul>

</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="WorkingArea" runat="server">

    <h4 id="PageHeading" runat="server">Daily Sales</h4>

    <asp:GridView ID="SalesGridView" runat="server" CssClass="table" AutoGenerateColumns="False" DataKeyNames="sales_id">
        <Columns>

            <asp:BoundField DataField="sales_id" HeaderText="Sales #" SortExpression="sales_id" />
            <asp:BoundField DataField="sales_total_amount" HeaderText="Total Amount" />
            <asp:BoundField DataField="sales_time" HeaderText="Time" />
            <asp:BoundField DataField="sales_date" HeaderText="Date" />
        </Columns>

    </asp:GridView>
    <label runat="server" id="lblSalesTotal" class="pull-right"></label>

    <h4 id="H1" runat="server">Daily Motion Rider Sales</h4>
    

    <asp:GridView ID="MotionGridView" runat="server" CssClass="table" AutoGenerateColumns="False" OnRowDataBound="MotionGridView_RowDataBound">
        <Columns>

            <asp:BoundField DataField="sales_id" HeaderText="Sales #" SortExpression="sales_id" />
            <asp:BoundField DataField="MotionRideName" HeaderText="Ticket Name" />
            <asp:BoundField DataField="ts_quantity" HeaderText="Ticket Count" />
            <asp:BoundField DataField="ts_unit_price" HeaderText="Unit Price" />
            <asp:BoundField DataField="ts_total_amount" HeaderText="Total Amount" />
            <asp:BoundField DataField="Time" HeaderText="Time" />
            <asp:BoundField DataField="Date" HeaderText="Date" />
        </Columns>

    </asp:GridView>
    <label runat="server" id="lblMotionRiderTotal" class="pull-right"></label>

    <h4 id="H2" runat="server">Daily Ice Gola Sales</h4>
    

    <asp:GridView ID="IceGolaGridView" runat="server" CssClass="table" AutoGenerateColumns="False">
        <Columns>

            <asp:BoundField DataField="sales_id" HeaderText="Sales #" SortExpression="sales_id" />
            <asp:BoundField DataField="IceGolaName" HeaderText="Ice Gola Name" />
            <asp:BoundField DataField="ss_quantity" HeaderText="Ticket Count" />
            <asp:BoundField DataField="ss_unit_price" HeaderText="Unit Price" />
            <asp:BoundField DataField="ss_total_amount" HeaderText="Total Amount" />
            <asp:BoundField DataField="Time" HeaderText="Time" />
            <asp:BoundField DataField="Date" HeaderText="Date" /> 

        </Columns>

    </asp:GridView>
    <label runat="server" id="lblIceGolaTotal" class="pull-right"></label>
</asp:Content>
