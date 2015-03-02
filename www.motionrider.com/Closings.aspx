<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Closings.aspx.cs" Inherits="www.motionrider.com.Closings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="WorkingArea" runat="server">

    <h4 id="PageHeading" runat="server">All Closings</h4>

    <asp:GridView ID="ClosingsGridView" runat="server" CssClass="table" AutoGenerateColumns="False" OnRowDataBound="On_ClosingsGridView_RowDataBound">
        <Columns>

            <asp:BoundField DataField="closing_id" HeaderText="Closing #" />
            <asp:BoundField DataField="closing_start_sales_id" HeaderText="Start Sales #" />
            <asp:BoundField DataField="closing_end_sales_id" HeaderText="End Sales #" />
            <asp:BoundField DataField="closing_total_amount" HeaderText="Total Amout of Sale" />
            <asp:BoundField DataField="closing_login_time" HeaderText="Login Time" />
            <asp:BoundField DataField="closing_login_date" HeaderText="Login Date" />
            <asp:BoundField DataField="closing_logout_time" HeaderText="Logout Time" />
            <asp:BoundField DataField="closing_logout_date" HeaderText="Logout Date" />
        </Columns>

    </asp:GridView>

</asp:Content>
